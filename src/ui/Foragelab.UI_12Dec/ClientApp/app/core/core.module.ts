import { NgModule, Optional, SkipSelf } from '@angular/core';
import { CookieService } from 'angular2-cookie/services/cookies.service';

import { NotificationService } from './services/notification.service';
import { SettingService } from './services/setting.service';
import { StateService } from './services/state.service';

import { AddressService } from './services/address.service';
import { ARTermService } from './services/ar-terms.service';
import { AuthService } from './services/auth.service';
import { ClientService } from './services/client.service';
import { ContactService } from './services/contact.service';
import { CommonService } from './services/common.service';
import { EmployeeService } from './services/employee.service';
import { JobServices } from './services/job.service';
import { LocationService } from './services/location.service';
import { ModalService } from './services/modal.service';
import { PermissionService } from './services/permission.service';
import { RoleService } from './services/role.service';
import { UserService } from './services/user.service';
import { TransactionService } from './services/transaction.service';
import { CreatePDFService } from './services/create-pdf.service';
import { WorkInstructionService } from './services/workinstruction.service';
import { ProductionReportServices } from './services/production-report.service';
import { RiskAssessmentService } from "./services/riskassessment.service"

/**
 * The CoreModule contains all services used by more than one feature module.
 * Per Angular style guides, it can only be loaded at the AppModule level of the
 * application.
 */
@NgModule({
    providers: [
        CookieService,
        NotificationService,
        SettingService,
        StateService,

        AddressService,
        ARTermService,
        AuthService,
        ClientService,
        ContactService,
        CommonService,
        EmployeeService,
        JobServices,
        LocationService,
        ModalService,
        PermissionService,
        RoleService,
        UserService,
        CreatePDFService,
        TransactionService,
        WorkInstructionService,
        ProductionReportServices,
        RiskAssessmentService
    ]
})
export class CoreModule {
    constructor( @Optional() @SkipSelf() parentModule: CoreModule) {
        if (parentModule) {
            throw new Error(
                'CoreModule is already loaded. Import it in the AppModule only');
        }
    }
}
