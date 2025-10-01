import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { AuthResponse, Login, RegisterDto } from "../Components/login/loginDto";
import { Observable } from "rxjs";
import { apiurl } from "../Constatnt/Constants";
import { Router, RouterOutlet } from "@angular/router";
import { Token } from "@angular/compiler";

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor(private http:HttpClient,
    private route:Router
  ) {}
    userRegister(data : RegisterDto):Observable<any>{
      return this.http.post<any>(`${apiurl}/Auth/Register`, data)
    }

    login(data: Login):Observable<any>{
      return this.http.post<{jwtToken:string}>(`${apiurl}/Auth/Login`,data)
    }

    logOut(){
      localStorage.removeItem("Jwt Token");
      localStorage.clear()
    }
    //to check logged in or not 
    isLogedIn():boolean{
      return !!localStorage.getItem("Jwt Token")
    }
}
