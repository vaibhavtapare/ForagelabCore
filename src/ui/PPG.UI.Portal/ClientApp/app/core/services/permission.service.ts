import { Inject, Injectable } from '@angular/core';
import { Http } from '@angular/http';

import { AuthenticatedServiceBase } from '../../shared/bases/authenticated.service.base';

import { StateService } from './state.service';

import { Permission } from '../../shared/models/permission.model';

/**
 * The permission service is used to retrieve all permissions
 * from the API.
 */
@Injectable()
export class PermissionService extends AuthenticatedServiceBase {
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
    baseUrl: string = '/permissions';

    /**
     * Gets all permissions from the API
     */
    getPermissions() {
        return this.get(this.baseUrl);
    }    
}