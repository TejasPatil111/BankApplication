import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { ForgotPasswordService } from '../../Services/forgot-password.service';
import { forgotPasswordDto, resetPasswordDto } from './forgot-passwordDto';

@Component({
  selector: 'app-forgot-password',
  standalone: true,
  imports: [FormsModule,CommonModule,],
  templateUrl: './forgot-password.component.html',
  styleUrl: './forgot-password.component.css'
})
export class ForgotPasswordComponent {
  constructor(private route :Router,
    private forgotPassSrc: ForgotPasswordService
  ){}
step:number=1;
isOtpVissible = false;
isLoading=false;
login(){   
this.route.navigateByUrl('/');
  }


  ForgotPassObj: forgotPasswordDto ={
    email:''
  }
    forgotpass(){
    this.isLoading=true;
    this.forgotPassSrc.forgotpassword(this.ForgotPassObj).subscribe({
      next:() =>{
      alert("Otp Has Been Sent To Your Email");
      this.ResetPassObj.email = this.ForgotPassObj.email
      this.step=2;
      this.isOtpVissible=true;
      this.isLoading=false;
    },error:(err)=>{
      console.error('Error while Sending Otp:', err)
      this.isLoading=false;
    }
  });
  }
  
ResetPassObj:resetPasswordDto={
email:'',
otpCode:'',
newPassword:'',

}
  resetPassword(){
    this.isLoading=true;
    this.forgotPassSrc.resetPassword(this.ResetPassObj).subscribe(()=>{
      alert ("password Reset Succesfully");
      this.route.navigateByUrl('')
      this.isLoading=false
    })
  }
}
