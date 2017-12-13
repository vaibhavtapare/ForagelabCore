import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { CreatePDFComponent } from './create-pdf.component'
import { CreatePDFRoutes } from './create-pdf-routing.module';

/**
 * Module for dashboard features
 */
@NgModule({
    declarations: [
        CreatePDFComponent
    ],
    imports: [
        RouterModule.forChild(CreatePDFRoutes)
    ],
    exports: [
        RouterModule
    ]
})
export class CreatePDFModule {
}
