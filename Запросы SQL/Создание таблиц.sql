-- Создание базы данных
CREATE DATABASE ComputerCompanyDB;
GO

-- Использование созданной базы данных
USE ComputerCompanyDB;
GO


-- Создание таблицы Categories
CREATE TABLE Categories (
    CategoryID INT IDENTITY(1,1) PRIMARY KEY,  
    CategoryName NVARCHAR(100) NOT NULL UNIQUE, 
    Description NVARCHAR(256)  -- Поле для описания категории, может быть NULL
);

GO

-- Создание таблицы Suppliers
CREATE TABLE Suppliers (
    SupplierID INT IDENTITY(1,1) PRIMARY KEY,  
    SupplierName NVARCHAR(100) NOT NULL UNIQUE, 
	ContactInfo NVARCHAR(100) NOT NULL DEFAULT 'Нет данных',
    Address NVARCHAR(255) NOT NULL DEFAULT 'Не указан'
);

GO
-- Создание таблицы Components
CREATE TABLE Components (
    ComponentID INT IDENTITY(1,1) PRIMARY KEY, 
    ComponentName NVARCHAR(100) NOT NULL UNIQUE, 
    Price DECIMAL(10, 2) NOT NULL CHECK (Price >= 0),  -- Цена не может быть отрицательной
    CategoryID INT,  -- Ссылка на CategoryID, может быть NULL
    FOREIGN KEY (CategoryID) REFERENCES Categories(CategoryID) ON DELETE SET NULL ON UPDATE CASCADE
);

GO
-- Создание таблицы Purchases
CREATE TABLE Purchases (
    PurchaseID INT IDENTITY(1,1) PRIMARY KEY,  
    SupplierID INT,  
    PurchaseDate DATE DEFAULT GETDATE(),  
	PurchaseReason NVARCHAR(255),
    FOREIGN KEY (SupplierID) REFERENCES Suppliers(SupplierID) ON DELETE SET NULL ON UPDATE CASCADE, --Лучше ON DELETE SET NULL
);

GO
CREATE TABLE PurchaseDetails (
	PurchaseDetailID INT IDENTITY(1,1) PRIMARY KEY,
	PurchaseID INT NOT NULL,
	ComponentID INT,
	Quantity INT NOT NULL,
	UnitPrice DECIMAL(10, 2) NOT NULL DEFAULT 0,
	FOREIGN KEY (PurchaseID) REFERENCES Purchases(PurchaseID)
	ON DELETE CASCADE ON UPDATE CASCADE,
	FOREIGN KEY (ComponentID) REFERENCES Components(ComponentID)
	ON DELETE SET NULL ON UPDATE CASCADE,
	CONSTRAINT CHK_Quantity CHECK (Quantity > 0),-- Проверка для Quantity
	CONSTRAINT CHK_UnitPrice CHECK (UnitPrice >= 0) -- Проверка для UnitPrice
);
