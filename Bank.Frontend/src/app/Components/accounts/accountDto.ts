export interface AccountDto
 {
  id: number,
  customerId: number,
  accountNo: string,
  accountType: number,
  status: number,
  balance: number,
  currency: string,
  opendOnUtc: Date,
  closedOnUtc: Date,
  rowVersion: string
}