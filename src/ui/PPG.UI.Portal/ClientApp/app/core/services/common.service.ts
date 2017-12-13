import { Inject, Injectable } from '@angular/core';
import { Http } from '@angular/http';

import { AuthenticatedServiceBase } from '../../shared/bases/authenticated.service.base';

import { StateService } from './state.service';

import { Country } from '../../shared/models/country.model';

/**
 * The common service is used to communicate with the API in receiving
 * read only datasets.
 */
@Injectable()
export class CommonService extends AuthenticatedServiceBase {
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
    baseUrl: string = '/common';

    /**
     * Gets all countries from the API
     */
    getCountries() {
        return this.get(this.baseUrl + '/countries');
    }

    /**
     * Gets all states/provinces from the API
     */
    getStates() {
        return this.get(this.baseUrl + '/states');
    }
}
