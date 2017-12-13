import { Injectable } from "@angular/core";
import { CanActivate, Router, ActivatedRouteSnapshot, RouterStateSnapshot } from "@angular/router";

@Injectable()
export class AuthGuard implements CanActivate {
    constructor(private router: Router) {
    }
    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot )
    {
        //return true; 

        this.router.navigate(['auth/login'], { queryParams: { returnUrl: state.url } });
        return false;
    }

} 