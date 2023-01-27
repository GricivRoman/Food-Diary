import { Component, OnInit } from "@angular/core";
import { ProductService } from "../../services/product.service";
import { Product } from "../../shared/Product";

@Component({
    selector: "product-list",
    templateUrl: "productPage.component.html",
    styleUrls: ["productPage.component.css"]
})

export class ProductPage implements OnInit{

    constructor(public productService: ProductService) {

    }

    ngOnInit(): void {
        this.productService.loadProducts()
            .subscribe();
    }

    prod = this.productService.products;
    
}