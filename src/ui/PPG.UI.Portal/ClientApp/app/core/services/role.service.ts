import { Inject, Injectable } from '@angular/core';
import { Http } from '@angular/http';

import { AuthenticatedServiceBase } from '../../shared/bases/authenticated.service.base';

import { StateService } from './state.service';

import { Role } from '../../shared/models/role.model';
import { Permission } from '../../shared/models/permission.model';

import { Pagination } from '../../shared/models/pagination.model';
import { DataTableConfig } from '../../shared/models/data-table-config.model';

/**
 * The role service is used to communicate with the API in handling
 * all transactions related to roles.
 */
@Injectable()
export class RoleService extends AuthenticatedServiceBase {
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
    baseUrl: string = '/roles';

    /**
     * Gets all roles optionally paginated
     * @param {DataTableConfig} [config] Optional configuration settings for a data table
     * @param {Pagination} [pagination] Optional pagination data for the request
     */
    getRoles(config?: DataTableConfig, pagination?: Pagination) {
        return this.get(this.baseUrl, config, pagination);
    }

    /**
     * Returns a specific role from the API based on the provided id
     * @param {number} id Unique identifier of the role to retrieve
     */
    getRole(id: number) {
        return this.get(this.baseUrl + '/' + id);
    }

    /**
     * Saves or creates a role depending on whether the role.id is specified and greater than zero
     * @param {Role} role The role object to save
     */
    saveRole(role: Role) {
        let body = JSON.stringify(role);

        // no role.id means we should add the role.
        if (role.id == null || role.id == 0) {
            return this.post(this.baseUrl, body);
        }
        else {
            return this.put(this.baseUrl + '/' + role.id, body);
        }
    }

    /**
     * Deletes the role identified by the provided id
     * @param {number} id Unique identifier of the role to delete
     */
    deleteRole(id: number) {
        return this.delete(this.baseUrl + '/' + id);
    }

    /**
     * Gets all users associated with the role
     * @param {number} id Unique identifier of the role
     * @param {DataTableConfig} [config] Optional configuration settings for a data table
     * @param {Pagination} [pagination] Optional pagination data for the request
     */
    getUsers(id: number, config?: DataTableConfig, pagination?: Pagination) {
        return this.get(this.baseUrl + '/' + id + '/users', config, pagination);
    }

    /**
     * Gets all permissions associated with the role
     * @param {number} id Unique identifier of the role
     * @param {DataTableConfig} [config] Optional configuration settings for a data table
     * @param {Pagination} [pagination] Optional pagination data for the request
     */
    getPermissions(id: number, config?: DataTableConfig, pagination?: Pagination) {
        return this.get(this.baseUrl + '/' + id + '/permissions', config, pagination);
    }

    /**
     * Adds a permission to the role
     * @param {number} roleId Unique identifier of the role to add the permission to
     * @param {Permission} permission The permission object to save
     */
    addPermission(roleId: number, permission: Permission) {
        let body = JSON.stringify(permission);
        return this.post(this.baseUrl + '/' + roleId + '/permissions', body);
    }

    /**
     * Removes a permission from the role
     * @param {number} roleId Unique identifier of the role to remove the permission from
     * @param {number} permissionId Unique identifier of the permission to remove
     */
    deletePermission(roleId: number, permissionId: number) {
        return this.delete(this.baseUrl + '/' + roleId + '/permissions/' + permissionId);
    }
}