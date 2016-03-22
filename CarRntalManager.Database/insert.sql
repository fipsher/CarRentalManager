
USE CarRental;

SET IDENTITY_INSERT tblUser ON;
INSERT INTO tblUser (Id, FirstName, LastName, [Login], [Password], [Disabled])
VALUES 
		(1, 'Mike', 'Melnyk', 'MMelnyk','7923c1f51252737b7802fc62197c2e0c', 0), --Password: 45ds14
		(2, 'Stepan', 'Petrov', 'SPetrov', 'bbee0a60e38a9521efdeaf73e9edbf28', 0), --Password: 9856lk
		(3, 'Ivan', 'Golynsky', 'IGolynsky', '05f00abba10f3ac71aa9e4cd680da82f', 0); --Password: ig7813
SET IDENTITY_INSERT tblUser OFF;

SET IDENTITY_INSERT tblCar ON;
INSERT INTO tblCar(Id, Class, Name, RegNum, PassengerNum, FuelConsuption, Rate, Operating)
VALUES 
		(1, 'Mini', 'Renault Twingo', 'BC4510BK', 4, 3.2, 40, 1),
		(2, 'Mini', 'Fiat 500', 'BC4511BK', 4, 3.0, 40, 1),
		(3, 'Economy', 'Ford Fiesta', 'BC4512BK', 4, 4.5, 50, 1),
		(4, 'Economy', 'Opel Corsa', 'BC4513BK', 4, 4.0, 50, 1),
		(5, 'Economy', 'VW Polo', 'BC4514BK', 4, 5.0, 50, 1),
		(6, 'Compact', 'Peugeot 3008', 'BC4515BK', 5, 6.1, 60, 1),
		(7, 'Compact', 'VW Golf', 'BC4516BK', 4, 6.0, 60, 1),
		(8, 'Compact', 'Ford Focus', 'BC4517BK', 5, 6.3, 60, 1),
		(9, 'Mid-Size', 'Citroen C4', 'BC4518BK', 5, 7.3, 70, 1),
		(10, 'Mid-Size', 'Ford Kuga', 'BC4519BK', 5, 7.0, 70, 1),
		(11, 'Family-Size', 'Citroen C5', 'BC6789BK', 5, 7.8, 80, 1),
		(12, 'Family-Size', 'Opel Insignia', 'BC6790BK', 5, 8.4, 80, 1),
		(13, 'Minivan', 'VW Caravelle', 'BC6791BK', 9, 9.1, 100, 1),
		(14, 'Minivan', 'VW Multivan', 'BC6792BK', 7, 9.4, 100, 1);
		
SET IDENTITY_INSERT tblCar OFF;

SET IDENTITY_INSERT tblCustomer ON;
INSERT INTO tblCustomer (Id, FirstName, LastName, LicenseNum)
VALUES 
		(1, 'Dima', 'Barinov', 'PPB457243'),
		(2, 'Andriy', 'Sikora', 'PKB453243'),
		(3, 'Andriy', 'Samoilich', 'PEH398700'),
		(4, 'Alex', 'Luchyshyn', 'PEH562147'),
		(5, 'Ostap', 'Maly', 'PKB997531'),
		(6, 'Igor', 'Voytovych', 'PCC647792'),
		(7, 'Ivan', 'Denysenko', 'PKK493125'),
		(8, 'Vasyl', 'Muzyka', 'MKK117269'),
		(9, 'Vlad', 'Yama', 'CKM459877'),
		(10, 'Denys', 'Tkach', 'PHH964178');
SET IDENTITY_INSERT tblCustomer OFF;

SET IDENTITY_INSERT tblOrder ON;
INSERT INTO tblOrder (Id, CustomerId, CarId, StartDate, EndDate, Cost, Active, Delayed, UserId)
VALUES 
		(1, 1, 3, '2016-03-11', '2016-03-13', 100, 0, 0, 1),
		(2, 2, 1, '2016-03-11', '2016-03-16', 200, 0, 1, 1),
		(3, 7, 2, '2016-03-10', '2016-03-21', 400, 1, 0, 2),
		(4, 8, 4, '2016-03-12', '2016-03-14', 100, 0, 0, 3),
		(5, 9, 9, '2016-03-16', '2016-03-26', 700, 1, 0, 2),
		(6, 8, 6, '2016-03-09', '2016-03-11', 120, 0, 1, 3),
		(7, 3, 7, '2016-03-07', '2016-03-10', 180, 0, 0, 1),
		(8, 8, 8, '2016-03-21', '2016-03-30', 540, 1, 0, 3),
		(9, 5, 9, '2016-03-29', '2016-04-03', 350, 1, 0, 1),
		(10, 6, 13, '2016-03-22', '2016-03-27', 500, 1, 0, 1);
SET IDENTITY_INSERT tblOrder OFF;
