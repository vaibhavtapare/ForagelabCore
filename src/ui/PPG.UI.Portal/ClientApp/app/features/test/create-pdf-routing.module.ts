import { Routes } from '@angular/router';

import { MenuItem } from '../../shared/models/menu-item.model';

import { LayoutComponent } from '../../layout/layout.component';

import { CreatePDFComponent } from './create-pdf.component';
import { AuthGuard } from '../../shared/guards/auth.guard';

export const CreatePDFRoutes: Routes = [
    {
        path: 'testpdf',
        component: LayoutComponent,
        canActivateChild: [AuthGuard],
        children: [
            {
                path: '', pathMatch: 'full', component: CreatePDFComponent
            }
        ]
    }
];