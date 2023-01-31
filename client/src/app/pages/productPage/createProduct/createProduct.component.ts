import { HttpErrorResponse } from "@angular/common/http";
import { Component } from "@angular/core";
import { Router } from "@angular/router";
import { LibraryService } from "../../../services/library.service";

import { Product } from "../../../shared/Product";

@Component({
    selector: "product-list",
    templateUrl: "createProduct.component.html",
    styleUrls: []
})

export class CreateProduct {

    constructor(public libraryService: LibraryService, private router: Router) {

    }
       
    product: Product = new Product();

    errorMessage: string = ``;

    onCreate() {
        this.libraryService.createProduct(this.product)
            .subscribe(() => {
                this.router.navigate(["product"]);
            }, err => {
                this.errorMessage = `${(err as HttpErrorResponse).error}`;
            });
    }

   
}