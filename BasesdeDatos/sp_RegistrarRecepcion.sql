DELIMITER $$

DROP PROCEDURE IF EXISTS sp_RegistrarRecepcion$$

CREATE PROCEDURE sp_RegistrarRecepcion(
    IN p_NumeroLote VARCHAR(50),
    IN p_UsuarioAtendio VARCHAR(50),
    IN p_IdCliente INT,
    IN p_IdProducto INT,
    IN p_Cantidad INT,
    OUT p_Resultado VARCHAR(255)
)
BEGIN
    -- Control de errores 
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        ROLLBACK;
        SET p_Resultado = 'ERROR: Transacción abortada. No se pudo registrar la recepción.';
    END;

    IF p_Cantidad <= 0 THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'La cantidad debe ser mayor a cero.';
    END IF;

    -- Inicio de la transacción ACID
    START TRANSACTION;

        INSERT INTO RECEPCION (NumeroLote, FechaRecepcion, UsuarioAtendio, IdCliente)
        VALUES (p_NumeroLote, NOW(), p_UsuarioAtendio, p_IdCliente);
        
        SET @v_IdRecepcion = LAST_INSERT_ID();

        INSERT INTO DETALLE_RECEPCION (IdRecepcion, IdProducto, Cantidad)
        VALUES (@v_IdRecepcion, p_IdProducto, p_Cantidad);

        UPDATE PRODUCTO 
        SET CantidadActual = CantidadActual + p_Cantidad
        WHERE IdProducto = p_IdProducto;

    COMMIT;
    
    SET p_Resultado = CONCAT('ÉXITO: Recepción #', @v_IdRecepcion, ' procesada correctamente.');

END$$

DELIMITER ;