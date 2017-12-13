import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';

import { AuthenticatedComponentBase } from '../../../../shared/bases/authenticated.component.base';
import { ModalService } from '../../../../core/services/modal.service';
import { NotificationService } from '../../../../core/services/notification.service';
import { StateService } from '../../../../core/services/state.service';

import { ARTerm } from '../../../../shared/models/ar-term.model';
import { ARTermService } from '../../../../core/services/ar-terms.service';

/**
 * Component to handle editing an AR term
 */
@Component({
    templateUrl: './ar-terms-detail.component.html'
})
export class ARTermsDetailComponent extends AuthenticatedComponentBase implements OnInit {
    constructor(
        public modalService: ModalService,
        private route: ActivatedRoute,
        private router: Router,
        public notificationService: NotificationService,
        private arTermsService: ARTermService,
        stateService: StateService) {
        super(modalService, notificationService, stateService);
    }

    arTerm: ARTerm = new ARTerm();
    processing: boolean = false;

    ngOnInit() {
        this.loadARTerm();
    }

    /**
     * Loads AR term data based on {id} route parameter
     */
    loadARTerm() {
        this.processing = true;
        this.route.params
            .switchMap((params: Params) => this.arTermsService.getARTerm(+params['id']))
            .subscribe(
            arTerm => {
                this.arTerm = arTerm.json();
                this.processing = false;
            },
            error => {
                this.router.navigate(['/admin/ar-terms']);
                this.processing = false;
            });
    }

    /**
     * Saves the AR term via the ARTermService
     */
    saveARTerm() {
        this.processing = true;
        this.arTermsService.saveARTerm(this.arTerm)
            .subscribe(
            response => {
                let r: ARTerm = response.json()
                this.notificationService.notify('success', this.arTerm.name + ' was saved successfully.');
                this.processing = false;
                window.scrollTo(0, 0);
            },
            error => {
                this.notificationService.notify('error', error);
                this.processing = false;
                window.scrollTo(0, 0);
            });
    }

    /**
     * Deletes the AR term via the ARTermService
     */
    deleteARTerm() {
        this.processing = true;
        this.arTermsService.deleteARTerm(this.arTerm.id)
            .subscribe(
            response => {
                this.notificationService.notify('warning', "The '" + this.arTerm.name + "' AR Term has been deleted.");
                this.closeModal('deleteARTerm');
                this.processing = false;
                this.router.navigate(['/admin/ar-terms']);
            },
            error => {
                this.notificationService.notify('error', error._body);
                this.processing = false;
                this.closeModal('deleteARTerm');
            });
    }
}