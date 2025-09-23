CREATE OR ALTER PROCEDURE GetAccountsWithCustomers
AS
BEGIN
    SELECT 
        a.Id, 
        a.AccountNo, 
        c.Id AS CustomerId,
        c.Name AS CustomerName, 
        c.Email AS CustomerEmail
        -- Add other Customer columns as needed
    FROM Accounts a
    INNER JOIN Customers c ON a.CustomerId = c.Id;
END
