import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { postTransactionDto, ReverseTransactionRequest, ReverseTransactionResponse,  TransactionDto } from './TransactionsDto';
import { TransactionService } from '../../Services/transaction.service';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AccountsService } from '../../Services/accounts.service';
import { AccountDto } from '../accounts/accountDto';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-transaction',
  standalone: true,
  imports: [CommonModule,FormsModule,ReactiveFormsModule,RouterModule ],
  templateUrl: './transaction.component.html',
  styleUrl: './transaction.component.css'
})
export class TransactionComponent  implements OnInit{
[x: string]: any;
  role:string|null ='';
  customerId:string|null='';
  loggedInCustomerId! :number;

  ngOnInit(): void {
    this.role = localStorage.getItem('CustomerRole')
    this.customerId=localStorage.getItem('CustomerId')
    this.loggedInCustomerId =Number(localStorage.getItem('CustomerId'));
    
    if(this.role ==='Admin'){
    this.getAllTransaction();
    }
    if(this.role ==='User'){
      this.getTransactionByCustId(this.customerId);
    }
    this.getAccount();
  }
  isEditMode:Boolean=false;

  transfer :postTransactionDto = new postTransactionDto();

  constructor(private TransferService : TransactionService,
              private AccountService : AccountsService,
  ){}

  //to get al transfer
Transfers :any;
//to get all acount
getAccountsDto: any[] =[];
getAccount(){
  this.AccountService.getAccSr().subscribe({
    next:(res)=>{
      this.getAccountsDto= res;
      //Find logged-in User in FrmAcc
      const myAccount = this.getAccountsDto.find((a)=>a.customerId === this.loggedInCustomerId);
      if(myAccount){
        this.transfer.fromAccountId=myAccount.id;
      }else{
        console.warn('No Account Found For Loggd In Customeer');
      }
    },
    error:(err) => console.error(err)
  })
}

getAllTransaction(){
this.TransferService.getTransaction().subscribe({
  next:(res) => this.Transfers = res,
  error:(err)=> console.error(err)
})
}

getTransactionByCustId(id:any){
  this.TransferService.gettransactionByCustomerId(id).subscribe({
    next:(res)=>{
      console.log("Api Response",res)
      this.Transfers =Array.isArray(res)? res:[res];
    },
    error:(err)=>console.error(err)
  })
}

SendMoney(){
  console.log('Trnasfer Request:',this.transfer)
  if(!this.transfer.fromAccountId || !this.transfer.toAccountId || !this.transfer.amount || !this.transfer.currency||this.transfer.refrence)
  this.TransferService.postTransaction(this.transfer).subscribe({
  next : (res:any)=>{
  alert(res.message);
  console.log(res)
  this.getTransactionByCustId(this.customerId);
},
error:(err)=>{
  console.error(err);
  alert(err.error?.message ||'Transaction Failed');
}
  });
}

isLoading=false;
request : ReverseTransactionRequest= {transactionId: 0, reference: ''};
response?:ReverseTransactionResponse;
revrseTransaction(){
  
  if(!this.request.transactionId ){
  this.response ={success:false, message:'Please Enter Valid Transaction Id'}
return;
}
this.isLoading=true;
this.response=undefined;
this.TransferService.revrseTransaction(this.request).subscribe({
  next:(res)=>{
    this.response=res;
    this.isLoading= false;
    this.getAllTransaction();

  },
   error: (err) => {
        this.response = {
          success: false,
          message: err.error?.message || 'An error occurred while reversing the transaction.'
        };
        alert("Cannot reverse A Cancelled Or Failed Transaction:")
        this.isLoading = false;
      }
});
}

deleteTransaction(id: number) {
  this.TransferService.Delete(id).subscribe({
    next: () => {
      this.getAllTransaction(); // refresh table
      alert('Transaction  deleted successfully.');
    },
    error: (err) => {
      console.error(err);
      alert('Failed to delete transaction. First Delete Reverse Transaction');
    }
  });
}

}
