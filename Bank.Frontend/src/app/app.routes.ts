import { Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { CustomerComponent } from './Components/customer/customer.component';
import { AccountsComponent } from './Components/accounts/accounts.component';
import { TransactionComponent } from './Components/transaction/transaction.component';
import { LoginComponent } from './Components/login/login.component';
import { HomeComponent } from './Components/home/home.component';
import { ForgotPasswordComponent } from './Components/forgot-password/forgot-password.component';

export const routes: Routes = [
     // Default route → login
     { path: '', redirectTo: '/login', pathMatch: 'full' },
     
     // Login
     { path: 'login', component: LoginComponent },
     {path:'forgotPassword',component:ForgotPasswordComponent},

  // Parent (Home) with children
  {
    path: '',
    component: HomeComponent,
    children: [
      { path: 'customer', component: CustomerComponent },
      { path: 'account', component: AccountsComponent },
      { path: 'transfer', component: TransactionComponent }
    ]
  },

  // Wildcard (optional: catch unknown paths)
  { path: '**', redirectTo: '/login' }
];

