export interface  AccountDto {

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
export interface withCustomerDto {

  id: number;
  accountNo: string,
  customerId: number,
  customerName: string,
  customerEmail: string

}