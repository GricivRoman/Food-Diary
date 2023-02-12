import { HttpErrorResponse } from "@angular/common/http";
import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { UserService } from "../../services/user.servise";
import { LoginRequest } from "../../shared/Account/LoginResults";
import { Location } from '@angular/common';

@Component({
    selector: "login-page",
    templateUrl: "loginPage.component.html",
    styleUrls: []
})

export class LoginPage implements OnInit {
    constructor(private userService: UserService,
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
        this.userService.login(this.creds)
            .subscribe(() => {
                this.userService.getUser(this.creds)
                    .subscribe(() => {
                        this.router.navigateByUrl(this.returnUrl);
                                                
                    })    
            }, error => {
                console.log(error);
                this.errorMessage = `${(error as HttpErrorResponse).error}`;;
            });
    }
}