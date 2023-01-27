import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Product } from "../shared/Product";
import { map } from "rxjs/operators";

@Injectable()

export class ProductService {
    constructor(private http: HttpClient) {

    }
       
    products: Product[] = [];


    createProduct(product: Product) {
        return this.http.post("/api/product", product);
    }

    loadProducts() :Observable<void>{
        return this.http.get<[]>("/api/product")
            .pipe(map(data => {
                this.products = data;
                return;
            }));
    }

}