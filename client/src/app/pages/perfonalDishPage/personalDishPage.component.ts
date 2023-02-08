import { Component } from "@angular/core";
import { Router} from "@angular/router";
import { LibraryService } from "../../services/library.service";
import { Login } from "../../services/login.servise";



@Component({
    selector: "perfonal-dish-page",
    templateUrl: "personalDishPage.component.html",
    styleUrls: ["personalDishPage.component.css"]
})
export class PersonalDishPage {

    constructor(public libraryService: LibraryService,
        public loginService: Login,
        private router: Router) {
    }
       
    navigateDish(){
        this.router.navigate(["dish"], { queryParams: { returnUrl: "personalDish" } })        
    }

    onSave() {
        this.loginService.user.userMenu.dishes = this.libraryService.personalDishes;
        this.loginService.updateUser()
            .subscribe(() => {
                this.router.navigateByUrl("");
            });
    }

    deleteComponent(index: number) {
        this.loginService.user.userMenu.dishes.splice(index, 1);        
    }

}