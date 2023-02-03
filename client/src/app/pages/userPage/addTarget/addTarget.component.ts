
import { Component } from "@angular/core";
import { Router } from "@angular/router";
import { Login } from "../../../services/login.servise";
import { Target } from "../../../shared/User/Target";
import { WeightCondition } from "../../../shared/User/WeightContition";

@Component({
    selector: "add-target",
    templateUrl: "addTarget.component.html",
    styles:[]
    })
export class AddTarget {

    constructor(public loginService: Login, private router: Router) {
    }

    target: Target = new Target();

    onAddTarget() {
        this.loginService.user.targets.push(this.target);

        const weightCondition = new WeightCondition();
        weightCondition.bodyWeight = this.target.currentBodyWeight;
        this.loginService.user.weightConditions.push(weightCondition);

        this.loginService.updateUser()
            .subscribe(() => {
                this.loginService.getUserWithIdentity()
                    .subscribe(() => {
                        this.router.navigate(["user"]);
                    })
            })
    }
}
