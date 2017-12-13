import { Component } from '@angular/core';
import { Params, ActivatedRoute, Router } from "@angular/router";

import { AuthenticatedComponentBase } from '../../../shared/bases/authenticated.component.base';
import { ModalService } from '../../../core/services/modal.service';
import { NotificationService } from '../../../core/services/notification.service';
import { StateService } from '../../../core/services/state.service';

import { Address, adminaddressFullDataTableConfig } from '../../../shared/models/address.model';
import { JobServices } from '../../../core/services/job.service';

import { Pagination } from '../../../shared/models/pagination.model';
import { DataTableConfig } from '../../../shared/models/data-table-config.model';
import { JobClosure, jobClosureStatuses } from "../../../shared/models/job-closure.model";
import { Job } from "../../../shared/models/job.model";

/**
 * Component for displaying a job closure
 */
@Component({
    templateUrl: './job-closure.component.html'
})
export class JobClosureComponent extends AuthenticatedComponentBase {
    constructor(
        private route: ActivatedRoute,
        private router: Router,
        public modalService: ModalService,
        public notificationService: NotificationService,
        private jobServices: JobServices,
        stateService: StateService) {
        super(modalService, notificationService, stateService);
    }

    showRequest: boolean;
    showApprove: boolean;
    showDecline: boolean;
    isEnableRequest: boolean;
    approveBtnText: string = 'Approve';
    declineBtnText: string = 'Decline';
    
    jobId: number;
    job: Job;
    jobClosure: JobClosure = new JobClosure();
    jobClosureLoading: boolean = false;
    isAllChecked: boolean = false;
    requestBtnText: string;
    
    ngOnInit() {
        this.loadJob();
        this.loadJobClosure();
    }

    /**
     * Set status buttons text and show/hide/disable buttons
     */
    setStatusText() {
        if (this.jobClosure.documentsCollected && this.jobClosure.boundrySamplesReturned && this.jobClosure.boundriesRemoved
            && this.jobClosure.areaCleaned && this.jobClosure.ppgMaterialsCollected && this.jobClosure.clientFixturesReturned) {

            this.isAllChecked = true;
        }
        else {
            this.isAllChecked = false;
        }
        
        switch (this.jobClosure.statusId) {
          case jobClosureStatuses.Requested:
                this.showRequest = true;
                this.requestBtnText = "Requested";
                this.showApprove = true;
                this.showDecline = true;
                this.isEnableRequest = false;
                return;
            case jobClosureStatuses.New:
                this.showRequest = true;
                this.requestBtnText = "Request Approval";
                this.showApprove = false;
                this.showDecline = false;
                this.isEnableRequest = true;
                return;
            case jobClosureStatuses.Active:
                this.showRequest = false;
                this.requestBtnText = "Request Approval";
                this.showApprove = false;
                this.showDecline = false;
                this.isEnableRequest = false;
                return;
            default:
                this.showRequest = true;
                this.requestBtnText = "Request Approval";
                this.showApprove = false;
                this.showDecline = false;
                this.isEnableRequest = true;
                return;
        }
    }

    /**
     * Gets job associated with job closure.
     */
    loadJob() {
        this.jobClosureLoading = true;
        this.route.params
            .switchMap((params: Params) => this.jobServices.getJob(+params['id']))
            .subscribe(
            response => {
                this.job = response.json();
                this.jobClosureLoading = false;
            },
            error => {
                //this.notificationService.notify('error', error);
                this.jobClosureLoading = false;
            });
    }

    /**
     * Gets job closure for associated job.
     */
    loadJobClosure() {
        this.route.params.subscribe(params => {
            this.jobId = +params['id'];
        });
        this.jobClosureLoading = true;
        this.route.params
            .switchMap((params: Params) => this.jobServices.getJobClosure(+params['id']))
            .subscribe(
            response => {
                this.jobClosure = response.json();
                this.setStatusText();
                this.jobClosureLoading = false;
            },
            error => {
                if (error.status == 404) {
                this.showRequest = true;
                    this.requestBtnText = "Request Approval";
                    this.showApprove = false;
                    this.showDecline = false;
                    this.isEnableRequest = true;
                }
              //this.notificationService.notify('error', error);
                this.jobClosureLoading = false;
            });
    }

    /*
    * Request Job Closure
    */
    requestJobClosure(event: any) {
        this.jobClosureLoading = true;
        this.jobServices.saveJobClosure(this.jobId,this.jobClosure)
            .subscribe(
            response => {
                let createdJobClosure: JobClosure = response.json();
                if (createdJobClosure) {
                    this.jobServices.requestJobClosure(this.jobId, createdJobClosure.id)
                        .subscribe(
                        response => {
                            this.jobClosure = response.json();
                            this.setStatusText();
                            this.notificationService.notify('success', 'Job closure was saved and requested successfully.');            
                        });
                }
                this.jobClosureLoading = false;
                },
            error => {
                this.notificationService.notify('error', error);
                this.jobClosureLoading = false;
            });
    }

    /**
     * Approves requested Job Closure
     */
    ApproveJobClosure() {
        this.jobClosureLoading = true;
        this.jobServices.approveJobClosure(this.jobId, this.jobClosure.id)
            .subscribe(
            response => {
                this.jobClosure = response.json();
                this.setStatusText();
                this.notificationService.notify('sucesss', 'Job Closure approved successfully.');
                this.jobClosureLoading = false;
            });
    }

    /**
     * Declines requested Job Closure
     */
    DeclineJobClosure() {
        this.jobClosureLoading = true;
        this.jobServices.declineJobClosure(this.jobId, this.jobClosure.id)
            .subscribe(
            response => {
                this.jobClosure = response.json();
                this.setStatusText();
                this.notificationService.notify('warning', 'Job Closure declined successfully.');
                this.jobClosureLoading = false;
            });
    }

    toggleCheckListCheck(event: any) {
        this.setCheckedValue(event.target.id);
        if (event && this.jobClosure.documentsCollected && this.jobClosure.boundrySamplesReturned && this.jobClosure.boundriesRemoved
            && this.jobClosure.areaCleaned && this.jobClosure.ppgMaterialsCollected && this.jobClosure.clientFixturesReturned) {

            this.isAllChecked = true;
        }
        else {
            this.isAllChecked = false;
        }
    }

    setCheckedValue(id) {
        switch (id) {
            case "1":
                this.jobClosure.documentsCollected = !this.jobClosure.documentsCollected
                return;
            case "2":
                this.jobClosure.boundrySamplesReturned = !this.jobClosure.boundrySamplesReturned
                return;
            case "3":
                this.jobClosure.boundriesRemoved = !this.jobClosure.boundriesRemoved
                return;
            case "4":
                this.jobClosure.areaCleaned = !this.jobClosure.areaCleaned
                return;
            case "5":
                this.jobClosure.ppgMaterialsCollected = !this.jobClosure.ppgMaterialsCollected
                return;
            case "6":
                this.jobClosure.clientFixturesReturned = !this.jobClosure.clientFixturesReturned
                return;
            default:
                return;
        }
    }
}