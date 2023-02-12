import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router} from "@angular/router";
import { LibraryService } from "../../services/library.service";
import { Dish } from "../../shared/Food/Dish";

@Component({
    selector: "dish-list",
    templateUrl: "dishPage.component.html",
    styleUrls: ["dishPage.component.css"]
})

export class DishPage implements OnInit  {

    constructor(public libraryService: LibraryService, private router: Router, private activatedRoute:ActivatedRoute) {

    }
    public returnUrl: string = "";

    ngOnInit(): void {
        this.libraryService.loadDishes()
            .subscribe();   
        this.returnUrl = this.activatedRoute.snapshot.queryParams['returnUrl'];
    }

    setEmptyDish() {
        this.libraryService.dish = new Dish();
    }

    getDishToUpdate(index: number) {        
        if (this.returnUrl == "personalDish") {
            this.libraryService.personalDishes.push(this.libraryService.dishes[index] as Dish);                      
            this.router.navigate(["/personalDish"]);
            
        } else {
            this.libraryService.dishToUpdate = this.libraryService.dishes[index] as Dish;
        }
    }
}