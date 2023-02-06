import { HttpErrorResponse } from "@angular/common/http";
import { Component } from "@angular/core";
import { Router } from "@angular/router";
import { Login } from "../../../services/login.servise";
import { CheckInRequest } from "../../../shared/Account/CheckInRequest";
import { LoginRequest } from "../../../shared/Account/LoginResults";


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

        const loginCreds: LoginRequest = {
            username: this.checkInCreds.username,
            password: this.checkInCreds.password
        }
        
        this.loginService.checkIn(this.checkInCreds)
            .subscribe(() => {
                this.loginService.login(loginCreds)
                    .subscribe(() => {
                        this.loginService.getUserWithIdentity()
                            .subscribe(() => {
                                this.router.navigate([""])
                                })
                    });

            }, error => {
                console.log(error);
                this.errorMessage = `${(error as HttpErrorResponse).error}`;
            });
    }
}