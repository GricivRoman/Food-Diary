import { HttpErrorResponse } from "@angular/common/http";
import { Component } from "@angular/core";
import { Router } from "@angular/router";
import { Login } from "../../services/login.servise";
import { Target } from "../../shared/User/Target";
import { User } from "../../shared/User/User";


@Component({
    selector: "user-page",
    templateUrl: "userPage.component.html",
    styles: []
    })
export class UserPage {
    constructor(public loginService:Login, private router:Router) {
    }

    user: User = this.loginService.user;

    target: Target = this.loginService.user.targets.find(f => f.relevance == true) as Target;

    errorMessage: string = "";

    setUserParameters() {
        this.loginService.user = this.user

        this.loginService.updateUser()
            .subscribe(() => {
                this.loginService.getUserWithIdentity()
                    .subscribe(() => {
                        this.router.navigate(["/"]);
                    });
            }, error => {
                console.log(error);
                this.errorMessage = `${(error as HttpErrorResponse).error}`;;
            });

    }
}