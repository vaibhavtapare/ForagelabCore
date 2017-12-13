import { NgModule } from "@angular/core";
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { DataTableComponent } from "./components/data-table/data-table.component";
import { ModalComponent } from "./components/modal/modal.component";
import { PaginationComponent } from "./components/pagination/pagination.component";
import { PaginationSummaryComponent } from "./components/pagination-summary/pagination-summary.component";


@NgModule({
    imports: [      
        CommonModule,
        FormsModule,
        HttpModule,
        RouterModule,
    ],
    declarations: [        
        DataTableComponent,       
        ModalComponent,
        PaginationComponent,
        PaginationSummaryComponent        
    ],
    entryComponents: [
        
    ],
    exports: [       
        DataTableComponent,
        ModalComponent,
        PaginationComponent,
        PaginationSummaryComponent
       
    ],   
})
export class SharedModule {
}
