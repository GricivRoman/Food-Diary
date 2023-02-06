import { HttpErrorResponse } from "@angular/common/http";
import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { CatalogService } from "../../services/catalog.service";
import { Login } from "../../services/login.servise";
import { PhysicalActivityCatalog } from "../../shared/Catalogs/PhysicalActivityCatalog";
import { SexCatalog } from "../../shared/Catalogs/SexCatalog";
import { Target } from "../../shared/User/Target";
import { User } from "../../shared/User/User";


@Component({
    selector: "user-page",
    templateUrl: "userPage.component.html",
    styles: []
})

export class UserPage implements OnInit {
    constructor(public loginService: Login,
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

/*    user: User = this.loginService.user;*/

    target: Target = this.loginService.user.targets.find(f => f.relevance == true) as Target;
      
    
    sexIndex: number = 0;

    errorMessage: string = "";

    setUserParameters() {
        
        /*this.loginService.user = this.user*/


        this.loginService.updateUser()
            .subscribe(() => {
                this.loginService.getUserWithIdentity()
                    .subscribe(() => {
                        this.router.navigate(["/"]);
                    });
            }, error => {
                console.log(error);
                this.errorMessage = `${(error as HttpErrorResponse).error}`;;
            });

    }

    

    

    
}