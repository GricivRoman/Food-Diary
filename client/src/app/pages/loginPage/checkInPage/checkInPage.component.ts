import { HttpErrorResponse } from "@angular/common/http";
import { Component } from "@angular/core";
import { Router } from "@angular/router";
import { UserService } from "../../../services/user.servise";
import { CheckInRequest } from "../../../shared/Account/CheckInRequest";
import { LoginRequest } from "../../../shared/Account/LoginResults";

@Component({
    selector: "check-in",
    templateUrl: "checkInPage.component.html"
    })
export class CheckInPage {
    constructor(private userService:UserService,private router: Router) {

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
        
        this.userService.checkIn(this.checkInCreds)
            .subscribe(() => {
                this.userService.login(loginCreds)
                    .subscribe(() => {
                        this.userService.getUserWithIdentity()
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