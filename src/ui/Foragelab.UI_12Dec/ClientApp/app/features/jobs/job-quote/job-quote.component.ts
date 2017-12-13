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

import { Pagination } from '../../../shared/models/pagination.model';
import { DataTableConfig } from '../../../shared/models/data-table-config.model';

import { Client } from '../../../shared/models/client.model';
import { Contact } from '../../../shared/models/contact.model';
import { Employee } from '../../../shared/models/employee.model';
import { Job, jobTypes, jobstatuses, jobtypes } from '../../../shared/models/job.model';
import { WorkInstructionDefect, workInstructionDefectFullDataTableConfig } from '../../../shared/models/workInstruction-defect.model';
import { WorkInstructionPartNumber, workInstructionPartNumberFullDataTableConfig } from '../../../shared/models/workInstruction-partnumber.model';
import { Location } from '../../../shared/models/location.model';
import { Transaction, transactionFullDataTableConfig } from '../../../shared/models/transaction.model';
import { JobService, serviceTypes, jobServiceFullDataTableConfig, jobServiceRateFullDataTableConfig } from "../../../shared/models/job-service.model";
import { usertypes } from "../../../shared/models/user.model";
import { WorkInstruction } from "../../../shared/models/workInstruction.model";
import { WorkInstructionRework, workInstructionReworkFullDataTableConfig } from "../../../shared/models/workinstruction-rework.model";

declare var HelloSign: any;

@Component({
    templateUrl: './job-quote.component.html'
})
export class JobQuoteComponent extends AuthenticatedComponentBase implements OnInit {
    constructor(
        public modalService: ModalService,
        private route: ActivatedRoute,
        private router: Router,
        public notificationService: NotificationService,
        private employeeService: EmployeeService,
        private clientService: ClientService,
        private jobService: JobServices,
        private workInstructionService: WorkInstructionService,
        stateService: StateService) {
        super(modalService, notificationService, stateService);
    }

    job: Job = new Job();
    newPartNumber: WorkInstructionPartNumber = new WorkInstructionPartNumber();
    newDefect: WorkInstructionDefect = new WorkInstructionDefect();
    newRework: WorkInstructionRework = new WorkInstructionRework();
    newService: JobService = new JobService();
    clients: Array<Client>;
    locations: Array<Location>;
    contacts: Array<Contact>;
    processing: boolean = false;
    private jobTypes: any = jobTypes;
    private serviceTypes: any = serviceTypes;
    requestBtnText: string = 'Request';
    showRequest: boolean;
    isEnableRequest: boolean;
    approveBtnText: string = 'Approve';
    showApprove: boolean;
    declineBtnText: string = 'Decline';
    showDecline: boolean;
    isContact: boolean = false;
    workInstruction: WorkInstruction = new WorkInstruction();
    showDefect: boolean = false;
    showRework: boolean = false;

    jobPartNumbersLoading: boolean = false;
    jobPartNumbersPagination: Pagination = new Pagination(null);
    jobPartNumbersConfig: DataTableConfig = workInstructionPartNumberFullDataTableConfig;
    jobPartNumbers: Array<WorkInstructionPartNumber>;

    jobDefectsLoading: boolean = false;
    jobDefectPagination: Pagination = new Pagination(null);
    jobDefectsConfig: DataTableConfig = workInstructionDefectFullDataTableConfig;
    jobDefects: Array<WorkInstructionDefect>;

    workInstructionReworkLoading: boolean = false;
    workInstructionReworkPagination: Pagination = new Pagination(null);
    workInstructionReworkConfig: DataTableConfig = workInstructionReworkFullDataTableConfig;
    workInstructionReworks: Array<WorkInstructionRework>;

    transactionsLoading: boolean = false;
    transactionPagination: Pagination = new Pagination(null);
    transactionsConfig: DataTableConfig = transactionFullDataTableConfig;
    transactions: Array<Transaction>;

    JobServicesLoading: boolean = false;
    JobServicesConfig: DataTableConfig = jobServiceFullDataTableConfig;
    JobServices: Array<JobService>;

    jobserviceRateLoading: boolean = false;
    jobserviceRateConfig: DataTableConfig = jobServiceRateFullDataTableConfig;
    jobserviceRate: Array<JobService>;

    @Input()
    set jobdata(data: any) {
        this.job = data;
    }

    ngOnInit() {
        this.isContact = this.stateService.currentUser.userTypeId == usertypes.Contact;
        this.transactionPagination.pageSize = 3;
        this.transactionPagination.pageIndex = 0;
        this.setStatusText();
        this.loadJob();
    }

