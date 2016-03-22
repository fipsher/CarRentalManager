
USE CarRental

GO
CREATE PROC spGetUserByLogin
	@Login NVARCHAR(50),
	@Password NVARCHAR(50)
AS
BEGIN
	SELECT 
		Id, 
		FirstName, 
		LastName, 
		[Login], 
		[Password], 
		[Disabled] 
	FROM tblUser
	WHERE [Login] = @Login COLLATE SQL_Latin1_General_CP1_CS_AS 
			AND [Password] = @Password AND [Disabled] <> 1;

END;
GO

GO
CREATE PROC spGetPriceList
AS
BEGIN
	SELECT Id, Class, Name, PassengerNum, FuelConsuption, Rate 
	FROM tblCar WHERE Operating = 1
END;
GO

GO
CREATE PROC spGetAvailableCars
	@StartDate DATETIME,
	@EndDate DATETIME,
	@Class NVARCHAR(50),
	@Price NUMERIC(8,2),
	@PassengerNum INT,
	@FuelConsuption NUMERIC(3,1)
AS
BEGIN
	DECLARE @Date DATETIME;
	SELECT @Date = GETDATE();
	
	IF (DATEDIFF(yy, @StartDate, @Date) > 0) 
		OR (DATEDIFF(m, @StartDate, @Date) > 0)
		OR (DATEDIFF(d, @StartDate, @Date) > 0)
		OR (DATEDIFF(yy, @StartDate, @EndDate) < 0)
		OR (DATEDIFF(m, @StartDate, @EndDate) < 0)
		OR (DATEDIFF(d, @StartDate, @EndDate) < 0) 
	BEGIN
		THROW 51000, 'The date is not correct', 100;
	END;
		
	SELECT DISTINCT
		c.Id, 
		c.Class, 
		c.Name, 
		c.PassengerNum, 
		c.FuelConsuption, 
		c.Rate 
	FROM tblCar AS c
	WHERE c.Id NOT IN
				( SELECT o.CarId 
				FROM tblOrder AS o
				WHERE (@StartDate BETWEEN o.StartDate AND o.EndDate) 
						OR (@EndDate BETWEEN o.StartDate AND o.EndDate) 
						OR (@StartDate < o.StartDate AND @EndDate > o.EndDate)
				) 
			AND c.PassengerNum >= @PassengerNum 
			AND c.FuelConsuption <= @FuelConsuption 
			AND c.Rate <= @Price 
			AND c.Operating = 1 
			AND (@Class = '' OR c.Class = @Class)
	END;

GO

GO
CREATE PROC spGetDelayedCars
AS
BEGIN
	DECLARE @Date DATETIME;
	SELECT @Date = GETDATE();

	SELECT 
		c.Id, 
		c.Class, 
		c.Name, 
		cu.FirstName,
		cu.LastName,
		cu.LicenseNum 
	FROM tblOrder AS o
	INNER JOIN tblCar AS c
	ON o.CarId = c.Id
	INNER JOIN tblCustomer AS cu
	ON o.CustomerId = cu.Id
	WHERE o.EndDate < @Date 
			AND o.Active = 1
END
GO

GO
CREATE PROC spGetCustomerHistory
	@FirstName NVARCHAR(50),
	@LastName NVARCHAR(50),
	@LicenseNum NVARCHAR(50)
AS
BEGIN
	IF (
		SELECT 1 
		FROM tblCustomer
		WHERE FirstName = @FirstName 
			AND LastName = @LastName 
			AND LicenseNum = @LicenseNum
		) IS NULL
	BEGIN
		THROW 51000, 'No such customer in the database', 100;
	END;
	
	SELECT 
		o.Id,
		cu.FirstName AS FirstName, 
		cu.LastName AS LastName, 
		ca.Name AS CarName, 
		LEFT(o.StartDate, 11) AS StartDate, 
		LEFT(o.EndDate, 11) AS EndDate, 
		o.Cost, 
		o.Active, 
		o.Delayed,
		o.UserId 
	FROM tblOrder AS o
	INNER JOIN tblCustomer AS cu
	ON o.CustomerId = cu.Id
	INNER JOIN tblCar AS ca
	ON o.CarId = ca.Id
	WHERE cu.FirstName = @FirstName 
		AND cu.LastName = @LastName 
		AND cu.LicenseNum = @LicenseNum
END;
GO

GO
CREATE PROC spGetIncome
	@StartDate DATETIME,
	@EndDate DATETIME
AS
BEGIN
	SELECT 
		LEFT(@StartDate, 11) AS StartDate, 
		LEFT(@EndDate, 11) AS EndDate, 
		SUM(Cost) AS Income
	FROM tblOrder as o
	WHERE o.StartDate >= @StartDate 
			AND o.EndDate <= @EndDate
END;
GO

GO
CREATE PROC spCreateOrder
	(
		@StartDate DATETIME,
		@EndDate DATETIME,
		@FirstName NVARCHAR(50),
		@LastName NVARCHAR(50),
		@LicenseNum NVARCHAR(50),
		@CarId INT,
		@UserId INT
	)
