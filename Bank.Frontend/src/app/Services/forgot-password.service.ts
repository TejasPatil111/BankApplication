import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { forgotPasswordDto, resetPasswordDto } from '../Components/forgot-password/forgot-passwordDto';
import { apiurl } from '../Constatnt/Constants';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ForgotPasswordService {

  constructor(private http:HttpClient) { }

  forgotpassword(data:forgotPasswordDto):Observable<any>{
    return this.http.post(`${apiurl}/Auth/forgot-password`,data)
  }
  resetPassword(data:resetPasswordDto):Observable<any>{
  return this.http.post(`${apiurl}/Auth/reset-password`,data)
  }

}
