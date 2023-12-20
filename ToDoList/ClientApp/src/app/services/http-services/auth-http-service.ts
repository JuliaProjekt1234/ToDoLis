import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { User, UserToAdd } from "src/app/models/user.model";

@Injectable({ providedIn: 'root' })
export class AuthHttpService {
    constructor(private httpClinet: HttpClient) { }

    public registerUser(userToAdd: UserToAdd) {
        return this.httpClinet.post("api/Auth/RegisterUser", userToAdd)
    }

    public login(user: User): Observable<string>{
        return this.httpClinet.post("api/Auth/Login", user) as Observable<string>;
    }
}