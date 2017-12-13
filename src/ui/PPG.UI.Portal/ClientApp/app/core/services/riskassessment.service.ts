import { Inject, Injectable } from '@angular/core';
import { Http } from '@angular/http';

import { AuthenticatedServiceBase } from '../../shared/bases/authenticated.service.base';

import { StateService } from './state.service';

import { Job } from '../../shared/models/job.model';
import { Pagination } from '../../shared/models/pagination.model';

import { DataTableConfig } from '../../shared/models/data-table-config.model';
import { RiskAssessment } from '../../shared/models/risk-assessment.model'
import { RiskAssessmentResponse } from '../../shared/models/risk-assessment-response.model'

/**
 * The riskassessment service is used to communicate with the API in handling
 * all transactions related to riskassessment.
 */

@Injectable()
export class RiskAssessmentService extends AuthenticatedServiceBase {
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
     * Gets risk assessment associated with the job and workinstruction.
     * @param {number} jobId Unique identifier of the job.
     * @param {number} workInstructionId Unique identifier of the workInstruction.
     **/
    getRiskAssessments(jobId: number, workInstructionId: number, config?: DataTableConfig, pagination?: Pagination) {
        return this.get(this.baseUrl + '/' + jobId + '/work-instructions/' + workInstructionId + '/risk-assessments', config, pagination);
    }

    /**
     * Gets risk assessment associated with the job,riskassessmentid and workinstructionId.
     * @param {number} jobId Unique identifier of the job.
     * @param {number} workInstructionId Unique identifier of the workInstruction.
     * @param {number} riskAssessmentId Unique identifier of the riskAssessment.
     **/
    getRiskAssessment(jobId: number, workInstructionId: number, riskAssessmentId: number) {
        return this.get(this.baseUrl + '/' + jobId + '/work-instructions/' + workInstructionId + '/risk-assessments/' + riskAssessmentId);
    }

