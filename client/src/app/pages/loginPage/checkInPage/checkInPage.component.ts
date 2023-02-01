import { HttpErrorResponse } from "@angular/common/http";
import { Component } from "@angular/core";
import { Router } from "@angular/router";
import { Login } from "../../../services/login.servise";
import { CheckInRequest } from "../../../shared/CheckInRequest";
import { LoginRequest } from "../../../shared/LoginResults";


@Component({
    selector: "check-in",
    templateUrl: "checkInPage.component.html"
    })
export class CheckInPage {
    constructor(private loginService:Login,private router: Router) {

    }
    public checkInCreds: CheckInRequest =  {
        username: "",
        email: "",
        password: ""
    }

    

    public errorMessage: string = "";

    onCheckIn() {
        
        this.loginService.checkIn(this.checkInCreds)
            .subscribe(() => {

                const loginCreds: LoginRequest = {
                    username: this.checkInCreds.username,
                    password: this.checkInCreds.password
                }
                
                this.loginService.login(loginCreds)
                    .subscribe(() => {
                        this.router.navigate([""])
                    });
                                                
            }, error => {
                console.log(error);
                this.errorMessage = `${(error as HttpErrorResponse).error}`;
            })
    }
}