import { Routes } from '@angular/router';

import { MenuItem } from '../../shared/models/menu-item.model';

import { LayoutComponent } from '../../layout/layout.component';

import { DashboardComponent } from './dashboard.component';
import { AuthGuard } from '../../shared/guards/auth.guard';

export const dashboardRoutes: Routes = [
    {
        path: 'dashboard',
        component: LayoutComponent,
        canActivateChild: [AuthGuard],
        data: {
            menuItem: {
                text: 'Dashboard',
                link: '/dashboard',
                initials: 'Db',
                icon: 'fa-tachometer',
                pageTitle: 'Dashboard',
                iconBgClass: 'bg-success'
            }
        },
        children: [
            {
                path: '', pathMatch: 'full', component: DashboardComponent
            }
        ]
    }
];