    /**
    * Add or update riskassessment object associated with jobId,riskassessmentId and workinstructionId.
    * @param {number} jobId Unique identifier of the job.
    * @param {number} workInstructionId Unique identifier of the workInstruction.
    * @param {number} riskAssessmentId Unique identifier of the riskAssessment.
    * @param {RiskAssessment} riskAssessment Object of riskassessment.
    **/
    saveRiskAssessment(jobId: number, workInstructionId: number, riskAssessmentId: number, riskAssessment: RiskAssessment) {
        let body = JSON.stringify(riskAssessment);
        if (riskAssessment.id == null || riskAssessment.id == 0) {
            return this.post(this.baseUrl + "/" + jobId + '/work-instructions/' + workInstructionId + '/risk-assessments', body);
        }
        else {            
            return this.put(this.baseUrl + jobId + "/work-instructions/" + workInstructionId + "/risk-assessments/" + riskAssessmentId, body);
        }
    }
    /**
     * Delete risk assessment associated with the job,riskassessmentid and workinstructionId.
     * @param {number} jobId Unique identifier of the job.
     * @param {number} workInstructionId Unique identifier of the workInstruction.
     * @param {number} riskAssessmentId Unique identifier of the riskAssessment.
     **/
    deleteRiskAssessment(jobId: number, workInstructionId: number, riskAssessmentId: number) {
        return this.delete(this.baseUrl + "/" + jobId + '/work-instructions/' + workInstructionId + '/risk-assessments/' + riskAssessmentId);
    }
    /**
     * Gets risk assessment request associated with the job,riskassessmentid and workinstructionId.
     * @param {number} jobId Unique identifier of the job.
     * @param {number} workInstructionId Unique identifier of the workInstruction.
     * @param {number} riskAssessmentId Unique identifier of the riskAssessment.
     **/
    requestRiskAssessment(jobId: number, workInstructionId: number, riskAssessmentId: number) {
        return this.get(this.baseUrl + '/' + jobId + '/work-instructions/' + workInstructionId + '/risk-assessments/' + riskAssessmentId + '/request');
    }
    /**
     * Gets risk assessment approved request associated with the job,riskassessmentid and workinstructionId.
     * @param {number} jobId Unique identifier of the job.
     * @param {number} workInstructionId Unique identifier of the workInstruction.
     * @param {number} riskAssessmentId Unique identifier of the riskAssessment.
     **/
    approveRiskAssessment(jobId: number, workInstructionId: number, riskAssessmentId: number) {
        return this.get(this.baseUrl + '/' + jobId + '/work-instructions/' + workInstructionId + '/risk-assessments/' + riskAssessmentId + '/approve');
    }
    /**
     * Gets risk assessment decline request associated with the job,riskassessmentid and workinstructionId.
     * @param {number} jobId Unique identifier of the job.
     * @param {number} workInstructionId Unique identifier of the workInstruction.
     * @param {number} riskAssessmentId Unique identifier of the riskAssessment.
     **/
    declineRiskAssessment(jobId: number, workInstructionId: number, riskAssessmentId: number) {
        return this.get(this.baseUrl + '/' + jobId + '/work-instructions/' + workInstructionId + '/risk-assessments/' + riskAssessmentId + '/decline');
    }
     /**
     * Gets risk assessment question associated with the job,riskassessmentid and workinstructionId.
     * @param {number} jobId Unique identifier of the job.
     * @param {number} workInstructionId Unique identifier of the workInstruction.     
     **/
    getQuestions(jobId: number, workInstructionId: number) {
        return this.get(this.baseUrl + '/' + jobId + '/work-instructions/' + workInstructionId + '/risk-assessments/questions');
    }
    /**
     * Gets risk assessment question response associated with the job,riskassessmentid and workinstructionId.
     * @param {number} jobId Unique identifier of the job.
     * @param {number} workInstructionId Unique identifier of the workInstruction.
    * @param {number} riskAssessmentId Unique identifier of the riskassessmentId.
     **/
    getRiskAssessmentResponses(jobId: number, workInstructionId: number, riskAssessmentId: number)
    {
        return this.get(this.baseUrl + '/' + jobId + '/work-instructions/' + workInstructionId + '/risk-assessments/questions');
    }
    /**
     * Add or update riskassessment question response.
     * @param {number} jobId Unique identifier of the job.
     * @param {number} workInstructionId Unique identifier of the workInstruction.
     * @param {number} riskAssessmentId Unique identifier of the riskassessment.
     * @param {RiskAssessmentResponse} riskAssessmentResponse riskassessment response object.
     **/
    saveRiskAssessmentResponse(jobId: number, workInstructionId: number, riskAssessmentId: number, riskAssessmentResponse: RiskAssessmentResponse)
    {
        let body = JSON.stringify(riskAssessmentResponse);
        if (riskAssessmentResponse.id == null || riskAssessmentResponse.id == 0)
        {
            return this.post(this.baseUrl + "/" + jobId + '/work-instructions/' + workInstructionId + '/risk-assessments/responses', body);
        }
        else
        {
            return this.put(this.baseUrl + "/" + jobId + "/work-instructions/" + workInstructionId + "/risk-assessments/" + riskAssessmentId + '/responses/' + riskAssessmentResponse.id, body);
        }
    }
    /**
     * Delete RiskAssessmentResponse by jobId,workinstructionId,riskassessmentId and riskassessmentResponse.
     * @param {number} jobId Unique identifier of the job.
     * @param {number} workInstructionId Unique identifier of the workInstruction.
     * @param {number} riskAssessmentId Unique identifier of the riskassessment.
     * @param {number} riskAssessmentResponse Unique id for riskAssessmentResponse.
     **/
    deleteRiskAssessmentResponse(jobId: number, workInstructionId: number, riskAssessmentId: number, riskAssessmentResponse: number)
    {
        return this.delete(this.baseUrl + "/" + jobId + '/work-instructions/' + workInstructionId + '/risk-assessments/' + riskAssessmentId + 'responses' + riskAssessmentResponse);
    }
}