import { Component } from '@angular/core';

import { AuthenticatedComponentBase } from '../../../shared/bases/authenticated.component.base';
import { ModalService } from '../../../core/services/modal.service';
import { NotificationService } from '../../../core/services/notification.service';
import { StateService } from '../../../core/services/state.service';

import { Address, adminaddressFullDataTableConfig } from '../../../shared/models/address.model';
import { AddressService } from '../../../core/services/address.service';

import { Pagination } from '../../../shared/models/pagination.model';
import { DataTableConfig } from '../../../shared/models/data-table-config.model';

/**
 * Component for displaying a list of AR terms
 */
@Component({
    templateUrl: './address.component.html'
})
export class AddressComponent extends AuthenticatedComponentBase {
    constructor(
        public modalService: ModalService,
        public notificationService: NotificationService,
        private addressService: AddressService,
        stateService: StateService) {
        super(modalService, notificationService, stateService);
    }

    addressesLoading: boolean = false;
    addressesPagination: Pagination;
    addressesConfig: DataTableConfig = adminaddressFullDataTableConfig;
    newAddress: Address = new Address();
    
    ngOnInit() {
        this.loadAddresses();
    }

    addresses: Array<Address>;

    /**
     * Loads the listing of Addresses
     */
    loadAddresses() {
        this.addressesLoading = true;
        this.addressService.getAddresses(this.addressesConfig, this.addressesPagination).subscribe(
            addresses => {
                this.addresses = addresses.json();
                this.addressesPagination = this.getPagination(addresses);
                this.addressesLoading = false;
            },
            error => {
                this.notificationService.notify('error', error);
                this.addressesLoading = false;
            });
    }

  /*
  * Called after an address has been created to reload grids/datasets with addresses so
  * they will include the newly created address.  Also closes the add address modal window.
  */
    createAddress(event: any) {
        if (event) {
            this.newAddress = new Address();
            this.loadAddresses();
        }
        this.closeModal('addAddress');
    }
}