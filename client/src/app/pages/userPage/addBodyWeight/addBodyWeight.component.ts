import { Component } from "@angular/core";
import { Router } from "@angular/router";
import { UserService } from "../../../services/user.servise";
import { WeightCondition } from "../../../shared/User/WeightContition";

@Component({
    selector: "add-bodyWeight",
    templateUrl: "addBodyWeight.component.html",
    styles: []
    })
export class AddBodyWeight {
    constructor(private userService:UserService, private router:Router) {
    }

    weightCondidion: WeightCondition = new WeightCondition();

    onAddWeightCondition() {
        this.userService.user.weightConditions.push(this.weightCondidion);
        this.userService.updateUser()
            .subscribe(() => {
                this.userService.getUserWithIdentity()
                    .subscribe(() => {
                        this.router.navigate(["user"]);
                    })
            })
       
    }

}