import { Inject, Injectable } from '@angular/core';
import { Http } from '@angular/http';

import { AuthenticatedServiceBase } from '../../shared/bases/authenticated.service.base';
import { StateService } from './state.service';
/**
 * The common service is used to communicate with the API in receiving
 * read only datasets.
 */
@Injectable()
export class CreatePDFService extends AuthenticatedServiceBase {
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
    baseUrl: string = '/testpdf';

       /**
     * Generates test PDF from the API
     */
    generateTestPDF() {
        return this.get(this.baseUrl + '/testpdfdownload');
    }

    getStates() {
        debugger
        return this.get('/common' + '/states');
    }
}
