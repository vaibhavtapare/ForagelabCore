import { Component, OnInit } from '@angular/core';

import { AuthenticatedComponentBase } from '../../shared/bases/authenticated.component.base';

import { ClientService } from '../../core/services/client.service';
import { ModalService } from '../../core/services/modal.service';
import { NotificationService } from '../../core/services/notification.service';
import { StateService } from '../../core/services/state.service';

import { Client, clientFullDataTableConfig } from '../../shared/models/client.model';

import { Pagination } from '../../shared/models/pagination.model';
import { DataTableConfig } from '../../shared/models/data-table-config.model';

/*
* Component for displaying list of clients
*/
@Component({
    templateUrl: './client.component.html'
})
export class ClientComponent extends AuthenticatedComponentBase implements OnInit {
    constructor(
        public modalService: ModalService,
        public notificationService: NotificationService,
        private clientService: ClientService,
            stateService: StateService) {
        super(modalService, notificationService, stateService);
    } 

    areClientsLoading: boolean = false;
    searchFor: string = '';
    clientPagination: Pagination;
    clientsConfig: DataTableConfig = clientFullDataTableConfig;

    hasFullPrivileges: boolean = false;

    ngOnInit() {
        this.hasFullPrivileges = this.stateService.hasPrivilege('clients - full');

        this.clientsConfig.filter = () => {
            if (this.searchFor.length == 0) {
                return null;
            }
            return 'name ctn ' + this.searchFor; // + ' or ' +
                //'alias ctn ' + this.searchFor + ' or ' +
                //'phoneNumber ctn ' + this.searchFor + ' or ' +
                //'website ctn ' + this.searchFor + ' or ' +
                //'faxNumber ctn ' + this.searchFor;
        };

        this.loadClients();
    }

    clients: Array<Client>;

    /*
    * Loads clients to the UI grid
    */
    loadClients() {
        this.areClientsLoading = true;
        this.clientService.getClients(this.clientsConfig, this.clientPagination).subscribe(
            clients => {
                this.clients = clients.json();
                this.clientPagination = this.getPagination(clients);
                this.areClientsLoading = false;
            },
            error => {
                this.notificationService.notify('error', error);
                this.areClientsLoading = false;
            });
    }

    /*
    * Reloads the grid of clients when the searchFor value has changed
    */
    filterChanged() {
        if (this.searchFor.length > 1) {
            this.loadClients();
        }
    }
}