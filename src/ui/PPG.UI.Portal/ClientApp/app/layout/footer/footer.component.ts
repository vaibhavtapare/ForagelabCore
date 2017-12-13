import { Component, Input } from '@angular/core';
import { Router } from '@angular/router';

import { StateService } from '../../core/services/state.service';

@Component({
    selector: 'app-footer',
    templateUrl: './footer.component.html'
})

export class FooterComponent {
    constructor(
        private router: Router,
        private stateService: StateService) { }

 
}