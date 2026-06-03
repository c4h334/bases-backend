DELIMITER $$

DROP PROCEDURE IF EXISTS sp_ProcesarDespacho$$

CREATE PROCEDURE sp_ProcesarDespacho(
    IN p_IdDespacho INT,
    IN p_IdCliente INT,
    OUT p_Resultado VARCHAR(255)
)
BEGIN
    DECLARE v_FaltaStock INT DEFAULT 0;
    
    -- Manejador de excepciones del sistema
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        ROLLBACK;
        SET p_Resultado = 'ERROR: Transacción abortada por fallo del sistema.';
    END;

    -- 1. Validar si algún producto en el carrito supera el stock físico actual
    SELECT COUNT(*) INTO v_FaltaStock
    FROM CARRITO_DESPACHO c
    INNER JOIN PRODUCTO p ON c.IdProducto = p.IdProducto
    WHERE c.IdDespacho = p_IdDespacho AND c.Cantidad > p.CantidadActual;

    -- 2. Iniciar la transacción ACID
    START TRANSACTION;

    IF v_FaltaStock > 0 THEN
        -- Abortar cualquier posible cambio pendiente
        ROLLBACK;
        
        -- Cambiar estado a CANCELADO (Se hace fuera del rollback para que el cambio persista)
        UPDATE DESPACHO 
        SET Estado = 'CANCELADO' 
        WHERE IdDespacho = p_IdDespacho AND IdCliente = p_IdCliente;
        
        -- Limpiar la tabla intermedia (Carrito)
        DELETE FROM CARRITO_DESPACHO 
        WHERE IdDespacho = p_IdDespacho;
        
        SET p_Resultado = 'ERROR: La orden fue cancelada por falta de stock en uno o más productos (Rollback aplicado).';
    ELSE
        -- Si hay stock suficiente para TODO el carrito, se procesa en bloque
        
        -- Mover los productos del carrito al detalle oficial
        INSERT INTO DETALLE_DESPACHO (IdDespacho, IdProducto, Cantidad)
        SELECT IdDespacho, IdProducto, Cantidad 
        FROM CARRITO_DESPACHO 
        WHERE IdDespacho = p_IdDespacho;

        -- Descontar el inventario (Esto disparará automáticamente el trigger tg_AuditoriaInventario por cada producto)
        UPDATE PRODUCTO p
        INNER JOIN CARRITO_DESPACHO c ON p.IdProducto = c.IdProducto
        SET p.CantidadActual = p.CantidadActual - c.Cantidad
        WHERE c.IdDespacho = p_IdDespacho;

        -- Cambiar el estado a PROCESADO
        UPDATE DESPACHO 
        SET Estado = 'PROCESADO' 
        WHERE IdDespacho = p_IdDespacho AND IdCliente = p_IdCliente;

        -- Limpiar la tabla intermedia (Carrito)
        DELETE FROM CARRITO_DESPACHO 
        WHERE IdDespacho = p_IdDespacho;

        -- Confirmar la transacción
        COMMIT;
        
        SET p_Resultado = CONCAT('ÉXITO: Despacho #', p_IdDespacho, ' procesado correctamente en bloque.');
    END IF;
END$$

DELIMITER ;