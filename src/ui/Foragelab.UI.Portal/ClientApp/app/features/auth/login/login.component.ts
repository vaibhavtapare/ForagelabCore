import { Component } from "@angular/core";
import { Router } from "@angular/router";
import { UserLogin } from "../../../shared/model/user-login.model";
import { AuthService } from "../../../core/services/auth.service";
import { StateService } from "../../../core/services/state.service";

@Component({
    templateUrl: './login.component.html'
})
export class LoginComponent {
    loginModel: UserLogin = new UserLogin(); 
    submitPending: boolean = false; 
    constructor(private _router: Router
        , private _authService: AuthService
        , private _stateService: StateService
    )
    {

        this.loginModel.emailAddress = "cvas@foragelab.com"; 
        this.loginModel.password = "jj"; 
    }


    RouteToHome() {
        this.submitPending = true;
        alert('clicked'); 
        //localStorage.setItem("CVASUser", "Set"); 
        //this._router.navigate(['\home']);

        this._authService.login(this.loginModel.emailAddress, this.loginModel.password)
            .subscribe(s => {
                this.submitPending = false;
                this._router.navigate(['\home']); 
            },
            e => {
                this.submitPending = false;
                console.log(e);

            }
        )
    }


}