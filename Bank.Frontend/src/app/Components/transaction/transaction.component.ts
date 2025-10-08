import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { postTransactionDto, ReverseTransactionRequest, ReverseTransactionResponse,  TransactionDto } from './TransactionsDto';
import { TransactionService } from '../../Services/transaction.service';
import { FormsModule } from '@angular/forms';
import { AccountsService } from '../../Services/accounts.service';
import { AccountDto } from '../accounts/accountDto';

@Component({
  selector: 'app-transaction',
  standalone: true,
  imports: [CommonModule,FormsModule,],
  templateUrl: './transaction.component.html',
  styleUrl: './transaction.component.css'
})
export class TransactionComponent  implements OnInit{
  ngOnInit(): void {
    this.getAllTransaction();
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

SendMoney(){
  
  if(!this.transfer.fromAccountId || !this.transfer.toAccountId || !this.transfer.amount || !this.transfer.currency||this.transfer.refrence)
  this.TransferService.postTransaction(this.transfer).subscribe({
  next : (res:any)=>{
  alert(res.message);
  console.log(res)
  this.getAllTransaction();
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

  },
   error: (err) => {
        this.response = {
          success: false,
          message: err.error?.message || 'An error occurred while reversing the transaction.'
        };
        this.isLoading = false;
      }
});
}
}



