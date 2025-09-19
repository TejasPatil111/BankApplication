import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AccountDto } from '../Components/accounts/accountDto';
import { apiurl } from '../Constatnt/Constants';
import { Observable } from 'rxjs';

// const apiUrl= 'https://localhost:7210/api';
@Injectable({
  providedIn: 'root'
})

export class AccountsService {
  constructor(private http:HttpClient) { }
  
  getAccSr():Observable<any>{
    return this.http.get(`${apiurl}/Account/with-customers`);
  }

  addAcount(dto:AccountDto):Observable<AccountDto>{
    return this.http.post<AccountDto>( `${apiurl}`,dto);
  }

  updateAccount(id:number, dto:AccountDto):Observable<AccountDto>{
    return this.http.put<AccountDto>(`${apiurl}/Update/${id}`,dto);
  }
  
}
