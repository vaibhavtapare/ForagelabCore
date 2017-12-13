import { Component, OnInit, Input, ViewChild } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import * as _ from 'lodash';

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
import { JobService, serviceTypes, jobServiceFullDataTableConfig } from "../../../shared/models/job-service.model";
import { usertypes } from "../../../shared/models/user.model";
import { WorkInstruction } from "../../../shared/models/workInstruction.model";
import { WorkInstructionRework, workInstructionReworkFullDataTableConfig } from "../../../shared/models/workinstruction-rework.model";
import { WorkInstructionStep, workInstructionStepFullDataTableConfig } from "../../../shared/models/workInstruction-step-model";

import { DragulaService } from 'ng2-dragula/ng2-dragula';

@Component({
    templateUrl: './job-request.component.html',
    styles: [
        `
.tagline {
  position: relative;
  margin-top: 0;
}
.tagline-text {
  vertical-align: middle;
}
.__slackin {
  float: right;
  margin-left: 10px;
  vertical-align: middle;
}

.promo {
  margin-bottom: 0;
  font-style: italic;
  padding: 10px;
  background-color: #ff4020;
  border-bottom: 5px solid #c00;
}

.gh-fork {
  position: fixed;
  top: 0;
  right: 0;
  border: 0;
}

/* dragula-specific example page styles */
.wrapper {
  display: table;
}
.container {
  display: table-cell;
  background-color: rgba(255, 255, 255, 0.2);
  width: 50%;
}
.container:nth-child(odd) {
  background-color: rgba(0, 0, 0, 0.2);
}
/*
 * note that styling gu-mirror directly is a bad practice because it's too generic.
 * you're better off giving the draggable elements a unique class and styling that directly!
 */
.container > div,
.gu-mirror {
  margin: 10px;
  padding: 10px;
  background-color: rgba(0, 0, 0, 0.2);
  transition: opacity 0.4s ease-in-out;
}
.container > div {
  cursor: move;
  cursor: grab;
  cursor: -moz-grab;
  cursor: -webkit-grab;
}
.gu-mirror {
  cursor: grabbing;
  cursor: -moz-grabbing;
  cursor: -webkit-grabbing;
}
.container .ex-moved {
  background-color: #e74c3c;
}
.container.ex-over {
  background-color: rgba(255, 255, 255, 0.3);
}
#left-lovehandles > div,
#right-lovehandles > div {
  cursor: initial;
}
.handle {
  padding: 0 5px;
  margin-right: 5px;
  background-color: rgba(0, 0, 0, 0.4);
  cursor: move;
}
.image-thing {
  margin: 20px 0;
  display: block;
  text-align: center;
}
.slack-join {
  position: absolute;
  font-weight: normal;
  font-size: 14px;
  right: 10px;
  top: 50%;
  margin-top: -8px;
  line-height: 16px;
}

/* Carbon */

#carbonads {
  position: absolute;
  display: block;
  overflow: hidden;
  margin-left: -180px;
  padding: 1em;
  max-width: calc(130px + 2em);
  background-color: #aa5579;
  text-align: center;
  font-size: 12px;
  font-family: Verdana, "Helvetica Neue", Helvetica, sans-serif;
  line-height: 1.5;
}

#carbonads a {
  color: inherit;
  text-decoration: none;
  font-weight: 400;
  transition: color .2s ease-in-out;
}

#carbonads a:hover {
  color: #221c3b;
}

#carbonads span {
  display: block;
  overflow: hidden;
}

.carbon-img {
  display: block;
  margin: 0 auto 1em;
}

.carbon-text {
  display: block;
  margin-bottom: 1em;
}

.carbon-poweredby {
  display: block;
  text-transform: uppercase;
  letter-spacing: 1px;
  font-size: 9px;
}

@media only screen and (min-width: 320px) and (max-width: 960px) {
  #carbonads {
    position: relative;
    float: none;
    margin: 0 auto -2em;
    max-width: 330px;
  }
  #carbonads span {
    position: relative;
  }
  #carbonads > span {
    max-width: none;
  }
  .carbon-img {
    float: left;
    margin: 0 1em 0 0;
  }
  .carbon-text {
    float: left;
    margin-bottom: 0;
    max-width: calc(100% - 130px - 1em);
    text-align: left;
  }
  .carbon-poweredby {
    position: absolute;
    right: 0;
    bottom: 0;
    display: block;
  }
}`
    ]
})
export class JobRequestComponent extends AuthenticatedComponentBase implements OnInit {
    constructor(
        public modalService: ModalService,
        private route: ActivatedRoute,
        private router: Router,
        public notificationService: NotificationService,
        private employeeService: EmployeeService,
        private clientService: ClientService,
        private jobService: JobServices,
        private workInstructionService: WorkInstructionService,
        stateService: StateService, private dragulaService: DragulaService) {
        super(modalService, notificationService, stateService);
    }

