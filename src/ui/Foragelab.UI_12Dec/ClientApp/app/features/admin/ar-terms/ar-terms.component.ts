import { Component } from '@angular/core';

import { AuthenticatedComponentBase } from '../../../shared/bases/authenticated.component.base';
import { ModalService } from '../../../core/services/modal.service';
import { NotificationService } from '../../../core/services/notification.service';
import { StateService } from '../../../core/services/state.service';

import { ARTerm, arTermsFullDataTableConfig } from '../../../shared/models/ar-term.model';
import { ARTermService } from '../../../core/services/ar-terms.service';

import { Pagination } from '../../../shared/models/pagination.model';
import { DataTableConfig } from '../../../shared/models/data-table-config.model';

/**
 * Component for displaying a list of AR terms
 */
@Component({
    templateUrl: './ar-terms.component.html'
})
export class ARTermsComponent extends AuthenticatedComponentBase {
    constructor(
        public modalService: ModalService,
        public notificationService: NotificationService,
        private arTermService: ARTermService,
        stateService: StateService) {
        super(modalService, notificationService, stateService);
    }

    areTermsLoading: boolean = false;
    searchFor: string = '';
    termsPagination: Pagination;
    termsConfig: DataTableConfig = arTermsFullDataTableConfig;

    hasFullPrivileges: boolean = false;

    ngOnInit() {
        this.hasFullPrivileges = this.stateService.hasPrivilege('ar terms - full');

        this.termsConfig.filter = () => {
            if (this.searchFor.length == 0) {
                return null;
            }
            return 'name ctn ' + this.searchFor;
        };

        this.loadARTerms();
    }

    arTerms: Array<ARTerm>;

    /**
     * Loads the listing of AR terms
     */
    loadARTerms() {
        this.areTermsLoading = true;
        this.arTermService.getARTerms(this.termsConfig, this.termsPagination).subscribe(
            arTerms => {
                this.arTerms = arTerms.json();
                this.termsPagination = this.getPagination(arTerms);
                this.areTermsLoading = false;
            },
            error => {
                this.notificationService.notify('error', error);
                this.areTermsLoading = false;
            });
    }

    /**
     * Fires when the filter is changed to reload the list of
     * AR terms filtered by the provided string.
     */
    filterChanged() {
        if (this.searchFor.length > 1) {
            this.loadARTerms();
        }
    }
}