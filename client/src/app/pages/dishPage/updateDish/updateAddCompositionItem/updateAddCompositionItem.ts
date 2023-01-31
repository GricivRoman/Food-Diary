import { Component, OnInit } from "@angular/core";
import { Router, UrlTree } from "@angular/router";

import { LibraryService } from "../../../../services/library.service";





@Component({
    selector: "update-add-composition-item",
    templateUrl: "updateAddCompositionItem.html",
    styleUrls:[]
    })

export class UpdateAddCompositionItem implements OnInit{
    constructor(public libraryService:LibraryService, private router: Router) {

    }
       
    ngOnInit(): void {
        this.libraryService.loadProducts().subscribe();                 
    }
        
}