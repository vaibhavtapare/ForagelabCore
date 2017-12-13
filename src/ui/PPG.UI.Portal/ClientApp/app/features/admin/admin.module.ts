import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { ARTermsComponent } from './ar-terms/ar-terms.component';
import { ARTermsAddComponent } from './ar-terms/ar-terms-add/ar-terms-add.component';
import { ARTermsDetailComponent } from './ar-terms/ar-terms-detail/ar-terms-detail.component';
import { RoleComponent } from './role/role.component'
import { RoleAddComponent } from './role/role-add/role-add.component'
import { RoleDetailComponent } from './role/role-detail/role-detail.component'
import { UserComponent } from './user/user.component'
import { AddressComponent } from './address/address.component';
import { AddressDetailComponent } from './address/address-detail/address-detail.component';

import { adminRoutes } from './admin-routing.module';
import { SharedModule } from '../../shared/shared.module';

/**
 * Module to manage all administrative tasks
 */
@NgModule({
    declarations: [
        ARTermsComponent,
        ARTermsAddComponent,
        ARTermsDetailComponent,
        RoleComponent,
        RoleAddComponent,
        RoleDetailComponent,
        UserComponent,
        AddressComponent,
        AddressDetailComponent
    ],
    imports: [
        SharedModule,

        RouterModule.forChild(adminRoutes)
    ],
    exports: [
        RouterModule
    ]
})
export class AdminModule {
}
