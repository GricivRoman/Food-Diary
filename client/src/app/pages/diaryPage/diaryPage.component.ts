import { Component } from "@angular/core";
import { Router } from "@angular/router";
import { Login } from "../../services/login.servise";
import { Meal } from "../../shared/User/Meal";


@Component({
    selector: "diary-page",
    templateUrl: "diaryPage.component.html",
    styles: ["#mealConteiner{cursor:pointer}"]
    })
export class DiaryPage {
   
    constructor(public loginService: Login,
    private router:Router) {

    }

    addMeal() {
        this.loginService.meal = new Meal();
        this.router.navigate(["addmeal"]);
    }

    updateMeal(index: number) {
        this.loginService.meal = this.loginService.user.meals[index];
        this.router.navigate(["addmeal"], { queryParams: { "queryMessageIndex": `${index}`, "queryMessage": "update" } });
    }

    deleteMeal(index: number) {
        this.loginService.user.meals.splice(index, 1);
        this.loginService.updateUserMeals()
            .subscribe(() => {
                this.loginService.getUserWithIdentity()
            });
    }

}