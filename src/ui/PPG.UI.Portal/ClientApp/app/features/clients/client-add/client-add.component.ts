import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { ARTermService } from '../../../core/services/ar-terms.service';
import { ClientService } from '../../../core/services/client.service';
import { ModalService } from '../../../core/services/modal.service';
import { NotificationService } from '../../../core/services/notification.service';
import { StateService } from '../../../core/services/state.service';

import { AuthenticatedComponentBase } from '../../../shared/bases/authenticated.component.base';

import { ARTerm } from '../../../shared/models/ar-term.model';
import { Client } from '../../../shared/models/client.model';

/*
* Component used to add a new client
*/
@Component({
    templateUrl: './client-add.component.html'
})
export class ClientAddComponent extends AuthenticatedComponentBase implements OnInit {
    constructor(
        public router: Router,
        public modalService: ModalService,
        public notificationService: NotificationService,
        private arTermService: ARTermService,
        public stateService: StateService,
        private clientService: ClientService) {
        super(modalService, notificationService, stateService);
    }

    ngOnInit() {
        this.loadARTerms();   
    }

    client: Client = new Client();
    arTerms: Array<ARTerm>;
    processing: boolean = false;

    /*
    * Loads listing of AR terms so user can select one for the new client
    */
    loadARTerms() {
        this.processing = true;
        this.arTermService.getARTerms()
            .subscribe(
            arTerms => {
                this.arTerms = arTerms.json();
                this.processing = false;
            },
            error => {
                this.processing = false;
            });
    }

    /*
    * Saves the new client and redirect to client listing
    */
    saveClient() {
        this.processing = true;
        this.clientService.saveClient(this.client)
            .subscribe(
            client => {
                this.client = client.json();
                this.processing = false;
                this.stateService.refreshToken();
                this.router.navigate(['/clients', this.client.id]);
            },
            error => {
                this.notificationService.notify('error', error._body);
                this.processing = false;
            });
    }
}