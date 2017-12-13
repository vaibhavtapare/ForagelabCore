import { Routes } from '@angular/router';

import { LayoutComponent } from '../../layout/layout.component';

import { AuthComponent } from './auth.component';
import { LoginComponent } from './login/login.component';
import { LogoutComponent } from './logout/logout.component';

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
            //{ path: 'confirm/:code', component: ConfirmComponent },
            //{ path: 'reset/:hash', component: ResetComponent },
            //{ path: 'forgot', component: ForgotComponent }
        ]
    }
];
