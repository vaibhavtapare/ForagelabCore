import { Directive, Input, TemplateRef, ViewContainerRef } from '@angular/core';

import { StateService } from '../../../core/services/state.service';

@Directive({
    selector: '[permission]'
})
export class PermissionDirective { 
    constructor(
        private stateService: StateService,
        private templateRef: TemplateRef<any>,
        private viewContainer: ViewContainerRef) { }

    @Input() set permission(requiredPermission: string) {
        if (this.stateService.hasPrivilege(requiredPermission)) {
            this.viewContainer.createEmbeddedView(this.templateRef);
        } else {
            this.viewContainer.clear();
        }
    }
}

@Directive({
    selector: '[noPermission]'
})
export class NoPermissionDirective {
    constructor(
        private stateService: StateService,
        private templateRef: TemplateRef<any>,
        private viewContainer: ViewContainerRef) { }

    @Input() set noPermission(requiredPermission: string) {
        if (!this.stateService.hasPrivilege(requiredPermission)) {
            this.viewContainer.createEmbeddedView(this.templateRef);
        } else {
            this.viewContainer.clear();
        }
    }
}