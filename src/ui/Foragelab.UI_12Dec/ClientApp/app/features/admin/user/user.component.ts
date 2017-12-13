import { Component, OnInit } from '@angular/core';

import { AuthenticatedComponentBase } from '../../../shared/bases/authenticated.component.base';

import { UserService } from '../../../core/services/user.service';
import { ModalService } from '../../../core/services/modal.service';
import { NotificationService } from '../../../core/services/notification.service';
import { StateService } from '../../../core/services/state.service';

import { UserGrid, userFullDataTableConfig } from '../../../shared/models/user-grid.model';
import { Pagination } from '../../../shared/models/pagination.model';
import { DataTableConfig, DataTableColumn } from '../../../shared/models/data-table-config.model';

/**
 * Component for displaying a listing of users
 */
@Component({
    templateUrl: './user.component.html'
})
export class UserComponent extends AuthenticatedComponentBase {
    constructor(
        public modalService: ModalService,
        public notificationService: NotificationService,
        private userService: UserService,
        stateService: StateService) {
        super(modalService, notificationService, stateService);
    } 

    usersPagination: Pagination;
    areUsersLoading: boolean = false;
    searchFor: string = '';
    userConfig: DataTableConfig = userFullDataTableConfig;

    ngOnInit() {

        this.userConfig.filter = () => {
            if (this.searchFor.length == 0) {
                return null;
            }
            return 'fullName ctn ' + this.searchFor;

            //return 'emailAddress ctn ' + this.searchFor + ' or ' + 
            //'alias ctn ' + this.searchFor + ' or ' +
            //'phoneNumber ctn ' + this.searchFor + ' or ' +
            //'website ctn ' + this.searchFor + ' or ' +
            //'faxNumber ctn ' + this.searchFor;
        };

        this.loadUsers();
    }

    users: Array<UserGrid>;

    /**
     * Loads the listing of users
     */
    loadUsers() {
        this.areUsersLoading = true;
        this.userService.getUsers(this.userConfig, this.usersPagination).subscribe(
            users => {
                this.users = users.json();
                this.usersPagination = this.getPagination(users);
                this.areUsersLoading = false;
            },
            error => {
                this.notificationService.notify('error', error);
                this.areUsersLoading = false;
            });
    }

    /**
     * Filters the users
     */
    filterChanged() {
        if (this.searchFor.length > 1) {
            this.loadUsers();
        }
    }

    /**
  * Clear the users fliter
  */
    filterClear() {
        
        this.searchFor = '';
        this.loadUsers();
    }
}