GO
CREATE DATABASE CarRental;
GO

GO
USE CarRental;

CREATE TABLE tblUser
(
	Id INT NOT NULL IDENTITY (1, 1),
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	[Login] NVARCHAR(50) NOT NULL,
	[Password] NVARCHAR(50) NOT NULL,
	[Disabled] BIT NOT NULL,
	CONSTRAINT PK_tblUser_Id PRIMARY KEY (Id),
	CONSTRAINT UQ_tblUser_Login UNIQUE ([Login])
);

CREATE TABLE tblCar
(
	Id INT NOT NULL IDENTITY (1, 1),
	Class NVARCHAR(50) NOT NULL,
	Name NVARCHAR(50) NOT NULL,
	RegNum NVARCHAR(50) NOT NULL,
	PassengerNum INT NOT NULL,
	FuelConsuption NUMERIC(3,1),
	Rate NUMERIC(8,2),
	Operating BIT NOT NULL, 
	CONSTRAINT PK_tblCar_Id PRIMARY KEY (Id),
	CONSTRAINT UQ_tblCar_RegNum UNIQUE (RegNum)
);

CREATE TABLE  tblCustomer
(
	Id INT NOT NULL IDENTITY (1, 1),
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	LicenseNum NVARCHAR(50) NOT NULL,
	CONSTRAINT PK_tblCustomer_Id PRIMARY KEY (Id),
	CONSTRAINT UQ_tblCustomer_LicenseNum UNIQUE (LicenseNum)
);

CREATE TABLE tblOrder
(
	Id INT NOT NULL IDENTITY (1, 1),
	CustomerId INT NOT NULL,
	CarId INT NOT NULL,
	StartDate DATETIME NOT NULL,
	EndDate DATETIME NOT NULL,
	Cost NUMERIC(8,2) NOT NULL,
	Active BIT NOT NULL,
	Delayed BIT NOT NULL,
	UserId INT NOT NULL,
	CONSTRAINT PK_tblOrder_Id PRIMARY KEY (Id),
	CONSTRAINT PK_tblOrder_UserId_tblUser_Id FOREIGN KEY (UserId) REFERENCES tblUser(Id),
	CONSTRAINT FK_tblOrder_CustomerId_tblCustomer_Id FOREIGN KEY (CustomerId) REFERENCES tblCustomer(Id),
	CONSTRAINT FK_tblOrder_CarId_tblCar_Id FOREIGN KEY (CarId) REFERENCES tblCar(Id)
);
GO
