import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { map } from "rxjs/operators";
import { LoginRequest, LoginResults } from "../shared/LoginResults";

@Injectable()

export class Login {

    constructor(private http: HttpClient) {

    }
       
    public token = "";
    public expiration = new Date();

    
    get loginRequired(): boolean {
        return this.token.length === 0 || this.expiration > new Date();
    }

    login(creds: LoginRequest) {
        return this.http.post<LoginResults>("/account/createtoken", creds)
            .pipe(map(data => {
                this.token = data.token;
                this.expiration = data.expiration;
            }));
    }
    
}