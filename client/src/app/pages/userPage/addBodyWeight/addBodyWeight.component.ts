import { Component } from "@angular/core";
import { Router } from "@angular/router";
import { Login } from "../../../services/login.servise";
import { WeightCondition } from "../../../shared/User/WeightContition";

@Component({
    selector: "add-bodyWeight",
    templateUrl: "addBodyWeight.component.html",
    styles: []
    })
export class AddBodyWeight {
    constructor(public loginService:Login, private router:Router) {
    }

    weightCondidion: WeightCondition = new WeightCondition();

    onAddWeightCondition() {
        this.loginService.user.weightConditions.push(this.weightCondidion);
        this.loginService.updateUser()
            .subscribe(() => {
                this.loginService.getUserWithIdentity()
                    .subscribe(() => {
                        this.router.navigate(["user"]);
                    })
            })
       
    }

}