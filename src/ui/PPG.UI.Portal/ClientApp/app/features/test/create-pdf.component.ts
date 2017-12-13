import { Component, OnInit } from '@angular/core';

import { AuthenticatedComponentBase } from '../../shared/bases/authenticated.component.base';
import { ModalService } from '../../core/services/modal.service';
import { NotificationService } from '../../core/services/notification.service';
import { StateService } from '../../core/services/state.service';
import * as FileSaver from 'file-saver';

import { CreatePDFService } from '../../core/services/create-pdf.service';

@Component({
    templateUrl: './create-pdf.component.html'
})

/**
 * Component for displaying the create-pdf (to be completed later)
 */
export class CreatePDFComponent extends AuthenticatedComponentBase implements OnInit {
    constructor(
        public modalService: ModalService,
        public notificationService: NotificationService,
        private createPDFservice: CreatePDFService,
        stateService: StateService) {
        super(modalService, notificationService, stateService);
    }
    processing: boolean = false;

    GeneratePDF() {
        this.processing = true;
        this.createPDFservice.generateTestPDF()
            .subscribe(
            response => {
            },
            error => {
                this.notificationService.notify('error', error._body);
                this.processing = false;
            });
    }
}