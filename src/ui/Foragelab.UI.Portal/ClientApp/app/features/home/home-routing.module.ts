import { Routes } from "@angular/router/src";
import { AuthGuard } from "../../shared/guards/auth.guard";
import { HomeComponent } from "./home.component";
import { LayoutComponent } from "../../layout/layout.component";

export const homeRoutes: Routes = [
    {
        path: 'home',
        component: LayoutComponent,
        canActivateChild: [AuthGuard],
        data: {
            menuItem: {
                text: 'Home',
                link: '/home',                                
                pageTitle: 'Dashboard'                
            }
        },
        children: [
            {
                path: '', pathMatch: 'full', component: HomeComponent
            }
        ]
    }
];