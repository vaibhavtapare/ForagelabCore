import { NgModule } from "@angular/core"; 
import { authRoutes } from "./auth-routing.module";
import { RouterModule } from "@angular/router";
import { AuthComponent } from "./auth.component";
import { LoginComponent } from "./login/login.component";
import { LogoutComponent } from "./logout/logout.component";
import { FormsModule } from "@angular/forms";

/**
 * Module to control login/logout for application
 */


@NgModule({
    imports: [       
        FormsModule,
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
