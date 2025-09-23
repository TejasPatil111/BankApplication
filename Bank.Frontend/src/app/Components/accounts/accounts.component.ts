import { Component, NgModule, OnInit } from '@angular/core';
import { AccountsService } from '../../Services/accounts.service';
import { AccountDto, CreateAccountDto, withCustomerDto } from './accountDto';
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
  ngOnInit(): void {
    this.loadAccounts();
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
 
}
