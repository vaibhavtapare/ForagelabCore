import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { EmployeeComponent } from './employee.component'
import { EmployeeAddComponent } from './employee-add/employee-add.component'
import { EmployeeDetailComponent } from './employee-detail/employee-detail.component'
import { employeeRoutes } from './employee-routing.module';
import { DualListBoxModule } from 'ng2-dual-list-box';

import { SharedModule } from '../../shared/shared.module';

/**
 * Module for managing employees
 */
@NgModule({
    declarations: [
        EmployeeComponent,
        EmployeeAddComponent,
        EmployeeDetailComponent
    ],
    imports: [
        SharedModule, 
        DualListBoxModule.forRoot(),
        RouterModule.forChild(employeeRoutes)
    ],
    exports: [
        RouterModule
    ]
})
export class EmployeeModule {
}
