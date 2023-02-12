import { Component } from "@angular/core";
import { Router } from "@angular/router";
import { UserService } from "../../services/user.servise";
import { Meal } from "../../shared/User/Meal";


@Component({
    selector: "diary-page",
    templateUrl: "diaryPage.component.html",
    styles: ["#mealConteiner{cursor:pointer}"]
    })
export class DiaryPage {
   
    constructor(public userService: UserService,
    private router:Router) {

    }

    addMeal() {
        this.userService.meal = new Meal();
        this.router.navigate(["addmeal"]);
    }

    updateMeal(index: number) {
        this.userService.meal = this.userService.user.meals[index];
        this.router.navigate(["addmeal"], { queryParams: { "queryMessageIndex": `${index}`, "queryMessage": "update" } });
    }

    deleteMeal(index: number) {
        this.userService.mealToDelete = this.userService.user.meals[index];

        this.userService.deleteUserMeals()
            .subscribe(() => {
                this.userService.getUserWithIdentity().
                    subscribe(() => {
                        this.userService.mealToDelete = new Meal();
                    });
            });
    }

}