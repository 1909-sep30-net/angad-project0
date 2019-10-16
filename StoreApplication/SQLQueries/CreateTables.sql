DROP TABLE Inventory;
DROP TABLE OrderedProducts;
DROP TABLE Locations;
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
  ProductId INT PRIMARY KEY NOT NULL IDENTITY,
  ProductName VARCHAR(50) NOT NULL,
  ProductType VARCHAR(50),
);

CREATE TABLE Locations (
  LocationId INT PRIMARY KEY NOT NULL IDENTITY,
  City VARCHAR(50)
);

CREATE TABLE Orders (
  OrderId INT PRIMARY KEY NOT NULL IDENTITY,
  CustomerId INT FOREIGN KEY REFERENCES Customers(CustomerId),
  OrderDate DATE,
  Quantity INT
);

CREATE TABLE OrderedProducts (
  OPId INT PRIMARY KEY NOT NULL IDENTITY,
  CustomerId INT FOREIGN KEY REFERENCES Customers(CustomerId),
  OrderId INT FOREIGN KEY REFERENCES Orders(OrderId),
  ProductId INT FOREIGN KEY REFERENCES Products(ProductId),
  LocationId INT FOREIGN KEY REFERENCES Locations(LocationId)
);

CREATE TABLE Inventory (
	InventoryId INT PRIMARY KEY NOT NULL IDENTITY,
	LocationId INT FOREIGN KEY REFERENCES Locations(LocationId),
	ProductId INT FOREIGN KEY REFERENCES Products(ProductId),
	Inventory INT
);

GO

--INSERT INTO Customers (FirstName, LastName) VALUES
--('Arthur', 'Morgan'),
--('Angad', 'Minhas');

INSERT INTO Locations (City) VALUES
('LA'),
('San Diego'),
('Arlington'),
('Dallas'),
('Fort Worth');

GO

SELECT * FROM Customers;

SELECT * FROM Products;

SELECT * FROM Locations;

SELECT * FROM Inventory;

SELECT * FROM Orders;

SELECT * FROM OrderedProducts;