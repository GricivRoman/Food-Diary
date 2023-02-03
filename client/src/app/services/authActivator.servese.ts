import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from "@angular/router";
import { Observable } from "rxjs";
import { Login } from "./login.servise";

@Injectable()
export class AuthActivator implements CanActivate {

    constructor(private diary: Login, private router: Router) {

    }

    canActivate(route: ActivatedRouteSnapshot,
        state: RouterStateSnapshot):
        boolean | UrlTree | Observable<boolean | UrlTree> | Promise<boolean | UrlTree> {

        if (this.diary.loginRequired) {
            this.router.navigate(["login"], { queryParams: { returnUrl: state.url } })
            return false;
        } else {
            return true;
        }
    }

}