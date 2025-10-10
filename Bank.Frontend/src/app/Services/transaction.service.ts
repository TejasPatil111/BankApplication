import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { apiurl } from '../Constatnt/Constants';
import { postTransactionDto, ReverseTransactionRequest, ReverseTransactionResponse, } from '../Components/transaction/TransactionsDto';

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
  revrseTransaction(dto:ReverseTransactionRequest):Observable<ReverseTransactionResponse>{
    return this.http.post<ReverseTransactionResponse>(`${apiurl}/Transaction/reverse`, dto)
  }

  Delete(id:number):Observable<any>{
    return this.http.delete(`${apiurl}/Transaction/${id}`);
  } 
}
