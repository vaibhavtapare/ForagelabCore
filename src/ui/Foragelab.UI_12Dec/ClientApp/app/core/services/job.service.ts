import { Inject, Injectable } from '@angular/core';
import { Http } from '@angular/http';

import { AuthenticatedServiceBase } from '../../shared/bases/authenticated.service.base';

import { StateService } from './state.service';

import { Job } from '../../shared/models/job.model';
import { WorkInstructionDefect } from '../../shared/models/workInstruction-defect.model';
import { WorkInstructionPartNumber } from '../../shared/models/workInstruction-partnumber.model';
import { Pagination } from '../../shared/models/pagination.model';
import { DataTableConfig } from '../../shared/models/data-table-config.model';
import { JobService } from "../../shared/models/job-service.model";
import { JobClosure } from "../../shared/models/job-closure.model";

/**
 * The job service is used to communicate with the API in handling
 * all transactions related to jobs.
 */
@Injectable()
export class JobServices extends AuthenticatedServiceBase {
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
     * Gets all jobs optionally paginated
     * @param {DataTableConfig} [config] Optional configuration settings for a data table
     * @param {Pagination} [pagination] Optional pagination data for the request
     */
    getJobs(config?: DataTableConfig, pagination?: Pagination) {
        return this.get(this.baseUrl, config, pagination);
    }

    /**
     * Returns a specific job from the API based on the provided id
     * @param {number} id Unique identifier of the job to retrieve
     */
    getJob(id: number) {
        return this.get(this.baseUrl + '/' + id);
    }

    /**
     * Saves or creates an job depending on whether the job.id is specified and greater than zero
     * @param {Job} job The job object to save
     */
    saveJob(job: Job) {
        let body = JSON.stringify(job);

        // no job.id means we should add the job.
        if (job.id == null || job.id == 0) {
            return this.post(this.baseUrl, body);
        }
        else {
            return this.put(this.baseUrl + '/' + job.id, body);
        }
    }

    /**
     * Deletes the job identified by the provided id
     * @param {number} id Unique identifier of the job to delete
     */
    deleteJob(id: number) {
        return this.delete(this.baseUrl + '/' + id);
    }

    /**
     * Gets transactions associated with the job specified by the jobId
     * @param {number} jobId Unique identifier of the job
     * @param {DataTableConfig} [config] Optional configuration settings for a data table
     * @param {Pagination} [pagination] Optional pagination data for the request
     */
    getTransactions(jobId: number, config?: DataTableConfig, pagination?: Pagination) {
        return this.get(this.baseUrl + '/' + jobId + '/transactions', config, pagination);
    }

    /**
    * get job rates
    * @param {number} jobid - Unique identifier of the job
    */
    getJobServices(jobid: number) {        
        return this.get(this.baseUrl + '/' + jobid + '/rates');
    }

    /**
     * save job rate
     * @param {number} jobid - Unique identifier of the job
     * @param {JobService} JobService - JobService object for job rate data
     */
    saveJobService(jobid: number, JobService: JobService) {
        
        let body = JSON.stringify(JobService);
        // no employee.id means we should add the employee.
        if (JobService.id == null || JobService.id == 0) {
            return this.post(this.baseUrl + '/' + jobid + '/rates', body);
        }
        else {
            return this.put(this.baseUrl + '/' + jobid + '/rates/' + JobService.id, body);
        }
    }

    /**
    * remove job rate
    * @param {number} jobid - Unique identifier of the job
    * @param {number} JobServiceId - Unique identifier of the job rate
    */
    removeJobService(jobid: number, JobServiceId: number) {
        return this.delete(this.baseUrl + '/' + jobid + '/rates/' + JobServiceId);
    }

    /**
    * create job request if job status is new
    * @param {number} jobid - Unique identifier of the job
    */
    createJobRequest(jobid: number) {
        return this.get(this.baseUrl + '/' + jobid + '/request');
    }

