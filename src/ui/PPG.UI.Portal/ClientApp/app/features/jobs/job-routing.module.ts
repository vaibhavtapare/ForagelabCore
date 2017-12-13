import { Routes } from '@angular/router';

import { MenuItem } from '../../shared/models/menu-item.model';

import { LayoutComponent } from '../../layout/layout.component';

import { JobComponent } from './job.component';
import { JobDetailComponent } from './job-detail/job-detail.component';
import { JobRouteComponent} from './job-route/job-route.component';
import { WorkInstructionDetailComponent } from "../work-instruction/work-instruction-detail/work-instruction-detail.component";
import { WorkInstructionStepDetailComponent } from "../work-instruction/work-instruction-defect-detail/work-instruction-defect-detail.component";
import { JobClosureComponent } from "./job-closure/job-closure.component";

import { AuthGuard } from '../../shared/guards/auth.guard';

export const jobRoutes: Routes = [
    {
        path: 'jobs',
        component: LayoutComponent,
        canActivateChild: [AuthGuard],
        data: {
            menuItem: {
                text: 'Jobs',
                icon: 'fa-cubes',
                link: '/jobs',
                pageTitle: 'Jobs',
                iconBgClass: 'bg-menu-light',
                requiredPrivileges: ['jobs']
            }
        },
        children: [
            {
                path: '', pathMatch: 'full', component: JobComponent
            },
            {
                path: ':id', component: JobRouteComponent,
                data: {
                    menuItem: {
                        link: '/jobs/:id',
                        pageTitle: 'Job Detail',
                        requiredPrivileges: ['jobs']
                    }
                }
            },
            {
                path: ':id/work-instructions/:workInstructionId', component: WorkInstructionDetailComponent,
                data: {
                    menuItem: {
                        link: '/jobs/:id/work-instructions/:workInstructionId',
                        pageTitle: 'WorkInstruction Detail',
                        requiredPrivileges: ['workinstructions']
                    }
                }
            },
            {
                path: ':id/work-instructions/:workInstructionId/steps/:stepId', component: WorkInstructionStepDetailComponent,
                data: {
                    menuItem: {
                        link: '/jobs/:id/work-instructions/:workInstructionId/steps/:stepId',
                        pageTitle: 'WorkInstruction Defect Detail',
                        requiredPrivileges: ['workinstructions']
                    }
                }
            },
            {
                path: ':id/closure', component: JobClosureComponent,
                data: {
                    menuItem: {
                        link: '/jobs/:id/closure',
                        pageTitle: 'Job Closure',
                        requiredPrivileges: ['jobclosure']
                    }
                }
            }
        ]
    }
];