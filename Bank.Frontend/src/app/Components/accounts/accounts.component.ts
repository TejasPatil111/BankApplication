import { Component, OnInit } from '@angular/core';
import { AccountsService } from '../../Services/accounts.service';
import { AccountDto } from './accountDto';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-accounts',
  standalone: true,
  imports: [CommonModule,],
  templateUrl: './accounts.component.html',
  styleUrls: ['./accounts.component.css',]
})
export class AccountsComponent  implements OnInit{
  ngOnInit(): void {
    this.loadAccounts();
  }
  account:AccountDto[] =[]; 

  constructor(private AccService:AccountsService){}
  loadAccounts(){
    this.AccService.getAllAccounts().subscribe({
      next:(res)=>this.account = res,
      error:(err)=>console.error(err)
    });
  }
}
