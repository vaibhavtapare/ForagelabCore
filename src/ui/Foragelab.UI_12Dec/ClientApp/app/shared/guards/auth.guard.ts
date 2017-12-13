import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';

import { StateService } from '../../core/services/state.service';

import { MenuItem } from '../../shared/models/menu-item.model';

@Injectable()
export class AuthGuard implements CanActivate {
    constructor(
        private router: Router,
        private stateService: StateService) { }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        if (this.stateService.currentUser) {

            if (route.data && route.data.menuItem) {
                let menuItem: MenuItem = route.data.menuItem;

                return this.stateService.canTraverseRoute(menuItem);
            }
            return true;
        }

        // not logged in so redirect to login page with the return url
        this.router.navigate(['/auth/login'], { queryParams: { returnUrl: state.url } });
        return false;
    }

    canActivateChild(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
        return this.canActivate(route, state);
    }
}