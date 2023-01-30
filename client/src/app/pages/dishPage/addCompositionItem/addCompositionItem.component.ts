import { Component, OnInit } from "@angular/core";
import { LibraryService } from "../../../services/library.service";
import { Product } from "../../../shared/Product";
import { CreateDish } from "../createDish.component";


@Component({
    selector: "add-composition-item",
    templateUrl: "addCompositionItem.component.html",
    styleUrls:[]
    })



export class AddCompositionItem implements OnInit{
    constructor(public libraryService:LibraryService) {

    }
    ngOnInit(): void {
        this.libraryService.loadProducts().subscribe();
    }

   

         
   

}