Use ComputerCompanyDB;

Go
CREATE PROCEDURE AddSupplier
    @SupplierName NVARCHAR(100),
    @ContactInfo NVARCHAR(100) = 'Нет данных',
    @Address NVARCHAR(255) = 'Не указан'
AS
BEGIN
    INSERT INTO Suppliers (SupplierName, ContactInfo, Address)
    VALUES (@SupplierName, @ContactInfo, @Address);
END

Go 
CREATE PROCEDURE AddComponent
    @ComponentName NVARCHAR(100),
    @Price DECIMAL(10, 2),
	@WarrantyMonths INT = NULL,
	@CategoryID INT = NULL
AS
BEGIN
    INSERT INTO Components (ComponentName, Price, WarrantyMonths, CategoryID)
    VALUES (@ComponentName, @Price, @WarrantyMonths, @CategoryID);
END;

Go 
CREATE PROCEDURE GetPurchasesBySupplier
    @SupplierID INT
AS
BEGIN
    SELECT * 
    FROM Purchases
    WHERE SupplierID = @SupplierID;
END;

Go
CREATE PROCEDURE AddPurchase
    @SupplierID INT,
    @PurchaseDate DATE = NULL,
    @PurchaseReason NVARCHAR(255) = NULL
AS
BEGIN
    IF @PurchaseDate IS NULL
        SET @PurchaseDate = GETDATE();

    INSERT INTO Purchases (SupplierID, PurchaseDate, PurchaseReason)
    VALUES (@SupplierID, @PurchaseDate, @PurchaseReason);
END;

Go
CREATE PROCEDURE GetSupplierEarnings
    @StartDate DATE,
    @EndDate DATE
AS
BEGIN
    SELECT 
        S.SupplierName,
		Count(PD.Quantity) AS TotalQuantity,
        SUM(PD.UnitPrice) AS TotalEarnings
    FROM 
        Purchases P
    INNER JOIN 
        Suppliers S ON P.SupplierID = S.SupplierID
    INNER JOIN 
        PurchaseDetails PD ON P.PurchaseID = PD.PurchaseID
    WHERE 
        P.PurchaseDate BETWEEN @StartDate AND @EndDate
    GROUP BY 
        S.SupplierName
    ORDER BY 
        TotalEarnings DESC;
END;

Go
CREATE PROCEDURE GetPurchaseDetailsByPurchaseID
    @PurchaseID INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Запрос для получения данных о закупках и деталях закупки с вычисляемым столбцом
    SELECT 
        pd.PurchaseID,
        c.ComponentName,  -- Замена ComponentID на ComponentName
        pd.Quantity,
        pd.UnitPrice,
        pd.Quantity * pd.UnitPrice AS TotalPrice,  -- Вычисляемый столбец
        p.PurchaseDate,
        s.SupplierName
    FROM 
        PurchaseDetails pd
    JOIN 
        Purchases p ON pd.PurchaseID = p.PurchaseID
    JOIN 
        Suppliers s ON p.SupplierID = s.SupplierID
    JOIN 
        Components c ON pd.ComponentID = c.ComponentID  -- Объединение с таблицей Components
    WHERE 
        pd.PurchaseID = @PurchaseID;
END;