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
CREATE FUNCTION GetLastPurchaseDate (@SupplierID INT)
RETURNS DATE
AS
BEGIN
    DECLARE @LastDate DATE;

    SELECT @LastDate = MAX(PurchaseDate)
    FROM Purchases
    WHERE SupplierID = @SupplierID;

    RETURN @LastDate;
END;
