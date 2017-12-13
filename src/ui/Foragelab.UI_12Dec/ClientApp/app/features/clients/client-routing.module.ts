import { Routes } from '@angular/router';

import { MenuItem } from '../../shared/models/menu-item.model';

import { LayoutComponent } from '../../layout/layout.component';

import { ClientComponent } from './client.component';
import { ClientAddComponent } from './client-add/client-add.component';
import { ClientDetailComponent } from './client-detail/client-detail.component';

import { LocationDetailComponent } from './location-detail/location-detail.component'

import { AuthGuard } from '../../shared/guards/auth.guard';
import { ContactDetailComponent } from "./contact-detail/contact-detail.component";

export const clientRoutes: Routes = [
    {
        path: 'clients',
        component: LayoutComponent,
        canActivateChild: [AuthGuard],
        data: {
            menuItem: {
                text: 'Clients',
                icon: 'fa-building',
                link: '/clients',
                pageTitle: 'Clients',
                iconBgClass: 'bg-info',
                requiredPrivileges: ['clients']
            }
        },
        children: [
            {
                path: '', pathMatch: 'full', component: ClientComponent
            },
            {
                path: 'add', component: ClientAddComponent,
                data: {
                    menuItem: {
                        link: '/clients/add',
                        pageTitle: 'Add Client',
                        requiredPrivileges: ['clients-add']
                    }
                }
            },
            {
                path: ':id', component: ClientDetailComponent,
                data: {
                    menuItem: {
                        link: '/clients/:id',
                        pageTitle: 'Client Detail',
                        requiredPrivileges: ['clients']
                    }
                }
            },
            {
                path: ':id/locations/:locationId',
                component: LocationDetailComponent,
                canActivateChild: [AuthGuard],
                data: {
                    menuItem: {
                        link: '/clients/:id/locations/:locationId',
                        pageTitle: 'Edit Location',
                        requiredPrivileges: ['locations']
                    }
                }
            },
            {
                path: ':id/contacts/:contactId',
                component: ContactDetailComponent,
                canActivateChild: [AuthGuard],
                data: {
                    menuItem: {
                        link: '/clients/:id/contacts/:contactId',
                        pageTitle: 'Edit Contact',
                        requiredPrivileges: ['contacts']
                    }
                }
            }
        ]
    }
];