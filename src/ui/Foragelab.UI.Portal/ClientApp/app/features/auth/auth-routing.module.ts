import { LoginComponent } from "./login/login.component"; 
import { LogoutComponent } from "./logout/logout.component";
import { AuthComponent } from "./auth.component";
import { Routes } from "@angular/router";
import { HomeComponent } from "../home/home.component";
/**
 * Routes for path at /auth
 */
export const authRoutes: Routes = [
    {
        path: 'auth',
        component: AuthComponent,
        children: [
            { path: '', pathMatch: 'full', redirectTo: '/auth/login' },
            { path: 'login', component: LoginComponent },
            { path: 'logout', component: LogoutComponent },
            //{ path: 'home', component: HomeComponent },
            //{ path: 'reset/:hash', component: ResetComponent },
            //{ path: 'forgot', component: ForgotComponent }

        ]
    }
];
