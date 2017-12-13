import { Component, EventEmitter, Input, Output } from '@angular/core';

import { AuthenticatedComponentBase } from '../../../bases/authenticated.component.base';
import { ModalService } from '../../../../core/services/modal.service';
import { NotificationService } from '../../../../core/services/notification.service';
import { StateService } from '../../../../core/services/state.service';

import { AddressService } from '../../../../core/services/address.service';
import { LocationService } from '../../../../core/services/location.service';

import { Location } from '../../../models/location.model';
import { Address } from '../../../models/address.model';

@Component({
    selector: 'location',
    templateUrl: './location.component.html'
})
export class LocationComponent extends AuthenticatedComponentBase {
    constructor(
        public modalService: ModalService,
        public notificationService: NotificationService,
        private locationService: LocationService,
        stateService: StateService) {
        super(modalService, notificationService, stateService);
    }

    @Output() save: EventEmitter<any> = new EventEmitter();

    @Input() location: Location;
    @Input() addresses: Array<Address>;
    @Input() hideCancel: boolean = false;
    @Input() processing: boolean = false;

    saveLocation(event: any) {
        this.processing = true;
        this.locationService.saveLocation(this.location)
            .subscribe(
            location => {
                this.location = location.json();
                this.notificationService.notify('success', 'Location saved successfully.');
                this.stateService.refreshToken();
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