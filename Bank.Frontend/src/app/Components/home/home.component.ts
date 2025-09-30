import { Component, inject } from '@angular/core';
import { Router, RouterModule, RouterOutlet } from "@angular/router";

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [RouterOutlet,RouterModule],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {
route=inject(Router)
  Logout(){
    localStorage.clear();
    this.route.navigateByUrl('');
  }
}
