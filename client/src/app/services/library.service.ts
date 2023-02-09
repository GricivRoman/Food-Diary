import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, pipe } from "rxjs";
import { Product } from "../shared/Food/Product";
import { map } from "rxjs/operators";
import { Dish } from "../shared/Food/Dish";
import { CompositionItem } from "../shared/Food/CompositionItem";



@Injectable()

export class LibraryService {
    constructor(private http: HttpClient) {

    }
       
    products: Product[] = [];
    dishes: Dish[] = [];
    dish: Dish = new Dish();
    dishToUpdate: Dish = new Dish();


    personalDishes: Dish[] = []; 
    
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
    updateAddCompositionItem(product: Product) {

        if (this.dishToUpdate.resourseSpecification.composition.find(c => c.product.productName == product.productName) != null) {

        } else {
            let compositionItem = new CompositionItem();
            compositionItem.product = product;

            this.dishToUpdate.resourseSpecification.composition.push(compositionItem);
        }
    }
    updateDish() {
        return this.http.put("/api/dish", this.dishToUpdate)
            .pipe(map(() => {
                this.dishToUpdate = new Dish();
            }));
    }
}