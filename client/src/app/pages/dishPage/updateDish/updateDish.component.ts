import { HttpErrorResponse } from "@angular/common/http";
import { Component } from "@angular/core";
import { Router } from "@angular/router";
import { LibraryService } from "../../../services/library.service";
import { CompositionItem } from "../../../shared/CompositionItem";



@Component({
    selector: "update-dish",
    templateUrl: "updateDish.component.html",
    styleUrls: ["updateDish.component.css"]
})

export class UpdateDish {
    constructor(public libraryService: LibraryService, private router: Router) {

    }

    composition: CompositionItem[] = this.libraryService.dishToUpdate.resourseSpecification.composition;

    dishName: string = this.libraryService.dishToUpdate.dishName;
    outputDishWeightG: number = this.libraryService.dishToUpdate.resourseSpecification.outputDishWeightG;

    errorMessage: string = "";

    updateComposition() {
        this.libraryService.dishToUpdate.resourseSpecification.composition = this.composition;

        this.libraryService.dishToUpdate.dishName = this.dishName;
        this.libraryService.dishToUpdate.resourseSpecification.outputDishWeightG = this.outputDishWeightG;
    }

    deleteComponent(index: number) {
        this.libraryService.dishToUpdate.resourseSpecification.composition.splice(index, 1)
    }

    onUpdate() {
        this.updateComposition();

        this.libraryService.updateDish()
            .subscribe(() => {
                this.router.navigate(["dish"]);
            }, err => {
                this.errorMessage = `${(err as HttpErrorResponse).error}`;
            });
    }


}