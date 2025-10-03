import { Component, inject, Inject } from "@angular/core";
import { Login, RegisterDto } from "./loginDto";
import { FormsModule } from "@angular/forms";
import { CommonModule, JsonPipe } from "@angular/common";
import { HttpBackend, HttpClient } from "@angular/common/http";
import { LoginService } from "../../Services/login.service";
import { Route, Router, RouterOutlet } from "@angular/router";
import { jwtDecode } from "jwt-decode";


@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule,CommonModule,],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  //logic for toogle from login to reg & vv
  showRegisterForm:boolean=false;
  ToggleForm(){
    this.showRegisterForm=!this.showRegisterForm;
      this.LoginObj = { email: '', password: '' };
       this.regObj = new RegisterDto();
  }
  constructor(private http: HttpClient,
  private loginService : LoginService,
private router:Router){}

  // register data
regObj : RegisterDto = new RegisterDto();  
// Login Dto
onRegister(){
  console.log("Sending Register Payload: ", this.regObj);
this.loginService.userRegister(this.regObj).subscribe({
  next:(res:any)=>{
    alert(res.message)
},
error:(error)=>{
  console.log("Error Response",error);
  alert(JSON.stringify(error.error));
}

} ); 
}

LoginObj : Login = new Login();
UserLogin(){
  this.loginService.login(this.LoginObj).subscribe({
    next:(res)=>{
      // console.log(res);
      alert("Login Successfully");
      //save token
      localStorage.setItem("Jwt Token", res.jwtToken);
    //decodetoken
      const decoded :any=jwtDecode(res.jwtToken) ;
      localStorage.setItem("email",decoded["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress"]); 
      localStorage.setItem("customerId", decoded.CustomerId); 
      this.router.navigateByUrl('/customer');
    },
    error:(error)=>{
      console.log(error);
      alert(JSON.stringify(error.error));
    }
    
  })
}
LogOut(){
this.loginService.logOut();
alert("Logged Out Successfully");
this.router.navigateByUrl('');
// localStorage.clear();
}
}