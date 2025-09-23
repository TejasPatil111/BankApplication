alter procedure [dbo].[GetAccountNoWithTransaction]
as begin
select
a.AccountNo,
a.AccountType,
a.Balance,
t.ToAccountId as ToAccountNo
--a.AccountNo as ToAccount

from Transfers t
left join Accounts a on t.ToAccountId = a.Id

end

exec [dbo].[GetAccountNoWithTransaction]

CREATE PROCEDURE SP_SendMoney
    @FromAccountId INT,
    @ToAccountId INT,
    @Amount DECIMAL(18,2),
    @Currency NVARCHAR(10),
    @Reference NVARCHAR(100) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;

        DECLARE @FromBalance DECIMAL(18,2);

        -- 1. Check sender balance
        SELECT @FromBalance = Balance
        FROM Accounts
        WHERE Id = @FromAccountId;

        IF @FromBalance IS NULL
        BEGIN
            RAISERROR('Sender account not found', 16, 1);
            ROLLBACK TRANSACTION;
            RETURN;
        END

        IF @FromBalance < @Amount
        BEGIN
            RAISERROR('Insufficient balance', 16, 1);
            ROLLBACK TRANSACTION;
            RETURN;
        END

        -- 2. Deduct from sender
        UPDATE Accounts
        SET Balance = Balance - @Amount
        WHERE Id = @FromAccountId;

        -- 3. Add to receiver
        UPDATE Accounts
        SET Balance = Balance + @Amount
        WHERE Id = @ToAccountId;

        -- 4. Insert into Transfers
        INSERT INTO Transfers
        (Amount, Currency, Status, InitiatedOnUtc, CompletedOnUtc, Refrence, FromAccountId, ToAccountId)
        VALUES
        (@Amount, @Currency, 1, GETUTCDATE(), GETUTCDATE(), @Reference, @FromAccountId, @ToAccountId);

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END


select * from Accounts;
select * from Transfers;
select * from Customers;

EXEC SP_SendMoney 
    @FromAccountId = 1,
    @ToAccountId = 2,
    @Amount = 2345,
    @Currency = 'INR',
    @Reference = 'Transfer-001';


	select t.Amount as Amount,
	(select AccountNo from Accounts where id=t.FromAccountId) as fromAC,
	(select AccountNo from Accounts where id=t.ToAccountId) as ToAC
	from Transfers t
	where t.FromAccountId=1;