import { Inject, Injectable } from '@angular/core';
import { Http } from '@angular/http';

import { AuthenticatedServiceBase } from '../../shared/bases/authenticated.service.base';

import { StateService } from './state.service';

import { ARTerm } from '../../shared/models/ar-term.model';
import { Pagination } from '../../shared/models/pagination.model';
import { DataTableConfig } from '../../shared/models/data-table-config.model';

/**
 * The AR terms service is used to communicate with the API in handling
 * all transactions related to accounts receivable terms.
 */
@Injectable()
export class ARTermService extends AuthenticatedServiceBase {
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
    baseUrl: string = '/arterms';

    /**
     * Gets all AR terms optionally paginated
     * @param {DataTableConfig} [config] Optional configuration settings for a data table
     * @param {Pagination} [pagination] Optional pagination data for the request
     */
    getARTerms(config?: DataTableConfig, pagination?: Pagination) {
        return this.get(this.baseUrl, config, pagination);
    }

    /**
     * Returns a specific AR term from the API based on the provided id
     * @param {number} id Unique identifier of the AR term to retrieve
     */
    getARTerm(id: number) {
        return this.get(this.baseUrl + '/' + id);
    }

    /**
     * Saves or creates an AR term depending on whether the arTerm.id is specified and greater than zero
     * @param {ARTerm} arTerm The AR term object to save
     */
    saveARTerm(arTerm: ARTerm) {
        let body = JSON.stringify(arTerm);

        // no arTerm.id means we should add the ARTerm.
        if (arTerm.id == null || arTerm.id == 0) {
            return this.post(this.baseUrl, body);
        }
        else {
            return this.put(this.baseUrl + '/' + arTerm.id, body);
        }
    }

    /**
     * Deletes the AR term identified by the provided id
     * @param {number} id Unique identifier of the AR term to delete
     */
    deleteARTerm(id: number) {
        return this.delete(this.baseUrl + '/' + id);
    }
}