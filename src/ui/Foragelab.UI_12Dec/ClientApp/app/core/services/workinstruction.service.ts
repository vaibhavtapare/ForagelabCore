import { Inject, Injectable } from '@angular/core';
import { Http } from '@angular/http';

import { AuthenticatedServiceBase } from '../../shared/bases/authenticated.service.base';

import { StateService } from './state.service';

import { Job } from '../../shared/models/job.model';
import { Pagination } from '../../shared/models/pagination.model';
import { DataTableConfig } from '../../shared/models/data-table-config.model';
import { WorkInstructionPartNumber } from "../../shared/models/workInstruction-partnumber.model";
import { WorkInstructionDefect } from "../../shared/models/workInstruction-defect.model";
import { WorkInstructionStep } from "../../shared/models/workInstruction-step-model";
import { WorkInstructionRework } from "../../shared/models/workinstruction-rework.model";
import { JobAudit } from '../../shared/models/job-audit.model';
import { JobAuditResponse } from '../../shared/models/job-audit-response.model';

/**
 * The workinstruction service is used to communicate with the API in handling
 * all transactions related to workinstructions.
 */
@Injectable()
export class WorkInstructionService extends AuthenticatedServiceBase {
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
     * Gets work instructions associated with the job specified by the jobId
     * @param {number} jobId Unique identifier of the job
     * @param {DataTableConfig} [config] Optional configuration settings for a data table
     * @param {Pagination} [pagination] Optional pagination data for the request
     */
    getWorkInstructions(jobId: number, config?: DataTableConfig, pagination?: Pagination) {
        return this.get(this.baseUrl + '/' + jobId + '/work-instructions', config, pagination);
    }

    /**
     * Gets work instruction associated with the job specified by the jobId and workinstructionId
     * @param {number} jobId Unique identifier of the job
     * @param {number} workInstructionId Unique identifier of the workinstruction
    */
    getWorkInstruction(jobId: number, workInstructionId: number) {
        return this.get(this.baseUrl + '/' + jobId + '/work-instructions/'+workInstructionId);
    }

    /**
     * Clones workinstruction for workinstruction by the workinstructionid and jobid
     * @param {number} jobId Unique identifier of the job
     * @param {number} workInstructionId Unique identifier of the workinstruction
     */
    cloneWorkInstruction(jobId: number, workInstructionId: number)
    {
        return this.post(this.baseUrl + "/" + jobId + '/work-instructions/' + workInstructionId + '/clone',null);
    }

    /**
     * Gets transactions associated with the workinstruction specified by the jobId and workinstructionId
     * @param {number} jobId Unique identifier of the job
     * @param {number} workInstructionId Unique identifier of the workinstruction
     * @param {DataTableConfig} [config] Optional configuration settings for a data table
     * @param {Pagination} [pagination] Optional pagination data for the request
     */
    getTransactions(jobId: number, workInstructionId: number, config?: DataTableConfig, pagination?: Pagination)
    {
        return this.get(this.baseUrl + "/" + jobId + '/work-instructions/' + workInstructionId + '/transactions', config, pagination);
    }

    /**
     * Gets defects associated with the job specified by the jobId
     * @param {number} jobId Unique identifier of the job
     * @param {number} workInstructionId Unique identifier of the workinstruction
     * @param {DataTableConfig} [config] Optional configuration settings for a data table
     * @param {Pagination} [pagination] Optional pagination data for the request
     */
    getDefects(jobId: number, workInstructionId: number, config?: DataTableConfig, pagination?: Pagination) {
        return this.get(this.baseUrl + "/" + jobId + '/work-instructions/' + workInstructionId +  '/defects', config, pagination);
    }

    /**
     * Gets defect associated with the job specified by the jobId
     * @param {number} jobId Unique identifier of the job
     * @param {number} workInstructionId Unique identifier of the workinstruction
     * @param {number} defectId Unique identifier of the workinstructiondefect
     */
    getDefect(jobId: number, workInstructionId: number, defectId:number) {
        return this.get(this.baseUrl + "/" + jobId + '/work-instructions/' + workInstructionId + '/defects/'+ defectId);
    }

    /**
    * Adds a defect to the job
    * @param {number} jobId Unique identifier of the job
    * @param {number} workInstructionId Unique identifier of the workinstruction
    * @param {WorkInstructionDefect} defect Defect to add to the job
    */
    addDefect(jobId: number, workInstructionId: number, defect: WorkInstructionDefect) {
        let body = JSON.stringify(defect);
        return this.post(this.baseUrl + "/" + jobId + '/work-instructions/' + workInstructionId + '/defects', body);
    }

