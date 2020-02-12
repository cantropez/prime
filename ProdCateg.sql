if not exists (select * from sysobjects where name='Category' and xtype='U')
	CREATE TABLE Category (
	ID INT NOT NULL PRIMARY KEY,
	"CategoryName" nchar(40)
	)
go

INSERT INTO Category
VALUES
	(1, 'Car'),
	(2, 'Plane'),
	(3, 'Boat');

if not exists (select * from sysobjects where name='Product' and xtype='U')
	CREATE TABLE Product (
		ID int NOT NULL PRIMARY KEY,
		"ProductName" nchar(25),
		Category int
	);
go

INSERT INTO Product
VALUES
	(1, 'Porsche', 1),
	(2, 'Aerobus', 2),
	(3, 'Toyota', 1),
	(4, 'TU-154', 2),
	(5, 'Bentley', null);

SELECT Product.ProductName, Category.CategoryName 
FROM 
	Product LEFT JOIN Category ON Product.Category = Category.ID
	