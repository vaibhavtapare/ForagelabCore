import { Directive, Component, ComponentFactoryResolver, ComponentRef, Injector, Input, OnChanges, SimpleChange, ViewContainerRef } from '@angular/core';

import { InProgressComponent } from './in-progress.component';

@Directive({
    selector: '[in-progress]'
})
export class InProgressDirective {
    constructor(
        private cfResolver: ComponentFactoryResolver,
        private vcRef: ViewContainerRef,
        private injector: Injector) {

    }

    private inProgressRef: ComponentRef<InProgressComponent>;

    @Input('in-progress') serviceCallInProgress: boolean;

    ngOnChanges(changes: { [propKey: string]: SimpleChange }) {
        for (let propName in changes) {
            let changedProp = changes[propName];
            let to = changedProp.currentValue;
            if (to) {
                this.createInProgress();
            }
            else {
                this.destroyComponents();
            }
        }
    }

    ngOnDestroy() {
        this.destroyComponents();
    }

    private destroyComponents() {
        this.inProgressRef && this.inProgressRef.destroy();
    }

    private createInProgress() {
        const inProgressFactory = this.cfResolver.resolveComponentFactory(InProgressComponent);
        this.inProgressRef = this.vcRef.createComponent(inProgressFactory, null, this.injector);
        const instance = this.inProgressRef.instance;
    }
}