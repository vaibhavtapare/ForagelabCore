import { Inject, Injectable } from '@angular/core';
import { Http } from '@angular/http';

import { AuthenticatedServiceBase } from '../../shared/bases/authenticated.service.base';

import { StateService } from './state.service';

import { Address } from '../../shared/models/address.model';
import { Employee } from '../../shared/models/employee.model';
import { User } from '../../shared/models/user.model';

import { Pagination } from '../../shared/models/pagination.model';
import { DataTableConfig } from '../../shared/models/data-table-config.model';
import { UserClientLocation } from "../../shared/models/userclientlocation.model";

/**
 * The employee service is used to communicate with the API in handling
 * all transactions related to employees.
 */
@Injectable()
export class EmployeeService extends AuthenticatedServiceBase {
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
    baseUrl: string = '/employees';

    /**
     * Gets all employees optionally paginated
     * @param {DataTableConfig} [config] Optional configuration settings for a data table
     * @param {Pagination} [pagination] Optional pagination data for the request
     */
    getEmployees(config?: DataTableConfig, pagination?: Pagination) {
        return this.get(this.baseUrl, config, pagination);
    }

    /**
     * Returns a specific employee from the API based on the provided id
     * @param {number} id Unique identifier of the employee to retrieve
     */
    getEmployee(id: number) {
        return this.get(this.baseUrl + '/' + id);
    }

    /**
     * Saves or creates an employee depending on whether the employee.id is specified and greater than zero
     * @param {Employee} employee The employee object to save
     */
    saveEmployee(employee: Employee) {
        let body = JSON.stringify(employee);

        // no employee.id means we should add the employee.
        if (employee.id == null || employee.id == 0) {
            return this.post(this.baseUrl, body);
        }
        else {
            return this.put(this.baseUrl + '/' + employee.id, body);
        }
    }

    /**
     * Deletes the employee identified by the provided id
     * @param {number} id Unique identifier of the employee to delete
     */
    deleteEmployee(id: number) {
        return this.delete(this.baseUrl + '/' + id);
    }

    /**
     * Gets all transactions related to the employee
     * @param {number} id Unique identifier of the employee
     * @param {DataTableConfig} [config] Optional configuration settings for a data table
     * @param {Pagination} [pagination] Optional pagination data for the request
     */
    getTransactions(id: number, config?: DataTableConfig, pagination?: Pagination) {
        return this.get(this.baseUrl + '/' + id + '/transactions', config, pagination);
    }

    /**
     * Gets the address associated with the employee
     * @param {number} id Unique identifier of the employee
     */
    getAddress(id: number) {
        return this.get(this.baseUrl + '/' + id + '/address');
    }

    /**
     * Saves or creates an address depending on whether the address.id is specified and greater than zero
     * @param {number} id Unique identifier of the employee to save the address to
     * @param {Address} address The address object to save
     */
    saveAddress(id: number, address: Address) {
        let body = JSON.stringify(address);

        // no address.id means we should add the address.
        if (address.id == null || address.id == 0) {
            return this.post(this.baseUrl + '/' + id + '/address', body);
        }
        else {
            return this.put(this.baseUrl + '/' + id + '/address', body);
        }
    }

    /**
     * Gets the user account associated with the employee
     * @param {number} id Unique identifier of the employee
     */
    getUser(id: number) {
        return this.get(this.baseUrl + '/' + id + '/user');
    }

    /**
     * Saves or creates an user depending on whether the user.id is specified and greater than zero
     * @param {number} id Unique identifier of the employee to save the user to
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
     * Gets the user client location associated with the user
     * @param {number} id Unique identifier of the user
     */
    getUserclientlocation(userId: number) {
        return this.get(this.baseUrl + '/userclientlocation/' + userId);
    }

    /**
     * Creates an userclientlocation
     * @param {UserClientLocation} userClientLocation The userclientlocation object to save
     */
    createUserClientLocation(userClientLocation: UserClientLocation) {
        let body = JSON.stringify(userClientLocation);
        return this.post(this.baseUrl + '/userclientlocation', body);
    }

    /**
     * Creates an userclientlocation
     * @param {Array<UserClientLocation>} userClientLocation The userclientlocation object to save
     */
    createUserClientLocations(userClientLocations: Array<UserClientLocation>) {
        let body = JSON.stringify(userClientLocations);
        return this.post(this.baseUrl + '/userclientlocations', body);
    }

    /**
     * Deletes an userclientlocation by client
     * @param {Array<number>} clients Array of unique identifier of the userclientlocation to remove
     * @param {number} userId Unique identifier of the userclientlocation to remove
     */
    RemoveUserClientLocationByClient(clients: Array<number>,userId:number) {
        return this.post(this.baseUrl + '/userclientlocation/client/'+ userId,clients);
    }

    /**
     * Deletes an userclientlocation by location
     * @param {Array<number>} locations Array of unique identifier of the userclientlocation to remove
     * @param {number} userId Unique identifier of the userclientlocation to remove
     */
    RemoveUserClientLocationByLocation(locations: Array<number>, userId: number) {
        return this.post(this.baseUrl + '/userclientlocation/location/' + userId, locations);
    }

    /**
     * Deletes an userclientlocation
     * @param {number} userId Unique identifier of the userclientlocation to remove
     */
    RemoveUserClientLocationByUser(userId: number) {
        return this.delete(this.baseUrl + '/userclientlocation' + '/' + userId);
    }

}