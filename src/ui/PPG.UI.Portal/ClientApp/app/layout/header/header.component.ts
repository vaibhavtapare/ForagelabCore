import { Component, Inject, Input } from '@angular/core';
import { DomSanitizer, SafeUrl } from '@angular/platform-browser';

import { ModalService } from '../../core/services/modal.service';
import { NotificationService } from '../../core/services/notification.service';
import { StateService } from '../../core/services/state.service';
import { SettingService } from '../../core/services/setting.service';
import { TransactionService } from '../../core/services/transaction.service';

import { AuthenticatedComponentBase } from '../../shared/bases/authenticated.component.base';

@Component({
    selector: 'app-header',
    templateUrl: './header.component.html'
})

export class HeaderComponent extends AuthenticatedComponentBase {
    constructor(
        @Inject('API_BASE') private API_BASE: string,
        @Inject('API_VERSION') private API_VERSION: string,
        private sanitizer: DomSanitizer,
        public modalService: ModalService,
        public notificationService: NotificationService,
        public stateService: StateService,
        private settingService: SettingService,
        public transactionService:TransactionService
    ) {
        super(modalService, notificationService, stateService);
        this.profileImage = this.sanitizer.bypassSecurityTrustUrl(this.API_BASE + '/api/v' + this.API_VERSION + '/profileimage/' + this.stateService.currentUser.id.toString());
  }

    profileImage: SafeUrl;

    toggleSidebar() {
        this.settingService.toggleSetting('isCollapsed');
    }
}