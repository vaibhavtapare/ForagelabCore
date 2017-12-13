import { Inject, Injectable } from '@angular/core';
import { Http } from '@angular/http';

import { AuthenticatedServiceBase } from '../../shared/bases/authenticated.service.base';

import { StateService } from './state.service';

import { Address } from '../../shared/models/address.model';
import { Client } from '../../shared/models/client.model';
import { Location } from '../../shared/models/location.model';
import { Job } from '../../shared/models/job.model';
import { Contact } from '../../shared/models/contact.model';
import { Pagination } from '../../shared/models/pagination.model';
import { DataTableConfig } from '../../shared/models/data-table-config.model';

/**
 * The client service is used to communicate with the API in handling
 * all transactions related to clients.
 */
@Injectable()
export class ClientService extends AuthenticatedServiceBase {
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
    baseUrl: string = '/clients';

    /**
     * Gets all clients optionally paginated
     * @param {DataTableConfig} [config] Optional configuration settings for a data table
     * @param {Pagination} [pagination] Optional pagination data for the request
     */
    getClients(config?: DataTableConfig, pagination?: Pagination) {
        return this.get(this.baseUrl, config, pagination);
    }

    /**
     * Returns a specific client from the API based on the provided id
     * @param {number} id Unique identifier of the client to retrieve
     */
    getClient(clientId: number) {
        return this.get(this.baseUrl + '/' + clientId);
    }

    /**
     * Saves or creates an client depending on whether the client.id is specified and greater than zero
     * @param {Client} client The client object to save
     */
    saveClient(client: Client) {
        let body = JSON.stringify(client);

        // no client.id means we should add the client.
        if (client.id == null || client.id == 0) {
            return this.post(this.baseUrl, body);
        }
        else {
            return this.put(this.baseUrl + '/' + client.id, body);
        }
    }

    /**
     * Deletes the client identified by the provided id
     * @param {number} clientId Unique identifier of the client to delete
     */
    deleteClient(clientId: number) {
        return this.delete(this.baseUrl + '/' + clientId);
    }

    getTransactions(clientId: number, config?: DataTableConfig, pagination?: Pagination) {
        return this.get(this.baseUrl + '/' + clientId + '/transactions', config, pagination);
    }

    /* locations */
    getLocations(clientId: number, config?: DataTableConfig, pagination?: Pagination) {
        return this.get(this.baseUrl + '/' + clientId + '/locations', config, pagination);
    }

    getLocation(clientId: number, locationId: number) {
        return this.get(this.baseUrl + '/' + clientId + '/locations/' + locationId);
    }

    saveLocation(clientId: number, location: Location) {
        let body = JSON.stringify(location);

        // no location.id means we should add the location.
        if (location.id == null || location.id == 0) {
            return this.post(this.baseUrl + '/' + clientId + '/locations/', body);
        }
        else {
            return this.put(this.baseUrl + '/' + clientId + '/locations/' + location.id, body);
        }
    }

    deleteLocation(clientId: number, locationId: number) {
        return this.delete(this.baseUrl + '/' + clientId + '/locations/' + locationId);
    }

    /* jobs */
    getJobs(clientId: number, config?: DataTableConfig, pagination?: Pagination) {
        return this.get(this.baseUrl + '/' + clientId + '/jobs', config, pagination);
    }

    getJob(clientId: number, jobId: number) {
        return this.get(this.baseUrl + '/' + clientId + '/jobs/' + jobId);
    }

    saveJob(clientId: number, job: Job) {
        let body = JSON.stringify(job);

        // no job.id means we should add the job.
        if (job.id == null || job.id == 0) {
            return this.post(this.baseUrl + '/' + clientId + '/jobs/', body);
        }
        else {
            return this.put(this.baseUrl + '/' + clientId + '/jobs/' + job.id, body);
        }
    }

    deleteJob(clientId: number, jobId: number) {
        return this.delete(this.baseUrl + '/' + clientId + '/jobs/' + jobId);
    }

    /* contacts */
    getContacts(clientId: number, config?: DataTableConfig, pagination?: Pagination) {
        return this.get(this.baseUrl + '/' + clientId + '/contacts', config, pagination);
    }

    getContact(clientId: number, contactId: number) {
       return this.get(this.baseUrl + '/' + clientId + '/contacts/' + contactId);
    }

    saveContact(clientId: number, contact: Contact) {
        let body = JSON.stringify(contact);

        // no contact.id means we should add the contact.
        if (contact.id == null || contact.id == 0) {
            return this.post(this.baseUrl + '/' + clientId + '/contacts/', body);
        }
        else {
            return this.put(this.baseUrl + '/' + clientId + '/contacts/' + contact.id, body);
        }
    }

    deleteContact(clientId: number, contactId: number) {
        return this.delete(this.baseUrl + '/' + clientId + '/contacts/' + contactId);
    }
}