    /**
     * Updates a defect to the job
     * @param {number} jobId Unique identifier of the job
     * @param {number} workInstructionId Unique identifier of the workinstruction
     * @param {WorkInstructionDefect} defect defect to add to the job
     * @param {any} file file of defect to upload
     */
    saveDefect(jobId: number, workInstructionId: number, defect: WorkInstructionDefect, file: any) {
        let body = JSON.stringify(defect);
        return this.putWithFile(this.baseUrl + "/" + jobId + '/work-instructions/' + workInstructionId + '/defects/' + defect.id, body, file);
    }

    /**
     * Removes a defect from the job
     * @param {number} jobId Unique identifier of the job
     * @param {number} workInstructionId Unique identifier of the workinstruction
     * @param {number} defectId Unique identifier of the defect to remove
     */
    removeDefect(jobId: number, workInstructionId: number, defectId: number) {
        return this.delete(this.baseUrl + "/" + jobId + '/work-instructions/' + workInstructionId +  '/defects/' + defectId);
    }
    
    /**
     * Gets defects associated with the job specified by the jobId
     * @param {number} jobId Unique identifier of the job
     * @param {number} workInstructionId Unique identifier of the workinstruction
     * @param {DataTableConfig} [config] Optional configuration settings for a data table
     * @param {Pagination} [pagination] Optional pagination data for the request
     */
    getReworks(jobId: number, workInstructionId: number, config?: DataTableConfig, pagination?: Pagination) {
        return this.get(this.baseUrl + "/" + jobId + '/work-instructions/' + workInstructionId + '/reworks', config, pagination);
    }

    /**
   * Adds a rework to the job
   * @param {number} jobId Unique identifier of the job
   * @param {number} workInstructionId Unique identifier of the workinstruction
   * @param {WorkInstructionRework} rework Rework to add to the job
   */
    addRework(jobId: number, workInstructionId: number, rework: WorkInstructionRework) {
        let body = JSON.stringify(rework);
        return this.post(this.baseUrl + "/" + jobId + '/work-instructions/' + workInstructionId + '/reworks', body);
    }

    /**
     * Updates a rework to the job
     * @param {number} jobId Unique identifier of the job
     * @param {number} workInstructionId Unique identifier of the workinstruction
     * @param {WorkInstructionRework} rework Rework to add to the job
     */
    saveRework(jobId: number, workInstructionId: number, rework: WorkInstructionRework) {
        let body = JSON.stringify(rework);
        return this.put(this.baseUrl + "/" + jobId + '/work-instructions/' + workInstructionId + '/reworks/' + rework.id, body);
    }

    /**
     * Removes a defect from the job
     * @param {number} jobId Unique identifier of the job
     * @param {number} workInstructionId Unique identifier of the workinstruction
     * @param {number} reworkId Unique identifier of the rework to remove
     */
    removeRework(jobId: number, workInstructionId: number, reworkId: number) {
        return this.delete(this.baseUrl + "/" + jobId + '/work-instructions/' + workInstructionId + '/reworks/' + reworkId);
    }
    
    /**
  * Gets step associated with the job specified by the jobId
  * @param {number} jobId Unique identifier of the job
  * @param {number} workInstructionId Unique identifier of the workinstruction
  * @param {DataTableConfig} [config] Optional configuration settings for a data table
  * @param {Pagination} [pagination] Optional pagination data for the request
  */
    getSteps(jobId: number, workInstructionId: number, config?: DataTableConfig, pagination?: Pagination) {
        return this.get(this.baseUrl + "/" + jobId + '/work-instructions/' + workInstructionId + '/steps', config, pagination);
    }

    /**
     * Gets step associated with the job specified by the jobId
     * @param {number} jobId Unique identifier of the job
     * @param {number} workInstructionId Unique identifier of the workinstruction
     * @param {number} stepId Unique identifier of the workinstructiondefect
     */
    getStep(jobId: number, workInstructionId: number, stepId: number) {
        return this.get(this.baseUrl + "/" + jobId + '/work-instructions/' + workInstructionId + '/steps/' + stepId);
    }

    /**
    * Adds a step to the work instruction
    * @param {number} jobId Unique identifier of the job
    * @param {number} workInstructionId Unique identifier of the workinstruction
    * @param {WorkInstructionDefect} step Step to add to the job
    */
    addStep(jobId: number, workInstructionId: number, step: WorkInstructionStep) {
        let body = JSON.stringify(step);
        return this.post(this.baseUrl + "/" + jobId + '/work-instructions/' + workInstructionId + '/Steps', body);
    }

