import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import * as _ from 'lodash';

import { AuthenticatedComponentBase } from '../../../../shared/bases/authenticated.component.base';
import { ModalService } from '../../../../core/services/modal.service';
import { NotificationService } from '../../../../core/services/notification.service';
import { StateService } from '../../../../core/services/state.service';

import { Role } from '../../../../shared/models/role.model';
import { RoleService } from '../../../../core/services/role.service';
import { PermissionService } from '../../../../core/services/permission.service';

import { UserGrid, userFullDataTableConfig } from '../../../../shared/models/user-grid.model';
import { Permission, permissionFullDataTableConfig } from '../../../../shared/models/permission.model';

import { Pagination } from '../../../../shared/models/pagination.model';
import { DataTableConfig } from '../../../../shared/models/data-table-config.model';

/**
 * Component for editing or deleting a role
 */
@Component({
    templateUrl: './role-detail.component.html'
})
export class RoleDetailComponent extends AuthenticatedComponentBase implements OnInit {
    constructor(
        public modalService: ModalService,
        private route: ActivatedRoute,
        private router: Router,
        public notificationService: NotificationService,
        private roleService: RoleService,
        private permissionService: PermissionService,
        stateService: StateService) {
        super(modalService, notificationService, stateService);
    }

    role: Role = new Role();
    processing: boolean = false;

    usersLoading: boolean = false;
    usersPagination: Pagination = new Pagination(null);
    usersConfig: DataTableConfig = userFullDataTableConfig;
    users: Array<UserGrid>;
    userSearchFor: string = '';

    permissionsLoading: boolean = false;
    permissions: Array<Permission>;
    allPermissions: Array<Permission>;
    permissionGroups: any;

    ngOnInit() {
        this.loadRole();
        this.loadAllPermissions();

        this.usersConfig.filter = () => {
            if (this.userSearchFor.length == 0) {
                return null;
            }
            return 'emailAddress ctn ' + this.userSearchFor; // + ' or ' +
            //'alias ctn ' + this.searchFor + ' or ' +
            //'phoneNumber ctn ' + this.searchFor + ' or ' +
            //'website ctn ' + this.searchFor + ' or ' +
            //'faxNumber ctn ' + this.searchFor;
        };
    }

    /**
     * Loads the role based on the {id} route parameter
     */
    loadRole() {
        this.processing = true;
        this.route.params
            .switchMap((params: Params) => this.roleService.getRole(+params['id']))
            .subscribe(
            role => {
                this.role = role.json();
                this.processing = false;
                this.loadPermissions();
                this.loadUsers();
            },
            error => {
                this.router.navigate(['/admin/roles']);
                this.processing = false;
            });
    }

    /**
     * Saves the role via the RoleService
     */
    saveRole() {
        this.processing = true;
        this.roleService.saveRole(this.role)
            .subscribe(
            response => {
                let r: Role = response.json()
                this.notificationService.notify('success', this.role.name + ' was saved successfully.');
                this.processing = false;
                window.scrollTo(0, 0);
            },
            error => {
                this.notificationService.notify('error', error);
                this.processing = false;
                window.scrollTo(0, 0);
            });
    }

    /**
     * Gets a listing of all permissions
     */
    loadAllPermissions() {
        this.permissionService.getPermissions()
            .subscribe(
            response => {
                this.allPermissions = response.json();
            },
            error => {
                this.notificationService.notify('error', error);
            });
    }

    /**
     * Loads a listing of all users associated with the current role
     */
    loadUsers() {
        this.usersLoading = true;
        this.roleService.getUsers(this.role.id, this.usersConfig, this.usersPagination)
            .subscribe(
            response => {
                this.users = response.json();
                this.usersPagination = this.getPagination(response);
                this.usersLoading = false;
            },
            error => {
                this.notificationService.notify('error', error);
                this.usersLoading = false;
            });
    }

    /**
     * Loads the permissions associated with this role
     */
    loadPermissions() {
        this.permissionsLoading = true;

        let permPagination: Pagination = new Pagination(null);
        permPagination.pageSize = 500;

        this.roleService.getPermissions(this.role.id, null, permPagination)
            .subscribe(
            response => {
                this.permissions = response.json();
                this.permissionGroups = _.groupBy(this.allPermissions, 'groupName');
                this.permissionsLoading = false;
            },
            error => {
                this.notificationService.notify('error', error);
                this.permissionsLoading = false;
            });
    }

    /**
     * Filters users based on input provided from user
     */
    userFilterChanged() {
        if (this.userSearchFor.length > 1) {
            this.loadUsers();
        }
    }

    /**
     * Toggles whether a permission should be associated with the role
     * @param {Permission} permission Permission to add/remove from the role
     */
    togglePermission(permission: Permission) {
        if (this.isInRole(permission.id)) {
            this.removePermission(permission);
        } 
        else {
            this.addPermission(permission);
        }
    }

    /**
     * Removes a permission from the role
     * @param {Permission} permission Permission to remove from the role
     */
    removePermission(permission: Permission) {
        this.roleService.deletePermission(this.role.id, permission.id)
            .subscribe(
            response => {
                this.permissions = _.without(this.permissions, _.find(this.permissions, function (o) { return o.id == permission.id; })); 
            },
            error => {
                this.notificationService.notify('error', error);
                this.permissionsLoading = false;
            });
    }

    /**
     * Adds a permission to the role
     * @param {Permission} permission Permission to add to the role
     */
    addPermission(permission: Permission) {
        this.roleService.addPermission(this.role.id, permission)
            .subscribe(
            response => {
                this.permissions.push(permission);
            },
            error => {
                this.notificationService.notify('error', error._body);
                this.permissionsLoading = false;
            });
    }

    /**
     * Returns boolean of whether the provided permission exists in the role
     * @param {number} permissionId Unique identifier of the permission
     */
    isInRole(permissionId: number): boolean {
        return _.find(this.permissions, function (o) { return o.id == permissionId; }) != null;
    }

    /**
     * Deletes the role via the RoleService
     */
    deleteRole() {
        this.processing = true;
        this.roleService.deleteRole(this.role.id)
            .subscribe(
            response => {
                this.notificationService.notify('warning', "The '" + this.role.name + "' role has been deleted.");
                this.closeModal('deleteRole');
                this.processing = false;
                this.router.navigate(['/admin/roles']);
            },
            error => {
                this.notificationService.notify('error', error._body);
                this.processing = false;
                this.closeModal('deleteRole');
            });
    }
}