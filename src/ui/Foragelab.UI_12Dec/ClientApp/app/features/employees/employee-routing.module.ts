import { Routes } from '@angular/router';

import { MenuItem } from '../../shared/models/menu-item.model';

import { LayoutComponent } from '../../layout/layout.component';

import { EmployeeComponent } from './employee.component'
import { EmployeeAddComponent } from './employee-add/employee-add.component'
import { EmployeeDetailComponent } from './employee-detail/employee-detail.component'
import { AuthGuard } from '../../shared/guards/auth.guard';

export const employeeRoutes: Routes = [
    {
        path: 'employees',
        component: LayoutComponent,
        canActivateChild: [AuthGuard],
        data: {
            menuItem: {
                text: 'Employees',
                link: '/employees',
                icon: 'fa-id-badge',
                pageTitle: 'Employees',
                iconBgClass: 'bg-complete',
                requiredPrivileges: ['employees']
            }
        },
        children: [
            {
                path: '', pathMatch: 'full', component: EmployeeComponent
            },
            {
                path: 'add', component: EmployeeAddComponent,
                data: {
                    menuItem: {
                        link: '/employees/add',
                        pageTitle: 'Add Employee',
                        requiredPrivileges: ['employees-add']
                    }
                }
            },
            {
                path: 'detail/:id', component: EmployeeDetailComponent,
                data: {
                    menuItem: {
                        link: '/employees/detail:id',
                        pageTitle: 'Employee Detail',
                        requiredPrivileges: ['employees']
                    }
                }
            }
        ]
    }
];