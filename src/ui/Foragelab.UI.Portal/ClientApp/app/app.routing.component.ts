import { Component, OnInit } from "@angular/core"; 
import { Router } from "@angular/router";
import { AuthenticatedComponentBase } from "./shared/bases/authenticated.component.base";
import { StateService } from "./core/services/state.service";

/**
 * Component for routing of the application based on user type
 */


@Component({
    template: '<ng-template></ng-template>'
})

export class AppRoutingComponent extends AuthenticatedComponentBase implements OnInit {

    private isuserLoggedin: boolean = false;
    constructor(public stateService: StateService, private router: Router) {
        super(stateService);
        
    }
    ngOnInit() {
        this.RedirectRoute();
    }

    /**
     * Redirects to starting page based on user type
     */

    RedirectRoute() {
        if (this.isuserLoggedin) {            
                this.router.navigateByUrl('/home');            
        }
        else {
            this.router.navigateByUrl('/auth/login');
        }
    }
}