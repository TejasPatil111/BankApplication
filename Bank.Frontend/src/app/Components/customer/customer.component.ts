import { Component, NgModule, OnInit } from '@angular/core';
import { CustomerService } from '../../Services/customer.service';
import { CommonModule } from '@angular/common';
import { pipe } from 'rxjs';
import { CustomerDto } from './CustomerDto';
import { FormsModule } from '@angular/forms';
import { LoginService } from '../../Services/login.service';
import { RegisterDto } from '../login/loginDto';

@Component({
  selector: 'app-customer',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.css']
})
export class CustomerComponent implements OnInit {
  //for create new customer
  customer: CustomerDto[] = []; 
  newCustomer: CustomerDto = this.getEmptyCustomer();
  // regCust:RegisterDto[]=[];
  newReg:RegisterDto=this.regEmptyCustomer();
  isEditMode = false;

  constructor(private CusService: CustomerService,
    private LoginService:LoginService
  ) { }

  ngOnInit(): void {
    this.loadCustomers();
  }

  //for update
  private getEmptyCustomer(): CustomerDto {
    return{
    id: 0,
    name: '',
    email: '',
    password: '',
    keyStatus: true,
    status: 1,
    createdOnUtc:new Date()
    };
  }
  private regEmptyCustomer():RegisterDto{
    return{
    id: 0,
    name: '',
    email: '',
    password: '',
    keyStatus: true,
    status: 1,
    createdOnUtc:new Date()
    };
  }
  

  loadCustomers() {
    this.CusService.getAllCustomer().subscribe({
      next: (res) => this.customer = res,
      error: (err) => console.error(err)
    });
  }

  openAddModal() {
    this.isEditMode=false;
    this.newCustomer = this.getEmptyCustomer();
  }

  editCustomer(c: CustomerDto) {
    this.isEditMode=true;
    this.newCustomer = { ...c };
  }

  deleteCustomer(id: number) {
    this.CusService.delete(id).subscribe(() => {
      this.loadCustomers();
    });
  }


  // saveCustomer() {
  //   if (this.isEditMode) {
  //     this.CusService.update(this.newCustomer.id, this.newCustomer).subscribe(() => {
  //       this.loadCustomers();
  //     });
  //   } else {
  //     this.CusService.create(this.newCustomer).subscribe(() => {
  //       this.loadCustomers();
  //       this.newCustomer = this.getEmptyCustomer();
  //     });
  //   }
  // }
  saveCustomer(){
    if(this.isEditMode){
      this.CusService.update(this.newCustomer.id,this.newCustomer).subscribe(()=>{
        this.loadCustomers();
      });

    }
    else{
      debugger;
      this.CusService.create(this.newReg).subscribe(()=>{
        this.loadCustomers();
        
      })
    }
  }
}
