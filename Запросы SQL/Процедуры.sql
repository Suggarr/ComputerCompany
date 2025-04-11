Use ComputerCompanyDB;

GO
CREATE PROCEDURE AddSupplier
    @SupplierName NVARCHAR(100),
    @ContactInfo NVARCHAR(100) = 'Нет данных',
    @Address NVARCHAR(255) = 'Не указан'
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Suppliers (SupplierName, ContactInfo, Address)
    VALUES (@SupplierName, @ContactInfo, @Address);
END;

GO
CREATE PROCEDURE AddComponent
    @ComponentName NVARCHAR(100),
    @Price DECIMAL(10, 2),
    @CategoryID INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Components (ComponentName, Price, CategoryID)
    VALUES (@ComponentName, @Price, @CategoryID);
END;


--Go
--CREATE PROCEDURE GetSupplierEarnings
--    @StartDate DATE,
--    @EndDate DATE
--AS
--BEGIN
--    SELECT 
--        S.SupplierName,
--	Count(PD.Quantity) AS TotalQuantity,
--        SUM(PD.UnitPrice) AS TotalEarnings
--    FROM 
--        Purchases P
--    INNER JOIN 
--        Suppliers S ON P.SupplierID = S.SupplierID
--    INNER JOIN 
--        PurchaseDetails PD ON P.PurchaseID = PD.PurchaseID
--    WHERE 
--        P.PurchaseDate BETWEEN @StartDate AND @EndDate
--    GROUP BY 
--        S.SupplierName
--    ORDER BY 
--        TotalEarnings DESC;
--END;

Go
CREATE PROCEDURE GetPurchaseDetailsByPurchaseID --Для чека
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

Go

CREATE PROCEDURE GetPurchaseDetailsForSuppliers -------
    @StartDate DATE = NULL,
    @EndDate DATE = NULL,
    @SupplierID INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        p.PurchaseID,
        p.PurchaseDate,
        p.PurchaseReason,
        s.SupplierName,
        pd.Quantity,
        pd.UnitPrice,
        (pd.Quantity * pd.UnitPrice) AS ItemTotal,
        c.ComponentName,
        cat.CategoryName
    FROM 
        Purchases p
    LEFT JOIN 
        PurchaseDetails pd ON p.PurchaseID = pd.PurchaseID
    LEFT JOIN 
        Components c ON pd.ComponentID = c.ComponentID
    LEFT JOIN 
        Suppliers s ON p.SupplierID = s.SupplierID
    LEFT JOIN 
        Categories cat ON c.CategoryID = cat.CategoryID  
    WHERE 
        (@StartDate IS NULL OR p.PurchaseDate >= @StartDate) AND
        (@EndDate IS NULL OR p.PurchaseDate <= @EndDate) AND
        (@SupplierID IS NULL OR p.SupplierID = @SupplierID)
    ORDER BY 
        p.PurchaseID, c.ComponentName;
END

Go
CREATE PROCEDURE GetFilteredPurchases------
    @SupplierID INT = NULL,
    @StartDate DATE = NULL,
    @EndDate DATE = NULL
AS
BEGIN
    SELECT 
        p.PurchaseID,
        p.SupplierID,
        s.SupplierName,
        p.PurchaseDate,
        p.PurchaseReason,
        ISNULL(SUM(d.Quantity), 0) AS TotalQuantity,
        ISNULL(SUM(d.Quantity * d.UnitPrice), 0) AS TotalPrice
    FROM Purchases p
    LEFT JOIN PurchaseDetails d ON p.PurchaseID = d.PurchaseID
    INNER JOIN Suppliers s ON p.SupplierID = s.SupplierID
    WHERE 
        (@SupplierID IS NULL OR p.SupplierID = @SupplierID)
        AND (@StartDate IS NULL OR p.PurchaseDate >= @StartDate)
        AND (@EndDate IS NULL OR p.PurchaseDate <= @EndDate)
    GROUP BY 
        p.PurchaseID, p.SupplierID, s.SupplierName, p.PurchaseDate, p.PurchaseReason
    ORDER BY p.PurchaseDate;
END

