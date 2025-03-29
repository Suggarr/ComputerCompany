Use ComputerCompanyDB;

Go
CREATE TRIGGER SetUnitPrice
ON PurchaseDetails
AFTER INSERT
AS
BEGIN
    UPDATE pd
    SET pd.UnitPrice = c.Price --* i.Quantity  
    FROM PurchaseDetails pd
    JOIN inserted i ON pd.PurchaseID = i.PurchaseID AND pd.ComponentID = i.ComponentID
    JOIN Components c ON i.ComponentID = c.ComponentID;
END;

Go
CREATE TRIGGER UpdatePurchaseDateOnDetailChange
ON PurchaseDetails
AFTER UPDATE
AS
BEGIN
    UPDATE p
    SET p.PurchaseDate = GETDATE()
    FROM Purchases p
    JOIN inserted i ON p.PurchaseID = i.PurchaseID;
END;

Go
CREATE TRIGGER CheckCustomerExists
ON Purchases
INSTEAD OF INSERT
AS
BEGIN
    IF NOT EXISTS (
        SELECT 1 FROM Customers 
        WHERE CustomerID IN (SELECT CustomerID FROM inserted)
    )
    BEGIN
        RAISERROR('Клиент не найден.', 16, 1);
        ROLLBACK TRANSACTION;
    END
    ELSE
    BEGIN
        INSERT INTO Purchases (SupplierID, CustomerID, PurchaseDate)
        SELECT SupplierID, CustomerID, PurchaseDate FROM inserted;
    END
END;
