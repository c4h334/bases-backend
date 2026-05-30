USE ProyectoBD2;

/*
Función: fn_VerificarAlertaStock
Propósito:
Verifica si un producto tiene stock suficiente o si debe generar alerta de reorden.

Parámetro:
p_IdProducto: ID del producto a consultar.

Retorno:
'OK' Significa que el stock actual es mayor al stock crítico.
'REORDEN' El stock actual está en o por debajo del stock crítico.
'NO_EXISTE' El producto no existe.
*/

DROP FUNCTION IF EXISTS fn_VerificarAlertaStock;

DELIMITER //

CREATE FUNCTION fn_VerificarAlertaStock(
    p_IdProducto INT
)
RETURNS VARCHAR(20)
READS SQL DATA
BEGIN
    DECLARE v_CantidadActual INT DEFAULT 0;
    DECLARE v_StockCritico INT DEFAULT 0;
    DECLARE v_Existe INT DEFAULT 1;

    DECLARE CONTINUE HANDLER FOR NOT FOUND
        SET v_Existe = 0;

    SELECT 
        CantidadActual,
        StockCritico
    INTO 
        v_CantidadActual,
        v_StockCritico
    FROM PRODUCTO
    WHERE IdProducto = p_IdProducto;

    IF v_Existe = 0 THEN
        RETURN 'NO_EXISTE';
    END IF;

    IF v_CantidadActual <= v_StockCritico THEN
        RETURN 'REORDEN';
    ELSE
        RETURN 'OK';
    END IF;
END //

DELIMITER ;

/*
Trigger: tg_AuditoriaInventario
Propósito:
Registra automáticamente en AUDITORIA_PRODUCTO cada cambio realizado sobre la cantidad actual de un producto.

Momento de activación:
AFTER UPDATE

Evento:
UPDATE sobre la tabla PRODUCTO.

Tabla:
PRODUCTO
*/

DROP TRIGGER IF EXISTS tg_AuditoriaInventario;

DELIMITER //

CREATE TRIGGER tg_AuditoriaInventario
AFTER UPDATE ON PRODUCTO
FOR EACH ROW
BEGIN
    IF OLD.CantidadActual <> NEW.CantidadActual THEN
        INSERT INTO AUDITORIA_PRODUCTO (
            IdProducto,
            FechaMovimiento,
            CantidadAnterior,
            CantidadNueva,
            UsuarioModificacion
        )
        VALUES (
            NEW.IdProducto,
            NOW(),
            OLD.CantidadActual,
            NEW.CantidadActual,
            COALESCE(
                NULLIF(@UsuarioSistema, ''),
                SUBSTRING_INDEX(CURRENT_USER(), '@', 1)
            )
        );
    END IF;
END //

DELIMITER ;