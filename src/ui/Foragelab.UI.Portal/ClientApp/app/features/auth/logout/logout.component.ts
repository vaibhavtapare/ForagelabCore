import { Component, OnInit } from "@angular/core"; 
import { Router } from "@angular/router";

/**
 * Component for logging a user out of the application
 */


@Component({
    template: ''
})
export class LogoutComponent implements OnInit {
    constructor(
        private _router: Router)
    { }

    ngOnInit() {
        this.logout();
    }

    /**
     * Logs the user out and redirects them
     */
    logout(): void {
        //this._authService.logout();
        this._router.navigate(['']);
    };
}
