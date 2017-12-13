import { Component } from '@angular/core';

import { AuthenticatedComponentBase } from '../../shared/bases/authenticated.component.base';
import { ModalService } from '../../core/services/modal.service';
import { NotificationService } from '../../core/services/notification.service';
import { StateService } from '../../core/services/state.service';

import { Employee, employeeFullDataTableConfig } from '../../shared/models/employee.model';
import { EmployeeService } from '../../core/services/employee.service';

import { Pagination } from '../../shared/models/pagination.model';
import { DataTableConfig } from '../../shared/models/data-table-config.model';

/**
 * Component to list employees 
 */
@Component({
    templateUrl: './employee.component.html'
})
export class EmployeeComponent extends AuthenticatedComponentBase {
    constructor(
        public modalService: ModalService,
        public notificationService: NotificationService,
        private employeeService: EmployeeService,
        stateService: StateService) {
        super(modalService, notificationService, stateService);
    }

    areEmployeesLoading: boolean = false;
    searchFor: string = '';
    employeePagination: Pagination;
    employeesConfig: DataTableConfig = employeeFullDataTableConfig;

    hasFullPrivileges: boolean = false;

    ngOnInit() {
        this.hasFullPrivileges = this.stateService.hasPrivilege('employees - full');

        this.employeesConfig.filter = () => {
            if (this.searchFor.length == 0) {
                return null;
            }
            return 'firstName ctn ' + this.searchFor; // + ' or ' +
            //'alias ctn ' + this.searchFor + ' or ' +
            //'phoneNumber ctn ' + this.searchFor + ' or ' +
            //'website ctn ' + this.searchFor + ' or ' +
            //'faxNumber ctn ' + this.searchFor;
        };

        this.loadEmployees();
    }

    employees: Array<Employee>;

    /**
     * Loads existing employees
     */
    loadEmployees() {
        this.areEmployeesLoading = true;
        this.employeeService.getEmployees(this.employeesConfig, this.employeePagination).subscribe(
            employees => {
                this.employees = employees.json();
                this.employeePagination = this.getPagination(employees);
                this.areEmployeesLoading = false;
            },
            error => {
                this.notificationService.notify('error', error);
                this.areEmployeesLoading = false;
            });
    }

    /**
     * Refilters the list of users when the "search for" is changed
     */
    filterChanged() {
        if (this.searchFor.length > 1) {
            this.loadEmployees();
        }
    }
}