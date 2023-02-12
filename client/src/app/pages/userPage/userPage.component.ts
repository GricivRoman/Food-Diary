import { HttpErrorResponse } from "@angular/common/http";
import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { CatalogService } from "../../services/catalog.service";
import { UserService } from "../../services/user.servise";
import { Target } from "../../shared/User/Target";

@Component({
    selector: "user-page",
    templateUrl: "userPage.component.html",
    styles: []
})

export class UserPage implements OnInit {
    constructor(public userService: UserService,
        private router: Router,
        public catalogService: CatalogService) {
    }
    ngOnInit(): void {
        this.catalogService.loadSexCatalog()
            .subscribe(() => {

            });
        this.catalogService.loadPhysicalActivityCatalog()
            .subscribe(() => {

            });
    }

    target: Target = this.userService.user.targets.find(f => f.relevance == true) as Target;      
    
    sexIndex: number = 0;

    errorMessage: string = "";

    setUserParameters() {
        this.userService.updateUser()
            .subscribe(() => {
                this.userService.getUserWithIdentity()
                    .subscribe(() => {
                        this.router.navigate(["/"]);
                    });
            }, error => {
                console.log(error);
                this.errorMessage = `${(error as HttpErrorResponse).error}`;;
            });
    }

    

    

    
}