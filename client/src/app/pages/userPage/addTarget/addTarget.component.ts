
import { Component } from "@angular/core";
import { Router } from "@angular/router";
import { UserService } from "../../../services/user.servise";
import { Target } from "../../../shared/User/Target";
import { WeightCondition } from "../../../shared/User/WeightContition";

@Component({
    selector: "add-target",
    templateUrl: "addTarget.component.html",
    styles:[]
    })
export class AddTarget {

    constructor(private userService: UserService, private router: Router) {
    }

    target: Target = new Target();

    onAddTarget() {
        this.userService.user.targets.push(this.target);

        const weightCondition = new WeightCondition();
        weightCondition.bodyWeight = this.target.currentBodyWeight;
        this.userService.user.weightConditions.push(weightCondition);

        this.userService.updateUser()
            .subscribe(() => {
                this.userService.getUserWithIdentity()
                    .subscribe(() => {
                        this.router.navigate(["user"]);
                    })
            })
    }
}
