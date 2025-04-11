Use ComputerCompanyDB;

Go
CREATE FUNCTION GetComponentName (@ComponentID INT)
RETURNS NVARCHAR(100)
AS
BEGIN
    DECLARE @ComponentName NVARCHAR(100);

    SELECT @ComponentName = ComponentName
    FROM Components
    WHERE ComponentID = @ComponentID;

    RETURN @ComponentName;
END;



Go
CREATE FUNCTION GetCheapestComponent()
RETURNS INT
AS
BEGIN
    DECLARE @ComponentID INT;
    
    SELECT TOP 1 @ComponentID = ComponentID
    FROM Components
    ORDER BY Price ASC
    
    RETURN @ComponentID
END

GO
CREATE FUNCTION GetLastPurchaseDate (@SupplierID INT)--Возвращает дату последней закупки у конкретного поставщика.
RETURNS DATE
AS
BEGIN
    DECLARE @LastDate DATE;

    SELECT @LastDate = MAX(PurchaseDate)
    FROM Purchases
    WHERE SupplierID = @SupplierID;

    RETURN @LastDate;
END;

Go
CREATE FUNCTION dbo.GetPurchaseTotalCost (@PurchaseID INT) --Получение полной стоимости конкретной закупки
RETURNS DECIMAL(10, 2)
AS
BEGIN
    DECLARE @TotalCost DECIMAL(10, 2)

    SELECT @TotalCost = SUM(UnitPrice * Quantity)
    FROM PurchaseDetails
    WHERE PurchaseID = @PurchaseID

    RETURN ISNULL(@TotalCost, 0)
END

Go
CREATE FUNCTION dbo.GetSupplierPurchaseCount (@SupplierID INT) --Получение количества закупок у конкретного поставщика
RETURNS INT
AS
BEGIN
    DECLARE @Count INT

    SELECT @Count = COUNT(*)
    FROM Purchases
    WHERE SupplierID = @SupplierID

    RETURN @Count
END

Go
CREATE FUNCTION dbo.GetSupplierName (@SupplierID INT) --Получение полного наименования поставщика по его ID
RETURNS NVARCHAR(100)
AS
BEGIN
    DECLARE @Name NVARCHAR(100)

    SELECT @Name = SupplierName
    FROM Suppliers
    WHERE SupplierID = @SupplierID

    RETURN ISNULL(@Name, 'Неизвестный поставщик')
END

