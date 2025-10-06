export interface TransactionDto {
    id: number,
    amount: number,
    currency: number,
    status: number,
    initiatedOnUtc: Date,
    completedOnUtc: Date,
    refrence: string,
    toAccountId: number,
    fromAccountId: number
}
export class postTransactionDto {
    fromAccountId: number = 0;
    toAccountId: number = 0;
    amount: number = 0;
    currency?: string;
    refrence?: string;
}