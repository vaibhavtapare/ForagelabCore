import { Component } from "@angular/core";
import { Router } from "@angular/router";

@Component({
    templateUrl: './login.component.html'
})
export class LoginComponent {
    constructor(private _router: Router)
    {

    }


    RouteToHome() {

        alert('clicked'); 
        localStorage.setItem("CVASUser", "Set"); 
        this._router.navigate(['\home']);
    }


}