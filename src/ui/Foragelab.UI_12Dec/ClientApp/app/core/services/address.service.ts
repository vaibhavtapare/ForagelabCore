import { Inject, Injectable } from '@angular/core';
import { Http } from '@angular/http';

import { AuthenticatedServiceBase } from '../../shared/bases/authenticated.service.base';

import { StateService } from './state.service';

import { Address } from '../../shared/models/address.model';
import { PassDownLog } from '../../shared/models/pass-down-log.model';
import { Pagination } from '../../shared/models/pagination.model';
import { DataTableConfig } from '../../shared/models/data-table-config.model';
import { WorkplaceRiskAssessment } from '../../shared/models/workplace-risk-assessment.model';
import { WorkplaceRiskAssessmentResponse } from '../../shared/models/workplace-risk-assessment-response.model';

/**
 * The address service is used to communicate with the API in handling
 * all transactions related to addresses.
 */
@Injectable()
export class AddressService extends AuthenticatedServiceBase {
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
    baseUrl: string = '/addresses';

    /**
     * Gets all Addresses optionally paginated
     * @param {DataTableConfig} [config] Optional configuration settings for a data table
     * @param {Pagination} [pagination] Optional pagination data for the request
     */
    getAddresses(config?: DataTableConfig, pagination?: Pagination) {
        return this.get(this.baseUrl, config, pagination);
    }

    /**
     * Gets all Addresses in a postal code optionally paginated
     * @param {DataTableConfig} [config] Optional configuration settings for a data table
     * @param {Pagination} [pagination] Optional pagination data for the request
     */
    getAddressesByPostalCode(postalCode: string) {
        return this.get(this.baseUrl + '?filter=postalCode eq ' + postalCode);
    }

    /**
     * Gets address specified by the addressId
     * @param {number} addressId Unique identifier of the address
     */
    getAddress(addressId:number) {
        return this.get(this.baseUrl+'/'+addressId);
    }

    /**
     * Saves or creates an address depending on whether the address.id is specified and greater than zero
     * @param {Address} address The address object to save
     */
    saveAddress(address: Address) {
        let body = JSON.stringify(address);

        // no address.id means we should add the address.
        if (address.id == null || address.id == 0) {
            return this.post(this.baseUrl, body);
        }
        else {
            return this.put(this.baseUrl + '/' + address.id, body);
        }
    }

    /**
     * Deletes the address identified by the provided id
     * @param {number} addressId Unique identifier of the address
     */
    deleteAddress(addressId: number) {
        return this.delete(this.baseUrl + '/' + addressId);
    }

    /**
     * Gets pass down logs associated with the address specified by the addressId
     * @param {number} addressId Unique identifier of the address
     * @param {DataTableConfig} [config] Optional configuration settings for a data table
     * @param {Pagination} [pagination] Optional pagination data for the request
     */
    getPassDownLogs(addressId: number, config?: DataTableConfig, pagination?: Pagination) {
        return this.get(this.baseUrl + '/' + addressId + '/passdownlogs', config, pagination);
    }

    /**
     * Gets pass down logs associated with the address specified by the addressId and passDownLogId
     * @param {number} addressId Unique identifier of the job
     * @param {number} passDownLogId Unique identifier of the pass down log
    */
    getPassDownLog(addressId: number, passDownLogId: number) {
        return this.get(this.baseUrl + '/' + addressId + '/passdownlogs' + passDownLogId);
    }

    /**
     * Saves or creates an Pass Down Log depending on whether the passDownLogId is specified and greater than zero
     * @param {PassDownLog} passDownLog The Pass Down Log object to save
     */
    savePassDownLog(addressId: number, passDownLog: PassDownLog) {
        let body = JSON.stringify(passDownLog);

        // no passDownLog.id means we should add the passDownLog.
        if (passDownLog.id == null || passDownLog.id == 0) {
            return this.post(this.baseUrl + '/' + addressId + '/passdownlogs', body);
        }
        else {
            return this.put(this.baseUrl + '/' + addressId + '/passdownlogs' + passDownLog.id, body);
        }
    }

    /**
    * Gets risk assessments associated with the address specified by the addressId
    * @param {number} addressId Unique identifier of the address
    */
    getRiskAssessments(addressId: number) {
        return this.get(this.baseUrl + '/' + addressId + '/risk-assessments');
    }

    /**
     * Gets risk assessment associated with the address specified by the addressId and workplaceRiskAssessmentId
     * @param {number} addressId Unique identifier of the address
     * @param {number} workplaceRiskAssessmentId Unique identifier of the risk assessment
     */
    getRiskAssessment(addressId: number, workplaceRiskAssessmentId: number) {
        return this.get(this.baseUrl + '/' + addressId + '/risk-assessments/' + workplaceRiskAssessmentId);
    }

