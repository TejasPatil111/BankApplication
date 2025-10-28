import { Component, NgModule, OnInit } from '@angular/core';
import { AccountsService } from '../../Services/accounts.service';
import { AccountBalanceResponse, AccountDto, CheckBalanceDto, CreateAccountDto, withCustomerDto } from './accountDto';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { CustomerService } from '../../Services/customer.service';

@Component({
  selector: 'app-accounts',
  standalone: true,
  imports: [CommonModule, FormsModule,],
  templateUrl: './accounts.component.html',
  styleUrls: ['./accounts.component.css',]
})
export class AccountsComponent implements OnInit {
  role:string|null=''
  customerId:string|null=''
  pinCode!:string;
  errorMessage='';
  ngOnInit(): void {
    this.role= localStorage.getItem('CustomerRole'),
    this.customerId=localStorage.getItem('CustomerId')
    if(this.role==='Admin'){
      
    this.loadAccounts();
    }
    if(this.role === 'User'){
      this.loadCustomerById(this.customerId);
    }
    this.loadCustomer();

  }

  // account:AccountDto[] =[];

  isEditMode = false;
  withcustomer: withCustomerDto[] = [];
  getAccDto : any[]=[];

  newAccount: CreateAccountDto = this.getEmptyAccount();

  private getEmptyAccount(): CreateAccountDto {
    return {
      id:0,
      customerId:0,
      accountNo: '',
      accountType: 1,
      status: 1 ,
      balance: 0,
      currency: 'INR',
      opendOnUtc: new Date(),
      closedOnUtc: new Date(),
      rowVersion: "AAAAAAAAVfM=",
      customerName: '',
      customerEmail: ''
    }
  }

  constructor(private AccService: AccountsService,
    private custSer:CustomerService
  ) { }
  
  loadAccounts() {
    this.AccService.getAccSr().subscribe({
      next: (res) => this.withcustomer = res,
      error: (err) => console.error(err)
    });
  }
  //getCustomer
  loadCustomer(){
    this.custSer.getAllCustomer().subscribe({
      next:(res)=>this.getAccDto = res,
      error:(err)=> console.error(err)
    });
  }
  loadCustomerById (id:any){
    this.AccService.getAccountByIdSrc(id).subscribe({
      next:(res)=>{
        console.log("Api response",res) ;
        this .withcustomer= Array.isArray(res)? res:[res];
      },
      error:(err)=>console.error(err)
    })
  }
//update and create acc
  editAccount(c: any) {
    this.isEditMode = true;
    this.newAccount = { ...c };
  }

  create() {
    this.AccService.addAcount(this.newAccount).subscribe(() => {
      this.isEditMode = false;
      this.loadAccounts();
      this.newAccount = this.getEmptyAccount();
    })
  }
update(){
  this.AccService.updateAccount(this.newAccount.id,this.newAccount).subscribe(()=>{
    this.isEditMode = false;
    this.loadAccounts();
    this.newAccount= this.getEmptyAccount();
  })
}

 saveAccount() {
  if (this.isEditMode) {
    this.update();
  } else {
    this.create();
  }
}

  DeleteAccount(id:number){
    this.AccService.deleteAccount(id).subscribe(()=>{
      this.loadAccounts();
    });
  }
 
  request:CheckBalanceDto={customerId:0,pinCode:''};
  accountData?:AccountBalanceResponse;
  message:string='';
  isLoading=false;
CheckBalance():void{
  this.isLoading=true;
  this.accountData=undefined;
  this.message='';

if(!this.customerId||!this.pinCode){
this.errorMessage='please enter both customer Id and 4 digit Pin';
return;
}
this.AccService.checkBalanceServie(this.request.customerId,this.request.pinCode).subscribe({
  next:(response)=>{
    this.isLoading = false;
  },error:(error)=>{
    this.message = error.error?.message ?? 'Invalid Customer Id Or Pin Code';
    this.isLoading=false;
  }
})
}
  
}
