import { Component } from "@angular/core";
import { RegisterDto } from "./loginDto";
import { FormsModule } from "@angular/forms";
import { CommonModule } from "@angular/common";
import { HttpBackend, HttpClient } from "@angular/common/http";


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
  }
  constructor(private http: HttpClient){

  }

  regObj : RegisterDto = new RegisterDto()

onRegister(){

}  

}
