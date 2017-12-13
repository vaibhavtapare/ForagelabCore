import { Component, Inject, Input, OnInit } from '@angular/core';
import { DomSanitizer, SafeUrl } from '@angular/platform-browser';

import { Transaction } from '../../../models/transaction.model';
import { CommonStyles } from '../../../models/common-styles.model';

@Component({
    selector: 'timeline-item',
    templateUrl: './timeline-item.component.html',
    host: {
        '[class.timeline-block]': 'true'
    }
})
export class TimeLineItemComponent implements OnInit {
    constructor(
        @Inject('API_BASE') private API_BASE: string,
        @Inject('API_VERSION') private API_VERSION: string,
        private sanitizer: DomSanitizer) { }

    profileImage: SafeUrl;
    iconClass: string;
    icon: string;

    @Input() transaction: Transaction;

    ngOnInit() {
        this.profileImage = this.sanitizer.bypassSecurityTrustUrl(this.API_BASE + '/api/v' + this.API_VERSION + '/profileimage/' + this.transaction.userId.toString());
        
        let style = CommonStyles.pointStyles.filter((f) => {
            return f.id == this.transaction.transactionTypeId;
        });
        this.iconClass = (style[0]) ? style[0].class : '';
        this.icon = (style[0]) ? style[0].icon : '';
    }
}