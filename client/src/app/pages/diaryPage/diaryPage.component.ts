import { Component } from "@angular/core";
import { Login } from "../../services/login.servise";

@Component({
    selector: "diary-page",
    templateUrl: "diaryPage.component.html",
    styleUrls: []
    })
export class DiaryPage {
    constructor(public loginService: Login) {
    }
        


}