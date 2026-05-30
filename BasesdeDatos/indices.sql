USE ProyectoBD2;


-- Índice para filtrar clientes por rol.

CREATE INDEX idx_CLIENTE_RolCliente
ON CLIENTE (RolCliente);


-- Índice para búsquedas de productos por nombre.

CREATE INDEX idx_PRODUCTO_Nombre
ON PRODUCTO (Nombre);


-- Índice para monitoreo de inventario por ubicación física.

CREATE INDEX idx_PRODUCTO_Ubicacion
ON PRODUCTO (Bodega, Pasillo, Estante);


-- Índice para consultas de recepciones por fecha.

CREATE INDEX idx_RECEPCION_FechaRecepcion
ON RECEPCION (FechaRecepcion);


-- Índice para consultas de despachos por fecha y estado.

CREATE INDEX idx_DESPACHO_FechaEstado
ON DESPACHO (FechaDespacho, Estado);


-- Índice compuesto para auditoría por producto y rango de fechas.

CREATE INDEX idx_AUDITORIA_PRODUCTO_ProductoFecha
ON AUDITORIA_PRODUCTO (IdProducto, FechaMovimiento);