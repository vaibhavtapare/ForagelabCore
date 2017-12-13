import { Inject, Injectable } from '@angular/core';
import { Http } from '@angular/http';

import { AuthenticatedServiceBase } from '../../shared/bases/authenticated.service.base';
import { StateService } from './state.service';

import { Pagination } from '../../shared/models/pagination.model';
import { DataTableConfig } from '../../shared/models/data-table-config.model';
import { ProductionReport } from "../../shared/models/production-report.model";
import { ProductionReportPartNumber } from "../../shared/models/production-report-partnumber.model";
import { ProductionReportPartNumberDefect } from "../../shared/models/production-report-partnumber-defect.model";
import { ProductionReportService } from "../../shared/models/production-report-service.model";

/**
 * The production report service is used to communicate with the API in handling
 * all transactions related to workinstructions.
 */
@Injectable()
export class ProductionReportServices extends AuthenticatedServiceBase {
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
     * Gets production reports associated with the job specified by the jobId
     * @param {number} jobId Unique identifier of the job
     * @param {DataTableConfig} [config] Optional configuration settings for a data table
     * @param {Pagination} [pagination] Optional pagination data for the request
     */
    getProductionReports(jobId: number, config?: DataTableConfig, pagination?: Pagination) {
        return this.get(this.baseUrl + '/' + jobId + '/production-reports', config, pagination);
    }

    /**
     * Returns a specific production report from the API based on the provided id
     * @param {number} jobId Unique identifier of the job
     * @param {number} productionReportId Unique identifier of the production report to retrieve
     */
    getProductionReport(jobId: number, productionReportId: number) {
        return this.get(this.baseUrl + '/' + jobId + '/production-reports/'+productionReportId);
    }

    /**
     * Saves or creates production report data based on productionReport.id is specified and greater than zero
     * @param { number } jobId Unique identifier of the job
     * @param { ProductionReport } productionReport object for production report data
     */
    saveProductionReport(jobId: number, productionReport: ProductionReport) {
        let body = JSON.stringify(productionReport);

        // no productionReport.id means we should add the production report.
        if (productionReport.id == null || productionReport.id == 0) {
            return this.post(this.baseUrl + '/' + jobId + '/production-reports', body);
        }
        else {
            return this.put(this.baseUrl + '/' + jobId + '/production-reports/' + productionReport.id, body);
        }
    }

    /**
     * Deletes specified production report data based on productionReportId
     * @param { number } jobId Unique identifier of the job
     * @param { number } productionReportId Unique identifier of the production report
     */
    deleteProductionReport(jobId: number, productionReportId: number) {
        return this.delete(this.baseUrl + '/' + jobId + '/production-reports/' + productionReportId);
    }

    /**
     * create production report for given job and production report id
     * @param { number } jobId Unique identifier of the job
     * @param { number } productionReportId Unique identifier of the production report
     */
    requestProductionReport(jobId: number, productionReportId: number) {
        return this.get(this.baseUrl + '/' + jobId + '/production-reports/' + productionReportId + '/request');
    }

    /**
     * approves production report for given job and production report id
     * @param { number } jobId Unique identifier of the job
     * @param { number } productionReportId Unique identifier of the production report
     */
    approveProductionReport(jobId: number, productionReportId: number) {
        return this.get(this.baseUrl + '/' + jobId + '/production-reports/' + productionReportId + '/approve');
    }

    /**
     * declines production report for given job and production report id
     * @param { number } jobId Unique identifier of the job
     * @param { number } productionReportId Unique identifier of the production report
     */
    declineProductionReport(jobId: number, productionReportId: number) {
        return this.get(this.baseUrl + '/' + jobId + '/production-reports/' + productionReportId + '/decline');
    }

    /**
     * Returns a specific production report service from the API based on the provided id
     * @param { number } jobId Unique identifier of the job
     * @param { number } productionReportId Unique identifier of the production report
     */
    getProductionReportServices(jobId: number, productionReportId: number) {
        return this.get(this.baseUrl + '/' + jobId + '/production-reports/' + productionReportId+'/services');
    }

    /**
     * Returns a specific production report service from the API based on the provided id
     * @param { number } jobId Unique identifier of the job
     * @param { number } productionReportId Unique identifier of the production report
     * @param { number } productionReportServiceId Unique identifier of the production report service
     */
    getProductionReportService(jobId: number, productionReportId: number, productionReportServiceId: number) {
        return this.get(this.baseUrl + '/' + jobId + '/production-reports/' + productionReportId + '/services/'+productionReportServiceId);
    }

    /**
    * Saves or creates production report service data based on productionReportService.id is specified and greater than zero
    * @param { number } jobId Unique identifier of the job
    * @param { number } productionReportId Unique identifier of the production report
    * @param { ProductionReportService } productionReportService object for production report service data
    */
    saveProductionReportService(jobId: number, productionReportId: number, productionReportService: ProductionReportService) {
        let body = JSON.stringify(productionReportService);

        // no productionReport.id means we should add the production report.
        if (productionReportService == null || productionReportService.id == 0) {
            return this.post(this.baseUrl + '/' + jobId + '/production-reports/' + productionReportId +'/services', body);
        }
        else {
            return this.put(this.baseUrl + '/' + jobId + '/production-reports/' + productionReportId + '/services/' + productionReportService.id, body);
        }
    }

