import { Component, Input } from '@angular/core';
import { Router } from '@angular/router';

import { MenuItem } from '../../../shared/models/menu-item.model';

@Component({
    selector: 'menu-sublevel',
    templateUrl: './menu-sub-level.component.html'
})

export class MenuSubLevelComponent {
    constructor(private router: Router) { }

    @Input()
    menuItem: MenuItem;

    navigate() {
        if (this.menuItem.link) {
            let link = this.menuItem.link.toString();
            this.router.navigate([link]);
        }
    }
}