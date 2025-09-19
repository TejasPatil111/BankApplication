import { Component,NgModule, OnInit } from '@angular/core';
import { AccountsService } from '../../Services/accounts.service';
import { AccountDto, withCustomerDto } from './accountDto';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-accounts',
  standalone: true,
  imports: [CommonModule, FormsModule,],
  templateUrl: './accounts.component.html',
  styleUrls: ['./accounts.component.css',]
})
export class AccountsComponent  implements OnInit{
  ngOnInit(): void {
    this.loadAccounts();
  }

  // account:AccountDto[] =[];

  isEditMode = false;
  withcustomer: withCustomerDto[]=[]; 

  newAccount: AccountDto = this.getEmptyAccount();

  private getEmptyAccount():AccountDto{
    return{
    id: 0,
    customerId: 0,
    accountNo:'',
    accountType: 0,
    status: 1,
    balance: 0,
    currency: 'INR',
    opendOnUtc: new Date(),
    closedOnUtc: new Date(),
    rowVersion: ''
    }
  }

  constructor(private AccService:AccountsService){}
  loadAccounts(){
    this.AccService.getAccSr().subscribe({
      next:(res)=>this.withcustomer = res,
      error:(err)=>console.error(err)
    });
  }
  
  create(){
    this.AccService.addAcount(this.newAccount).subscribe(()=>{
      this.isEditMode=false;
      this.loadAccounts();
      this.newAccount = this.getEmptyAccount();
    })
  }

  editAccount(c: AccountDto) {
      this.isEditMode=true;
      this.newAccount = { ...c };
  }

  saveAccount() {
    if (this.isEditMode) {
      this.AccService.updateAccount(this.newAccount.id, this.newAccount).subscribe(() => {
        this.loadAccounts();
      });
    } else {
      this.AccService.addAcount(this.newAccount).subscribe(()=>{
      this.loadAccounts();
      this.newAccount = this.getEmptyAccount();
      });
    }
  }
}
