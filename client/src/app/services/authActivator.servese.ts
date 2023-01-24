import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from "@angular/router";
import { Observable } from "rxjs";
import { Diary } from "./diary.servise";

@Injectable()
export class AuthActivator implements CanActivate {

    constructor(private diary: Diary, private router: Router) {

    }

    canActivate(route: ActivatedRouteSnapshot,
        state: RouterStateSnapshot):
        boolean | UrlTree | Observable<boolean | UrlTree> | Promise<boolean | UrlTree> {

        if (this.diary.loginRequired) {
            this.router.navigate(["login"])
            return false;
        } else {
            return true;
        }
    }

}