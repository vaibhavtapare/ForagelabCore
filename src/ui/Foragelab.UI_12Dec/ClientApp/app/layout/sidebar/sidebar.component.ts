import { Component, HostBinding, HostListener, OnInit } from '@angular/core';
import { Title, DomSanitizer } from '@angular/platform-browser';
import { ActivatedRoute, NavigationEnd, Route, Router } from '@angular/router';

import { SettingService } from '../../core/services/setting.service';
import { StateService } from '../../core/services/state.service';

import { MenuItem } from '../../shared/models/menu-item.model';

@Component({
    selector: 'app-sidebar',
    templateUrl: './sidebar.component.html'
})

export class SidebarComponent implements OnInit {
    constructor(
        private sanitizer: DomSanitizer,
        private titleService: Title,
        private router: Router,
        private activatedRoute: ActivatedRoute,
        private settingService: SettingService,
        private stateService: StateService) {
    }

    ngOnInit() {

        let routeTree = this.router.config;
        this.menuItems = this.traverseRoutes(routeTree);
        
        this.router.events
            .filter(event => event instanceof NavigationEnd)
            .map(() => this.activatedRoute)
            .map(route => {
                while (route.firstChild) route = route.firstChild;
                return route;
            })
            .filter(route => route.outlet === 'primary')
            .mergeMap(route => route.data)
            .subscribe((event) => {
                this.menuItems.forEach((menuItem) => {
                    this.clearMenuItemState(menuItem);
                });
                if (event.menuItem) {
                    this.menuItems.forEach((menuItem) => {
                        this.identifyRoute(menuItem, event.menuItem);
                    });
                }
            });
    }

    @HostBinding('style.transform')
    get getStyle() {
        if (this.settingService.layout.isCollapsed) {
            return '';
        }

        return this.sanitizer.bypassSecurityTrustStyle('translate(210px, 0px)');
    }

    @HostListener('mouseover')
    onMouseOver() {
        this.settingService.layout.isCollapsed = false;
    }

    @HostListener('mouseleave')
    onMouseOut() {
        if (!this.settingService.layout.isPinned) {
            this.settingService.layout.isCollapsed = true;
        }
    }

    menuItems: MenuItem[] = new Array<MenuItem>();

    traverseRoutes(routes: Route[]): MenuItem[] {
        let mItems: MenuItem[] = new Array<MenuItem>();
        for (var i = 0; i < routes.length; i++) {
            let route: Route = routes[i];
            
            if (route.data && route.data.menuItem) {
                let menuItem: MenuItem = route.data.menuItem;
                if (this.stateService.canTraverseRoute(menuItem)) {
                    if (route.children) {
                        menuItem.submenu = this.traverseRoutes(route.children);
                    }
                    mItems.push(menuItem);
                }
            }
        };

        return mItems.length == 0 ? null : mItems;
    }

    clearMenuItemState(menuItem: MenuItem) {
        menuItem.isExpanded = false;
        menuItem.routeIsActive = false;
        if (menuItem.submenu) {
            menuItem.submenu.forEach((subMenuItem) => {
                this.clearMenuItemState(subMenuItem);
            });
        }
    }

    identifyRoute(currentMenuItem: MenuItem, routeMenuItem: MenuItem): boolean {
        let result: boolean = false;
        if (currentMenuItem.link == routeMenuItem.link) {
            currentMenuItem.routeIsActive = true;
            if (currentMenuItem.pageTitle) {
                let title = 'Preferred Precision Group | ' + currentMenuItem.pageTitle;
                this.titleService.setTitle(title);
            }
            result = true;
        }
        if (currentMenuItem.submenu) {
            currentMenuItem.submenu.forEach((submenuItem) => {
                let subMenuIsActive: boolean = this.identifyRoute(submenuItem, routeMenuItem);

                if (subMenuIsActive) {
                    currentMenuItem.isExpanded = true;
                    currentMenuItem.routeIsActive = true;
                    result = true;
                }
            });
        }

        return result;
    }

    isSidebarCollapsed() {
        return this.settingService.layout.isCollapsed;
    }

    toggleSubmenuHover(event) {
        let self = this;
        if (this.isSidebarCollapsed()) {
            event.preventDefault();
        }
    }

    toggleSidebarPinned() {
        this.settingService.toggleSetting('isPinned');
    }

}