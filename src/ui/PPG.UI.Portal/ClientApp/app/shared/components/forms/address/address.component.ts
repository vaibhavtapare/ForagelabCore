import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

import { AuthenticatedComponentBase } from '../../../bases/authenticated.component.base';
import { ModalService } from '../../../../core/services/modal.service';
import { NotificationService } from '../../../../core/services/notification.service';
import { StateService } from '../../../../core/services/state.service';

import { AddressService } from '../../../../core/services/address.service';
import { Address } from '../../../models/address.model';
import { CommonService } from '../../../../core/services/common.service';
import { State } from '../../../models/state.model';

@Component({
    selector: 'address',
    templateUrl: './address.component.html'
})
export class AddressComponent extends AuthenticatedComponentBase implements OnInit {
    constructor(
        public modalService: ModalService,
        public notificationService: NotificationService,
        public commonService: CommonService,
        stateService: StateService,
        private addressService: AddressService) {
        super(modalService, notificationService, stateService);
    }

    @Output() save: EventEmitter<any> = new EventEmitter();

    @Input() address: Address;
    @Input() hideCancel: boolean = false;
    @Input() processing: boolean = false;

    private states: Array<State>;

    ngOnInit() {
        this.commonService.getStates()
            .subscribe(
            s => {
                this.states = s.json();
            },
            e => {
                console.log(e._body);
            });
    }

    saveAddress(event: any) {
        this.processing = true;
        this.addressService.saveAddress(this.address)
            .subscribe(
            address => {
                this.address = address.json();
                this.notificationService.notify('success', 'Address saved successfully.');
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