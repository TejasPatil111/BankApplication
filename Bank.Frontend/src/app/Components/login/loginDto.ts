export class Login {
    email: string;
    password: string;
    constructor() {
        this.email = '';
        this.password = '';
    }
}

export interface AuthResponse {
    token: string;
}
export class RegisterDto {

    id: number;
    name: string;
    email: string;
    password: string;
    role:string;
    keyStatus: boolean;
    status: number;
    createdOnUtc: Date;
    otpCode:string;
    otpExpiry:Date;

    constructor() {
        this.id = 0;
        this.name = '';
        this.email = '';
        this.password = '';
        this.role='';
        this.keyStatus = true;
        this.status = 1;
        this.createdOnUtc = new Date();
        this.otpCode='';
        this.otpExpiry=new Date();


    }
}

