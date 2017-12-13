import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';

import { AuthenticatedComponentBase } from '../../../../shared/bases/authenticated.component.base';
import { ModalService } from '../../../../core/services/modal.service';
import { NotificationService } from '../../../../core/services/notification.service';
import { StateService } from '../../../../core/services/state.service';

import { Address } from '../../../../shared/models/address.model';
import { State } from "../../../../shared/models/state.model";
import { AddressService } from '../../../../core/services/address.service';
import { CommonService } from "../../../../core/services/common.service";

/**
 * Component to handle editing an Address
 */
@Component({
    templateUrl: './address-detail.component.html'
})
export class AddressDetailComponent extends AuthenticatedComponentBase implements OnInit {
    constructor(
        public modalService: ModalService,
        private route: ActivatedRoute,
        private router: Router,
        public commonService: CommonService,
        public notificationService: NotificationService,
        private addressService: AddressService,
        stateService: StateService) {
        super(modalService, notificationService, stateService);
    }

    address: Address = new Address();
    processing: boolean = false;
    private states: Array<State>;

    ngOnInit() {
        this.commonService.getStates()
            .subscribe(
            s => {
                this.states = s.json();
                this.loadAddress();
            },
            e => {
                console.log(e._body);
            });
     }

    /**
     * Loads Address data based on {id} route parameter
     */
    loadAddress() {
        this.processing = true;
        this.route.params
            .switchMap((params: Params) => this.addressService.getAddress(+params['id']))
            .subscribe(
            address => {
                this.address = address.json();
                this.processing = false;
            },
            error => {
                this.router.navigate(['/admin/addresses']);
                this.processing = false;
            });
    }

    /**
     * Saves the Address
     */
    saveAddress() {
        this.processing = true;
        this.addressService.saveAddress(this.address)
            .subscribe(
            response => {
                let r: Address = response.json()
                this.notificationService.notify('success', 'Address was saved successfully.');
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
     * Deletes the Address by provided address id
     */
    deleteAddress() {
        this.processing = true;
        this.addressService.deleteAddress(this.address.id)
            .subscribe(
            response => {
                this.notificationService.notify('warning', "The address has been deleted.");
                this.closeModal('deleteAddress');
                this.processing = false;
                this.router.navigate(['/admin/addresses']);
            },
            error => {
                this.notificationService.notify('error', error._body);
                this.processing = false;
                this.closeModal('deleteAddress');
            });
    }
}