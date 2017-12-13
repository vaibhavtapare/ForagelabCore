import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

import { ClientService } from '../../../../core/services/client.service';
import { JobServices } from '../../../../core/services/job.service';
import { LocationService } from '../../../../core/services/location.service';
import { ModalService } from '../../../../core/services/modal.service';
import { NotificationService } from '../../../../core/services/notification.service';
import { StateService } from '../../../../core/services/state.service';
import { ContactService } from "../../../../core/services/contact.service";

import { AuthenticatedComponentBase } from '../../../bases/authenticated.component.base';

import { Client } from '../../../models/client.model';
import { Job, jobTypes } from '../../../models/job.model';
import { Location } from '../../../models/location.model';
import { usertypes } from "../../../models/user.model";
import { Contact } from "../../../models/contact.model";

@Component({
    selector: 'job-add',
    templateUrl: './job-add.component.html'
})
export class JobAddComponent extends AuthenticatedComponentBase implements OnInit {
    constructor(
        public modalService: ModalService,
        public notificationService: NotificationService,
        public stateService: StateService,
        private contactService:ContactService,
        private jobService: JobServices,
        private clientService: ClientService,
        private locationService: LocationService) {
        super(modalService, notificationService, stateService);
    }

    ngOnInit() {
        if (this.job == null) {
            this.job = new Job();
        }
        if (this.client) {
            this.job.clientId = this.client.id;
        }
        if (this.location) {
            this.job.clientId = this.location.clientId;
            this.job.locationId = this.location.id;
        }
        if (!this.job.clientId || this.job.clientId == 0) {
            this.loadClients();
        }
       
        if (this.stateService.currentUser.userTypeId == usertypes.Contact) {
            this.isclientDisabled = true;
            this.isclientHide = true;
            this.iscontactDisabled = false;
            
        }
    }

    @Output() save: EventEmitter<any> = new EventEmitter();

    @Input() job: Job;
    @Input() client: Client;
    @Input() location: Location;

    @Input() hideCancel: boolean = false;
    @Input() processing: boolean = false;

    clients: Array<Client> = new Array<Client>();
    @Input() locations: Array<Location> = new Array<Location>();
    private jobTypes: any = jobTypes;
    isclientDisabled: boolean = false;
    iscontactDisabled: boolean = false;
    isclientHide: boolean = false;
    contact: Contact;

    loadClients() {
        this.processing = true;
        this.clientService.getClients()
            .subscribe(
            s => {
                this.clients = s.json();
                if (this.stateService.currentUser.userTypeId == usertypes.Contact) {
                    this.getContactByUser();
                }
                this.processing = false;
            },
            e => {
                this.processing = false;
            });
    }
    
    loadLocations() {
        this.processing = true;
        this.clientService.getLocations(this.job.clientId)
            .subscribe(
            s => {
                this.locations = s.json();
                if (this.stateService.currentUser.userTypeId == usertypes.Contact && this.job.locationId != null) {
                    this.iscontactDisabled = true;
                }
                else {
                    this.iscontactDisabled = false;
                }
                this.processing = false;
            },
            e => {
                this.processing = false;
            });
    }

    saveJob() {
        this.processing = true;
        this.jobService.saveJob(this.job)
            .subscribe(
            job => {
                this.job = job.json();
                this.processing = false;
                this.save.emit(this.job);
            },
            error => {
                this.notificationService.notify('error', error._body);
                this.processing = false;
                this.save.emit(null);
            });
    }

    close() {
        this.save.emit(null);
    }

    getContactByUser() {
        this.contactService.getContactByUser(this.stateService.currentUser.id).subscribe(
            contact => {
                if (this.clients != null) {
                this.contact = contact.json();
                this.job.clientId = this.contact.clientId;
                this.job.locationId = this.contact.locationId;
                this.loadLocations();
                }
            });
    }
}