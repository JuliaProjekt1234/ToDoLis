import { Component } from '@angular/core';
import { NavigationEnd, Router } from '@angular/router';
import { AuthService } from './services/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
})
export class AppComponent {
  title = 'ToDoList';
  showLogOutButton: boolean = false;

  constructor(
    private router: Router,
    private authService: AuthService
  ) {
    this.router.events.subscribe((event) => {
      if (event instanceof NavigationEnd) {
        const currentURL = event.url;
        this.showLogOutButton = currentURL !== "/login" && currentURL != "/registration";
      }
    });
  }

  logout() {
    this.authService.clearAuthToken();
    this.router.navigate(["/login"]);
  }
}
