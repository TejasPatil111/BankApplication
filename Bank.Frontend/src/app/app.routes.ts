import { Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { CustomerComponent } from './Components/customer/customer.component';
import { AccountsComponent } from './Components/accounts/accounts.component';

export const routes: Routes = [
    {path: 'customer' ,component:CustomerComponent },
    {path: 'account' ,component:AccountsComponent },
];
