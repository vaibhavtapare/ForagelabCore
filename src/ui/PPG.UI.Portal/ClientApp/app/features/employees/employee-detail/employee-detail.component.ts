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
import { ClientService } from "../../../core/services/client.service";

import { Employee, employeeStatuses, employeeTypes } from '../../../shared/models/employee.model';
import { EmployeeService } from '../../../core/services/employee.service';

import { Address } from '../../../shared/models/address.model';
import { Transaction, transactionFullDataTableConfig } from '../../../shared/models/transaction.model';
import { User } from '../../../shared/models/user.model';
import { Role } from '../../../shared/models/role.model';

import { phoneMask } from '../../../shared/masks/phone.mask';
import { ssnMask } from '../../../shared/masks/ssn.mask';

import { Pagination } from '../../../shared/models/pagination.model';
import { DataTableConfig } from '../../../shared/models/data-table-config.model';
import { IListBoxItem } from "ng2-dual-list-box/models";
import { Client } from "../../../shared/models/client.model";
import { Location } from "../../../shared/models/location.model";
import { UserClientLocation } from "../../../shared/models/userclientlocation.model";

/**
 * Component for displaying, editing & archiving employee information
 */
@Component({
    templateUrl: './employee-detail.component.html'
})
export class EmployeeDetailComponent extends AuthenticatedComponentBase implements OnInit {
    constructor(
        private sanitizer: DomSanitizer,
        public modalService: ModalService,
        private route: ActivatedRoute,
        private router: Router,
        private roleService: RoleService,
        private userService: UserService,
        private clientService: ClientService,
        public notificationService: NotificationService,
        private employeeService: EmployeeService,
        stateService: StateService) {
        super(modalService, notificationService, stateService);
    }

    private phoneMask = phoneMask;
    private ssnMask = ssnMask;
    profileImage: any;

    @ViewChild("fileInput") fileInput;
    @ViewChild('locationdualbox') dualbox;

    private employeeStatuses: any = employeeStatuses;
    private employeeTypes: any = employeeTypes;
    private roles: Array<Role>;
    private userRoles: Array<Role>;

    employee: Employee = new Employee();
    address: Address = new Address();
    user: User = new User();
    processing: boolean = false;
    locationprocessing: boolean = false;
    clientprocessing: boolean = false;
    clients: Array<Client>;
    locationClients: Client[] = new Array<Client>();
    selectedClients = [];
    selectedLocations = [];
    selectedclientId: number;
    isWildCard: boolean = true;

    locations: Array<Location>;
    userclientlocations: Array<UserClientLocation>;

    transactionsLoading: boolean = false;
    transactionPagination: Pagination = new Pagination(null);
    transactionsConfig: DataTableConfig = transactionFullDataTableConfig;
    transactions: Array<Transaction>;
    
    ngOnInit() {
        this.loadEmployee();
        this.loadRoles();
        this.transactionPagination.pageSize = 3;
        this.transactionPagination.pageIndex = 0;
    }

    /**
     * Loads all roles available to be assigned to employees user record
     */
    loadRoles() {
        this.roleService.getRoles()
            .subscribe(
            success => {
                this.roles = success.json();
            },
            error => { });
    }

    /**
     * Loads the employee record and associated record sets
     */
    loadEmployee() {
        this.processing = true;
        this.route.params
            .switchMap((params: Params) => this.employeeService.getEmployee(+params['id']))
            .subscribe(
            employee => {
                this.employee = employee.json();
                this.processing = false;
                this.loadAddress();
                this.loadUser();
                this.loadUserRoles();
                this.loadTransactions();
            },
            error => {
                this.router.navigate(['/employees']);
                this.processing = false;
            });
    }

