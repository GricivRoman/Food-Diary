import { Component, OnInit } from "@angular/core";
import { LibraryService } from "../../services/library.service";
import { Router } from "@angular/router";

@Component({
    selector: "product-list",
    templateUrl: "productPage.component.html",
    styleUrls: ["productPage.component.css"]
})

export class ProductPage implements OnInit{

    constructor(public libraryService: LibraryService, private router:Router) {

    }



    ngOnInit(): void {
        this.libraryService.loadProducts()
            .subscribe();
    }

    prod = this.libraryService.products;

    
    file: any;

    onFileChange(ev:any) {
        this.file = ev.target.files[0];        
    }

    uploadProducts() {        
        this.libraryService.createProducts(this.file)
            .subscribe(() => {
                this.router.navigateByUrl("product");
            });
                    
    }
}