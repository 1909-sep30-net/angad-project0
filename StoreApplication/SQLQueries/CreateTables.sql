DROP TABLE Inventory;
DROP TABLE Location;
DROP TABLE OrderedProducts;
DROP TABLE Orders;
DROP TABLE Products;
DROP TABLE Customer;

GO

CREATE TABLE Customer (
  CustomerId INT PRIMARY KEY NOT NULL,
  FirstName VARCHAR(50),
  LastName VARCHAR(50)
);

CREATE TABLE Products (
  ProductId INT PRIMARY KEY NOT NULL,
  ProductName VARCHAR(50),
  ProductType VARCHAR(50),
);

CREATE TABLE Orders (
  OrderId INT PRIMARY KEY NOT NULL,
  CustomerId INT FOREIGN KEY REFERENCES Customer(CustomerId),
  ProductId INT FOREIGN KEY REFERENCES Products(ProductId),
  OrderDate DATE,
  Quantity INT
);

CREATE TABLE OrderedProducts (
  CustomerId INT PRIMARY KEY NOT NULL,
  ProductId INT FOREIGN KEY REFERENCES Products(ProductId)
);

CREATE TABLE Location (
  LocationId INT PRIMARY KEY NOT NULL,
  City VARCHAR(50)
);

CREATE TABLE Inventory (
	LocationId INT PRIMARY KEY NOT NULL,
	ProductId INT FOREIGN KEY REFERENCES Products(ProductId),
	Inventory INT
);

INSERT INTO Customer (CustomerId, FirstName, LastName) VALUES
(1, 'Angad', 'Minhas'),
(2, 'Arthur', 'Morgan');

SELECT * FROM Customer;