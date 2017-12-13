import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { DashboardComponent } from './dashboard.component'
import { dashboardRoutes } from './dashboard-routing.module';

/**
 * Module for dashboard features
 */
@NgModule({
    declarations: [
        DashboardComponent
    ],
    imports: [
        RouterModule.forChild(dashboardRoutes)
    ],
    exports: [
        RouterModule
    ]
})
export class DashboardModule {
}
