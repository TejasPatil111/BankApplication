import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { AuthResponse, Login } from "../Components/login/loginDto";
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

    login(formLogin : Login):Observable<AuthResponse>{
      return this.http.post<AuthResponse>(`${apiurl}/Auth/Login`,formLogin)
    }

    // logOut(){
    //   sessionStorage.clear();
    //   this.route.navigate(['/'])
    //   this.alert.Toast.fire('Logged Out Succesfully','','Success')
    // }
}
