import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { WorkInstructionDetailComponent } from './work-instruction-detail/work-instruction-detail.component';
import { WorkInstructionStepDetailComponent} from './work-instruction-defect-detail/work-instruction-defect-detail.component';
import { DragulaModule } from 'ng2-dragula';

import { SharedModule } from '../../shared/shared.module';

/**
 * Module for managing workinstructions
 */
@NgModule({
    declarations: [
        WorkInstructionDetailComponent,
        WorkInstructionStepDetailComponent
    ],
    imports: [
        SharedModule,
        DragulaModule
    ],
    exports: [
        RouterModule
    ]
})
export class WorkInstructionModule {
}