    /**
     * Saves the employee via the employeeService
     */
    saveEmployee() {
        this.processing = true;
        this.employeeService.saveEmployee(this.employee)
            .subscribe(
            response => {
                let emp: Employee = response.json()
                this.notificationService.notify('success', this.employee.firstName + ' ' + this.employee.lastName + ' was saved successfully.');
                this.processing = false;
                window.scrollTo(0, 0);
                this.loadTransactions();
            },
            error => {
                this.notificationService.notify('error', error);
                this.processing = false;
                window.scrollTo(0, 0);
            });
    }

    /**
     * Loads all transactions associated with the user for the timeline interface
     */
    loadTransactions() {
        this.transactionsLoading = true;
        this.employeeService.getTransactions(this.employee.id, this.transactionsConfig, this.transactionPagination)
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

    /**
     * Archives an employee (and closes the user account if one exists)
     */
    archiveEmployee() {
        this.processing = true;
        this.employeeService.deleteEmployee(this.employee.id)
            .subscribe(
            response => {
                this.notificationService.notify('warning', this.employee.firstName + ' ' + this.employee.lastName + "' has been archived.");
                this.closeModal('archiveEmployee');
                this.processing = false;
                this.router.navigate(['/employees']);
            },
            error => {
                this.notificationService.notify('error', error._body);
                this.processing = false;
                this.closeModal('archiveEmployee');
            });
    }

    /**
     * Loads the personal address of the employee
     */
    loadAddress() {
        if (this.employee && this.employee.addressId) {
            this.employeeService.getAddress(this.employee.id)
                .subscribe(
                address => {
                    this.address = address.json();
                },
                error => {
                });
        }
    }

    saveAddress() {

    }

    /**
     * Loads the employees user record
     */
    loadUser() {
        if (this.employee && this.employee.userId) {
            this.employeeService.getUser(this.employee.id)
                .subscribe(
                user => {
                    this.user = user.json();
                    if (this.user.profileImage) {
                        this.profileImage = this.sanitizer.bypassSecurityTrustUrl('data:image/jpg;base64,' + this.user.profileImage);
                    }
                    this.loadUserRoles();
                    this.loadClients();
                },
                error => {
                });
        }
    }

    /**
     * Saves the employees user record
     */
    saveUser() {
        this.processing = true;

        if (((!this.user.password || this.user.password.length == 0) &&
            (!this.user.confirmPassword || this.user.confirmPassword.length == 0)) ||
            (this.user.password == this.user.confirmPassword)) {
            this.employeeService.saveUser(this.employee.id, this.user)
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

    /**
     * Loads user roles associated with the employees user if it exists.
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

    /**
     * Filter to determine whether the user exists in the specified role
     * @param roleId {number} Unique identifier of the role to check for the users existence in
     */
    isInRole(roleId: number): boolean {
        return _.find(this.userRoles, function (o) { return o.id == roleId; }) != null;
    }

    /**
     * Toggles adding/removing the user to or from the provided role
     * @param role {Role} Role to add/remove user to/from
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

    /**
     * Uploads and saves the employees profile image associated with their user account
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
                        this.processing = false;
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

    /**
     * Deactivates an employees user access
     */
    deactivateUser() {
        if (this.user) {
            this.processing = true;
            this.userService.archiveUser(this.user.id)
                .subscribe(
                response => {
                    this.notificationService.notify('warning', this.employee.firstName + ' ' + this.employee.lastName + "'s user account has been deactivated.");
                    this.closeModal('dectivateEmployee');
                    this.loadUser();
                },
                error => {
                    this.notificationService.notify('error', error._body);
                    this.processing = false;
                    this.closeModal('dectivateEmployee');
                });
        }
    }

    /**
     * Reactivates an employees previous user account
     */
    reactivateUser() {
        if (this.user) {
            this.processing = true;
            this.userService.unarchiveUser(this.user.id)
                .subscribe(
                response => {
                    this.notificationService.notify('success', this.employee.firstName + ' ' + this.employee.lastName + "'s user account has been reactivated.");
                    this.closeModal('activateEmployee');
                    this.loadUser();
                },
                error => {
                    this.notificationService.notify('error', error._body);
                    this.processing = false;
                    this.closeModal('activateEmployee');
                });
        }
    }

    /**
     * Loads clients for client rights assignment
     */
    loadClients() {
        this.processing = true;
        this.clientService.getClients()
            .subscribe(
            response => {
                this.clients = response.json();
                this.loadUserClientLocations();
                this.processing = false;
            },
            error => {
                this.notificationService.notify('error', error);
                this.processing = false;
            });
    }

    /**
     * Loads locations based on selected client and loads all locations to assign access rights
     */
    loadLocations(event: any) {
        this.locations = new Array<Location>();
        this.locationprocessing = true;
        this.clientService.getLocations(event.target.value)
            .subscribe(
            response => {
                this.locations = response.json();
                let selectedlocationIds = [];
                this.selectedLocations = [];
                let userId: number = this.employee.userId;
                selectedlocationIds = _.filter(this.userclientlocations, function (u) { return u.userId == userId && u.clientId == event.target.value && u.locationId != null });
                for (var i = 0; i < selectedlocationIds.length; i++) {
                    this.selectedLocations.push(selectedlocationIds[i].locationId.toString());
                }
                this.dualbox.selectedItems = [];
                this.dualbox.availableItems = [];
                this.locationprocessing = false;
            },
            error => {
                this.notificationService.notify('error', error);
                this.locationprocessing = false;
            });
    }

    /**
     * Loads user client locations based on employee user
     */
    loadUserClientLocations() {
        this.clientprocessing = true;
        this.employeeService.getUserclientlocation(this.employee.userId)
            .subscribe(response => {
                this.userclientlocations = response.json();
                let userId: number = this.employee.userId;
                let selectedclientIds = [];
                let selectedlocationIds = [];
                this.selectedClients = new Array();
                if (this.userclientlocations != null) {
                    this.isWildCard = _.some(this.userclientlocations, function (u) { return (u.clientId == null && u.locationId == null) });
                    selectedclientIds = _.filter(this.userclientlocations, function (u) { return u.userId == userId && u.clientId != null && u.locationId == null });
                    for (var i = 0; i < selectedclientIds.length; i++) {
                        this.selectedClients.push(selectedclientIds[i].clientId.toString());
                    }
                    this.updateClients();
                }
                this.clientprocessing = false;
            },
            error => {
                this.notificationService.notify('error', error);
                this.clientprocessing = false;
            });
    }

     /**
     * Event for toggle selection to add/remove wildcard entry for user's client location
     */
    toggleAccessClientCheck(e: any) {
        this.isWildCard = !this.isWildCard;
        this.processing = true;
        if (this.isWildCard) {
            // Removes all old entries of clientuserlocation for current user
            this.removeAllUserClientLocations();

            // creates userclientlocation for wildcard entry
            let userclientLocation: UserClientLocation = new UserClientLocation();
            userclientLocation.clientId = null;
            userclientLocation.locationId = null;
            userclientLocation.userId = this.employee.userId;
            this.addUserClientLocation(userclientLocation);
        }
        else {
            this.removeAllUserClientLocations();
        }
    }

     /**
     * Event for when add/remove client to selected list
     */
    onClientMove(item: any) {
        this.clientprocessing = true;
        let selectedItems: Array<{}>;
        let userclientLocations: UserClientLocation[] = new Array<UserClientLocation>();
        selectedItems = _.find(item.selected, function (o) { return o.value == item.movedItems[0] });
        if (selectedItems) {
            for (var i = 0; i < item.movedItems.length; i++) {
                let userclientLocation: UserClientLocation = new UserClientLocation();
                userclientLocation.clientId = item.movedItems[i];
                userclientLocation.userId = this.employee.userId;
                userclientLocation.locationId = null;
                userclientLocations.push(userclientLocation);
            }
            this.addUserClientLocations(userclientLocations);
        }
        else {
            this.removeUserClientLocationsByClient(item.movedItems);
        }
    }

     /**
     * Event for when add/remove location to selected list
     */
    onLocationMove(item: any) {
        this.locationprocessing = true;
        let selectedItems: Array<{}>;
        let userclientLocations: UserClientLocation[] = new Array<UserClientLocation>();
        selectedItems = _.find(item.selected, function (o) { return o.value == item.movedItems[0] });
        if (selectedItems) {
            for (var i = 0; i < item.movedItems.length; i++) {
                let userclientLocation: UserClientLocation = new UserClientLocation();
                userclientLocation.clientId = this.selectedclientId;
                userclientLocation.userId = this.employee.userId;
                userclientLocation.locationId = item.movedItems[i];
                userclientLocations.push(userclientLocation);
            }
            this.addUserClientLocations(userclientLocations);
        }
        else {
            this.removeUserClientLocationsByLocation(item.movedItems);
        }
    }

    /**
     * Updates clients based on assigned client access list
     */
    updateClients() {
        if (this.clients) {
            this.locationClients = this.clients.filter(function (e) { return this.indexOf(e.id.toString()) < 0; }, this.selectedClients);
            this.selectedclientId = 0;
            if (this.dualbox) {
                if (this.dualbox.selectedItems)
                { this.dualbox.selectedItems = []; }
                if (this.dualbox.availableItems) {
                    this.dualbox.availableItems = [];
                }
            }
        }
    }

    /**
     * Adds user's client and location
     * @param userclientLocation {UserClientLocation} UserClientLocation object to save
    */
    private addUserClientLocation(userclientLocation: UserClientLocation) {
        this.employeeService.createUserClientLocation(userclientLocation)
            .subscribe(
            response => {
                this.notificationService.notify('success', "User has been updated with client(s) & location(s) access.");
                this.processing = false;
            },
            error => {
                this.notificationService.notify('error', error);
                this.processing = false;
            });
    }

    /**
     * Adds all user's clients and locations
     * @param userclientLocations {Array<UserClientLocation>} UserClientLocation object list to save
    */
    private addUserClientLocations(userclientLocations: Array<UserClientLocation>) {
        this.employeeService.createUserClientLocations(userclientLocations).subscribe(
            response => {
                this.notificationService.notify('success', "User has been added with client(s) & location(s) access.");
                this.updateClients();
                this.clientprocessing = false;
                this.locationprocessing = false;
            },
            error => {
                this.notificationService.notify('error', error);
                this.clientprocessing = false;
                this.locationprocessing = false;
            });
    }

    /**
     * Removes all user's clients and locations by selected clients
     * @param clients {Array<number>} Selected Client Id list to remove
    */
    private removeUserClientLocationsByClient(clients: Array<number>) {
        this.employeeService.RemoveUserClientLocationByClient(clients, this.employee.userId)
            .subscribe(
            response => {
                this.notificationService.notify('success', "User has been removed with client(s) & location(s) access.");
                this.updateClients();
                this.clientprocessing = false;
            },
            error => {
                this.clientprocessing = false;
            });
    }

    /**
    * Removes all user's clients and locations by selected locations
    * @param clients {Array<number>} Selected Location Id list to remove
   */
    private removeUserClientLocationsByLocation(locations: Array<number>) {
        this.employeeService.RemoveUserClientLocationByLocation(locations, this.employee.userId)
            .subscribe(
            response => {
                this.notificationService.notify('success', "User has been removed with client(s) & location(s) access.");
                this.locationprocessing = false;
            },
            error => {
                this.locationprocessing = false;
            });
    }

    /**
     * Removes all user's clients and locations by current user
     */
    private removeAllUserClientLocations() {
        this.employeeService.RemoveUserClientLocationByUser(this.employee.userId)
            .subscribe(
            response => {
                this.notificationService.notify('success', "User has been removed with client(s) & location(s) access.");
                this.processing = false;
            },
            error => {
                this.processing = false;
            });
    }

}