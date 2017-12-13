import { Component, Input } from '@angular/core';

import { NotificationService } from '../../core/services/notification.service';
import { Notification } from '../../shared/models/notification.model';

import { slideUpDownAnimation } from '../../shared/animations/slide-up-down.animation';

@Component({
    selector: 'notification-bar',
    templateUrl: './notification-bar.component.html',
    animations: [slideUpDownAnimation]
})

export class NotificationBarComponent {
    constructor(
        private notificationService: NotificationService) {
        notificationService.notifications$.subscribe(
            notice => {
                let id: string = Date.now().toString();
                notice.id = id;
                this.notifications.push(notice);
                setTimeout(() => {
                    let ind: number = -1;
                    this.notifications.forEach(function (n, i) {
                        if (n.id == id) {
                            ind = i;
                        }
                    });
                    if (ind > -1) {
                        this.notifications.splice(ind, 1);
                    }
                }, 5000);
            });
    }

    notifications: Array<Notification> = new Array<Notification>();

    closeNotice(index: number) {
        this.notifications.splice(index, 1);
    }
}