import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { LibraryService } from "../../../../services/library.service";

@Component({
    selector: "add-composition-item",
    templateUrl: "addCompositionItem.component.html",
    styleUrls:[]
    })

export class AddCompositionItem implements OnInit{
    constructor(public libraryService:LibraryService, private router: Router) {

    }
       
    ngOnInit(): void {
        this.libraryService.loadProducts().subscribe();                 
    }
        
}