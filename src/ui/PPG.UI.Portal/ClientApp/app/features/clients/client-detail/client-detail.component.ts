import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';

import { AuthenticatedComponentBase } from '../../../shared/bases/authenticated.component.base';

import { AddressService } from '../../../core/services/address.service';
import { ARTermService } from '../../../core/services/ar-terms.service';
import { ClientService } from '../../../core/services/client.service';
import { ModalService } from '../../../core/services/modal.service';
import { NotificationService } from '../../../core/services/notification.service';
import { StateService } from '../../../core/services/state.service';

import { Pagination } from '../../../shared/models/pagination.model';
import { DataTableConfig } from '../../../shared/models/data-table-config.model';

import { ARTerm } from '../../../shared/models/ar-term.model';
import { Client } from '../../../shared/models/client.model';
import { Address, addressFullDataTableConfig } from '../../../shared/models/address.model';
import { Contact, contactFullDataTableConfig } from '../../../shared/models/contact.model';
import { Job, jobFullDataTableConfig } from '../../../shared/models/job.model';
import { Location, locationFullDataTableConfig } from '../../../shared/models/location.model';
import { Transaction, transactionFullDataTableConfig } from '../../../shared/models/transaction.model';
import { usertypes } from "../../../shared/models/user.model";

/*
* Component for editing or archiving a client
*/
@Component({
    templateUrl: './client-detail.component.html'
})
export class ClientDetailComponent extends AuthenticatedComponentBase implements OnInit {
    constructor(
        public modalService: ModalService,
        private route: ActivatedRoute,
        private router: Router,
        public notificationService: NotificationService,
        private addressService: AddressService,
        private arTermService: ARTermService,
        private clientService: ClientService,
        stateService: StateService) {
        super(modalService, notificationService, stateService);
    } 

    client: Client = new Client();
    arTerms: Array<ARTerm>;
    allContacts: Array<Contact>;
    allLocations: Array<Location>;
    processing: boolean = false;

    newJob: Job = new Job();
    selectedAddress: Address = new Address();
    selectedContact: Contact = new Contact();

    newLocation: Location = new Location();
    newContact: Contact = new Contact();

    locationsLoading: boolean = false;
    locationsPagination: Pagination = new Pagination(null);
    locationsConfig: DataTableConfig = locationFullDataTableConfig;
    locations: Array<Location>;

    jobsLoading: boolean = false;
    jobsPagination: Pagination = new Pagination(null);
    jobsConfig: DataTableConfig = jobFullDataTableConfig;
    jobs: Array<Job>;

    contactsLoading: boolean = false;
    contactsPagination: Pagination = new Pagination(null);
    contactsConfig: DataTableConfig = contactFullDataTableConfig;
    contacts: Array<Contact>;

    transactionsLoading: boolean = false;
    transactionPagination: Pagination = new Pagination(null);
    transactionsConfig: DataTableConfig = transactionFullDataTableConfig;
    transactions: Array<Transaction>;

    ngOnInit() {
        this.transactionPagination.pageSize = 3;
        this.transactionPagination.pageIndex = 0;
        this.loadARTerms();
        this.loadAllLocations();
        this.loadClient();
    }

    /*
* Loads all AR terms for drop down of terms
*/
    loadARTerms() {
        this.arTermService.getARTerms()
            .subscribe(
            arTerms => {
                this.arTerms = arTerms.json();
            },
            error => {
            });
    }

    /*
    * Loads all locations for the current client
    */
    loadAllLocations() {
        this.route.params
            .switchMap((params: Params) => this.clientService.getLocations(+params['id']))
            .subscribe(
            location => {
                this.allLocations = location.json();
            },
            error => {
            });
    }

    /*
    * Loads the clients information and then loads subsequent datasets for the client
    */
    loadClient() {
        this.processing = true;
        this.route.params
            .switchMap((params: Params) => this.clientService.getClient(+params['id']))
            .subscribe(
            client => {
                this.client = client.json();
                this.newLocation.clientId = this.client.id;
                this.newContact.clientId = this.client.id;
                this.newJob.clientId = this.client.id;
                this.processing = false;
                this.loadTransactions();
                this.loadLocations();
                this.loadJobs();
                this.loadContacts();
            },
            error => {
                this.router.navigate(['/clients']);
                this.processing = false;
            });
    }

