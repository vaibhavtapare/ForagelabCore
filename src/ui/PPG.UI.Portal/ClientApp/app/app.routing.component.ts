import { Component, OnInit } from '@angular/core';
import { Router } from "@angular/router";
import { AuthenticatedComponentBase } from "./shared/bases/authenticated.component.base";
import { StateService } from "./core/services/state.service";
import { ModalService } from "./core/services/modal.service";
import { NotificationService } from "./core/services/notification.service";
import { usertypes } from "./shared/models/user.model";

/**
 * Component for routing of the application based on user type
 */
@Component({
    template:'<template></template>'
})

export class AppRoutingComponent extends AuthenticatedComponentBase implements OnInit {
    constructor(public modalService: ModalService,
        public notificationService: NotificationService,
        public stateService: StateService, private router: Router) {
        super(modalService, notificationService, stateService);
      }

    ngOnInit() {
        this.RedirectRoute();
    }

    /**
     * Redirects to starting page based on user type
     */
    RedirectRoute() {
        if (this.stateService.currentUser) {
            if (this.stateService.currentUser.userTypeId == usertypes.Contact) {
                this.router.navigateByUrl('/jobs');
            }
            else{
               this.router.navigateByUrl('/dashboard');
            }
        }
        else {
            this.router.navigateByUrl('/auth/login');
        }
        
    }

}