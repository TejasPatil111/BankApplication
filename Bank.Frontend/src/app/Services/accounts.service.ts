import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AccountDto, CreateAccountDto } from '../Components/accounts/accountDto';
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

  addAcount(dto:CreateAccountDto):Observable<CreateAccountDto>{
    return this.http.post<CreateAccountDto>( `${apiurl}/Account`,dto);
  }

  updateAccount(id:number, dto:CreateAccountDto):Observable<CreateAccountDto>{
    return this.http.put<CreateAccountDto>(`${apiurl}/Account/${id}`,dto);
  }
  deleteAccount(id:number):Observable<void>{
    return this.http.delete<void>(`${apiurl}/Account/${id}`);
  }
}
