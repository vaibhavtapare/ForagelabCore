import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { SharedModule } from '../../shared/shared.module';

import { AuthComponent } from './auth.component';
import { LoginComponent } from './login/login.component';
import { LogoutComponent } from './logout/logout.component';

import { authRoutes } from './auth-routing.module';

/**
 * Module to control login/logout for application
 */
@NgModule({
    imports: [
        SharedModule,
        
        RouterModule.forChild(authRoutes)
    ],
    declarations: [
        AuthComponent,
        LoginComponent,
        LogoutComponent
    ],
    exports: [
        RouterModule
    ]
})
export class AuthModule { }
