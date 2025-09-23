export interface TransactionDto {
    id: number,
    amount: number,
    currency: number,
    status: number,
    initiatedOnUtc:Date,
    completedOnUtc: Date,
    refrence: string,
    toAccountId: 1,
    fromAccountId: 2


}