import { HttpClient, HttpHeaders} from "@angular/common/http";
import { Injectable } from "@angular/core";
import { map } from "rxjs/operators";
import { CheckInRequest } from "../shared/Account/CheckInRequest";
import { LoginRequest, LoginResults } from "../shared/Account/LoginResults";
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
                this.user.sex = data.sex;
                this.user.physicalActivity = data.physicalActivity;
                this.user.height = data.height;
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
                this.user.sex = data.sex;
                this.user.physicalActivity = data.physicalActivity;
                this.user.height = data.height;
            }));
    }

    updateUser() {       

        const headers = new HttpHeaders().set("Authorization", `Bearer ${this.token}`);
        return this.http.post("/api/user/updateUser", this.user, {headers:headers});
        
    }

    
}