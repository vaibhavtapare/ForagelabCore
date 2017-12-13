import { Inject, Injectable } from '@angular/core';
import { Http } from '@angular/http';

import { AuthenticatedServiceBase } from '../../shared/bases/authenticated.service.base';

import { StateService } from './state.service';

import { Contact } from '../../shared/models/contact.model';
import { Pagination } from '../../shared/models/pagination.model';
import { DataTableConfig } from '../../shared/models/data-table-config.model';
import { User } from "../../shared/models/user.model";

/**
 * The contact service is used to communicate with the API in handling
 * all transactions related to contacts.
 */
@Injectable()
export class ContactService extends AuthenticatedServiceBase {
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
    baseUrl: string = '/contacts';

    /**
     * Gets all contacts optionally paginated
     * @param {DataTableConfig} [config] Optional configuration settings for a data table
     * @param {Pagination} [pagination] Optional pagination data for the request
     */
    getContacts(config?: DataTableConfig, pagination?: Pagination) {
        return this.get(this.baseUrl, config, pagination);
    }

    /**
     * Returns a specific contact from the API based on the provided id
     * @param {number} id Unique identifier of the contact to retrieve
     */
    getContact(id: number) {
        return this.get(this.baseUrl + '/' + id);
    }

    /**
     * Saves or creates an contact depending on whether the contact.id is specified and greater than zero
     * @param {Contact} contact The contact object to save
     */
    saveContact(contact: Contact) {
        let body = JSON.stringify(contact);

        // no contact.id means we should add the contact.
        if (contact.id == null || contact.id == 0) {
            return this.post(this.baseUrl, body);
        }
        else {
            return this.put(this.baseUrl + '/' + contact.id, body);
        }
    }

    /**
     * Deletes the contact identified by the provided id
     * @param {number} id Unique identifier of the contact to delete
     */
    deleteContact(id: number) {
        return this.delete(this.baseUrl + '/' + id);
    }

    /**
     * Gets all transactions related to the contact
     * @param {number} id Unique identifier of the contact
     * @param {DataTableConfig} [config] Optional configuration settings for a data table
     * @param {Pagination} [pagination] Optional pagination data for the request
     */
    getTransactions(id: number, config?: DataTableConfig, pagination?: Pagination) {
        return this.get(this.baseUrl + '/' + id + '/transactions', config, pagination);
    }

    /**
     * Gets the user account associated with the contact
     * @param {number} id Unique identifier of the contact
     */
    getUser(id: number) {
        return this.get(this.baseUrl + '/' + id + '/user');
    }

    /**
     * Saves or creates an user depending on whether the user.id is specified and greater than zero
     * @param {number} id Unique identifier of the contact to save the user to
     * @param {User} user The user object to save
     */
    saveUser(id: number, user: User) {
        let body = JSON.stringify(user);

        // no location.id means we should add the location.
        if (user.id == null || user.id == 0) {
            return this.post(this.baseUrl + '/' + id + '/user', body);
        }
        else {
            return this.put(this.baseUrl + '/' + id + '/user', body);
        }
    }

    /**
     * Returns a specific contact from the API based on the provided user id
     * @param {number} userid Unique identifier of the user to retrieve contact
     */
    getContactByUser(userid: number) {
        return this.get(this.baseUrl + '/user/' + userid);
    }

}