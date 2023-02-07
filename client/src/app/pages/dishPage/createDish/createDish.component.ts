import { HttpErrorResponse } from "@angular/common/http";
import { Component } from "@angular/core";
import { Router } from "@angular/router";
import { LibraryService } from "../../../services/library.service";
import { CompositionItem } from "../../../shared/Food/CompositionItem";

@Component({
    selector: "create-dish",
    templateUrl: "createDish.component.html",
    styleUrls:["createDish.component.css"]
    })

export class CreateDish{

    constructor(public libraryService:LibraryService, private router:Router) {

    }

    composition: CompositionItem[] = this.libraryService.dish.resourseSpecification.composition;

    errorMessage: string = "";

    updateComposition() {
        this.libraryService.dish.resourseSpecification.composition = this.composition;       
    }

    onCreate() {
        
        this.libraryService.createDish()
            .subscribe(() => {
                this.router.navigate(["dish"]);
            }, err => {
                this.errorMessage = `${(err as HttpErrorResponse).error}`;
            });
    }

    deleteComponent(index: number) {
        this.libraryService.dish.resourseSpecification.composition.splice(index,1)
    }

}