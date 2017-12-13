import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { JobComponent } from './job.component'
import { JobDetailComponent } from './job-detail/job-detail.component'
import { jobRoutes } from './job-routing.module';
import { JobRouteComponent } from './job-route/job-route.component';
import { JobRequestComponent } from "./job-request/job-request.component";
import { JobQuoteComponent } from "./job-quote/job-quote.component";
import { JobClosureComponent } from "./job-closure/job-closure.component";
import { DragulaModule } from 'ng2-dragula';

import { SharedModule } from '../../shared/shared.module';
import { WorkInstructionModule } from '../../features/work-instruction/work-instruction.module';

@NgModule({
    declarations: [
        JobComponent,
        JobDetailComponent,
        JobRequestComponent,
        JobRouteComponent,
        JobQuoteComponent,
        JobClosureComponent
    ],
    entryComponents: [JobRouteComponent, JobDetailComponent, JobRequestComponent, JobQuoteComponent],
    imports: [
        SharedModule,
        DragulaModule,
        WorkInstructionModule,
        RouterModule.forChild(jobRoutes)
    ],
    exports: [
        RouterModule
    ]
})
export class JobModule {
}
