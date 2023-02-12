import { HttpErrorResponse } from "@angular/common/http";
import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { UserService } from "../../../services/user.servise";


@Component({
    selector: "add-meal",
    templateUrl: "addMeal.component.html",
    styleUrls:["addMeal.component.css"]
    })
export class AddMeal implements OnInit {

    constructor(public userService: UserService, private router:Router, private activatedRoute:ActivatedRoute) {
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
        this.userService.user.meals.push(this.userService.meal);       
    }


    navigateUserMenu() {
        
        this.router.navigate(["/personalDish"], { queryParams: { returnUrl: "addmeal" } })
    }

    deleteComponent(index: number) {        
        this.userService.meal.mealItems.splice(index, 1);
    }

    saveMeal() {
        if (this.queryMessage == "update") {

            const index = this.queryMessageIndex as unknown as number;
            this.userService.user.meals[index] = this.userService.meal;           
            
        } else {
            
            this.userService.user.meals.push(this.userService.meal);
        }

        this.userService.updateUserMeals()
            .subscribe(() => {
                this.userService.getUserWithIdentity()
                    .subscribe(() => {
                        this.router.navigateByUrl("");
                    });
            }, err => {
                this.errorMessage = `${(err as HttpErrorResponse).error}`;
            });

        
    }
}