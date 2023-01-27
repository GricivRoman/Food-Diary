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
    constructor(private diary: Login, private router: Router) {

    }
    public creds: LoginRequest = {
        username: "",
        password: ""
    }

    public errorMessage: string = "";

    onLogin() {
        this.diary.login(this.creds)
            .subscribe(() => {
                this.router.navigate([""])
                //Succesfully logged in
            }, error => {
                console.log(error);
                this.errorMessage = "Fail to login";
            })
    }
}