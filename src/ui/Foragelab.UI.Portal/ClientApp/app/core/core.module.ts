import { NgModule, Optional, SkipSelf } from "@angular/core";
import { StateService } from "./services/state.service";
import { AuthService } from "./services/auth.service";
import { CookieService } from "ngx-cookie-service";

@NgModule({
    providers: [
        CookieService,
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