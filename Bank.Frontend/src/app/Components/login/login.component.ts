import { Component } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators, ɵInternalFormsSharedModule } from '@angular/forms';
import { LoginService } from '../../Services/login.service';
import { AuthResponse } from './loginDto';
import { Router, RouterOutlet } from '@angular/router';
import { AlertService } from '../../Services/alert.service';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [ɵInternalFormsSharedModule, ReactiveFormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {

  loginForm = new FormGroup({
    email:new FormControl('',[Validators.required, ]),
    password:new FormControl('',[Validators.required,Validators.pattern('^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%^&-+=()])(?=\\S+$).{4,10}$'),])
  })
  constructor(private loginService:LoginService ,
    private route:Router,
    private alert: AlertService,
  ){

  }
loginUser(){
if(this.loginForm.invalid){
  this.loginForm.markAllAsTouched();
  return;
}
else{
  const email =this.loginForm.get('email')?.value;
  const password = this.loginForm.get('password')?.value;
  if(email && password){
    this.loginService.login({email,password}).subscribe({
      next:(response:AuthResponse)=>{
        sessionStorage.setItem('token',response.token);
        this.alert.Toast.fire('/Logged In Successfully','','success')
        this.route.navigate(['/customer']);

      },
      error:(error)=>{
// this.alert.Toast.fire((error.error)?error.error:((error.message)?error.message:'Something went wrong'),'','error');
        console.error(error);
        this.loginForm.reset({
          email:'',
          password:''

        })
      }
    });
  }
}
}


}