    setStatusText() {
        switch (this.job.jobStatusId) {
            case jobstatuses.QuoteNeeded:
                this.showRequest = true;
                this.requestBtnText = "Request Quote Approval";
                this.showApprove = false;
                this.showDecline = false;
                this.isEnableRequest = true;
                return;
            case jobstatuses.QuotePending:
                this.showRequest = true;
                this.requestBtnText = "Pending Approval";
                this.showApprove = true;
                this.showDecline = true;
                this.isEnableRequest = false;
                return;
            default:
                this.showRequest = true;
                this.requestBtnText = "Request Quote Approval";
                this.showApprove = false;
                this.showDecline = false;
                this.isEnableRequest = false;
                return;
        }
    }

    loadJob() {
        this.processing = true;
        this.showDefect = this.job.jobTypeId == jobtypes.Sort || this.job.jobTypeId == jobtypes.Sort_Rework ? true : false;
        this.showRework = this.job.jobTypeId == jobtypes.Sort_Rework || this.job.jobTypeId == jobtypes.Rework ? true : false;
        this.loadWorkInstruction();
        this.loadTransactions();
        if (!this.isContact) {
            this.loadClients();
        }
        this.loadLocations();
        this.loadContacts();
        if (this.stateService.hasPrivilege('jobs-rates')) {
            this.loadServices();
        }
        this.processing = false;
    }

    loadClientData() {
        this.loadLocations();
        this.loadContacts();
    }