    /**
    * Updates a risk assessment
    * @param {number} addressId Unique identifier of the address
    * @param {number} workplaceRiskAssessmentId Unique identifier of the workplace risk assessmentId
    */
    saveRiskAssessment(addressId: number, workplaceRiskAssessmentId: number, workplaceRiskAssessment: WorkplaceRiskAssessment) {
        let body = JSON.stringify(workplaceRiskAssessment);
        //If the workplaceRiskAssessment.id == null or 0 then POST the object, otherwise PUT using the workplaceRiskAssessment.id in the route.
        if (workplaceRiskAssessment.id == null || workplaceRiskAssessment.id == 0) {
            return this.post(this.baseUrl + '/' + addressId + '/risk-assessments', body);
        }
        else {
            return this.put(this.baseUrl + '/' + addressId + '/risk-assessments/' + workplaceRiskAssessmentId, body);
        }
    }

    /**
    * Removes a risk assessment
    * @param {number} addressId Unique identifier of the address
    * @param {number} workplaceRiskAssessmentId Unique identifier of the workplace risk assessmentId
    */
    deleteRiskAssessment(addressId: number, workplaceRiskAssessmentId: number) {
        return this.delete(this.baseUrl + "/" + addressId + '/risk-assessments/' + workplaceRiskAssessmentId);
    }

    /**
     * request a risk assessment
     * @param {number} addressId Unique identifier of the address
     * @param {number} workplaceRiskAssessmentId Unique identifier of the workplace risk assessmentId
     */
    requestRiskAssessment(addressId: number, workplaceRiskAssessmentId: number) {
        return this.get(this.baseUrl + '/' + addressId + '/risk-assessments/' + workplaceRiskAssessmentId + '/request');
    }

    /**
   * approve a risk assessment
   * @param {number} addressId Unique identifier of the address
   * @param {number} workplaceRiskAssessmentId Unique identifier of the workplace risk assessmentId
   */
    approveRiskAssessment(addressId: number, workplaceRiskAssessmentId: number) {
        return this.get(this.baseUrl + '/' + addressId + '/risk-assessments/' + workplaceRiskAssessmentId + '/approve');
    }

    /**
     * decline a risk assessment
     * @param {number} addressId Unique identifier of the address
     * @param {number} workplaceRiskAssessmentId Unique identifier of the workplace risk assessmentId
    */
    declineRiskAssessment(addressId: number, workplaceRiskAssessmentId: number) {
        return this.get(this.baseUrl + '/' + addressId + '/risk-assessments/' + workplaceRiskAssessmentId + '/decline');
    }

    /**
     * Gets risk assessments questions associated with the address specified by the addressId
     * @param {number} addressId Unique identifier of the address
     */
    getRiskAssessmentQuestions(addressId: number) {
        return this.get(this.baseUrl + '/' + addressId + '/risk-assessments/questions');
    }

    /**
     * Gets risk assessment responses associated with the address specified by the addressId & workplaceRiskAssessmentId
     * @param {number} addressId Unique identifier of the address
     * @param {number} workplaceRiskAssessmentId Unique identifier of the workplace risk assessmentId
     */
    getRiskAssessmentResponses(addressId: number, workplaceRiskAssessmentId: number) {
        return this.get(this.baseUrl + '/' + addressId + '/risk-assessments/' + workplaceRiskAssessmentId + '/responses');
    }

    /**
     * Gets a risk assessment response associated with the address specified by the addressId & workplaceRiskAssessmentId
     * @param {number} addressId Unique identifier of the address
     * @param {number} workplaceRiskAssessmentId Unique identifier of the workplace risk assessmentId
    */
    getRiskAssessmentResponse(addressId: number, workplaceRiskAssessmentId: number, riskAssessmentResponseId: number) {
        return this.get(this.baseUrl + '/' + addressId + '/risk-assessments/' + workplaceRiskAssessmentId + '/responses');
    }

    /**
   * Updates a risk assessment response
   * @param {number} addressId Unique identifier of the address
   * @param {number} workplaceRiskAssessmentId Unique identifier of the workplace risk assessmentId
   */
    saveRiskAssessmentResponse(addressId: number, workplaceRiskAssessmentId: number, workplaceRiskAssessmentResponseId: number, workplaceRiskAssessmentResponse: WorkplaceRiskAssessmentResponse) {
        let body = JSON.stringify(workplaceRiskAssessmentResponse);
        //If the workplaceRiskAssessmentResponse.id == null or 0 then POST the object, otherwise PUT using the workplaceRiskAssessmentResponse.id in the route.
        if (workplaceRiskAssessmentResponse.id == null || workplaceRiskAssessmentResponse.id == 0) {
            return this.post(this.baseUrl + '/' + addressId + '/risk-assessments/' + workplaceRiskAssessmentId + '/responses/', body);
        }
        else {
            return this.put(this.baseUrl + '/' + addressId + '/risk-assessments/' + workplaceRiskAssessmentId + '/responses/' + workplaceRiskAssessmentResponse.id, body);
        }
    }

    /**
   * Removes a risk assessment response
   * @param {number} addressId Unique identifier of the address
   * @param {number} workplaceRiskAssessmentId Unique identifier of the workplace risk assessmentId
   */
    deleteRiskAssessmentResponse(addressId: number, workplaceRiskAssessmentId: number, workplaceRiskAssessmentResponseId: number)  {
        return this.delete(this.baseUrl + "/" + addressId + '/risk-assessments/' + workplaceRiskAssessmentId + '/responses/' + workplaceRiskAssessmentResponseId);
    }

}