import { Component, OnInit } from '@angular/core';
import { CustomerService } from '../../Services/customer.service';
import { CommonModule } from '@angular/common';
import { pipe } from 'rxjs';
import { CustomerDto } from '../../Services/CustomerDto';

@Component({
  selector: 'app-customer',
  standalone: true,
  imports: [CommonModule, ],
  templateUrl: './customer.component.html',
  styleUrl: './customer.component.css'
})
export class CustomerComponent implements OnInit   {
   fromData :CustomerDto[]=[];
   newCustomer: CustomerDto={id:0, Name:'',Email:'',Password:'',KeyStatus:true,Status:1,CreatedOnUtc:new Date()};
customers : any;

constructor(private CusService:CustomerService){}

ngOnInit(): void {
  this.loadCustomers();
}

loadCustomers(){
this.CusService.getAllCustomer().subscribe({
  next: (res) => this.customers = res,
  error: (err)=>console.error(err)
});
}

addCustomer(){
  this.CusService.create(this.newCustomer).subscribe(()=>{
    this.loadCustomers();
    this.newCustomer ={id:0, Name:'',Email:'',Password:'',KeyStatus:true,Status:1,CreatedOnUtc:new Date()};
  })
}

updateCustomer(customer: CustomerDto){
  this.CusService.update(customer.id, customer).subscribe(()=>{
    this.loadCustomers();
  })
}
 deleteCustomer(id: number) {
  debugger
    this.CusService.delete(id).subscribe(() => {
      this.loadCustomers();
    });
  }
}
