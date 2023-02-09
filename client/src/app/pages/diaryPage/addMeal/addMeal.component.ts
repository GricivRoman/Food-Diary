import { HttpErrorResponse } from "@angular/common/http";
import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { Login } from "../../../services/login.servise";


@Component({
    selector: "add-meal",
    templateUrl: "addMeal.component.html",
    styleUrls:["addMeal.component.css"]
    })
export class AddMeal implements OnInit {

    constructor(public loginService: Login, private router:Router, private activatedRoute:ActivatedRoute) {
    }

    errorMessage: string = "";   
    previousPageUrl: string = "";
    queryMessageIndex: string = "";
    queryMessage: string = "";


    ngOnInit(): void {
        this.queryMessageIndex = this.activatedRoute.snapshot.queryParams["queryMessageIndex"];
        this.queryMessage = this.activatedRoute.snapshot.queryParams["queryMessage"];
    }
   
    addMeal() {
        this.loginService.user.meals.push(this.loginService.meal);       
    }


    navigateUserMenu() {
        
        this.router.navigate(["/personalDish"], { queryParams: { returnUrl: "addmeal" } })
    }

    deleteComponent(index: number) {        
        this.loginService.meal.mealItems.splice(index, 1);
    }

    saveMeal() {
        if (this.queryMessage == "update") {

            const index = this.queryMessageIndex as unknown as number;
            this.loginService.user.meals[index] = this.loginService.meal;           
            
        } else {
            
            this.loginService.user.meals.push(this.loginService.meal);
        }

        this.loginService.updateUserMeals()
            .subscribe(() => {
                this.loginService.getUserWithIdentity()
                    .subscribe(() => {
                        this.router.navigateByUrl("");
                    });
            }, err => {
                this.errorMessage = `${(err as HttpErrorResponse).error}`;
            });

        
    }
}