    /**
     * Saves the step
     * @param {number} jobId Unique identifier of the job
     * @param {number} workInstructionId Unique identifier of the workinstruction
     * @param {WorkInstructionStep} step Work instruction step to save
     * @param file image file to upload
     */
    saveStep(jobId: number, workInstructionId: number, step: WorkInstructionStep, file: any) {
        let body = JSON.stringify(step);
        return this.putWithFile(this.baseUrl + "/" + jobId + '/work-instructions/' + workInstructionId + '/Steps/' + step.id, body, file);
    }

    /**
     * Removes a step from the job
     * @param {number} jobId Unique identifier of the job
     * @param {number} workInstructionId Unique identifier of the workinstruction
     * @param {number} stepId Unique identifier of the defect to remove
     */
    removeStep(jobId: number, workInstructionId: number, stepId: number) {
        return this.delete(this.baseUrl + "/" + jobId + '/work-instructions/' + workInstructionId + '/Steps/' + stepId);
    }

    /**
     * Clones workinstruction for workinstruction by the workinstructionid and jobid
     * @param {number} jobId Unique identifier of the job
     * @param {number} workInstructionId Unique identifier of the workinstruction
     * @param {Array<WorkInstructionDefect>} defects List of workinstruction defects
     */
    updateWorkInstructionDefectSequence(jobId: number, workInstructionId: number, defects: Array<WorkInstructionDefect>) {
        return this.post(this.baseUrl + "/" + jobId + '/work-instructions/' + workInstructionId + '/defects/sequence', defects);
    }

    /**
    * Clones workinstruction for workinstruction by the workinstructionid and jobid
    * @param {number} jobId Unique identifier of the job
    * @param {number} workInstructionId Unique identifier of the workinstruction
    * @param {Array<WorkInstructionStep>} steps List of workinstruction steps
    */
    updateWorkInstructionStepSequence(jobId: number, workInstructionId: number, steps: Array<WorkInstructionStep>) {
        return this.post(this.baseUrl + "/" + jobId + '/work-instructions/' + workInstructionId + '/steps/sequence', steps);
    }

    /**
     * Gets part numbers associated with the job specified by the jobId
     * @param {number} jobId Unique identifier of the job
     * @param {number} workInstructionId Unique identifier of the workinstruction
     * @param {DataTableConfig} [config] Optional configuration settings for a data table
     * @param {Pagination} [pagination] Optional pagination data for the request
     */
    getPartNumbers(jobId: number, workInstructionId: number, config?: DataTableConfig, pagination?: Pagination) {
        return this.get(this.baseUrl + "/" + jobId + '/work-instructions/' + workInstructionId +  '/part-numbers', config, pagination);
    }

    /**
     * Adds a part number to the job
     * @param {number} jobId Unique identifier of the job
     * @param {number} workInstructionId Unique identifier of the workinstruction
     * @param {WorkInstructionPartNumber} partNumber Part number to add to the job
     */
    addPartNumber(jobId: number, workInstructionId: number, partNumber: WorkInstructionPartNumber) {
        let body = JSON.stringify(partNumber);
        return this.post(this.baseUrl + "/" + jobId + '/work-instructions/' + workInstructionId + '/part-numbers', body);
    }

    /**
     * Removes a part number from the job
     * @param {number} jobId Unique identifier of the job
     * @param {number} workInstructionId Unique identifier of the workinstruction
     * @param {number} partNumberId Unique identifier of the part number to remove
     */
    removePartNumber(jobId: number, workInstructionId: number, partNumberId: number) {
        return this.delete(this.baseUrl + "/" + jobId + '/work-instructions/' + workInstructionId + '/part-numbers/' + partNumberId);
    }

    /**
   * get job documents by job id
   * @param {number} jobid - Unique identifier of the job
   * @param {number} workInstructionId Unique identifier of the workinstruction
   */
    getWorkInstructionDocuments(jobid: number, workInstructionId: number) {
        return this.get(this.baseUrl + '/' + jobid + '/work-instructions/'+ workInstructionId +'/documents');
    }

    /**
    * download document for job by document id
    * @param {number} jobid - Unique identifier of the job
    * @param {number} workInstructionId Unique identifier of the workinstruction
    * @param {number} documentId - Unique identifier of the document
    */
    fetchWorkInstructionDocument(jobid: number, workInstructionId: number,documentId: number) {
        return this.DownloadFile(this.baseUrl + '/' + jobid + '/work-instructions/' + workInstructionId + '/documents/' + documentId +'/download', 'application/ pdf');
    }

    /**
     * create work instruction for given job and work instruction id
     * @param jobId
     * @param workInstructionId
     */
    createWorkInstructionRequest(jobId: number, workInstructionId: number) {
        return this.get(this.baseUrl + '/' + jobId + '/work-instructions/' + workInstructionId + '/request');
    }

