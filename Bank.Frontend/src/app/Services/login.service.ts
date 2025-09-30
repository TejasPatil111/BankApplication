import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { AuthResponse, Login, RegisterDto } from "../Components/login/loginDto";
import { Observable } from "rxjs";
import { apiurl } from "../Constatnt/Constants";
import { Router, RouterOutlet } from "@angular/router";

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor(private http:HttpClient,
    private route:Router
  ) {}
    userRegister(data : Login){
      return this.http.post(`${apiurl}/Auth/Register`,data)
    }
}
