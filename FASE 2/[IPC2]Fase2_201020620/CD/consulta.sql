CREATE DATABASE QUETZAL_EXPRESS

use QUETZAL_EXPRESS

CREATE TABLE sucursal(
cod_sucursal INT IDENTITY,
pais VARCHAR(150),
direccion VARCHAR(150),
telefono INT,
capacidad_max_emp INT,
CONSTRAINT pk_codsucursal PRIMARY KEY (cod_sucursal)
)

CREATE TABLE departamento(
cod_depto INT IDENTITY,
nombre VARCHAR(150),
descripcion VARCHAR(150),
cod_sucursal INT,
CONSTRAINT pk_coddepto PRIMARY KEY (cod_depto),
CONSTRAINT fk_codsucursal FOREIGN KEY(cod_sucursal) REFERENCES sucursal(cod_sucursal)
)


CREATE TABLE Puesto (
cod_puesto INT IDENTITY,
nombre VARCHAR(150),
sueldo MONEY,
CONSTRAINT pk_codpuesto PRIMARY KEY (cod_puesto)
)

CREATE TABLE Comision(
cod_comision INT IDENTITY,
nombre VARCHAR(150),
porcentaje INT,
descripcion VARCHAR(150),
CONSTRAINT pk_codcomision PRIMARY KEY (cod_comision)
)

CREATE TABLE Descuento(
cod_descuento INT IDENTITY,
nombre VARCHAR(150),
porcentaje INT,
descripcion VARCHAR(150),
CONSTRAINT pk_coddescuento PRIMARY KEY (cod_descuento)
)

CREATE TABLE Impuesto(
cod_impuesto INT IDENTITY,
nombre VARCHAR(150),
porcentaje INT,
descripcion VARCHAR(150),
CONSTRAINT pk_codimpuesto PRIMARY KEY (cod_impuesto)
)

CREATE TABLE Empleado (
cod_empleado INT IDENTITY,
DPI BIGINT,
nombre VARCHAR(150),
apellido VARCHAR(150),
telefono INT,
cod_puesto INT,
direccion VARCHAR(150),
email VARCHAR(150),
pass VARCHAR(150),
cod_depto INT,
director BIT,
administrador BIT,
CONSTRAINT pk_codempleado PRIMARY KEY (cod_empleado),
CONSTRAINT fk_codpuesto FOREIGN KEY(cod_puesto) REFERENCES Puesto(cod_puesto),
CONSTRAINT fk_coddepto FOREIGN KEY(cod_depto) REFERENCES departamento(cod_depto)
)

CREATE TABLE Cliente(
cod_cliente INT IDENTITY,
dpi BIGINT,
nombre VARCHAR(150),
apellido VARCHAR(150),
NIT INT,
telefono INT,
direccion VARCHAR(150),
autorizado BIT,
email VARCHAR(150),
pass VARCHAR(150),
casilla INT,
CONSTRAINT pk_codcliente PRIMARY KEY (cod_cliente)
)

CREATE TABLE Acceso (
cod_acceso INT IDENTITY,
cod_cliente INT,
cod_empleado INT,
hora TIME,
fecha DATE,
CONSTRAINT pk_codacceso PRIMARY KEY (cod_acceso),
CONSTRAINT fk_codclientea FOREIGN KEY(cod_cliente) REFERENCES Cliente(cod_cliente),
CONSTRAINT fk_codempleadoa FOREIGN KEY(cod_empleado) REFERENCES Empleado(cod_empleado)
)

CREATE TABLE Tarjeta(
cod_tarjeta INT IDENTITY,
cod_cliente INT,
numero BIGINT,
fecha_venc VARCHAR(150),
cod_sec INT,
CONSTRAINT pk_codtarjeta PRIMARY KEY (cod_tarjeta),
CONSTRAINT fk_codclientet FOREIGN KEY(cod_cliente) REFERENCES Cliente(cod_cliente)
)

CREATE TABLE Pedido (
cod_pedido INT IDENTITY,
cod_cliente INT,
nombre VARCHAR(150),
precio_USA MONEY,
cod_impuesto INT,
cod_comision INT,
cod_descuento INT,
total MONEY,
peso_libra INT,
devolucion BIT,
estado VARCHAR(150)
CONSTRAINT pk_codpedido PRIMARY KEY (cod_pedido),
CONSTRAINT fk_codclientep FOREIGN KEY(cod_cliente) REFERENCES Cliente(cod_cliente),
CONSTRAINT fk_codimpuesto FOREIGN KEY(cod_impuesto) REFERENCES Impuesto(cod_impuesto),
CONSTRAINT fk_codcomision FOREIGN KEY(cod_comision) REFERENCES Comision(cod_comision),
CONSTRAINT fk_coddescuento FOREIGN KEY(cod_descuento) REFERENCES Descuento(cod_descuento)
)

CREATE TABLE Factura (
cod_factura INT IDENTITY,
cod_pedido INT,
cod_sucursal INT,
CONSTRAINT pk_codfactura PRIMARY KEY (cod_factura),
CONSTRAINT fk_codpedidof FOREIGN KEY(cod_pedido) REFERENCES Pedido(cod_pedido),
CONSTRAINT fk_codsucrusalf FOREIGN KEY(cod_sucursal) REFERENCES Sucursal(cod_sucursal)
)

