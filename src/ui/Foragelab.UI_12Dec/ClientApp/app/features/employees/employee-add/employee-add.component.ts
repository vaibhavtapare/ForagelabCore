import { Component, HostBinding, Renderer } from '@angular/core';
import { Router } from '@angular/router';

import { AuthenticatedComponentBase } from '../../../shared/bases/authenticated.component.base';
import { ModalService } from '../../../core/services/modal.service';
import { NotificationService } from '../../../core/services/notification.service';
import { StateService } from '../../../core/services/state.service';

import { Employee, employeeStatuses, employeeTypes } from '../../../shared/models/employee.model';
import { EmployeeService } from '../../../core/services/employee.service';

/**
 * Component for adding an employee
 */
@Component({
    templateUrl: './employee-add.component.html'
})
export class EmployeeAddComponent extends AuthenticatedComponentBase {
    constructor(
        public modalService: ModalService,
        public notificationService: NotificationService,
        private employeeService: EmployeeService,
        private router: Router,
        stateService: StateService,
        private renderer: Renderer
    ) {
        super(modalService, notificationService, stateService);
    }

    private employeeStatuses: any = employeeStatuses;
    private employeeTypes: any = employeeTypes;

    employee: Employee = new Employee();
    processing: boolean = false;

    /**
    * Saves an employee using the employeeService
    */
    saveEmployee() {
        this.processing = true;
        this.employeeService.saveEmployee(this.employee)
            .subscribe(
            response => {
                let emp: Employee = response.json()
                this.router.navigate(['/employees/detail', emp.id]);
                this.processing = false;
            },
            error => {
                this.notificationService.notify('error', error);
                this.processing = false;
                window.scrollTo(0, 0);
            });
    }
}