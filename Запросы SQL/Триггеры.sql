Use ComputerCompanyDB;

Go
CREATE TRIGGER SetUnitPrice----
ON PurchaseDetails
AFTER INSERT
AS
BEGIN
    UPDATE pd
    SET pd.UnitPrice = c.Price  
    FROM PurchaseDetails pd
    JOIN inserted i ON pd.PurchaseID = i.PurchaseID AND pd.ComponentID = i.ComponentID
    JOIN Components c ON i.ComponentID = c.ComponentID;
END;

GO
CREATE TRIGGER PreventNegativeComponentPrice
ON Components
AFTER UPDATE
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM inserted
        WHERE Price < 0
    )
    BEGIN
        RAISERROR ('Цена компонента не может быть отрицательной.', 16, 1);
        ROLLBACK TRANSACTION;
    END
END;

GO
CREATE TRIGGER CheckSupplierBeforeInsert
ON Purchases
INSTEAD OF INSERT
AS
BEGIN
    IF NOT EXISTS (
		SELECT 1 FROM Suppliers 
		WHERE SupplierID IN (SELECT SupplierID FROM inserted)
	)
    BEGIN
        -- Если поставщик не найден, выводим ошибку
        RAISERROR('Поставщик с данным ID не существует!', 16, 1);
    END
    ELSE
    BEGIN
        -- Если поставщик существует, выполняем вставку
        INSERT INTO Purchases (SupplierID, PurchaseDate, PurchaseReason)
        SELECT SupplierID, PurchaseDate, PurchaseReason FROM inserted;
    END
END;

