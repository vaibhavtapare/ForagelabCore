import { Inject, Injectable } from '@angular/core';
import { Http } from '@angular/http';

import { AuthenticatedServiceBase } from '../../shared/bases/authenticated.service.base';

import { StateService } from './state.service';

import { Address } from '../../shared/models/address.model';
import { Contact } from '../../shared/models/contact.model';
import { Job } from '../../shared/models/job.model';
import { Location } from '../../shared/models/location.model';
import { Pagination } from '../../shared/models/pagination.model';
import { DataTableConfig } from '../../shared/models/data-table-config.model';

/**
 * The location service is used to communicate with the API in handling
 * all transactions related to locations.
 */
@Injectable()
export class LocationService extends AuthenticatedServiceBase {
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
    baseUrl: string = '/locations';

    /**
     * Gets all locations optionally paginated
     * @param {DataTableConfig} [config] Optional configuration settings for a data table
     * @param {Pagination} [pagination] Optional pagination data for the request
     */
    getLocations(config?: DataTableConfig, pagination?: Pagination) {
        return this.get(this.baseUrl, config, pagination);
    }

    /**
     * Returns a specific location from the API based on the provided id
     * @param {number} id Unique identifier of the location to retrieve
     */
    getLocation(id: number) {
        return this.get(this.baseUrl + '/' + id);
    }

    /**
     * Saves or creates an location depending on whether the location.id is specified and greater than zero
     * @param {Location} location The employee object to save
     */
    saveLocation(location: Location) {
        let body = JSON.stringify(location);

        // no location.id means we should add the location.
        if (location.id == null || location.id == 0) {
            return this.post(this.baseUrl, body);
        }
        else {
            return this.put(this.baseUrl + '/' + location.id, body);
        }
    }

    /**
     * Deletes the location identified by the provided id
     * @param {number} id Unique identifier of the location to delete
     */
    deleteLocation(id: number) {
        return this.delete(this.baseUrl + '/' + id);
    }

    /**
     * Gets all transactions related to the location
     * @param {number} id Unique identifier of the location
     * @param {DataTableConfig} [config] Optional configuration settings for a data table
     * @param {Pagination} [pagination] Optional pagination data for the request
     */
    getTransactions(locationId: number, config?: DataTableConfig, pagination?: Pagination) {
        return this.get(this.baseUrl + '/' + locationId + '/transactions', config, pagination);
    }

    /**
     * Gets all jobs related to the location
     * @param {number} id Unique identifier of the location
     * @param {DataTableConfig} [config] Optional configuration settings for a data table
     * @param {Pagination} [pagination] Optional pagination data for the request
     */
    getJobs(id: number, config?: DataTableConfig, pagination?: Pagination) {
        return this.get(this.baseUrl + '/' + id + '/jobs', config, pagination);
    }

    /**
     * Gets a specific job associated with the location
     * @param {number} id Unique identifier of the location
     * @param {number} jobId Unique identifier of the job to retrieve
     */
    getJob(id: number, jobId: number) {
        return this.get(this.baseUrl + '/' + id + '/jobs/' + jobId);
    }

    /**
     * Saves or creates a job depending on whether the job.id is specified and greater than zero
     * @param {number} id Unique identifier of the location to save the address to
     * @param {Job} job The job object to save
     */
    saveJob(id: number, job: Job) {
        let body = JSON.stringify(job);

        // no job.id means we should add the job.
        if (job.id == null || job.id == 0) {
            return this.post(this.baseUrl + '/' + id + '/jobs/', body);
        }
        else {
            return this.put(this.baseUrl + '/' + id + '/jobs/' + job.id, body);
        }
    }

    /**
     * Deletes the job identified by the provided id
     * @param {number} id Unique identifier of the location
     * @param {number} jobId Unique identifier of the job to delete
     */
    deleteJob(id: number, jobId: number) {
        return this.delete(this.baseUrl + '/' + id + '/jobs/' + jobId);
    }

    /**
     * Gets all contacts related to the location
     * @param {number} id Unique identifier of the location
     * @param {DataTableConfig} [config] Optional configuration settings for a data table
     * @param {Pagination} [pagination] Optional pagination data for the request
     */
    getContacts(id: number, config?: DataTableConfig, pagination?: Pagination) {
        return this.get(this.baseUrl + '/' + id + '/contacts', config, pagination);
    }

    /**
     * Gets a specific contact associated with the location
     * @param {number} id Unique identifier of the location
     * @param {number} contactId Unique identifier of the contact to retrieve
     */
    getContact(id: number, contactId: number) {
        return this.get(this.baseUrl + '/' + id + '/contacts/' + contactId);
    }

    /**
     * Saves or creates a contact depending on whether the contact.id is specified and greater than zero
     * @param {number} id Unique identifier of the location to save the address to
     * @param {Contact} contact The contact object to save
     */
    saveContact(id: number, contact: Contact) {
        let body = JSON.stringify(contact);

        // no contact.id means we should add the contact.
        if (contact.id == null || contact.id == 0) {
            return this.post(this.baseUrl + '/' + id + '/contacts/', body);
        }
        else {
            return this.put(this.baseUrl + '/' + id + '/contacts/' + contact.id, body);
        }
    }

    /**
     * Deletes the contact identified by the provided id
     * @param {number} id Unique identifier of the location
     * @param {number} contactId Unique identifier of the contact to delete
     */
    deleteContact(id: number, contactId: number) {
        return this.delete(this.baseUrl + '/' + id + '/contacts/' + contactId);
    }
}