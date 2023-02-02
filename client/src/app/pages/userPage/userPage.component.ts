import { Component } from "@angular/core";
import { Login } from "../../services/login.servise";
import { User } from "../../shared/User/User";
import { WeightCondition } from "../../shared/User/WeightContition";

@Component({
    selector: "user-page",
    templateUrl: "userPage.component.html",
    styles: []
    })
export class UserPage {
    constructor(public loginService:Login) {
    }

    user: User = this.loginService.user;

    weightCondition: WeightCondition = new WeightCondition();

    setUserParameters() {

    }
}