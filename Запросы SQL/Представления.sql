Use ComputerCompanyDB;

---Представление для показа покупок	  
Go
CREATE VIEW vw_Purchases AS
SELECT 
    p.PurchaseID, 
    s.SupplierName, 
    p.PurchaseDate
FROM Purchases p
JOIN Suppliers s ON p.SupplierID = s.SupplierID;

---Представление для деталей закупок с комплектующими
Go
CREATE VIEW View_PurchaseSummary AS
SELECT 
    pd.PurchaseDetailID,
    pd.PurchaseID,
    c.ComponentName,
	p.PurchaseDate,
	p.PurchaseReason,
    pd.Quantity,
    pd.UnitPrice
FROM 
    PurchaseDetails pd
JOIN 
    Purchases p ON pd.PurchaseID = p.PurchaseID
JOIN 
    Components c ON pd.ComponentID = c.ComponentID

---Представление для суммарной стоимости закупок по комплектующим
Go
CREATE VIEW View_ComponentPurchaseTotal AS
SELECT 
    c.ComponentID,
    c.ComponentName,
    SUM(pd.UnitPrice) AS TotalSpent
FROM 
    Components c
JOIN 
    PurchaseDetails pd ON c.ComponentID = pd.ComponentID
GROUP BY 
    c.ComponentID, c.ComponentName

Go
CREATE VIEW View_SupplierPurchases AS
SELECT 
    s.SupplierID,
    s.SupplierName,
    COUNT(p.PurchaseID) AS TotalPurchases
FROM 
    Suppliers s
LEFT JOIN 
    Purchases p ON s.SupplierID = p.SupplierID
GROUP BY 
    s.SupplierID, s.SupplierName;

Go
CREATE VIEW View_SupplierTotalRevenue AS
SELECT 
    s.SupplierID,
    s.SupplierName,
	Sum(pd.Quantity) AS TotalQuantity,
    SUM(pd.UnitPrice*pd.Quantity) AS TotalRevenue
FROM 
    Suppliers s
JOIN Purchases p ON s.SupplierID = p.SupplierID
JOIN PurchaseDetails pd ON p.PurchaseID = pd.PurchaseID
GROUP BY 
    s.SupplierID, s.SupplierName;

----------------------------------------------

Go
CREATE VIEW vw_ComponentsWithCategoryAndPrice AS
SELECT 
    c.ComponentID,
    c.ComponentName,
    cat.CategoryName,
    c.Price
FROM Components c
LEFT JOIN Categories cat ON c.CategoryID = cat.CategoryID;

Go
CREATE VIEW vw_SupplierStatistics AS
SELECT 
    s.SupplierID,
    s.SupplierName,
    COUNT(DISTINCT p.PurchaseID) AS TotalPurchases,
    SUM(pd.Quantity) AS TotalItems,
    SUM(pd.Quantity * pd.UnitPrice) AS TotalAmount
FROM Suppliers s
LEFT JOIN Purchases p ON s.SupplierID = p.SupplierID
LEFT JOIN PurchaseDetails pd ON p.PurchaseID = pd.PurchaseID
GROUP BY s.SupplierID, s.SupplierName;

Go
CREATE VIEW vw_CategoryComponentCount AS
SELECT 
    cat.CategoryID,
    cat.CategoryName,
    COUNT(c.ComponentID) AS ComponentCount
FROM Categories cat
LEFT JOIN Components c ON c.CategoryID = cat.CategoryID
GROUP BY cat.CategoryID, cat.CategoryName;

Go
CREATE VIEW vw_RecentPurchases AS
SELECT TOP 5
    p.PurchaseID,
    p.PurchaseDate,
    s.SupplierName,
    p.PurchaseReason
FROM Purchases p
JOIN Suppliers s ON p.SupplierID = s.SupplierID
ORDER BY p.PurchaseDate DESC;
