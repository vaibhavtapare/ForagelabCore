import { Component, EventEmitter, Input, Output } from '@angular/core';

import { AuthenticatedComponentBase } from '../../../bases/authenticated.component.base';
import { ModalService } from '../../../../core/services/modal.service';
import { NotificationService } from '../../../../core/services/notification.service';
import { StateService } from '../../../../core/services/state.service';

import { ContactService } from '../../../../core/services/contact.service';

import { Location } from '../../../models/location.model';
import { Contact } from '../../../models/contact.model';

@Component({
    selector: 'contact',
    templateUrl: './contact.component.html'
})
export class ContactComponent extends AuthenticatedComponentBase {
    constructor(
        public modalService: ModalService,
        public notificationService: NotificationService,
        private contactService: ContactService,
        stateService: StateService) {
        super(modalService, notificationService, stateService);
    }

    @Output() save: EventEmitter<any> = new EventEmitter();

    @Input() contact: Contact;
    @Input() locations: Array<Location>;
    @Input() hideCancel: boolean = false;
    @Input() processing: boolean = false;

    saveContact(event: any) {
        this.processing = true;
        this.contactService.saveContact(this.contact)
            .subscribe(
            contact => {
                this.contact = contact.json();
                this.notificationService.notify('success', 'Contact saved successfully.');
                this.processing = false;
                this.save.emit(true);
            },
            error => {
                this.notificationService.notify('error', error._body);
                this.processing = false;
                this.save.emit(false);
            });
    }

    close() {
        this.save.emit(false);
    }
}