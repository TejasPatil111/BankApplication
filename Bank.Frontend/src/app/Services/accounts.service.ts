import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AccountDto } from '../Components/accounts/accountDto';
//import { apiurl } from '../Constatnt/Constants';
import { Observable } from 'rxjs';

const apiUrl= 'https://localhost:7210/api/Account';
@Injectable({
  providedIn: 'root'
})
export class AccountsService {
  constructor(private http:HttpClient) { }
  
  getAllAccounts():Observable<any>{
    return this.http.get(`${apiUrl}`);
  }
}
