import { Component, Input, OnInit } from '@angular/core';
import { Title, DomSanitizer } from '@angular/platform-browser';
import { ActivatedRoute, NavigationEnd, Route, Router } from '@angular/router';

import { SettingService } from '../../../core/services/setting.service';

import { subMenuAnimation } from '../menu.animation';
import { MenuItem } from '../../../shared/models/menu-item.model';

import { NotificationService } from '../../../core/services/notification.service';

@Component({
    selector: 'menu-toplevel',
    templateUrl: './menu-top-level.component.html',
    animations: [subMenuAnimation]
})

export class MenuTopLevelComponent implements OnInit {
    constructor(
        private sanitizer: DomSanitizer,
        private titleService: Title,
        private router: Router,
        private activatedRoute: ActivatedRoute,
        private notificationService: NotificationService,
        public settingService: SettingService) {
    }

    @Input()
    menuItem: MenuItem;
    hasSubmenu: boolean = false;

    ngOnInit() {
        if (this.menuItem.submenu) {
            this.menuItem.submenu.forEach((item) => {
                if (item.icon) {
                    this.hasSubmenu = true;
                }
            });
        }
    }

    navigate() {
        if (!this.hasSubmenu) {
            this.router.navigate([this.menuItem.link]);
        } else {
            this.toggleExpansion();
        }
    }

    toggleExpansion() {
        this.menuItem.isExpanded = !this.menuItem.isExpanded;
    }
}