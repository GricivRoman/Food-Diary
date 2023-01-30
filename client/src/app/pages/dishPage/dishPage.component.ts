import { Component, OnInit } from "@angular/core";
import { LibraryService } from "../../services/library.service";
import { Dish } from "../../shared/Dish";

@Component({
    selector: "dish-list",
    templateUrl: "dishPage.component.html",
    styleUrls: ["dishPage.component.css"]
})

export class DishPage implements OnInit  {

    constructor(public libraryService: LibraryService) {
    }


    ngOnInit(): void {
        this.libraryService.loadDishes()
            .subscribe();
    }

    setEmptyDish() {
        this.libraryService.dish = new Dish;
    }

}