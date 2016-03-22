
USE CarRental

DROP PROC spGetUserByLogin;
DROP PROC spGetPriceList;
DROP PROC spGetAvailableCars;
DROP PROC spGetDelayedCars;
DROP PROC spGetCustomerHistory;
DROP PROC spGetIncome;
DROP PROC spCreateOrder;
DROP FUNCTION udfOrderDelay;
DROP PROC spCloseOrder;


DROP TABLE tblOrder;
DROP TABLE tblCustomer;
DROP TABLE tblCar;
DROP TABLE tblUser;
GO