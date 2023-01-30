import { Component, OnInit } from "@angular/core";
import { LibraryService } from "../../services/library.service";
import { Product } from "../../shared/Product";

@Component({
    selector: "product-list",
    templateUrl: "productPage.component.html",
    styleUrls: ["productPage.component.css"]
})

export class ProductPage implements OnInit{

    constructor(public libraryService: LibraryService) {

    }

    ngOnInit(): void {
        this.libraryService.loadProducts()
            .subscribe();
    }

    prod = this.libraryService.products;
    
}