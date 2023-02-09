import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router} from "@angular/router";
import { LibraryService } from "../../services/library.service";
import { Login } from "../../services/login.servise";
import { Dish } from "../../shared/Food/Dish";
import { MealItem } from "../../shared/User/MealItem";



@Component({
    selector: "perfonal-dish-page",
    templateUrl: "personalDishPage.component.html",
    styleUrls: ["personalDishPage.component.css"]
})
export class PersonalDishPage implements OnInit {

    constructor(public libraryService: LibraryService,
        public loginService: Login,
        private router: Router,
        private activatedRoute: ActivatedRoute) {
    }

    public returnUrl: string = "";

    navigateDish(){
        this.router.navigate(["dish"], { queryParams: { returnUrl: "personalDish" } })        
    }    

    ngOnInit(): void {        
        this.returnUrl = this.activatedRoute.snapshot.queryParams['returnUrl'];
    }

    onSave() {
        this.loginService.user.userMenu.dishes = this.libraryService.personalDishes;
        this.loginService.updateUser()
            .subscribe(() => {
                this.router.navigateByUrl("");
            });
    }

    deleteComponent(index: number) {
        this.loginService.user.userMenu.dishes.splice(index, 1);        
    }


    takeDish(index:number) {

        if (this.returnUrl = "addmeal") {

            const mealItem: MealItem = new MealItem();
            mealItem.dish = this.loginService.user.userMenu.dishes[index];
            mealItem.dishId = this.loginService.user.userMenu.dishes[index].id;
            this.loginService.meal.mealItems.push(mealItem);
                        
            this.router.navigateByUrl(this.returnUrl);
        }        
    }
}