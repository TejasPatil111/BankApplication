import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CustomerDto } from '../Components/customer/CustomerDto';

const API_URL = 'https://localhost:7210/api/Customer'; 
@Injectable({
  providedIn: 'root'
})
export class CustomerService {
  // Customer: CustomerDto[] = []
constructor(private http:HttpClient){}

//service for get Customer
getAllCustomer(): Observable<any>{
  return this.http.get(`${API_URL}`);
}

create(fromData:CustomerDto): Observable<CustomerDto>{
return  this.http.post<CustomerDto>(`${API_URL} `,fromData);
}

update(id:number,fromData: CustomerDto): Observable<void>{
  return this.http.put<void>(`${API_URL}/Update/${id}`,fromData);
}

delete(id : number):Observable<void>{
 return this.http.delete<void>( `${API_URL}/${id}`);
}

}
