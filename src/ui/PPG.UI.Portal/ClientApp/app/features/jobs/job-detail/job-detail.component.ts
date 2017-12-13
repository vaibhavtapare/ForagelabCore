import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';

import { AuthenticatedComponentBase } from '../../../shared/bases/authenticated.component.base';

import { ClientService } from '../../../core/services/client.service';
import { EmployeeService } from '../../../core/services/employee.service';
import { JobServices } from '../../../core/services/job.service';
import { ModalService } from '../../../core/services/modal.service';
import { NotificationService } from '../../../core/services/notification.service';
import { StateService } from '../../../core/services/state.service';
import { WorkInstructionService } from "../../../core/services/workinstruction.service";
import { ProductionReportServices } from "../../../core/services/production-report.service";

import { Pagination } from '../../../shared/models/pagination.model';
import { DataTableConfig } from '../../../shared/models/data-table-config.model';
import { usertypes } from "../../../shared/models/user.model";
import { WorkInstruction, workInstructionFullDataTableConfig, workinstructionstatuses } from "../../../shared/models/workInstruction.model";
import { ProductionReport, productionReportFullDataTableConfig } from "../../../shared/models/production-report.model";

import { Client } from '../../../shared/models/client.model';
import { Contact } from '../../../shared/models/contact.model';
import { Employee } from '../../../shared/models/employee.model';
import { Job, jobTypes, jobstatuses } from '../../../shared/models/job.model';
import { Location } from '../../../shared/models/location.model';
import { Transaction, transactionFullDataTableConfig } from '../../../shared/models/transaction.model';
import { JobService, serviceTypes, jobServiceFullDataTableConfig, jobServiceRateFullDataTableConfig } from "../../../shared/models/job-service.model";
import { DocumentRevision, jobDocumentRevisionFullDataTableConfig } from "../../../shared/models/job-documentrevision.model";
import { ResponseContentType, RequestOptions } from "@angular/http";
import * as FileSaver from 'file-saver';
import * as _ from 'lodash';

@Component({
    templateUrl: './job-detail.component.html'
})
export class JobDetailComponent extends AuthenticatedComponentBase implements OnInit {
    constructor(
        public modalService: ModalService,
        private route: ActivatedRoute,
        private router: Router,
        public notificationService: NotificationService,
        private employeeService: EmployeeService,
        private clientService: ClientService,
        private jobService: JobServices,
        private workInstructionService: WorkInstructionService,
        private productionReportService: ProductionReportServices,
        stateService: StateService) {
        super(modalService, notificationService, stateService);
    }

    job: Job = new Job();
    newService: JobService = new JobService();
    clients: Array<Client>;
    locations: Array<Location>;
    contacts: Array<Contact>;
    processing: boolean = false;
    documentsProcessing: boolean = false;
    private jobTypes: any = jobTypes;
    private serviceTypes: any = serviceTypes;
    isContact: boolean = false;
    showJobClosure: boolean = false;

    workInstructionsLoading: boolean = false;
    workInstructionsPagination: Pagination = new Pagination(null);
    workInstructionsConfig: DataTableConfig = workInstructionFullDataTableConfig;
    workInstructions: Array<WorkInstruction>;

    productionReportsLoading: boolean = false;
    productionReportsPagination: Pagination = new Pagination(null);
    productionReportsConfig: DataTableConfig = productionReportFullDataTableConfig;
    productionReports: Array<ProductionReport>;

    jobDocumentsLoading: boolean = false;
    jobDocumentsPagination: Pagination = new Pagination(null);
    jobDocumentsConfig: DataTableConfig = jobDocumentRevisionFullDataTableConfig;
    jobDocuments: Array<DocumentRevision>;

    transactionsLoading: boolean = false;
    transactionPagination: Pagination = new Pagination(null);
    transactionsConfig: DataTableConfig = transactionFullDataTableConfig;
    transactions: Array<Transaction>;

    jobServicesLoading: boolean = false;
    jobServicesConfig: DataTableConfig = jobServiceFullDataTableConfig;
    jobRatesConfig: DataTableConfig = jobServiceRateFullDataTableConfig;
    jobServices: Array<JobService>;

    @Input()
    set jobdata(data: any) {
        this.job = data;
    }

    ngOnInit() {
        this.transactionPagination.pageSize = 3;
        this.transactionPagination.pageIndex = 0;
        this.loadJob();
    }

    loadJob() {
        this.isContact = this.stateService.currentUser.userTypeId == usertypes.Contact;
        this.showJobClosure = this.job.jobStatusId == jobstatuses.Active ? true : false;
        this.processing = true;
        this.loadWorkInstructions();
        this.loadTransactions();
        if (!this.isContact) {
            this.loadClients();
        }
        this.loadLocations();
        this.loadContacts();
        this.loadDocuments();
        this.loadProductionReports();
        this.loadServices();
        this.processing = false;
    }

    loadClientData() {
        this.loadLocations();
        this.loadContacts();
    }

    loadClients() {
        this.processing = true;
        this.clientService.getClients()
            .subscribe(
            response => {
                this.clients = response.json();
                this.processing = false;
            },
            error => {
                this.notificationService.notify('error', error);
                this.processing = false;
            });
    }

    loadLocations() {
        this.processing = true;
        this.clientService.getLocations(this.job.clientId)
            .subscribe(
            response => {
                this.locations = response.json();
                this.processing = false;
            },
            error => {
                this.notificationService.notify('error', error);
                this.processing = false;
            });
    }

    loadContacts() {
        this.processing = true;
        this.clientService.getContacts(this.job.clientId)
            .subscribe(
            response => {
                this.contacts = response.json();
                this.processing = false;
            },
            error => {
                this.notificationService.notify('error', error);
                this.processing = false;
            });
    }

