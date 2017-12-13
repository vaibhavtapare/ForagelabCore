import { Component, ComponentFactoryResolver, ViewChild, Type, ViewContainerRef, OnInit } from '@angular/core';
import { ActivatedRoute, Router, Routes, Route } from '@angular/router';

import { JobServices } from '../../../core/services/job.service';

import { jobRoutes } from '../../jobs/job-routing.module';
import { Job, jobStatuses, jobstatuses } from "../../../shared/models/job.model";
import { JobDetailComponent } from "../job-detail/job-detail.component";
import { AuthGuard } from "../../../shared/guards/auth.guard";
import { JobComponent } from "../job.component";
import { JobRequestComponent } from "../job-request/job-request.component";
import { JobQuoteComponent } from "../job-quote/job-quote.component";

@Component({
    templateUrl: './job-route.component.html'
})

export class JobRouteComponent implements OnInit {
    constructor(
        private route: ActivatedRoute,
        private router: Router,
        private jobService: JobServices,
        private componentFactoryResolver: ComponentFactoryResolver) {

    }

    childrenRoutes: Routes;
    jobid: number;
    Currentjob: Job = new Job();

    @ViewChild('dynamicview', { read: ViewContainerRef })
    viewContainer: ViewContainerRef;


    ngOnInit() {
        this.route.params.subscribe(params => {
            this.jobService.getJob(+params['id'])
                .subscribe(job => this.loadcomponent(job.json()));
        },
            error => {
                this.router.navigate(['/jobs']);
            });
    }

    private loadcomponent(job: Job) {
        const componentFactory = this.componentFactoryResolver.resolveComponentFactory(this.getComponent(job.jobStatusId));
        this.viewContainer.clear();

        const componentRef = this.viewContainer.createComponent(componentFactory);
        componentRef.instance.jobdata = job;
    }

    private getComponent(jobstatusid: number): Type<any> {
        switch (jobstatusid) {
            case jobstatuses.Active:
                return JobDetailComponent;
            case jobstatuses.New:
            case jobstatuses.Requested:
                return JobRequestComponent;
            case jobstatuses.QuoteNeeded:
            case jobstatuses.QuotePending:
                return JobQuoteComponent;
            default:
                return JobComponent;
        }
    }
}