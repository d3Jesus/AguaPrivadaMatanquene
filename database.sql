CREATE TABLE tblCliente(
	idCliente INT NOT NULL identity(1,1),
	nome VARCHAR(45) NOT NULL, 
	sexo VARCHAR(45) NOT NULL, 
	dataNascimento VARCHAR(50) NOT NULL, 
	provincia VARCHAR(100) NOT NULL, 
	bairro VARCHAR(50) NOT NULL, 
	quarteirao VARCHAR(50) NOT NULL, 
	rua VARCHAR(50) NOT NULL, 
	estadoCivil VARCHAR(50) NOT NULL, 
	contacto VARCHAR(45) NOT NULL, 
	PRIMARY KEY (idCliente)
);
GO

CREATE TABLE tblFuncionario(
	idFuncionario INT NOT NULL identity(1,1),
	nome VARCHAR(45) NOT NULL, 
	sexo VARCHAR(10) NOT NULL, 
	dataNascimento DATE NOT NULL,  
	estadoCivil VARCHAR(10) NOT NULL, 
	contacto VARCHAR(45) NOT NULL, 
	endereco VARCHAR(45) NOT NULL
	PRIMARY KEY(idFuncionario)
);
GO

CREATE TABLE tblUsuario(
	idUsuario INT NOT NULL identity(1,1),
	idFuncionario INT NOT NULL, 
	nomeUsuario VARCHAR(45) NOT NULL,
	senha VARCHAR(45) NOT NULL,
	cargo VARCHAR(45) NOT NULL,
	situacao VARCHAR(10) NOT NULL,
	PRIMARY KEY(idUsuario),
	FOREIGN KEY(idFuncionario) REFERENCES tblFuncionario(idFuncionario)
);
GO

CREATE TABLE tblEscalao(
	idEscalao INT NOT NULL identity(1,1),
	especie VARCHAR(45) NOT NULL, 
	quantidade INT NOT NULL, 
	valorUn DECIMAL(18,2) NOT NULL,  
	IVA DECIMAL(18,2) NOT NULL,
	PRIMARY KEY(idEscalao)
);
GO

CREATE TABLE tblRecibo (
  idRecibo INT NOT NULL identity(1,1),
  nrFatura INT NULL,
  IVA DECIMAL(18,2) NOT NULL,
  dataPag DATE NOT NULL,
  valorPago DECIMAL(18,2) NOT NULL,
  PRIMARY KEY (idRecibo))
go

CREATE TABLE tblFactura(
	idFactura INT NOT NULL identity(1,1),
	idInstalacao Int NOT NULL,
	idCliente INT NOT NULL,
	data DATE NOT NULL,
	IVA DECIMAL(18,2) NOT NULL,
	valorTotal DECIMAL(18,2) NOT NULL,
	estado VARCHAR(30) NOT NULL,
	PRIMARY KEY(idFactura)
);
GO

CREATE TABLE tblPagamento (
	idPagamento INT NOT NULL identity(1,1),
	idFactura INT NULL,
	idRecibo INT NULL,
	dataPagamento DATE NOT NULL,
	tipoPagamento VARCHAR(9) NOT NULL,
	nrCheque INT NULL,
	valorTotal DECIMAL(18,2) NOT NULL,
	PRIMARY KEY (idPagamento),
	FOREIGN KEY(idRecibo) REFERENCES tblRecibo(idRecibo),
	FOREIGN KEY(idFactura) REFERENCES tblFactura(idFactura)
);
GO

CREATE TABLE tblInstalacao(
	idInstalacao Int NOT NULL identity(1,1),
	idCliente Int NOT NULL,
	idFuncionario Int NOT NULL,
	idEscalao Int NOT NULL,
	data DATE NOT NULL,
	contador Int NOT NULL,
	localAbastecimento VARCHAR(200) NOT NULL,
	PRIMARY KEY(idInstalacao),
	FOREIGN KEY(idCliente) REFERENCES tblCliente(idCliente),
	FOREIGN KEY(idFuncionario) REFERENCES tblFuncionario(idFuncionario),
	FOREIGN KEY(idEscalao) REFERENCES tblEscalao(idEscalao)
);
GO

