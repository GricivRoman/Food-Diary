import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, pipe } from "rxjs";
import { Product } from "../shared/Product";
import { map } from "rxjs/operators";
import { Dish } from "../shared/Dish";
import { CompositionItem } from "../shared/CompositionItem";

@Injectable()

export class LibraryService {
    constructor(private http: HttpClient) {

    }
       
    products: Product[] = [];
    dishes: Dish[] = [];

   

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

    loadDishes(): Observable<void> {
        return this.http.get<[]>("/api/dish")
            .pipe(map(data => {
                this.dishes = data;
                return;
            }));        
    }


    dish: Dish = new Dish();



    addCompositionItem(product: Product) {

        if (this.dish.resourseSpecification.composition.find(c => c.product.productName == product.productName) != null) {

        } else {
            let compositionItem = new CompositionItem();
            compositionItem.product = product;

            this.dish.resourseSpecification.composition.push(compositionItem);
        }

    }
        

   

    createDish() {
        return this.http.post("/api/dish", this.dish)
            .pipe(map(() => {
                this.dish = new Dish();
            }));
    }
    
}