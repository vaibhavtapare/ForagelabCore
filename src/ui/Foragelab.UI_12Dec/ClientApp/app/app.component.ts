import { Component, HostBinding} from '@angular/core';

import { SettingService } from './core/services/setting.service';

@Component({
    selector: 'body',
    templateUrl: './app.component.html'
})

export class AppComponent {
    constructor(private settingService: SettingService) { }

    @HostBinding('class.windows')
    @HostBinding('class.desktop')
    @HostBinding('class.pace-done')
    @HostBinding('class.sidebar-visible')
    @HostBinding('class.menu-pin')
    @HostBinding('class.sidebar-open')
    get isCollapsed() {
        return !this.settingService.layout.isCollapsed;
    }

    @HostBinding('class.menu-pin')
    get isPinned() {
        return this.settingService.layout.isPinned;
    }
}