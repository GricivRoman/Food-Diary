import { HttpErrorResponse } from "@angular/common/http";
import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { Login } from "../../services/login.servise";
import { LoginRequest } from "../../shared/Account/LoginResults";
import { Location } from '@angular/common';

@Component({
    selector: "login-page",
    templateUrl: "loginPage.component.html",
    styleUrls: []
})

export class LoginPage implements OnInit {
    constructor(private loginService: Login,
        private router: Router,
        private route: ActivatedRoute,
        private location:Location ) {

    }
    
    public creds: LoginRequest = {
        username: "",
        password: ""
    };
    public returnUrl: string = "";

    public errorMessage: string = "";

    ngOnInit(): void {
        this.returnUrl = this.route.snapshot.queryParams['returnUrl'];
    }

    onLogin() {
        this.loginService.login(this.creds)
            .subscribe(() => {
                this.loginService.getUser(this.creds)
                    .subscribe(() => {
                        this.router.navigateByUrl(this.returnUrl);
                        //if (this.returnUrl == "") {
                        //    this.location.back();
                        //} else {
                        //    this.router.navigateByUrl(this.returnUrl); 
                        //}
                        
                    })    
            }, error => {
                console.log(error);
                this.errorMessage = `${(error as HttpErrorResponse).error}`;;
            });
    }
}