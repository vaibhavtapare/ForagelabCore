import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { ClientComponent } from './client.component'
import { ClientAddComponent } from './client-add/client-add.component'
import { ClientDetailComponent } from './client-detail/client-detail.component'
import { clientRoutes } from './client-routing.module';

import { LocationDetailComponent } from './location-detail/location-detail.component'
import { ContactDetailComponent } from "./contact-detail/contact-detail.component";

import { SharedModule } from '../../shared/shared.module';

@NgModule({
    declarations: [
        ClientComponent,
        ClientAddComponent,
        ClientDetailComponent,

        LocationDetailComponent,
        ContactDetailComponent

    ],
    imports: [
        SharedModule,

        RouterModule.forChild(clientRoutes)
    ],
    exports: [
        RouterModule
    ]
})
export class ClientModule {
}
