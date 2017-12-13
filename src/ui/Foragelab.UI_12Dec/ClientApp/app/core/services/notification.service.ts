import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

import { Notification } from '../../shared/models/notification.model';

/**
 * The notification service is used by the notification bar
 * to display error/success/warning/info notices.
 */
@Injectable()
export class NotificationService {

    private notificationSource = new Subject<Notification>();

    notifications$ = this.notificationSource.asObservable();

    /**
     * Pushes a notification to the service to display in the UI
     * @param {string} type Type of notice to display
     * @param {string} message Message to display in the notification
     */
    public notify(type: string, message: string) {
        this.notificationSource.next(new Notification(message, type));
    }
}