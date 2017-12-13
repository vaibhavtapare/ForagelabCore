import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { DomSanitizer } from '@angular/platform-browser';
import * as _ from 'lodash';

import { AuthenticatedComponentBase } from '../../../shared/bases/authenticated.component.base';
import { ModalService } from '../../../core/services/modal.service';
import { NotificationService } from '../../../core/services/notification.service';
import { RoleService } from '../../../core/services/role.service';
import { StateService } from '../../../core/services/state.service';
import { UserService } from '../../../core/services/user.service';
import { ContactService } from "../../../core/services/contact.service";

import { Address } from '../../../shared/models/address.model';
import { Transaction, transactionFullDataTableConfig } from '../../../shared/models/transaction.model';
import { User } from '../../../shared/models/user.model';
import { Role } from '../../../shared/models/role.model';

import { phoneMask } from '../../../shared/masks/phone.mask';
import { ssnMask } from '../../../shared/masks/ssn.mask';

import { Pagination } from '../../../shared/models/pagination.model';
import { DataTableConfig } from '../../../shared/models/data-table-config.model';
import { Contact } from "../../../shared/models/contact.model";

/*
* Component for editing or archiving a contact
*/
@Component({
    templateUrl: './contact-detail.component.html'
})
export class ContactDetailComponent extends AuthenticatedComponentBase implements OnInit {
    constructor(
        private sanitizer: DomSanitizer,
        public modalService: ModalService,
        private route: ActivatedRoute,
        private router: Router,
        private roleService: RoleService,
        private userService: UserService,
        public notificationService: NotificationService,
        private contactService: ContactService,
        stateService: StateService) {
        super(modalService, notificationService, stateService);
    }

    private phoneMask = phoneMask;
    private ssnMask = ssnMask;
    profileImage: any;

    @ViewChild("fileInput") fileInput;

    private roles: Array<Role>;
    private userRoles: Array<Role>;

    contact: Contact = new Contact();
    address: Address = new Address();
    user: User = new User();
    processing: boolean = false;

    transactionsLoading: boolean = false;
    transactionPagination: Pagination = new Pagination(null);
    transactionsConfig: DataTableConfig = transactionFullDataTableConfig;
    transactions: Array<Transaction>;

    ngOnInit() {
        this.loadContact();
        this.loadRoles();
        this.transactionPagination.pageSize = 3;
        this.transactionPagination.pageIndex = 0;
    }

    /*
    * Loads all Roles
    */
    loadRoles() {
        this.roleService.getRoles()
            .subscribe(
            success => {
                this.roles = success.json();
            },
            error => { });
    }

    /*
    * Loads the contact information and then loads subsequent datasets for the contact
    */
    loadContact() {
        this.processing = true;
        this.route.params
            .switchMap((params: Params) => this.contactService.getContact(+params['contactId']))
            .subscribe(
            contact => {
                this.contact = contact.json();
                this.processing = false;
                this.loadUser();
                this.loadUserRoles();
                this.loadTransactions();
            },
            error => {
                this.router.navigate(['/clients']);
                this.processing = false;
            });
    }

