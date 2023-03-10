import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from "@angular/router";
import { Observable } from "rxjs";
import { UserService } from "./user.servise";

@Injectable()
export class AuthActivator implements CanActivate {

    constructor(private diary: UserService, private router: Router) {

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