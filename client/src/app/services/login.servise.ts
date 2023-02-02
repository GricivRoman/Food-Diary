import { HttpClient, HttpHeaders} from "@angular/common/http";
import { Injectable } from "@angular/core";
import { map } from "rxjs/operators";
import { CheckInRequest } from "../shared/CheckInRequest";
import { LoginRequest, LoginResults } from "../shared/LoginResults";
import { User } from "../shared/User/User";
import { WeightCondition } from "../shared/User/WeightContition";

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
    logOut() {
        this.token = "";
        this.expiration = new Date();
        this.user = new User();
    }
    getUser(creds: LoginRequest) {
        return this.http.post<User>("api/user/getuser", creds)
            .pipe(map(data => {
                this.user.id = data.id;
                this.user.age = data.age;
                this.user.email = data.email;
                this.user.gender = data.gender;
                this.user.meals = data.meals;
                this.user.name = data.name;
                this.user.targets = data.targets;
                this.user.userMenu = data.userMenu;
                this.user.userName = data.userName;
                this.user.weightConditions = data.weightConditions;                
            }));
    }

    checkIn(checkInCreds: CheckInRequest) {
        return this.http.post("/account/checkin", checkInCreds);
    }

    getUserWithIdentity() { 
        const headers = new HttpHeaders().set("Authorization", `Bearer ${this.token}`);
        return this.http.get<User>("api/user/getUserWithIdentity", { headers: headers })
            .pipe(map(data => {
                this.user.id = data.id;
                this.user.age = data.age;
                this.user.email = data.email;
                this.user.gender = data.gender;
                this.user.meals = data.meals;
                this.user.name = data.name;
                this.user.targets = data.targets;
                this.user.userMenu = data.userMenu;
                this.user.userName = data.userName;
                this.user.weightConditions = data.weightConditions;
            }));
    }

    updateUser() {       

        const headers = new HttpHeaders().set("Authorization", `Bearer ${this.token}`);
        return this.http.post("/api/user/setWeightConditiodn", this.user, {headers:headers});
        
    }

    
}