AS
BEGIN
	DECLARE @CustomerId INT;
	DECLARE @Cost INT;
	DECLARE @OrderId INT; 
	DECLARE @Date DATETIME;
	SET @Date = GETDATE();
	
	
	IF(@StartDate IS NULL
		OR @EndDate IS NULL
		OR @FirstName IS NULL
		OR @LastName IS NULL
		OR @LicenseNum IS NULL
		OR @CarId = 0)
	BEGIN
		THROW 51000, 'The form is not filled, you should fill every field', 100;
	END;

	IF (DATEDIFF(yy, @StartDate, @Date) > 0)
		OR (DATEDIFF(m, @StartDate, @Date) > 0)
		OR (DATEDIFF(d, @StartDate, @Date) > 0)
		OR (DATEDIFF(yy, @StartDate, @EndDate) < 0)
		OR (DATEDIFF(m, @StartDate, @EndDate) < 0)
		OR (DATEDIFF(d, @StartDate, @EndDate) < 0) 
	BEGIN
		THROW 51000, 'The date is not correct', 100;
	END;

	IF @CarId IN 
	(
		SELECT CarId 
		FROM tblOrder
		WHERE 
		(Active = 1
		AND (@StartDate BETWEEN StartDate AND EndDate) 
			OR (@EndDate BETWEEN StartDate AND EndDate) 
			OR (@StartDate < StartDate AND @EndDate > EndDate)) 		
	)
	BEGIN
		THROW 51000, 'Car is occupied for this date', 100;
	END;
	
	IF (
		SELECT 1 
		FROM tblCustomer
		WHERE FirstName = @FirstName 
			AND LastName = @LastName
			AND LicenseNum = @LicenseNum
		) IS NULL
	BEGIN
		INSERT INTO tblCustomer (FirstName, LastName, LicenseNum)
		VALUES 
			(@FirstName, @LastName, @LicenseNum)
	END;

	SELECT @CustomerId = Id FROM tblCustomer WHERE LicenseNum = @LicenseNum;

	SELECT @Cost = DATEDIFF(d, @StartDate, @EndDate) * Rate FROM tblCar WHERE Id = @CarId;
	
	INSERT INTO tblOrder (CustomerId, CarId, startDate, EndDate, Cost, Active, Delayed, UserId)
	VALUES 
		(@CustomerId, @CarId, @StartDate, @EndDate, @Cost, 1, 0, @UserId)

	SET @OrderId = @@IDENTITY;

	SELECT 
		o.Id,
		cu.FirstName, 
		cu.LastName,
		cu.LicenseNum,
		o.CarId, 
		ca.Name AS CarName, 
		LEFT(o.StartDate, 11) AS StartDate, 
		LEFT(o.EndDate, 11) AS EndDate, 
		o.Cost, 
		o.Active, 
		o.Delayed,
		o.UserId  
	FROM tblOrder AS o
	INNER JOIN tblCustomer AS cu
	ON o.CustomerId = cu.Id
	INNER JOIN tblCar AS ca
	ON o.CarId = ca.Id 
	WHERE o.Id = @OrderId 
	
END;
GO

GO
CREATE FUNCTION udfOrderDelay (@OrderId INT)
RETURNS INT
AS
BEGIN
	DECLARE @EndDate DATETIME;
	SELECT @EndDate = EndDate FROM tblOrder WHERE Id = @OrderId;
	RETURN DATEDIFF(d, @EndDate, GETDATE());
END;
GO


GO
CREATE PROC spCloseOrder
	@Id INT,
	@UserId INT
AS
BEGIN	
	IF(@Id = 0)
	BEGIN
		THROW 51000, 'Please enter the Order ID', 100;
	END;

	IF(SELECT Active FROM tblOrder WHERE ID = @Id) = 0
	BEGIN
		THROW 51000, 'This order is already closed', 100;
	END;
	
	DECLARE @Delay INT = dbo.udfOrderDelay(@Id);
	
	UPDATE tblOrder
	SET Active = 0,
		Delayed = CAST(@Delay AS BIT),
		Cost = (Cost + @Delay * (
								SELECT ca.Rate
								FROM tblOrder AS o
								INNER JOIN tblCustomer AS cu
								ON o.CustomerId = cu.Id
								INNER JOIN tblCar AS ca
								ON o.CarId = ca.Id 
								WHERE o.Id = @Id
								))
	WHERE Id = @Id
	
	SELECT 
		o.Id,
		cu.FirstName, 
		cu.LastName,
		cu.LicenseNum,
		o.CarId, 
		ca.Name AS CarName, 
		LEFT(o.StartDate, 11) AS StartDate, 
		LEFT(o.EndDate, 11) AS EndDate, 
		Cost, 
		Active, 
		Delayed,
		o.UserId,
		(@Delay * ca.Rate) AS Fine 
	FROM tblOrder AS o
	INNER JOIN tblCustomer AS cu
	ON o.CustomerId = cu.Id
	INNER JOIN tblCar AS ca
	ON o.CarId = ca.Id 
	WHERE o.Id = @Id 
END
GO