    /**
     * Deletes specified production report service data based on productionReportServiceId
     * @param { number } jobId Unique identifier of the job
     * @param { number } productionReportId Unique identifier of the production report
     * @param { number } productionReportServiceId Unique identifier of the production report service
     */
    deleteProductionReportService(jobId: number, productionReportId: number, productionReportServiceId: number) {
        return this.delete(this.baseUrl + '/' + jobId + '/production-reports/' + productionReportId + '/services/' + productionReportServiceId);
    }

    /**
     * Returns a specific production reports service from the API based on the provided production report id
     * @param { number } jobId Unique identifier of the job
     * @param { number } productionReportId Unique identifier of the production report
     */
    getProductionReportPartNumbers(jobId: number, productionReportId: number) {
        return this.get(this.baseUrl + "/" + jobId + '/production-reports/' + productionReportId + '/part-numbers');
    }

    /**
     * Returns a specific production report part number from the API based on the provided id
     * @param { number } jobId Unique identifier of the job
     * @param { number } productionReportId Unique identifier of the production report
     * @param { number } productionReportPartNumberId Unique identifier of the production report part number
     */
    getProductionReportPartNumber(jobId: number, productionReportId: number,productionReportPartNumberId: number) {
        return this.get(this.baseUrl + "/" + jobId + '/production-reports/' + productionReportId + '/part-numbers/'+ productionReportPartNumberId);
    }

     /**
     * Saves or creates production report data based on productionReport.id is specified and greater than zero
     * @param { number } jobId Unique identifier of the job
     * @param { number } productionReportId Unique identifier of the production report
     * @param { ProductionReportPartNumber } partNumber object of production report part number data
     */
    saveProductionReportPartNumber(jobId: number, productionReportId: number, partNumber: ProductionReportPartNumber) {
        let body = JSON.stringify(partNumber);

        // no partNumber.id means we should add the production report part numbers.
        if (partNumber.id == null || partNumber.id == 0) {
            return this.post(this.baseUrl + jobId + '/production-reports/' + productionReportId + '/part-numbers', body);
        }
        else {
            return this.put(this.baseUrl + jobId + '/production-reports/' + productionReportId + '/part-numbers/' + partNumber.id, body);
        }
    }

    /**
     * Deletes specified production report part number data based on productionReportId & productionReportPartNumberId
     * @param { number } jobId Unique identifier of the job
     * @param { number } productionReportId Unique identifier of the production report
     * @param { number }  productionReportPartNumberId Unique identifier of the production report part number
     */
    deleteProductionReportPartNumber(jobId: number, productionReportId: number, productionReportPartNumberId: number) {
        return this.delete(this.baseUrl + '/' + jobId + '/production-reports/' + productionReportId + '/part-numbers/' + productionReportPartNumberId);
    }

    /**
     * Gets production reports part number defects associated with the job specified by jobId and production report id
     * @param { number } jobId Unique identifier of the job
     * @param { number } productionReportId Unique identifier of the production report
     * @param { number } productionReportPartNumberId Unique identifier of the production report part number
     */
    getProductionReportPartNumberDefects(jobId: number, productionReportId: number, productionReportPartNumberId: number) {
        return this.get(this.baseUrl + "/" + jobId + 'production-reports/' + productionReportId + '/part-numbers/' + productionReportPartNumberId + '/defects');
    }

    /**
    * Gets production reports part number defects associated with the job specified by the productionReportPartNumberId
    * @param { number } jobId Unique identifier of the job
    * @param { number } productionReportId Unique identifier of the production report
    * @param { number } productionReportPartNumberId Unique identifier of the production report part number
    * @param { number } productionReportPartNumberDefectId Unique identifier of the production report part number defect
    */
    getProductionReportPartNumberDefect(jobId: number, productionReportId: number, productionReportPartNumberId: number, productionReportPartNumberDefectId:number) {
        return this.get(this.baseUrl + "/" + jobId + 'production-reports/' + productionReportId + '/part-numbers/' + productionReportPartNumberId + '/defects/' + productionReportPartNumberDefectId);
    }

    /**
     * Saves or creates production report data based on productionReport.id is specified and greater than zero
     * @param { number } jobId Unique identifier of the job
     * @param { number } productionReportId Unique identifier of the production report
     * @param { number } productionReportPartNumberId Unique identifier of the production report part number
     * @param { ProductionReportPartNumberDefect } defect object of production report defect data
     */
    saveProductionReportPartNumberDefect(jobId: number, productionReportId: number, productionReportPartNumberId: number, defect: ProductionReportPartNumberDefect) {
        let body = JSON.stringify(defect);

        // no defect.id means we should add the production report defect.
        if (defect.id == null || defect.id == 0) {
            return this.post(this.baseUrl + jobId + 'production-reports/' + productionReportId + '/part-numbers/' + productionReportPartNumberId + '/defects', body);
        }
        else {
            return this.put(this.baseUrl + jobId + 'production-reports/' + productionReportId + '/part-numbers/' + productionReportPartNumberId + '/defects/' + defect.id, body);
        }
    }

    /**
     * Deletes specified production report part number data based on productionReportId & productionReportPartNumberId
     * @param { number } jobId Unique identifier of the job
     * @param { number } productionReportId Unique identifier of the production report
     * @param { number } productionReportPartNumberId Unique identifier of the production report part number
     * @param { number } productionReportPartNumberDefectId Unique identifier of the production report defect
     */
    deleteProductionReportPartNumberDefect(jobId: number, productionReportId: number, productionReportPartNumberId: number, productionReportPartNumberDefectId: number) {
        return this.delete(this.baseUrl + '/' + jobId + 'production-reports/' + productionReportId + '/part-numbers/' + productionReportPartNumberId + '/defects/' + productionReportPartNumberDefectId);
    }
}