import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { apiurl } from '../Constatnt/Constants';
import { postTransactionDto } from '../Components/transaction/TransactionsDto';

@Injectable({
  providedIn: 'root'
})
export class TransactionService {

  constructor(private http : HttpClient) { }
  

  getTransaction():Observable<any>{
    return this.http.get(`${apiurl}/Transaction/GetAccountNoWithTransaction`);
  }

  postTransaction(dto:postTransactionDto):Observable<any>{
    return this.http.post(`${apiurl}/Transaction`,dto)
  }

}
