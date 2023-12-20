import { Injectable } from "@angular/core";
import { User } from "src/app/models/user.model";
import { AuthHttpService } from "./http-services/auth-http-service";
import { Router } from "@angular/router";

@Injectable({ providedIn: 'root' })
export class AuthService {
    public get token() { return localStorage.getItem('token'); }

    constructor(
        private router: Router,
        private authHttpService: AuthHttpService
    ) { }

    public login(user: User) {
        this.authHttpService.login(user).subscribe((token: string) => {
            this.setToken(token);
            this.router.navigate(['/']);
        });
    }

    setToken(token: string) {
        localStorage.setItem('token', token);
    }

    clearAuthToken(): void {
        localStorage.removeItem("token");
    }
}