    /*
    * Loads transactions associated with the contact
    */
    loadTransactions() {
        this.transactionsLoading = true;
        this.contactService.getTransactions(this.contact.id, this.transactionsConfig, this.transactionPagination)
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
    * Saves the contact object
    */
    saveContact() {
        this.processing = true;
        this.contactService.saveContact(this.contact)
            .subscribe(
            response => {
                this.notificationService.notify('success', this.contact.firstName + ' ' + this.contact.lastName + ' was saved successfully.');
                this.processing = false;
                window.scrollTo(0, 0);
                this.loadTransactions();
            },
            error => {
                this.notificationService.notify('error', error._body);
                this.processing = false;
                window.scrollTo(0, 0);
            });
    }

    /*
    * Loads user associated with the contact
    */
    loadUser() {
        if (this.contact && this.contact.userId) {
            this.contactService.getUser(this.contact.id)
                .subscribe(
                user => {
                    this.user = user.json();
                    if (this.contact.emailAddress)
                    {
                        this.user.emailAddress = this.contact.emailAddress;
                    }
                    if (this.user.profileImage) {
                        this.profileImage = this.sanitizer.bypassSecurityTrustUrl('data:image/jpg;base64,' + this.user.profileImage);
                    }
                    this.loadUserRoles();
                },
                error => {
                });
        }
    }


    /*
    * Saves the user associated with the contact
    */
    saveUser() {
        this.processing = true;
        if (this.contact.emailAddress) {
            this.user.emailAddress = this.contact.emailAddress
        }
        if (((!this.user.password || this.user.password.length == 0) &&
            (!this.user.confirmPassword || this.user.confirmPassword.length == 0)) ||
            (this.user.password == this.user.confirmPassword)) {
            this.contactService.saveUser(this.contact.id, this.user)
                .subscribe(
                user => {
                    this.user = user.json();
                    this.notificationService.notify('success', 'User saved successfully.');
                    this.processing = false;
                },
                error => {
                    this.notificationService.notify('error', error._body);
                    this.processing = false;
                });
        }
        else {
            this.notificationService.notify('error', 'Passwords must match');
            this.processing = false;
        }
    }

    /*
    * Loads user associated with the contact
    */
    loadUserRoles() {
        if (this.user && this.user.id > 0) {
            this.processing = true;
            this.userService.getRoles(this.user.id)
                .subscribe(
                success => {
                    this.userRoles = success.json();
                    this.processing = false;
                },
                error => {
                    this.processing = false;
                });
        }
    }

    /*
    * Checks user role exist or not
    */
    isInRole(roleId: number): boolean {
        return _.find(this.userRoles, function (o) { return o.id == roleId; }) != null;
    }

    /*
    * Add/Remove role by checked or unchecked the role checkbox
    */
    toggleRoleCheck(role: Role) {
        this.processing = true;
        if (this.isInRole(role.id)) {
            this.userService.removeRole(this.user.id, role.id)
                .subscribe(s => {
                    this.loadUserRoles();
                    this.notificationService.notify('warning', 'Removed ' + role.name + ' role from user.');
                    this.processing = false;
                }, e => {
                    this.notificationService.notify('error', 'There was a problem removing this role.  Please try again.');
                    this.processing = false;
                });
        }
        else {
            this.userService.addRole(this.user.id, role.id)
                .subscribe(s => {
                    this.loadUserRoles();
                    this.notificationService.notify('success', 'Added ' + role.name + ' role to user.');
                    this.processing = false;
                }, e => {
                    this.notificationService.notify('error', 'There was a problem adding this role.  Please try again.');
                    this.processing = false;
                });
        }
    }

    /*
    * Saves the profile image of the user associated with the contact
    */
    saveProfileImage() {
        this.processing = true;
        if (this.user && this.user.id > 0) {
            let fi = this.fileInput.nativeElement;
            if (fi.files && fi.files[0]) {
                let fileToUpload = fi.files[0];
                this.userService.saveProfileImage(this.user.id, fileToUpload).subscribe(
                    r => {
                        this.notificationService.notify('success', "Profile image updated.");
                        this.loadUser();
                    },
                    err => {
                        this.notificationService.notify('error', err);
                        this.processing = false;
                    });
            }
            else {
                this.processing = false;
            }
        }
    }

    /*
    * Deactivates the user associated with the contact
    */
    deactivateUser() {
        if (this.user) {
            this.processing = true;
            this.userService.archiveUser(this.user.id)
                .subscribe(
                response => {
                    this.notificationService.notify('warning', this.contact.firstName + ' ' + this.contact.lastName + "'s user account has been deactivated.");
                    this.closeModal('dectivateContact');
                    this.loadUser();
                },
                error => {
                    this.notificationService.notify('error', error._body);
                    this.processing = false;
                    this.closeModal('dectivateContact');
                });
        }
    }

    /*
    * Reactivates the user associated with the contact
    */
    reactivateUser() {
        if (this.user) {
            this.processing = true;
            this.userService.unarchiveUser(this.user.id)
                .subscribe(
                response => {
                    this.notificationService.notify('success', this.contact.firstName + ' ' + this.contact.lastName + "'s user account has been reactivated.");
                    this.closeModal('activateContact');
                    this.loadUser();
                },
                error => {
                    this.notificationService.notify('error', error._body);
                    this.processing = false;
                    this.closeModal('activateContact');
                });
        }
    }

    /*
    * Archives the current contact
    */
    archiveContact() {
        this.processing = true;
        this.contactService.deleteContact(this.contact.id)
            .subscribe(
            response => {
                this.notificationService.notify('warning', this.contact.firstName + ' ' + this.contact.lastName + "' has been archived.");
                this.closeModal('archiveContact');
                this.processing = false;
                this.router.navigate(['/clients/',this.contact.clientId]);
            },
            error => {
                this.notificationService.notify('error', error._body);
                this.processing = false;
                this.closeModal('archiveContact');
            });
    }


}