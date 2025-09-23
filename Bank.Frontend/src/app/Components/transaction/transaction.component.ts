import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { TransactionDto } from './TransactionsDto';
import { TransactionService } from '../../Services/transaction.service';

@Component({
  selector: 'app-transaction',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './transaction.component.html',
  styleUrl: './transaction.component.css'
})
export class TransactionComponent  implements OnInit{
  ngOnInit(): void {
    this.getAllTransaction();
  }
  constructor(private TransferService : TransactionService){}
Transfers :any; 

getAllTransaction(){
this.TransferService.getTransaction().subscribe({
  next:(res) => this.Transfers = res,
  error:(err)=> console.error(err)
})
}

}
