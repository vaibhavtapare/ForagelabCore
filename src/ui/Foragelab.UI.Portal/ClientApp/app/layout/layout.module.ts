import { NgModule, Optional, SkipSelf } from '@angular/core';
import { SharedModule } from "../shared/shared.module";
import { LayoutComponent } from "./layout.component";

@NgModule({
    imports: [
        SharedModule
    ],
    declarations: [
        LayoutComponent
    ]
})
export class LayoutModule {
    constructor( @Optional() @SkipSelf() parentModule: LayoutModule) {
        if (parentModule) {
            throw new Error(
                'LayoutModule is already loaded. Import it in the AppModule only');
        }
    }
}