import { Component, OnInit } from "@angular/core"; 
import { Router } from "@angular/router";

/**
 * Component for routing of the application based on user type
 */


@Component({
    template: '<template></template>'
})

export class AppRoutingComponent implements OnInit {

    private isuserLoggedin: boolean = false;
    constructor(private router: Router) {
        
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