    /**
     * approve work instruction for Job and work instruction
     * @param jobId
     * @param workInstructionId
     */
    approveWorkInstructionRequest(jobId: number, workInstructionId: number) {
        return this.get(this.baseUrl + '/' + jobId + '/work-instructions/' + workInstructionId + '/approve');
    }

    /**
     * decline work instruction for Job and work instruction
     * @param jobId
     * @param workInstructionId
     */
    declineWorkInstructionRequest(jobId: number, workInstructionId: number) {
        return this.get(this.baseUrl + '/' + jobId + '/work-instructions/' + workInstructionId + '/decline');
    }

    /**
     * Gets all Job Audits
     * @param {number} [jobId] Unique identifier of the job
     * @param {number} [workInstructionId] Unique identifier of the work instruction
     */
    getJobAudits(jobId: number, workInstructionId: number) {
        return this.get(this.baseUrl + '/' + jobId + '/work-instructions/' + workInstructionId + '/jobaudits');
    }

     /**
     * Gets specific Job Audit from the API based on the provided id
     * @param {number} [jobId] Unique identifier of the job
     * @param {number} [workInstructionId] Unique identifier of the work instruction
     * @param {number} [jobAuditId] Unique identifier of the job audit
     */
    getJobAudit(jobId: number, workInstructionId: number, jobAuditId: number) {
        return this.get(this.baseUrl + '/' + jobId + '/work-instructions/' + workInstructionId + '/jobaudits/' + jobAuditId);
    }

    /**
     * Saves or creates an Job Audit depending on whether the jobAudit.id is specified and greater than zero
     * @param {JobAudit} jobAudit  The Job Audit object to save
     */
    saveJobAudit(jobId: number, workInstructionId: number, jobAudit: JobAudit) {
        let body = JSON.stringify(jobAudit);

        // no jobAudit.id means we should add the JobAudit.
        if (jobAudit.id == null || jobAudit.id == 0) {
            return this.post(this.baseUrl + '/' + jobId + '/work-instructions/' + workInstructionId + '/jobaudits', body);
        }
        else {
            return this.put(this.baseUrl + '/' + jobId + '/work-instructions/' + workInstructionId + '/jobaudits/' + jobAudit.id, body);
        }
    }

    /**
     * Gets all Job Audit Questions
    */
    getJobAuditQuestions() {
        return this.get(this.baseUrl + '/jobauditquestions');
    }

    /**
     * Gets specific Job Audit Responses from the API based on the provided id
     * @param {number} [jobId] Unique identifier of the job
     * @param {number} [workInstructionId] Unique identifier of the work instruction
     * @param {number} [jobAuditId] Unique identifier of the job audit
     */
    getJobAuditResponses(jobId: number, workInstructionId: number, jobAuditId: number) {
        return this.get(this.baseUrl + '/' + jobId + '/work-instructions/' + workInstructionId + '/jobaudits/' + jobAuditId + '/jobauditresponses');
    }

     /**
     * Saves or creates an Job Audit Response depending on whether the jobAuditResponse.id is specified and greater than zero
     * @param {JobAuditResponse} jobAuditResponse  The Job Audit Response object to save
     */
    saveJobAuditResponse(jobId: number, workInstructionId: number, jobAuditId: number, jobAuditResponse: JobAuditResponse) {
        let body = JSON.stringify(jobAuditResponse);

        // no jobAuditResponse.id means we should add the JobAuditResponse.
        if (jobAuditResponse.id == null || jobAuditResponse.id == 0) {
            return this.post(this.baseUrl + '/' + jobId + '/work-instructions/' + workInstructionId + '/jobaudits' + jobAuditId + '/jobauditresponses', body);
        }
        else {
            return this.put(this.baseUrl + '/' + jobId + '/work-instructions/' + workInstructionId + '/jobaudits/' + jobAuditId
                            + '/jobauditresponses/' + jobAuditResponse.id, body);
        }
    }

    /**
     * Deletes the Job Audit Response identified by the provided id
     * @param {number} [jobId] Unique identifier of the job
     * @param {number} [workInstructionId] Unique identifier of the work instruction
     * @param {number} [jobAuditId] Unique identifier of the job audit
     * @param {number} [jobAuditResponseId] Unique identifier of the Job Audit Response to delete
     */
    deleteJobAuditResponse(jobId: number, workInstructionId: number, jobAuditId: number, jobAuditResponseId: number) {
        return this.delete(this.baseUrl + '/' + jobId + '/work-instructions/' + workInstructionId + '/jobaudits/' + jobAuditId
                            + '/jobauditresponses/' + jobAuditResponseId);
    }
}