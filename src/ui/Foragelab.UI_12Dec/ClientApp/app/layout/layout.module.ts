import { NgModule, Optional, SkipSelf } from '@angular/core';

import { FooterComponent } from './footer/footer.component';
import { HeaderComponent } from './header/header.component';
import { LayoutComponent } from './layout.component';
import { NotificationBarComponent } from './notification-bar/notification-bar.component';
import { NotificationPopupComponent } from './notification-popup/notification-popup.component';
import { SidebarComponent } from './sidebar/sidebar.component';

import { MenuTopLevelComponent } from './sidebar/menu-top-level/menu-top-level.component';
import { MenuSubLevelComponent } from './sidebar/menu-sub-level/menu-sub-level.component';

import { SharedModule } from '../shared/shared.module';

@NgModule({
    imports: [
        SharedModule
    ],
    declarations: [
        FooterComponent,
        HeaderComponent,
        LayoutComponent,
        NotificationBarComponent,
        NotificationPopupComponent,
        SidebarComponent,

        MenuTopLevelComponent,
        MenuSubLevelComponent
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
