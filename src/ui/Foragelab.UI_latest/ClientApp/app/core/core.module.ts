import { NgModule, Optional, SkipSelf } from '@angular/core';
import { FeedCodeService } from "./services/feedcode.service";
import { ModalService } from "./services/modal.service";

@NgModule({
    providers: [
        FeedCodeService, 
        ModalService
    ],
})
export class CoreModule {
    constructor( @Optional() @SkipSelf() parentModule: CoreModule) {
        if (parentModule) {
            throw new Error(
                'CoreModule is already loaded. Import it in the AppModule only');
        }
    }
}
