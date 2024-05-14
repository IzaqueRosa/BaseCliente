--Criação banco BaseCliente
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'BaseCliente')
BEGIN
-- Cria o banco de dados
CREATE DATABASE BaseCliente;
PRINT 'O banco de dados BaseCliente foi criado com sucesso.';
END
ELSE
BEGIN
PRINT 'O banco de dados BaseCliente já existe.';
END

USE BaseCliente

IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'BANCO')
BEGIN
CREATE TABLE BANCO(
Id INT IDENTITY NOT NULL,
Nome VARCHAR (500) NOT NULL,
DataCriacao DATETIME NOT NULL,
CONSTRAINT PK_EMPRESA PRIMARY KEY (Id)
)

INSERT INTO BANCO (Nome, DataCriacao) VALUES ('Nubank', GETDATE())
INSERT INTO BANCO (Nome, DataCriacao) VALUES ('Inter', GETDATE())
INSERT INTO BANCO (Nome, DataCriacao) VALUES ('Bradesco', GETDATE())

END

IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'CLIENTE')
BEGIN
CREATE TABLE CLIENTE(
Id INT IDENTITY NOT NULL,
IdBanco INT NOT NULL,
Nome VARCHAR (200),
CPF VARCHAR (11),
DataCriacao DATETIME NOT NULL,
CONSTRAINT PK_BANNER PRIMARY KEY (Id),
CONSTRAINT FK_BANNER_EMPRESA FOREIGN KEY (IdBanco) REFERENCES BANCO (Id)
)

INSERT INTO CLIENTE (IdBanco, Nome, CPF, DataCriacao) VALUES (1, 'Izaque', '30144066009', GETDATE())
INSERT INTO CLIENTE (IdBanco, Nome, CPF, DataCriacao) VALUES (1, 'Fran', '89193374038', GETDATE())
INSERT INTO CLIENTE (IdBanco, Nome, CPF, DataCriacao) VALUES (2, 'Matheus', '25335729007', GETDATE())

END



