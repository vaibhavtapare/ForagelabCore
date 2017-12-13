import { Component, ViewChild, Renderer } from '@angular/core';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';

import { AuthService } from '../../../core/services/auth.service';
import { NotificationService } from '../../../core/services/notification.service';
import { StateService } from '../../../core/services/state.service';

import { UserLogin } from '../../../shared/models/user-login.model';

/**
 * Component used for the login page
 */
@Component({
    templateUrl: './login.component.html'
})
export class LoginComponent {
    constructor(
        private _router: Router,
        private _authService: AuthService,
        private _notificationService: NotificationService,
        private renderer: Renderer,
        private _stateService: StateService) { }

    loginModel: UserLogin = new UserLogin();
    submitPending: boolean = false;

    // TO DO: Log In button does not become enabled unless I click inside the password edit.
    //@ViewChild('emailAddress')
    //emailAddress: any;

    //ngOnInit() {
    //    //this.emailAddress.nativeElement.focus();
    //    this.renderer.invokeElementMethod(this.emailAddress.nativeElement, 'focus');
    //}

    /**
     * Calls the AuthService to authenticate the user
     */
    login(): void {
        this.submitPending = true;
        
        this._authService.login(this.loginModel.emailAddress, this.loginModel.password)
            .subscribe(s => {
                this.submitPending = false;
                this._router.navigate(['']);
            },
            e => {

                console.log(e);
                this.submitPending = false;
                this._notificationService.notify('error', e._body);
            });
    }
}
