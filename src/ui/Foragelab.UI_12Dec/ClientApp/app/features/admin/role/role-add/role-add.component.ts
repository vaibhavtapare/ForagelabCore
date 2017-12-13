import { Component } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';

import { AuthenticatedComponentBase } from '../../../../shared/bases/authenticated.component.base';
import { ModalService } from '../../../../core/services/modal.service';
import { NotificationService } from '../../../../core/services/notification.service';
import { StateService } from '../../../../core/services/state.service';

import { Role } from '../../../../shared/models/role.model';
import { RoleService } from '../../../../core/services/role.service';

/**
 * Component for adding a new role
 */
@Component({
    templateUrl: './role-add.component.html'
})
export class RoleAddComponent extends AuthenticatedComponentBase {
    constructor(
        public modalService: ModalService,
        private route: ActivatedRoute,
        private router: Router,
        public notificationService: NotificationService,
        private roleService: RoleService,
        stateService: StateService) {
        super(modalService, notificationService, stateService);
    }

    role: Role = new Role();
    processing: boolean = false;

    /**
     * Saves the new role via the RoleService
     */
    saveRole() {
        this.processing = true;
        this.roleService.saveRole(this.role)
            .subscribe(
            response => {
                let r: Role = response.json()
                this.notificationService.notify('success', this.role.name + ' was saved successfully.');
                this.router.navigate(['/admin/roles/detail', r.id]);
                this.processing = false;
            },
            error => {
                this.notificationService.notify('error', error);
                this.processing = false;
                window.scrollTo(0, 0);
            });
    }
}