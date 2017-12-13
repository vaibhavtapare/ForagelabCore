import { Inject, Injectable } from '@angular/core';
import { Http } from '@angular/http';

import { AuthenticatedServiceBase } from '../../shared/bases/authenticated.service.base';
import { StateService } from './state.service';

import { Pagination } from '../../shared/models/pagination.model';
import { DataTableConfig } from '../../shared/models/data-table-config.model';

import { ProcessAudit } from '../../shared/models/process-audit.model';
import { ProcessAuditQuestionResponse } from '../../shared/models/process-audit-question-response.model';
import { WorkInstruction } from '../../shared/models/workInstruction.model';
import { Employee } from '../../shared/models/employee.model';



/**
 * The processaudit service is used to communicate with the API in handling
 * all transactions related to processaudit.
 */

@Injectable()
export class ProcessAuditService extends AuthenticatedServiceBase {
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
    baseUrl: string = '/jobs';

    /**
     * This function is used to get all questions related to processaudit.
     * @param {number} jobId Unique identifier of the job
     * @param {number} workInstructionId Unique id for workinstruction.
     */
    getProcessAuditQuestions(jobId: number, workInstructionId: number)
    {
        return this.get(this.baseUrl + '/' + jobId + '/work-instructions/' + workInstructionId + '/processAudits/questions')
    }
    /**
     * This function is used to get all processaudit data related to jobid and workinstruction id.
     * @param {number} jobId Unique identifier of the job
     * @param {number} workInstructionId Unique id for workinstruction.     
     */
    getProcessAudits(jobId: number, workInstructionId: number)
    {
        return this.get(this.baseUrl + '/' + jobId + '/work-instructions/' + workInstructionId +'/processAudits');
    }
    /**
     * This function is used to get all process audit data based on jobid, workinstructionid and processaudit id.
     * @param {number} jobId Unique identifier of the job
     * @param {number} workInstructionId Unique id for workinstruction.
     * @param {number} processAuditId Unique id for processauditId.
     */
    getProcessAudit(jobId: number, workInstructionId: number, processAuditId: number) {
        return this.get(this.baseUrl + '/' + jobId + '/work-instructions/' + workInstructionId + '/processAudits/' + processAuditId);
    }
    /**
     * This function is used to save or update ProcessAuditdata. 
     * @param {number} jobId Unique identifier of the job
     * @param {number} workInstructionId Unique id for workinstruction.
     * @param {ProcessAudit} processAudit Processaudit object to save or update.
     */
    saveProcessAudit(jobId: number, workInstructionId: number, processAudit: ProcessAudit) {
        let body = JSON.stringify(processAudit);
        if (processAudit.id == null || processAudit.id == 0) {
            return this.post(this.baseUrl + "/" + jobId + '/work-instructions/' + workInstructionId + '/processAudits', body);
        }
        else {
            return this.put(this.baseUrl + "/" + jobId + '/work-instructions/' + workInstructionId + '/processAudits/' + processAudit.id, body);
        }
    }
    /**
     * This function is used to delete processaudit based on processaudit uniqueId.
     * @param {number} jobId Unique identifier of the job
     * @param {number} workInstructionId Unique id for workinstruction.
     * @param {number} processAuditId Unique id for processauditId.
     */
    deleteProcessAudit(jobId: number, workInstructionId: number, processAuditId: number) {
        return this.delete(this.baseUrl + "/" + jobId + '/work-instructions/' + workInstructionId + '/processAudits' + processAuditId);
    }
    /**
     * This function is used to get ProcessAuditResponse data based on jobId, workinstructionId and processAuditId.
     * @param {number} jobId Unique identifier of the job
     * @param {number} workInstructionId Unique id for workinstruction.
     * @param {number} processAuditId Unique id for processauditId.
     */
    getProcessAuditResponses(jobId: number, workInstructionId: number, processAuditId: number) {
        return this.get(this.baseUrl + '/' + jobId + '/work-instructions/' + workInstructionId + '/processAudits/' + processAuditId + '/responses');
    }
    /**
     * This function is used to save/update processauditresponse.
     * @param {number} jobId Unique identifier of the job
     * @param {number} workInstructionId Unique id for workinstruction.
     * @param {number} processAuditId Unique id for processauditId.
     * @param {ProcessAuditQuestionResponse} processAuditResponse ProcessAuditResponse object needs to save/update.
     */
    saveProcessAuditResponse(jobId: number, workInstructionId: number, processAuditId: number, processAuditResponse: ProcessAuditQuestionResponse) {
        let body = JSON.stringify(processAuditResponse);
        if (processAuditResponse.id == null || processAuditResponse.id == 0) {
            return this.post(this.baseUrl + "/" + jobId + '/work-instructions/' + workInstructionId + '/processAudits/' + processAuditId + '/responses', body);
        }
        else {
            return this.put(this.baseUrl + "/" + jobId + '/work-instructions/' + workInstructionId + '/processAudits/' + processAuditId + '/responses', body);
        }
    }
    /**
     * This function is used to delete processAuditResponse object based on processauditResponseId.
     * @param {number} jobId Unique identifier of the job
     * @param {number} workInstructionId Unique id for workinstruction.
     * @param {number} processAuditId Unique id for processauditId.
     */
    deleteProcessAuditResponse(jobId: number, workInstructionId: number, processAuditId: number, processAuditResponseId: number)
    {
        return this.delete(this.baseUrl + "/" + jobId + '/work-instructions/' + workInstructionId + '/processAudits' + processAuditId + '/responses/' + processAuditResponseId);
    }
}