    job: Job = new Job();
    newPartNumber: WorkInstructionPartNumber = new WorkInstructionPartNumber();
    newDefect: WorkInstructionDefect = new WorkInstructionDefect();
    newRework: WorkInstructionRework = new WorkInstructionRework();
    newStep: WorkInstructionStep = new WorkInstructionStep();
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

    workInstructionStepLoading: boolean = false;
    workInstructionStepPagination: Pagination = new Pagination(null);
    workInstructionStepConfig: DataTableConfig = workInstructionStepFullDataTableConfig;
    workInstructionStep: Array<WorkInstructionStep>;

    transactionsLoading: boolean = false;
    transactionPagination: Pagination = new Pagination(null);
    transactionsConfig: DataTableConfig = transactionFullDataTableConfig;
    transactions: Array<Transaction>;

    JobServicesLoading: boolean = false;
    JobServicesConfig: DataTableConfig = jobServiceFullDataTableConfig;
    JobServices: Array<JobService>;

    isContact: boolean = false;

    contactRequiredMessage: string = "Quote Approval Contact and Work Instruction Approval Contact must have values before Job Approval can be requested.";
    clientInformationRequiredMessage: string = "Client Billing Address and Client Corporate Address must have values before Job Approval can be requested.";
    jobClient: Client;

    @Input()
    set jobdata(data: any) {
        this.job = data;
    }

    @ViewChild('serviceform')
    serviceform: any;
    
    ngOnInit() {
        this.isContact = this.stateService.currentUser.userTypeId == usertypes.Contact;
        this.transactionPagination.pageSize = 3;
        this.transactionPagination.pageIndex = 0;
        this.setStatusText();
        this.loadJob();
    }

    setStatusText() {
        switch (this.job.jobStatusId) {
            case jobstatuses.New:
                this.showRequest = true;
                this.requestBtnText = "Job Request";
                this.showApprove = false;
                this.showDecline = false;
                this.isEnableRequest = true;
                return;
            case jobstatuses.Requested:
                this.showRequest = true;
                this.requestBtnText = "Pending Approval";
                this.showApprove = true;
                this.showDecline = true;
                this.isEnableRequest = false;
                return;
            default:
                this.showRequest = true;
                this.requestBtnText = "Job Request";
                this.showApprove = false;
                this.showDecline = false;
                this.isEnableRequest = false;
                return;
        }
    }

    getJobData() {
        this.jobService.getJob(this.job.id)
            .subscribe(result => this.job = result.json());
    }

