import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { PerfectScrollbarModule, PerfectScrollbarConfigInterface } from 'ngx-perfect-scrollbar';
import { TimeAgoPipe } from 'time-ago-pipe';

import { PhoneNumberPipe } from './pipes/phoneNumber.pipe';
import { ShortDescriptionPipe } from './pipes/shortDescription.pipe';

import { AddressComponent } from './components/forms/address/address.component';
import { ContactComponent } from './components/forms/contact/contact.component';
import { JobAddComponent } from './components/forms/job-add/job-add.component';
import { LocationComponent } from './components/forms/location/location.component';

import { FileFocusComponent } from './components/file-focus/file-focus.component';
import { ModalComponent } from './components/modal/modal.component';
import { DataTableComponent } from './components/data-table/data-table.component';
import { InProgressDirective } from './directives/in-progress/in-progress.directive';
import { InProgressComponent } from './directives/in-progress/in-progress.component';
import { InputFocusComponent } from './components/input-focus/input-focus.component';
import { TextAreaFocusComponent } from './components/textarea-focus/textarea-focus.component';
import { PasswordFocusComponent } from './components/password-focus/password-focus.component';
import { PaginationComponent } from './components/pagination/pagination.component';
import { PaginationSummaryComponent } from './components/pagination-summary/pagination-summary.component';
import { PermissionDirective, NoPermissionDirective } from './directives/permission/permission.directive';
import { SelectFocusComponent } from './components/select-focus/select-focus.component';
import { TimeLineComponent } from './components/timeline/timeline.component';
import { TimeLineItemComponent } from './components/timeline/timeline-item/timeline-item.component';

import { AuthGuard } from './guards/auth.guard';

const PERFECT_SCROLLBAR_CONFIG: PerfectScrollbarConfigInterface = {
    suppressScrollX: true
};

@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        HttpModule,
        RouterModule,
        PerfectScrollbarModule.forRoot(PERFECT_SCROLLBAR_CONFIG)
    ],
    declarations: [
        PhoneNumberPipe,
        ShortDescriptionPipe,
        TimeAgoPipe,

        AddressComponent,
        ContactComponent,
        JobAddComponent,
        LocationComponent,
        NoPermissionDirective,
        FileFocusComponent,
        DataTableComponent,
        InProgressDirective,
        InProgressComponent,
        InputFocusComponent,
        ModalComponent,
        PaginationComponent,
        PaginationSummaryComponent,
        PasswordFocusComponent,
        PermissionDirective,
        SelectFocusComponent,
        TextAreaFocusComponent,
        TimeLineComponent,
        TimeLineItemComponent
    ],
    entryComponents: [
        InProgressComponent
    ],
    exports: [
        CommonModule,
        FormsModule,
        HttpModule,
        RouterModule,
        PerfectScrollbarModule,

        AddressComponent,
        ContactComponent,
        JobAddComponent,
        LocationComponent,

        PhoneNumberPipe,
        ShortDescriptionPipe,
        TimeAgoPipe,

        InProgressDirective,
        InputFocusComponent,
        PermissionDirective,
        NoPermissionDirective,
        FileFocusComponent,
        DataTableComponent,
        ModalComponent,
        PaginationComponent,
        PaginationSummaryComponent,
        PasswordFocusComponent,
        SelectFocusComponent,
        TextAreaFocusComponent,
        TimeLineComponent,
        TimeLineItemComponent
    ],
    providers: [
        AuthGuard
    ]
})
export class SharedModule {
}
