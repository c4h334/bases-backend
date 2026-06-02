DELIMITER $$

DROP PROCEDURE IF EXISTS sp_ProcesarDespacho$$

CREATE PROCEDURE sp_ProcesarDespacho(
    IN p_IdCliente INT,
    IN p_Operario VARCHAR(50),
    IN p_Estado INT, 
    IN p_IdProducto INT,
    IN p_Cantidad INT,
    OUT p_Resultado VARCHAR(255)
)
BEGIN
    DECLARE v_CantidadActual INT;
    
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        ROLLBACK;
        SET p_Resultado = 'ERROR: Transacción abortada. Fallo en el proceso de despacho.';
    END;

    IF p_Cantidad <= 0 THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'La cantidad a despachar debe ser mayor a cero.';
    END IF;

    START TRANSACTION;

        SELECT CantidadActual INTO v_CantidadActual 
        FROM PRODUCTO 
        WHERE IdProducto = p_IdProducto 
        FOR UPDATE;

        IF v_CantidadActual IS NULL THEN
            SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'El producto especificado no existe.';
        ELSEIF v_CantidadActual < p_Cantidad THEN
            SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Fallo de Consistencia: Stock insuficiente para el despacho.';
        ELSE
            INSERT INTO DESPACHO (FechaDespacho, Estado, Operario, IdCliente)
            VALUES (NOW(), p_Estado, p_Operario, p_IdCliente);
            
            SET @v_IdDespacho = LAST_INSERT_ID();

            INSERT INTO DETALLE_DESPACHO (IdDespacho, IdProducto, Cantidad)
            VALUES (@v_IdDespacho, p_IdProducto, p_Cantidad);

            UPDATE PRODUCTO 
            SET CantidadActual = CantidadActual - p_Cantidad
            WHERE IdProducto = p_IdProducto;

            COMMIT;
            SET p_Resultado = CONCAT('ÉXITO: Despacho #', @v_IdDespacho, ' completado con éxito.');
        END IF;

END$$

DELIMITER ;