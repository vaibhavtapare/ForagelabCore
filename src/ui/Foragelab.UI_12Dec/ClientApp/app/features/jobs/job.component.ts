import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { AuthenticatedComponentBase } from '../../shared/bases/authenticated.component.base';

import { JobServices} from '../../core/services/job.service';
import { ModalService } from '../../core/services/modal.service';
import { NotificationService } from '../../core/services/notification.service';
import { StateService } from '../../core/services/state.service';

import { Job, jobFullDataTableConfig } from '../../shared/models/job.model';

import { Pagination } from '../../shared/models/pagination.model';
import { DataTableConfig } from '../../shared/models/data-table-config.model';
import { usertypes } from "../../shared/models/user.model";

@Component({
    templateUrl: './job.component.html'
})
export class JobComponent extends AuthenticatedComponentBase implements OnInit {
    constructor(
        public modalService: ModalService,
        private router: Router,
        public notificationService: NotificationService,
        private jobService: JobServices,
            stateService: StateService) {
        super(modalService, notificationService, stateService);
    } 

    areJobsLoading: boolean = false;
    searchFor: string = '';
    jobPagination: Pagination;
    jobsConfig: DataTableConfig = jobFullDataTableConfig;
    newJob: Job = new Job();
    locations: Array<Location> = new Array<Location>();
    canAddJob: boolean = false;
    
    ngOnInit() {
       this.jobsConfig.filter = () => {
            if (this.searchFor.length == 0) {
                return null;
            }
            return 'name ctn ' + this.searchFor; // + ' or ' +
                //'alias ctn ' + this.searchFor + ' or ' +
                //'phoneNumber ctn ' + this.searchFor + ' or ' +
                //'website ctn ' + this.searchFor + ' or ' +
                //'faxNumber ctn ' + this.searchFor;
        };

       this.loadJobs();
       this.canAddJob = this.stateService.hasPrivilege('jobs-add');
    }

    jobs: Array<Job>;

    loadJobs() {
        this.areJobsLoading = true;
        this.jobService.getJobs(this.jobsConfig, this.jobPagination).subscribe(
            jobs => {
                this.jobs = jobs.json();
                this.jobPagination = this.getPagination(jobs);
                this.areJobsLoading = false;
            },
            error => {
                this.notificationService.notify('error', error);
                this.areJobsLoading = false;
            });
    }

    filterChanged() {
        if (this.searchFor.length > 1) {
            this.loadJobs();
        }
    }

    createJob(job: Job) {
        if (job) {
            this.newJob = new Job();
            this.router.navigate(['/jobs', job.id]);
            this.loadJobs();
        }
        this.closeModal('addJob');
    }
}