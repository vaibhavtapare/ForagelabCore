import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';

import { AuthenticatedComponentBase } from '../../../shared/bases/authenticated.component.base';

import { ClientService } from '../../../core/services/client.service';
import { ModalService } from '../../../core/services/modal.service';
import { NotificationService } from '../../../core/services/notification.service';
import { StateService } from '../../../core/services/state.service';

import { Pagination } from '../../../shared/models/pagination.model';
import { DataTableConfig } from '../../../shared/models/data-table-config.model';

import { Address } from '../../../shared/models/address.model';
import { Contact, contactFullDataTableConfig } from '../../../shared/models/contact.model';
import { Job, jobFullDataTableConfig } from '../../../shared/models/job.model';
import { Transaction, transactionFullDataTableConfig } from '../../../shared/models/transaction.model';
import { Location } from '../../../shared/models/location.model';
import { LocationService } from '../../../core/services/location.service';

/*
* Component used to edit details of a location and its related child objects
*/
@Component({
    templateUrl: './location-detail.component.html'
})

export class LocationDetailComponent extends AuthenticatedComponentBase implements OnInit {
    constructor(
        public modalService: ModalService,
        private route: ActivatedRoute,
        private router: Router,
        public notificationService: NotificationService,
        private locationService: LocationService,
        private clientService: ClientService,
        stateService: StateService) {
        super(modalService, notificationService, stateService);
    }

    location: Location = new Location();
    newContact: Contact = new Contact();
    newJob: Job = new Job();
    allAddresses: Array<Address>;
    processing: boolean = false;

    jobsLoading: boolean = false;
    jobsPagination: Pagination = new Pagination(null);
    jobsConfig: DataTableConfig = jobFullDataTableConfig;
    jobs: Array<Job>;

    transactionsLoading: boolean = false;
    transactionPagination: Pagination = new Pagination(null);
    transactionsConfig: DataTableConfig = transactionFullDataTableConfig;
    transactions: Array<Transaction>;

    contactsLoading: boolean = false;
    contactsPagination: Pagination = new Pagination(null);
    contactsConfig: DataTableConfig = contactFullDataTableConfig;
    contacts: Array<Contact>;

    ngOnInit() {
        this.transactionPagination.pageSize = 3;
        this.transactionPagination.pageIndex = 0;
        this.newJob.clientId = this.location.clientId;
        this.newJob.locationId = this.location.id;
        this.loadLocation();
    }

    /*
    * Loads the current location based on the locationId route parameter
    */
    loadLocation() {
        this.processing = true;
        this.route.params
            .switchMap((params: Params) => this.locationService.getLocation(+params['locationId']))
            .subscribe(
            location => {
                this.location = location.json();
                this.newContact.clientId = this.location.clientId;
                this.newContact.locationId = this.location.id;
                this.newJob.clientId = this.location.clientId;
                this.newJob.locationId = this.location.id;
                this.processing = false;
                this.loadTransactions();
                this.loadJobs();
                this.loadContacts();
            },
            error => {
                this.router.navigate(['/clients']);
                this.processing = false;
            });
    }

    /*
    * Loads jobs associated with the current location to the jobs grid
    */
    loadJobs() {
        this.jobsLoading = true;
        this.locationService.getJobs(this.location.id, this.jobsConfig, this.jobsPagination)
            .subscribe(
            response => {
                this.jobs = response.json();
                this.jobsPagination = this.getPagination(response);
                this.jobsLoading = false;
            },
            error => {
                this.notificationService.notify('error', error);
                this.jobsLoading = false;
            });
    }

    /*
    * Loads transactions associated with the current location to the timeline
    */
    loadTransactions() {
        this.transactionsLoading = true;
        this.locationService.getTransactions(this.location.id, this.transactionsConfig, this.transactionPagination)
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
    * Loads contacts associated with the current location to the contacts grid
    */
    loadContacts() {
        this.contactsLoading = true;
        this.locationService.getContacts(this.location.id, this.contactsConfig, this.contactsPagination)
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
    * Fired after saving a location.  Reloads transactions
    */
    saveLocation(event: any) {
        this.loadTransactions();
    }

    /*
    * Archives the current location
    */
    archiveLocation() {
        this.processing = true;
        this.locationService.deleteLocation(this.location.id)
            .subscribe(
            response => {
                this.notificationService.notify('warning', this.location.name + "' has been archived.");
                this.closeModal('archiveLocation');
                this.processing = false;
                this.router.navigate(['/clients', this.location.clientId]);
            },
            error => {
                this.notificationService.notify('error', error._body);
                this.processing = false;
                this.closeModal('archiveLocation');
            });
    }

    /*
    * Called after a contact is created to reload the contact grid and close the add contact modal
    */
    createContact(event: any) {
        if (event) {
            this.newContact = new Contact();
            this.newContact.clientId = this.location.clientId;
            this.newContact.locationId = this.location.id;
            this.loadContacts();
        }
        this.closeModal('addContact');
    }

    /*
    * Called after a job is created to reload the job grid and close the add job modal
    */
    createJob(job: Job) {
        if (job) {
            this.newJob = new Job();
            this.newJob.clientId = this.location.clientId;
            this.newJob.locationId = this.location.id;
            this.loadJobs();
        }
        this.closeModal('addJob');
    }
}