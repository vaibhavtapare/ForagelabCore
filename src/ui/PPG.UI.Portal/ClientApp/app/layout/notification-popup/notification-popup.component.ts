import { Component, Input } from '@angular/core';
import { Router } from '@angular/router';

import { TransactionService } from '../../core/services/transaction.service';
import { Transaction } from '../../shared/models/transaction.model';
import { CommonStyles } from '../../shared/models/common-styles.model';

/**
 * Component to handle the notification globe and dropdown in the header
 */
@Component({
    selector: 'notification-popup',
    templateUrl: './notification-popup.component.html'
})
export class NotificationPopupComponent {
    constructor(
        private transactionService: TransactionService,
        private router: Router) {
        this.transactionService.getTransactions();
        transactionService.transactions.subscribe(
            transaction => {
                this.transactions = transaction;
                this.hasUnread = this.transactions.filter(t => t.isRead == false).length > 0;
            });
    }

    hasUnread: boolean = false;
    transactions: Array<Transaction> = new Array<Transaction>();

    /**
     * Marks a transaction as read
     * @param currentTransaction {Transaction} Transaction to mark as read
     */
    markTransactionAsRead(currentTransaction: Transaction) {
        this.transactionService.markTransactionAsRead(currentTransaction.id)
            .subscribe(s => {
                currentTransaction.isRead = true;
                this.hasUnread = this.transactions.filter(t => t.isRead == false).length > 0;
            });
    }

    /**
     * Redirects the user to the appropriate location for their notification
     * @param transaction {Transaction} Transaction to route for
     */
    routeNotification(transaction: Transaction) {
        this.markTransactionAsRead(transaction);
        if (transaction.jobId != null) {
            this.router.navigate(['jobs', transaction.jobId]);
        }
    }

    /**
     * Marks all transactions as read
     */
    markAllRead() {
        for (var i = 0; i < this.transactions.length; i++) {
            this.markTransactionAsRead(this.transactions[i]);
        }
        this.hasUnread = false;
    }
}