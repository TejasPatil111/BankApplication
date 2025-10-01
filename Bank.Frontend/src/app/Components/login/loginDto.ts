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
    keyStatus: boolean;
    status: number;
    createdOnUtc: Date;

    constructor() {
        this.id = 0;
        this.name = '';
        this.email = '';
        this.password = '';
        this.keyStatus = true;
        this.status = 1;
        this.createdOnUtc = new Date();


    }
}

