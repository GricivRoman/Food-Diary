import { Component } from "@angular/core";
import { ProductService } from "../../services/product.service";
import { Product } from "../../shared/Product";

@Component({
    selector: "product-list",
    templateUrl: "createProduct.component.html",
    styleUrls: []
})

export class CreateProduct {

    constructor(public productService: ProductService) {

    }

   
    product: Product = {
        productName: "",
        calories: 0,
        carbohydrate: 0,
        fat: 0,
        protein: 0
    };

    onCreate() {
        this.productService.createProduct(this.product)
            .subscribe(() => {
            });
    }

}