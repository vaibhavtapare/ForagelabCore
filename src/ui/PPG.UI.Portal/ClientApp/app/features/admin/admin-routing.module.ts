import { Routes } from '@angular/router';

import { MenuItem } from '../../shared/models/menu-item.model';

import { LayoutComponent } from '../../layout/layout.component';

import { ARTermsComponent } from './ar-terms/ar-terms.component';
import { ARTermsAddComponent } from './ar-terms/ar-terms-add/ar-terms-add.component';
import { ARTermsDetailComponent } from './ar-terms/ar-terms-detail/ar-terms-detail.component';
import { RoleComponent } from './role/role.component';
import { RoleAddComponent } from './role/role-add/role-add.component';
import { RoleDetailComponent } from './role/role-detail/role-detail.component';
import { UserComponent } from './user/user.component';
import { AddressComponent } from './address/address.component';
import { AddressDetailComponent } from './address/address-detail/address-detail.component';
import { AuthGuard } from '../../shared/guards/auth.guard';

/**
 * Routes associated with the /admin path
 */
export const adminRoutes: Routes = [
    {
        path: 'admin',
        component: LayoutComponent,
        canActivateChild: [AuthGuard],
        data: {
            menuItem: {
                text: 'Admin',
                icon: 'fa-cogs',
                iconBgClass: 'bg-primary-dark',
                requiredPrivileges: ['users', 'arterms', 'roles']
            }
        },
        children: [
            {
                path: 'ar-terms',
                data: {
                    menuItem: {
                        text: 'AR Terms',
                        icon: 'fa-usd',
                        link: '/admin/ar-terms',
                        pageTitle: 'AR Terms',
                        requiredPrivileges: ['arterms']
                    }
                },
                children: [
                    {
                        path: '',
                        pathMatch: 'full',
                        component: ARTermsComponent
                    },
                    {
                        path: 'add',
                        component: ARTermsAddComponent,
                        data: {
                            menuItem: {
                                link: '/admin/ar-terms/add',
                                pageTitle: 'Add AR Term',
                                requiredPrivileges: ['arterms-add']
                            }
                        }
                    },
                    {
                        path: 'detail/:id',
                        component: ARTermsDetailComponent,
                        data: {
                            menuItem: {
                                link: '/admin/ar-terms/detail/:id',
                                pageTitle: 'AR Term Detail',
                                requiredPrivileges: ['arterms']
                            }
                        }
                    }

                ]
            },
            {
                path: 'roles',
                data: {
                    menuItem: {
                        text: 'User Roles',
                        icon: 'fa-shield',
                        link: '/admin/roles',
                        pageTitle: 'Roles',
                        requiredPrivileges: ['roles']
                    }
                },
                children: [
                    {
                        path: '',
                        pathMatch: 'full',
                        component: RoleComponent
                    },
                    {
                        path: 'add',
                        component: RoleAddComponent,
                        data: {
                            menuItem: {
                                link: '/admin/roles/add',
                                pageTitle: 'Add Role',
                                requiredPrivileges: ['roles-add']
                            }
                        }
                    },
                    {
                        path: 'detail/:id',
                        component: RoleDetailComponent,
                        data: {
                            menuItem: {
                                link: '/admin/roles/detail/:id',
                                pageTitle: 'Role Detail',
                                requiredPrivileges: ['roles']
                            }
                        }
                    }

                ]
            },
            {
                path: 'users',
                component: UserComponent,
                data: {
                    menuItem: {
                        text: 'Users',
                        link: '/admin/users',
                        icon: 'fa-users',
                        pageTitle: 'Users',
                        requiredPrivileges: ['users']
                    }
                }
            },
            {
                path: 'addresses',
                data: {
                    menuItem: {
                        text: 'Addresses',
                        icon: 'fa-address-card',
                        link: '/admin/addresses',
                        pageTitle: 'Addresses',
                        requiredPrivileges: ['addresses']
                    }
                },
                children: [
                    {
                        path: '',
                        pathMatch: 'full',
                        component: AddressComponent
                    },
                    {
                        path: ':id', component: AddressDetailComponent,
                        data: {
                            menuItem: {
                                link: '/admin/addresses/:id',
                                pageTitle: 'Address Detail',
                                requiredPrivileges: ['addresses']
                            }
                        }
                    }
                ]
            }
        ]
    }
];