/* Stored Procedures for Reports */
/* 
	* clientes que efectuaram e nao efectuaram os pagamentos 
*/
CREATE PROCEDURE clienteDetails
AS
	SELECT distinct c.idCliente, nome, sexo, provincia, bairro, contacto, f.data, estado 
	FROM tblCliente c INNER JOIN tblFactura f ON f.idCliente = c.idCliente
	WHERE CONVERT(CHAR(4), data, 100) = CONVERT(CHAR(4), GETDATE(), 100) 
go

/*
	* o escalao mais usado
*/
CREATE PROCEDURE escalaoDetails
AS
	SELECT i.idEscalao, e.especie, e.quantidade, e.valorUn, COUNT(i.idEscalao) AS tot
	FROM tblEscalao e INNER JOIN tblInstalacao i ON e.idEscalao = i.idEscalao
	group BY i.idEscalao, e.especie, e.quantidade, e.valorUn
	ORDER BY tot DESC
go

/*
	* facturacao
*/
CREATE PROCEDURE facturacao
(
	@CLIENTE int
)
AS
	SELECT DISTINCT TOP 5 f.idFactura, f.idCliente, f.data, c.nome, c.quarteirao, c.bairro, i.contador,
	i.localAbastecimento, e.especie, e.quantidade, e.valorUn, e.IVA, f.valorTotal, f.estado
	FROM tblFactura f INNER JOIN tblCliente c ON f.idCliente = c.idCliente
	INNER JOIN tblInstalacao i ON i.idInstalacao = f.idInstalacao
	INNER JOIN tblEscalao e ON i.idEscalao = e.idEscalao
	WHERE f.idCliente = @CLIENTE
	group by f.idCliente, f.idFactura, f.data, c.nome, c.quarteirao, c.bairro, i.contador,
	i.localAbastecimento, e.especie, e.quantidade, e.valorUn, e.IVA, f.valorTotal, f.estado
	order by f.data desc

/*
	* factura
*/
CREATE PROCEDURE factura
AS
SELECT f.idFactura, f.idCliente, c.nome, c.provincia, c.bairro, f.data, f.valorTotal
FROM tblFactura f INNER JOIN tblCliente c ON f.idCliente = c.idCliente
INNER JOIN tblInstalacao i ON i.idInstalacao = f.idInstalacao
INNER JOIN tblEscalao e ON i.idEscalao = e.idEscalao
WHERE estado = 'Em Débito' and 
CONVERT(CHAR(4), f.data, 120) = CONVERT(CHAR(4), GETDATE(), 120)
and MONTH(f.data) = MONTH(GETDATE())

/*
	* divida e multa do cliente
*/
CREATE PROCEDURE DEBITO
(
	@CLIENTE INT
)
AS
DECLARE @DEBITO DECIMAL(18,2), @MULTA DECIMAL(18,2)
SET @DEBITO =
(
SELECT Sum(valorTotal) as divida
FROM tblInstalacao i INNER JOIN tblFactura f
on i.idInstalacao = f.idInstalacao INNER JOIN tblEscalao e on i.idEscalao = e.idEscalao
where f.idCliente = @CLIENTE and estado = 'Em Débito'
)
SET @MULTA =
(
select ROUND(SUM(f.valorTotal*10/100),2,0) as multa
FROM tblInstalacao i INNER JOIN tblFactura f
on i.idInstalacao = f.idInstalacao INNER JOIN tblEscalao e on i.idEscalao = e.idEscalao
where f.idCliente = @CLIENTE and estado = 'Em Débito' 
and CONVERT(CHAR(4), f.data, 120) = CONVERT(CHAR(4), GETDATE(), 120)
and MONTH(f.data) < MONTH(GETDATE())
)
SELECT @MULTA AS multa, @DEBITO as debito, (@MULTA+@DEBITO) as total