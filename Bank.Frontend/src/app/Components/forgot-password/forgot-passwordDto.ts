export interface forgotPasswordDto{
email: string;
}

export interface resetPasswordDto{
    email: string ;
    otpCode: string;
    newPassword:string;
    
}