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
  balance:number,
  customerId: number,
  customerName: string,
  customerEmail: string

}
export interface CreateAccountDto {
  id:number;
  accountNo: string;
  accountType: number;
  status: number;
  balance: number;
  currency: string;
  opendOnUtc: Date;
  closedOnUtc: Date;
  rowVersion: string;
  customerName: string;   
  customerEmail: string;  
  customerId:number;
}

export interface updateAccountDto{
id: number,
  customerId: number,
  accountNo: string,
  accountType: number,
  status: number,
  balance: number,
  currency: string, 
   opendOnUtc: Date,
  closedOnUtc: Date,
  rowVersion: string,
  pincode:string

}


export interface CheckBalanceDto {
  customerId: number;
  pinCode: string;
}

export interface AccountBalanceResponse {
  accountId: number;
  accountNo: string;
  customerName: string;
  accountType: number;
  balance: number;
}