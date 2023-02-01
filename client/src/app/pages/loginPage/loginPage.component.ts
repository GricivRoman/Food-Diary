import { Component } from "@angular/core";
import { Router } from "@angular/router";
import { Login } from "../../services/login.servise";
import { LoginRequest } from "../../shared/LoginResults";

@Component({
    selector: "login-page",
    templateUrl: "loginPage.component.html",
    styleUrls: []
})

export class LoginPage {
    constructor(private loginService: Login, private router: Router) {

    }
    public creds: LoginRequest = {
        username: "",
        password: ""
    };

    public errorMessage: string = "";

    onLogin() {
        this.loginService.login(this.creds)
            .subscribe(() => {
                this.loginService.getUser(this.creds)
                    .subscribe(() => {
                        this.router.navigate([""])
                    })    
            }, error => {
                console.log(error);
                this.errorMessage = "Fail to login";
            });
    }
}