    loadWorkInstructions() {
        this.workInstructionsLoading = true;
        this.workInstructionService.getWorkInstructions(this.job.id, this.workInstructionsConfig, this.workInstructionsPagination)
            .subscribe(
            response => {
                this.workInstructions = response.json();
                this.workInstructionsPagination = this.getPagination(response);
                this.workInstructionsLoading = false;
            },
            error => {
                this.notificationService.notify('error', error);
                this.workInstructionsLoading = false;
            });
    }

    loadTransactions() {
        this.transactionsLoading = true;
        this.jobService.getTransactions(this.job.id, this.transactionsConfig, this.transactionPagination)
            .subscribe(
            response => {
                this.transactions = response.json();
                this.transactionPagination = this.getPagination(response);
                this.transactionsLoading = false;
            },
            error => {
                this.notificationService.notify('error', error);
                this.transactionsLoading = false;
            });
    }

    loadProductionReports() {
        this.productionReportsLoading = true;
        this.productionReportService.getProductionReports(this.job.id, this.productionReportsConfig, this.productionReportsPagination)
            .subscribe(
            response => {
                this.productionReports = response.json();
                this.productionReportsPagination = this.getPagination(response);
                this.productionReportsLoading = false;
            },
            error => {
                this.notificationService.notify('error', error);
                this.productionReportsLoading = false;
            });
    }

    saveJob() {
        this.processing = true;
        this.jobService.saveJob(this.job)
            .subscribe(
            job => {
                this.job = job.json();
                this.notificationService.notify('success', this.job.jobCode + ' updated successfully.');
                this.processing = false;
                this.loadTransactions();
            },
            error => {
                this.notificationService.notify('error', error._body);
                this.processing = false;
            });
    }

    archiveJob() {
        this.processing = true;
        this.jobService.deleteJob(this.job.id)
            .subscribe(
            response => {
                this.notificationService.notify('warning', this.job.jobCode + "' has been archived.");
                this.closeModal('archiveJob');
                this.processing = false;
                this.router.navigate(['/jobs']);
            },
            error => {
                this.notificationService.notify('error', error._body);
                this.processing = false;
                this.closeModal('archiveJob');
            });
    }

    //job services & rates (shifts)
    loadServices() {
        this.jobServicesLoading = true;

        this.jobService.getJobServices(this.job.id)
            .subscribe(
            response => {
                this.jobServices = response.json();
                this.jobServicesLoading = false;
            },
            error => {
                this.notificationService.notify('error', error);
                this.jobServicesLoading = false;
            });
    }

    addService() {
        this.processing = true;
        this.jobService.saveJobService(this.job.id, this.newService)
            .subscribe(
            response => {
                this.notificationService.notify('success', 'New service added successfully.');
                this.newService = new JobService();
                this.newService.jobId = this.job.id;
                this.processing = false;
                this.loadServices();
                this.closeModal('addService');
            },
            error => {
                this.notificationService.notify('error', error._body);
                this.processing = false;
                this.closeModal('addService');
            });
    }

    saveService(JobService: JobService) {
        this.jobServicesLoading = true;
        this.jobService.saveJobService(this.job.id, JobService)
            .subscribe(
            response => {
                this.notificationService.notify('success', 'Service updated successfully.');
                this.jobServicesLoading = false;
                this.loadServices();
            },
            error => {
                this.notificationService.notify('error', error._body);
                this.jobServicesLoading = false;
            });
    }

    openServiceModal(id: string, record: any) {
        this.modalService.open(id, record);
    }

    closeServiceModal(id: string) {
        this.modalService.close(id);
    }

    deleteServiceRecord(id: string) {
        this.jobServicesLoading = true;
        let modal = this.modalService.get(id);
        let JobService: JobService = modal.record;
        this.jobService.removeJobService(JobService.jobId, JobService.id)
            .subscribe(
            response => {
                this.notificationService.notify('success', 'service deleted successfully.');
                this.loadServices();
                this.jobServicesLoading = false;
            },
            error => {
                this.notificationService.notify('error', error);
                this.jobServicesLoading = false;
            });
        this.modalService.close(id);
    }

    //job service rates
    openServiceRatesModal(id: string, record: any) {
        this.modalService.open(id, record);
    }

    closeServiceRatesModal(id: string) {
        this.modalService.close(id);
    }

    //document
    loadDocuments() {
        this.documentsProcessing = true;
        this.jobService.getJobDocuments(this.job.id, this.jobDocumentsConfig, this.jobDocumentsPagination)
            .subscribe(
            response => {
                this.jobDocuments = response.json();
                this.jobDocumentsPagination = this.getPagination(response);
                this.documentsProcessing = false;
            },
            error => {
                this.notificationService.notify('error', error);
                this.documentsProcessing = false;
            });
    }

    fetchDocument(documentrevision: DocumentRevision) {
        this.documentsProcessing = true;
        let options = new RequestOptions({ responseType: ResponseContentType.Blob });
        this.jobService.fetchDocument(this.job.id, documentrevision.documentId)
            .subscribe(
            response => {
                FileSaver.saveAs(response, documentrevision.documentName + '.pdf');
                let fileURL = URL.createObjectURL(response);
                window.open(fileURL);
                this.documentsProcessing = false;
            },
            error => {
                this.notificationService.notify('error', error);
                this.documentsProcessing = false;
            });
    }

    checkUnCheckUseIdentifiers() {
        this.job.useIdentifiers = !this.job.useIdentifiers;
    }

    keyPress(event: any) {
        const pattern = /^\d*[0-9]\d*$/;
        let inputChar = String.fromCharCode(event.charCode);
        if (event.keyCode != 8 && !pattern.test(inputChar)) {
            event.preventDefault();
        }
    }
}
