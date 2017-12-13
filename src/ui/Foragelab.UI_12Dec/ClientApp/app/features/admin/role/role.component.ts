import { Component } from '@angular/core';

import { AuthenticatedComponentBase } from '../../../shared/bases/authenticated.component.base';
import { ModalService } from '../../../core/services/modal.service';
import { NotificationService } from '../../../core/services/notification.service';
import { StateService } from '../../../core/services/state.service';

import { Role, roleFullDataTableConfig } from '../../../shared/models/role.model';
import { RoleService } from '../../../core/services/role.service';

import { Pagination } from '../../../shared/models/pagination.model';
import { DataTableConfig } from '../../../shared/models/data-table-config.model';

/**
 * Component for use in displaying a listing of roles
 */
@Component({
    templateUrl: './role.component.html'
})
export class RoleComponent extends AuthenticatedComponentBase {
    constructor(
        public modalService: ModalService,
        public notificationService: NotificationService,
        private roleService: RoleService,
        stateService: StateService) {
        super(modalService, notificationService, stateService);
    }

    areRolesLoading: boolean = false;
    searchFor: string = '';
    rolePagination: Pagination;
    rolesConfig: DataTableConfig = roleFullDataTableConfig;

    hasFullPrivileges: boolean = false;

    ngOnInit() {
        this.hasFullPrivileges = this.stateService.hasPrivilege('roles - full');

        this.rolesConfig.filter = () => {
            if (this.searchFor.length == 0) {
                return null;
            }
            return 'name ctn ' + this.searchFor;
        };

        this.loadRoles();
    }

    roles: Array<Role>;

    /**
     * Loads the list of roles via the RoleService
     */
    loadRoles() {
        this.areRolesLoading = true;
        this.roleService.getRoles(this.rolesConfig, this.rolePagination).subscribe(
            roles => {
                this.roles = roles.json();
                this.rolePagination = this.getPagination(roles);
                this.areRolesLoading = false;
            },
            error => {
                this.notificationService.notify('error', error);
                this.areRolesLoading = false;
            });
    }

    /**
     * Filters the listing of roles
     */
    filterChanged() {
        if (this.searchFor.length > 1) {
            this.loadRoles();
        }
    }
}