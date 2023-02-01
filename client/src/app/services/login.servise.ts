import { HttpClient} from "@angular/common/http";
import { Injectable } from "@angular/core";
import { map } from "rxjs/operators";
import { CheckInRequest } from "../shared/CheckInRequest";
import { LoginRequest, LoginResults } from "../shared/LoginResults";
import { User } from "../shared/User/User";

@Injectable()

export class Login {

    constructor(private http: HttpClient) {

    }
       
    public token = "";
    public expiration = new Date();

    public user: User = new User();

    
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
    getUser(creds: LoginRequest) {
        return this.http.post<User>("/account/getuser", creds)
            .pipe(map(data => {
                this.user = data;
            }));
    }

    checkIn(checkInCreds: CheckInRequest) {
        return this.http.post("/account/checkin", checkInCreds);
    }

    
}