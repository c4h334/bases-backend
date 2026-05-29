USE ProyectoBD2;

CREATE ROLE proyecto_operador;

GRANT SELECT, INSERT, UPDATE, DELETE
ON ProyectoBD2.*
TO proyecto_operador;

CREATE USER 'joviedo'@'localhost'
IDENTIFIED BY 'J@cqueline2026!';

CREATE USER 'amonge'@'localhost'
IDENTIFIED BY 'Anderson#2026!';

CREATE USER 'darce'@'localhost'
IDENTIFIED BY 'Diego#2026!';

CREATE USER 'jchacon'@'localhost'
IDENTIFIED BY 'Jose#2026!';

GRANT proyecto_operador TO 'joviedo'@'localhost';
GRANT proyecto_operador TO 'amonge'@'localhost';
GRANT proyecto_operador TO 'darce'@'localhost';
GRANT proyecto_operador TO 'jchacon'@'localhost';

SET DEFAULT ROLE proyecto_operador TO 'joviedo'@'localhost';
SET DEFAULT ROLE proyecto_operador TO 'amonge'@'localhost';
SET DEFAULT ROLE proyecto_operador TO 'darce'@'localhost';
SET DEFAULT ROLE proyecto_operador TO 'jchacon'@'localhost';