    loadWorkInstruction() {
        this.processing = true;
        this.workInstructionService.getWorkInstructions(this.job.id)
            .subscribe(
            response => {
                let workInstructions: Array<WorkInstruction> = response.json();
                this.workInstruction = workInstructions[0];
                if (this.showDefect) {
                    this.loadDefects();
                }
                if (this.showRework) {
                    this.loadWorkIstructionRework();
                }
                this.loadPartNumbers();
                this.processing = false;
            },
            error => {
                this.notificationService.notify('error', error);
                this.processing = false;
            });
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

    loadDefects() {
        this.jobDefectsLoading = true;
        this.workInstructionService.getDefects(this.job.id, this.workInstruction.id, this.jobDefectsConfig, this.jobDefectPagination)
            .subscribe(
            response => {
                this.jobDefects = response.json();
                this.jobDefectPagination = this.getPagination(response);
                this.jobDefectsLoading = false;
            },
            error => {
                this.notificationService.notify('error', error);
                this.jobDefectsLoading = false;
            });
    }

    loadPartNumbers() {
        this.jobPartNumbersLoading = true;
        this.workInstructionService.getPartNumbers(this.job.id, this.workInstruction.id, this.jobPartNumbersConfig, this.jobPartNumbersPagination)
            .subscribe(
            response => {
                this.jobPartNumbers = response.json();
                this.jobPartNumbersPagination = this.getPagination(response);
                this.jobPartNumbersLoading = false;
            },
            error => {
                this.notificationService.notify('error', error);
                this.jobPartNumbersLoading = false;
            });
    }

    loadWorkIstructionRework() {
        this.workInstructionReworkLoading = true;
        this.workInstructionService.getReworks(this.job.id, this.workInstruction.id, this.workInstructionReworkConfig, this.workInstructionReworkPagination)
            .subscribe(
            response => {
                this.workInstructionReworks = response.json();
                this.workInstructionReworkPagination = this.getPagination(response);
                this.workInstructionReworkLoading = false;
            },
            error => {
                this.notificationService.notify('error', error);
                this.workInstructionReworkLoading = false;
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

    addPartNumber() {
        this.processing = true;
        this.workInstructionService.addPartNumber(this.job.id, this.workInstruction.id, this.newPartNumber)
            .subscribe(
            response => {
                this.notificationService.notify('success', this.newPartNumber.partNumber + ' added successfully.');
                this.newPartNumber = new WorkInstructionPartNumber();
                //this.newPartNumber.jobId = this.job.id;
                this.processing = false;
                this.loadPartNumbers();
                this.closeModal('addPartNumber');
            },
            error => {
                this.notificationService.notify('error', error._body);
                this.processing = false;
                this.closeModal('addPartNumber');
            });
    }

    deletePartNumber(partnumber: WorkInstructionPartNumber) {
        this.jobPartNumbersLoading = true;
        this.workInstructionService.removePartNumber(this.job.id, this.workInstruction.id, partnumber.id)
            .subscribe(
            response => {
                this.notificationService.notify('success', partnumber.partNumber + ' deleted successfully.');
                this.loadPartNumbers();
                this.jobPartNumbersLoading = false;
            },
            error => {
                this.notificationService.notify('error', error);
                this.jobPartNumbersLoading = false;
            });
    }

    addDefect() {
        this.processing = true;
        this.workInstructionService.addDefect(this.job.id, this.workInstruction.id, this.newDefect)
            .subscribe(
            response => {
                this.notificationService.notify('success', 'New defect added successfully.');
                this.newDefect = new WorkInstructionDefect();
                //this.newDefect.jobId = this.job.id;
                this.processing = false;
                this.loadDefects();
                this.closeModal('addDefect');
            },
            error => {
                this.notificationService.notify('error', error._body);
                this.processing = false;
                this.closeModal('addDefect');
            });
    }

    deleteDefect(defect: WorkInstructionDefect) {
        this.jobDefectsLoading = true;
        this.workInstructionService.removeDefect(this.job.id, this.workInstruction.id, defect.id)
            .subscribe(
            response => {
                this.notificationService.notify('success', defect.name + ' deleted successfully.');
                this.loadDefects();
                this.jobDefectsLoading = false;
            },
            error => {
                this.notificationService.notify('error', error);
                this.jobDefectsLoading = false;
            });
    }

    addWorkInstructionReWork() {
        this.processing = true;
        this.workInstructionService.addRework(this.job.id, this.workInstruction.id, this.newRework)
            .subscribe(
            response => {
                this.notificationService.notify('success', 'New rework added successfully.');
                this.newRework = new WorkInstructionRework();
                this.processing = false;
                this.loadWorkIstructionRework();
                this.closeModal('addRework');
            },
            error => {
                this.notificationService.notify('error', error._body);
                this.processing = false;
                this.closeModal('addRework');
            });
    }

    deleteWorkInstructionRework(rework: WorkInstructionRework) {
        this.workInstructionReworkLoading = true;
        this.workInstructionService.removeRework(this.job.id, this.workInstruction.id, rework.id)
            .subscribe(
            response => {
                this.notificationService.notify('success', rework.name + ' deleted successfully.');
                this.loadWorkIstructionRework();
                this.workInstructionReworkLoading = false;
            },
            error => {
                this.notificationService.notify('error', error);
                this.workInstructionReworkLoading = false;
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

    //job rates (shifts)
    loadServices() {
        this.JobServicesLoading = true;

        this.jobService.getJobServices(this.job.id)
            .subscribe(
            response => {
                this.JobServices = response.json();
                this.JobServicesLoading = false;
            },
            error => {
                this.notificationService.notify('error', error);
                this.JobServicesLoading = false;
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
        this.JobServicesLoading = true;
        this.jobService.saveJobService(this.job.id, JobService)
            .subscribe(
            response => {
                this.notificationService.notify('success', 'Service updated successfully.');
                this.JobServicesLoading = false;
                this.loadServices();
            },
            error => {
                this.notificationService.notify('error', error._body);
                this.JobServicesLoading = false;
            });
    }

    openServiceModal(id: string, record: any) {
        this.modalService.open(id, record);
    }

    closeServiceModal(id: string) {
        this.modalService.close(id);
    }

    deleteServiceRecord(id: string) {
        this.JobServicesLoading = true;
        let modal = this.modalService.get(id);
        let JobService: JobService = modal.record;
        this.jobService.removeJobService(JobService.jobId, JobService.id)
            .subscribe(
            response => {
                this.notificationService.notify('success', 'service deleted successfully.');
                this.loadServices();
                this.JobServicesLoading = false;
            },
            error => {
                this.notificationService.notify('error', error);
                this.JobServicesLoading = false;
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

    //job transactions
    quoteRequest() {
        this.jobService.createQuoteRequest(this.job.id)
            .subscribe(job => {
                this.job = job.json()
                this.setStatusText();
            });
    }

    quoteApprove() {
        if (!this.isContact) {
            // This is an employee approving the quote.  Simply call the API
            this.jobService.approveQuoteRequest(this.job.id)
                .subscribe(job => {
                    this.job = job.json()
                    this.setStatusText();
                    this.notificationService.notify('success', 'Approval request sent.');
                });
        }
        else {
            // This is a client contact approving/declining the quote.  Present them
            // with the HelloSign iFrame to e-sign the quote PDF.
            this.jobService.fetchQuoteESignUrl(this.job.id)
                .subscribe(signUrl => {
                    HelloSign.init('569cd48ab104022f477dc2f79f97c8ab');
                    HelloSign.open({
                        url: signUrl.text(),
                        debug: true,
                        allowCancel: true,
                        skipDomainVerification: true,
                        healthCheckTimeoutMs: 600000,
                        messageListener: (eventData) => {
                            if (eventData.event == HelloSign.EVENT_SIGNED) {
                                this.jobService.approveQuoteRequest(this.job.id)
                                    .subscribe(job => {
                                        this.job = job.json()
                                        this.setStatusText();
                                        this.notificationService.notify('success', 'Approval request sent.');
                                    });
                            }
                            if (eventData.event == HelloSign.EVENT_DECLINED) {
                                this.quoteDecline();
                            }
                        }
                    });
                },
                error => {
                    this.notificationService.notify('error', error._body);
                });
        }
    }
    
    quoteDecline() {
        this.jobService.declineQuoteRequest(this.job.id)
            .subscribe(job => {
                this.job = job.json()
                this.setStatusText();
                this.notificationService.notify('warning', 'Quote declined successfully.');
            });
    }

    checkUnCheckUseIdentifiers() {
        this.job.useIdentifiers = !this.job.useIdentifiers;
    }
}