    loadJob() {
        this.processing = true;
        this.showDefect = this.job.jobTypeId == jobtypes.Sort || this.job.jobTypeId == jobtypes.Sort_Rework ? true : false;
        this.showRework = this.job.jobTypeId == jobtypes.Sort_Rework || this.job.jobTypeId == jobtypes.Rework ? true : false;
        this.loadWorkInstruction();
        this.loadStep();
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


    loadStep() {
        this.workInstructionStepLoading = true;
        this.workInstructionService.getSteps(this.job.id, this.workInstruction.id, this.workInstructionReworkConfig, this.workInstructionReworkPagination)
            .subscribe(
            response => {
                this.workInstructionStep = response.json();
                this.workInstructionStepPagination = this.getPagination(response);
                this.workInstructionStepLoading = false;
            },
            error => {
                this.notificationService.notify('error', error);
                this.workInstructionStepLoading = false;
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
        this.jobPartNumbersLoading = true;
        this.workInstructionService.addPartNumber(this.job.id, this.workInstruction.id, this.newPartNumber)
            .subscribe(
            response => {
                this.notificationService.notify('success', this.newPartNumber.partNumber + ' added successfully.');
                this.newPartNumber = new WorkInstructionPartNumber();
                this.loadPartNumbers();
                this.closeModal('addPartNumber');
                this.jobPartNumbersLoading =false
            },
            error => {
                this.notificationService.notify('error', error._body);
                this.jobPartNumbersLoading = false;
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
        this.jobDefectsLoading = true;
        this.workInstructionService.addDefect(this.job.id, this.workInstruction.id, this.newDefect)
            .subscribe(
            response => {
                this.notificationService.notify('success', 'New defect added successfully.');
                this.newDefect = new WorkInstructionDefect();
                this.jobDefectsLoading = false;
                this.loadDefects();
                this.closeModal('addDefect');
            },
            error => {
                this.notificationService.notify('error', error._body);
                this.jobDefectsLoading = false;
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

    addStep() {
        this.processing = true;
        this.workInstructionService.addStep(this.job.id, this.workInstruction.id, this.newStep)
            .subscribe(
            response => {
                this.notificationService.notify('success', 'New step added successfully.');
                this.newStep = new WorkInstructionStep();
                //Todo: jobId
                //this.newDefect.jobId = this.job.id;
                this.processing = false;
                this.loadStep();
                this.closeModal('addStep');
            },
            error => {
                this.notificationService.notify('error', error._body);
                this.processing = false;
                this.closeModal('addStep');
            });
    }

    deleteStep(Step: WorkInstructionStep) {
        this.workInstructionStepLoading = true;
        this.workInstructionService.removeStep(this.job.id, this.workInstruction.id, Step.id)
            .subscribe(
            response => {
                this.notificationService.notify('success', Step.description + ' deleted successfully.');
                this.loadStep();
                this.workInstructionStepLoading = false;
            },
            error => {
                this.notificationService.notify('error', error);
                this.workInstructionStepLoading = false;
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

    //job rates (shift)
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
                this.serviceform.reset();
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

    //job transactions
    jobRequest() {     
        this.processing = true;
        if (this.job.quoteApprovalContactId == null
            || this.job.quoteApprovalContactId == 0
            || this.job.workInstructionApprovalContactId == null
            || this.job.workInstructionApprovalContactId == 0) {
            this.notificationService.notify('error', this.contactRequiredMessage);
            this.processing = false;
        }
        else {
            this.clientService.getClient(this.job.clientId)
                .subscribe(
                response => {
                    this.jobClient = response.json();
                    if (this.jobClient != null
                        && (this.jobClient.billingAddressId == null
                            || this.jobClient.billingAddressId == 0
                            || this.jobClient.corporateAddressId == null
                            || this.jobClient.corporateAddressId == 0)) {
                        this.notificationService.notify('error', this.clientInformationRequiredMessage);
                        this.processing = false;
                    }
                    else {
                        this.jobService.createJobRequest(this.job.id)
                            .subscribe(job => {
                                this.job = job.json()
                                this.setStatusText();
                                this.processing = false;
                            });
                    }
                },
                error => {
                    this.notificationService.notify('error', "Invalid client id provided. "+error);
                    this.processing = false;
                });
        }
    }

    jobApprove() {
        this.jobService.approveJobRequest(this.job.id)
            .subscribe(job => {
                this.job = job.json()
                this.setStatusText();
                this.notificationService.notify('success', 'Approval request sent.');
            });
    }

    jobDecline() {
        this.jobService.declineJobRequest(this.job.id)
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