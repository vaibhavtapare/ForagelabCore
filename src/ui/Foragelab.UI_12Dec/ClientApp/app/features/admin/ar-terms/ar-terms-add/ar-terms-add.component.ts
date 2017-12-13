import { Component } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';

import { AuthenticatedComponentBase } from '../../../../shared/bases/authenticated.component.base';
import { ModalService } from '../../../../core/services/modal.service';
import { NotificationService } from '../../../../core/services/notification.service';
import { StateService } from '../../../../core/services/state.service';

import { ARTerm } from '../../../../shared/models/ar-term.model';
import { ARTermService } from '../../../../core/services/ar-terms.service';

/**
 * Component for adding a new AR term
 */
@Component({
    templateUrl: './ar-terms-add.component.html'
})
export class ARTermsAddComponent extends AuthenticatedComponentBase {
    constructor(
        public modalService: ModalService,
        private route: ActivatedRoute,
        private router: Router,
        public notificationService: NotificationService,
        private arTermService: ARTermService,
        stateService: StateService) {
        super(modalService, notificationService, stateService);
    }

    arTerm: ARTerm = new ARTerm();
    processing: boolean = false;

    /**
     * Saves the AR term via the ARTermService
     */
    saveARTerm() {
        this.processing = true;
        this.arTermService.saveARTerm(this.arTerm)
            .subscribe(
            response => {
                let r: ARTerm = response.json()
                this.notificationService.notify('success', this.arTerm.name + ' was saved successfully.');
                this.router.navigate(['/admin/ar-terms/detail', r.id]);
                this.processing = false;
            },
            error => {
                this.notificationService.notify('error', error);
                this.processing = false;
                window.scrollTo(0, 0);
            });
    }
}