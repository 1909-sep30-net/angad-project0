DROP TABLE Inventory;
DROP TABLE Locations;
DROP TABLE OrderedProducts;
DROP TABLE Orders;
DROP TABLE Products;
DROP TABLE Customers;

GO

CREATE TABLE Customers (
  CustomerId INT PRIMARY KEY NOT NULL IDENTITY,
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
  CustomerId INT FOREIGN KEY REFERENCES Customers(CustomerId),
  ProductId INT FOREIGN KEY REFERENCES Products(ProductId),
  OrderDate DATE,
  Quantity INT
);

CREATE TABLE OrderedProducts (
  CustomerId INT PRIMARY KEY NOT NULL,
  ProductId INT FOREIGN KEY REFERENCES Products(ProductId)
);

CREATE TABLE Locations (
  LocationId INT PRIMARY KEY NOT NULL,
  City VARCHAR(50)
);

CREATE TABLE Inventory (
	LocationId INT PRIMARY KEY NOT NULL,
	ProductId INT FOREIGN KEY REFERENCES Products(ProductId),
	Inventory INT
);

GO

INSERT INTO Customers (FirstName, LastName) VALUES
('Angad', 'Minhas'),
('Arthur', 'Morgan');

GO

SELECT * FROM Customers;