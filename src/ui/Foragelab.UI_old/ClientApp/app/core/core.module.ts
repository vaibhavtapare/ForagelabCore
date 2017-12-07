/**
 * The CoreModule contains all services used by more than one feature module.
 * Per Angular style guides, it can only be loaded at the AppModule level of the
 * application.
 */
import { CookieService } from "angular2-cookie/services/cookies.service";
import { NgModule, Optional, SkipSelf } from "@angular/core";
import { NotificationService } from "./services/notification.service";
import { AuthService } from "./services/auth.service";
import { StateService } from "./services/state.service";

@NgModule({
    providers: [
        CookieService,
        NotificationService,      
        StateService,       
        AuthService
       
    ]
})
export class CoreModule {
    constructor( @Optional() @SkipSelf() parentModule: CoreModule) {
        if (parentModule) {
            throw new Error(
                'CoreModule is already loaded. Import it in the AppModule only');
        }
    }
}
