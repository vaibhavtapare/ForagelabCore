import { Component } from '@angular/core';

import { SettingService } from '../core/services/setting.service';
import { StateService } from '../core/services/state.service';

@Component({
    templateUrl: './layout.component.html'
})

export class LayoutComponent  {
    constructor(
        public stateService: StateService,
        public settingService: SettingService) { }
}