import { Inject, Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { Observable } from 'rxjs';

import { AuthenticatedServiceBase } from '../../shared/bases/authenticated.service.base';

import { StateService } from './state.service';

import { UserGrid } from '../../shared/models/user-grid.model';
import { Pagination } from '../../shared/models/pagination.model';
import { DataTableConfig } from '../../shared/models/data-table-config.model';

/**
 * The location service is used to communicate with the API in handling
 * all transactions related to locations.
 */
@Injectable()
export class UserService extends AuthenticatedServiceBase {
    constructor(
        @Inject('API_BASE') API_BASE: string,
        @Inject('API_VERSION') API_VERSION: string,
        http: Http,
        stateService: StateService) {
        super(API_BASE, API_VERSION, http, stateService);
    }

    /**
    * Path appended to the API_BASE URL
    **/
    baseUrl: string = '/users';

    /**
     * Gets all users optionally paginated
     * @param {DataTableConfig} [config] Optional configuration settings for a data table
     * @param {Pagination} [pagination] Optional pagination data for the request
     */
    getUsers(config?: DataTableConfig, pagination?: Pagination) {
        return this.get(this.baseUrl, config, pagination);
    }    

    /**
     * Gets all roles related to the user
     * @param {number} userId Unique identifier of the user
     */
    getRoles(userId: number) {
        return this.get(this.baseUrl + '/' + userId + '/roles');
    }

    /**
     * Adds a role to the specified user
     * @param {number} userId Unique identifier of the user to add the role to
     * @param {number} roleId Unique identifier of the role to add to the user
     */
    addRole(userId: number, roleId: number) {
        return this.post(this.baseUrl + '/' + userId + '/roles/' + roleId, JSON.stringify(roleId));
    }

    /**
     * Removes a role from the specified user
     * @param {number} userId Unique identifier of the user to remove the role from
     * @param {number} roleId Unique identifier of the role to remove from the user
     */
    removeRole(userId: number, roleId: number) {
        return this.delete(this.baseUrl + '/' + userId + '/roles/' + roleId);
    }

    /**
     * Saves a profile image for the user
     * @param {number} id Unique identifier of the user
     * @param {any} file File object of the image to save
     */
    saveProfileImage(id: number, file: any): Observable<any> {
        return this.file(this.baseUrl + '/' + id + '/profile', file);
    }

    /**
     * Archives user
     * @param {number} userId Unique identifier of the user to archive
     */
    archiveUser(userId: number) {
        return this.delete(this.baseUrl + '/' + userId);
    }

    /**
     * Restores the specified user from the archive
     * @param {number} userId Unique identifier of the user to restore from archive
     */
    unarchiveUser(userId: number) {
        return this.post(this.baseUrl + '/' + userId + '/activate', null);
    }
}