    /**
    * approve job request if job status is requested
    * @param {number} jobid - Unique identifier of the job
    */
    approveJobRequest(jobid: number) {
        return this.get(this.baseUrl + '/' + jobid + '/approve');
    }

    /**
    * decline job request if job status is requested
    * @param {number} jobid - Unique identifier of the job
    */
    declineJobRequest(jobid: number) {
        return this.get(this.baseUrl + '/' + jobid + '/decline');
    }

    /**
    * create quote request if job status is quote needed
    * @param {number} jobid - Unique identifier of the job
    */
    createQuoteRequest(jobid: number) {
        return this.get(this.baseUrl + '/' + jobid + '/quote/request');
    }

    /**
    * approve quote request if job status is quote pending
    * @param {number} jobid - Unique identifier of the job
    */
    approveQuoteRequest(jobid: number) {
        return this.get(this.baseUrl + '/' + jobid + '/quote/approve');
    }

    /**
    * decline quote request if job status is quote pending
    * @param {number} jobid - Unique identifier of the job
    */
    declineQuoteRequest(jobid: number) {
        return this.get(this.baseUrl + '/' + jobid + '/quote/decline');
    }

    /**
     * Retrieves the HelloSign URL for e-signing the quote PDF
     * @param {number} jobid - Unique identifier of the job
     */
    fetchQuoteESignUrl(jobid: number) {
        return this.get(this.baseUrl + '/' + jobid + '/quote/esign');
    }

    /**
    * get job documents by job id
    * @param {number} jobid - Unique identifier of the job
    * @param {DataTableConfig?} config - Configuration object of data table layout
    * @param {Pagination?} pagination - Pagination object of data table layout
    */
    getJobDocuments(jobid: number, config?: DataTableConfig, pagination?: Pagination) {
        return this.get(this.baseUrl + '/' + jobid + '/documents', config, pagination);
    }

    /**
    * download document for job by document id
    * @param {number} jobid - Unique identifier of the job
    * @param {number} documentId - Unique identifier of the document
    */
    fetchDocument(jobid: number, documentId: number) {
        return this.DownloadFile(this.baseUrl + '/' + jobid + '/documents/' + documentId + '/download', 'application/ pdf');
    }

    /**
   * get job Closure
   * @param {number} jobId - Unique identifier of the job
   */
    getJobClosure(jobId: number) {
        return this.get(this.baseUrl + '/' + jobId + '/jobclosure');
    }

    /**
   * save job closure
   * @param {number} jobId - Unique identifier of the job
   * @param {JobClosure} JobClosure - JobClosure object for job rate data
   */
    saveJobClosure(jobId: number, jobClosure: JobClosure) {
        let body = JSON.stringify(jobClosure);
        // no employee.id means we should add the employee.
        if (jobClosure.id == null || jobClosure.id == 0) {
            return this.post(this.baseUrl + '/' + jobId + '/jobclosure', body);
        }
        else {
            return this.put(this.baseUrl + '/' + jobId + '/jobclosure/' + jobClosure.id, body);
        }
    }

    /**
   * request job closure
   * @param {number} jobId - Unique identifier of the job
   * @param {number} jobClosureId - Unique identifier of the job closure
   */
    requestJobClosure(jobId: number, jobClosureId: number) {
        return this.get(this.baseUrl + '/' + jobId + '/jobclosure/' + jobClosureId + '/request');
    }

    /**
     * approve job closure
     * @param {number} jobId - Unique identifier of the job
     * @param {number} jobClosureId - Unique identifier of the job closure
     */
    approveJobClosure(jobId: number, jobClosureId: number) {
        return this.get(this.baseUrl + '/' + jobId + '/jobclosure/' + jobClosureId + '/approve');
    }

    /**
   * decline job closure
   * @param {number} jobId - Unique identifier of the job
   * @param {number} jobClosureId - Unique identifier of the job closure
   */
    declineJobClosure(jobId: number, jobClosureId: number) {
        return this.get(this.baseUrl + '/' + jobId + '/jobclosure/' + jobClosureId + '/decline');
    }

}