    /*
    * Loads locations associated with the client for the Location grid in the UI
    */
    loadLocations() {
        this.locationsLoading = true;
        this.clientService.getLocations(this.client.id, this.locationsConfig, this.locationsPagination)
            .subscribe(
            response => {
                this.locations = response.json();
                this.locationsPagination = this.getPagination(response);
                this.locationsLoading = false;
            },
            error => {
                this.notificationService.notify('error', error);
                this.locationsLoading = false;
            });
    }

    /*
    * Loads jobs associated with the client for the Job grid in the UI
    */
    loadJobs() {
        this.jobsLoading = true;
        this.clientService.getJobs(this.client.id, this.jobsConfig, this.jobsPagination)
            .subscribe(
            response => {
                this.jobs = response.json();
                this.jobsPagination = this.getPagination(response);
                if (this.stateService.currentUser.userTypeId == usertypes.Contact && this.jobs != null) {
                    this.newJob.clientId = this.jobs[0].clientId;
                    //this.newJob.locationId = this.jobs[0].locationId;
                }
                this.jobsLoading = false;
            },
            error => {
                this.notificationService.notify('error', error);
                this.jobsLoading = false;
            });
    }

    /*
    * Loads contacts associated with the client for the Contact grid in the UI
    */
    loadContacts() {
        this.contactsLoading = true;
        this.clientService.getContacts(this.client.id, this.contactsConfig, this.contactsPagination)
            .subscribe(
            response => {
                this.contacts = response.json();
                this.contactsPagination = this.getPagination(response);
                this.contactsLoading = false;
            },
            error => {
                this.notificationService.notify('error', error);
                this.contactsLoading = false;
            });
    }

    /*
    * Loads transactions associated with the client
    */
    loadTransactions() {
        this.transactionsLoading = true;
        this.clientService.getTransactions(this.client.id, this.transactionsConfig, this.transactionPagination)
            .subscribe(
            response => {
                this.transactions = response.json();
                this.transactionPagination = this.getPagination(response);
                this.transactionsLoading = false;
            },
            error => {
                this.notificationService.notify('error', error);
                this.transactionsLoading = false;
            });
    }

    /*
    * Saves the client object
    */
    saveClient() {
        this.processing = true;
        this.clientService.saveClient(this.client)
            .subscribe(
            client => {
                this.notificationService.notify('success', this.client.name + ' updated successfully.');
                this.processing = false;
                this.loadTransactions();
            },
            error => {
                this.notificationService.notify('error', error._body);
                this.processing = false;
            });
    }

    /*
    * Called after a location has been created to reload grids/datasets with locations so
    * they will include the newly created location.  Also closes the add location modal window.
    */
    saveLocation(event: any) {
        if (event) {
            this.newLocation = new Location();
            this.newLocation.clientId = this.client.id;
            this.loadLocations();
            this.loadAllLocations();
        }
        this.closeModal('addLocation');
    }

    /*
    * Archives the current client
    */
    archiveClient() {
        this.processing = true;
        this.clientService.deleteClient(this.client.id)
            .subscribe(
            response => {
                this.notificationService.notify('warning', this.client.name + "' has been archived.");
                this.closeModal('archiveClient');
                this.processing = false;
                this.router.navigate(['/clients']);
            },
            error => {
                this.notificationService.notify('error', error._body);
                this.processing = false;
                this.closeModal('archiveClient');
            });
    }

    /*
    * Called after a contact has been created to reload grids/datasets with contacts so
    * they will include the newly created contact.  Also closes the add contact modal window.
    */
    createContact(event: any) {
        if (event) {
            this.newContact = new Contact();
            this.newContact.clientId = this.client.id;
            this.loadContacts();
        }
        this.closeModal('addContact');
    }

    /*
    * Called after a job has been created to reload grids/datasets with jobs so
    * they will include the newly created job.  Also closes the add job modal window.
    */
    createJob(job: Job) {
        if (job) {
            this.newJob = new Job();
            this.newJob.clientId = this.client.id;
            this.loadJobs();
        }
        this.closeModal('addJob');
    }
}