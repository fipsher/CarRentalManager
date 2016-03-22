# CarRentalManager
Manager for Car Rental

Before usage of proposed application you will need to make the next steps:
1. If you do not have MS SQL Server 2014 Express and MS SQL Management Studio 2014 you will need to install them.

2. Open with a help of MS SQL Management Studio 2014 next SQL queries: create.sql; insert.sql; procs.sql and drop.sql. These files are located in the directory path: "CarRntalManager.Database\".

3. Execute these scripts to create database and fill it in the next order: create.sql; insert.sql; procs.sql (drop.sql you will need if you decide to delete tables from database).

4. You will also need to change App.config file(path: "...CarRentalManager\") in order to provide parameters of you SQLServer. Open it and replace value of connectionString in
"connectionString="Server=SAN\SQLEXPRESS;Database=CarRental;Trusted_Connection=True;""
for "connectionString="Server=myServerAddress;Database=myDataBase;User Id=myUsername;Password=myPassword;"" with your values if you have standard security or "connectionString="Server=myServerAddress;Database=myDataBase;Trusted_Connection=True;"" with your values if you have trusted connection.
