import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { AuthGuard } from './shared/guards/auth.guard';
import { AppRoutingComponent } from "./app.routing.component";

export const appRoutes: Routes = [
    {
        path: '',
        pathMatch: 'full',
        component: AppRoutingComponent
        //redirectTo: '/dashboard'
    }
];
