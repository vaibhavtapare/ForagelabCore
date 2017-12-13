import { Component, EventEmitter, Input, Output, OnInit } from '@angular/core';

import { Pagination } from '../../models/pagination.model';
import { Transaction } from '../../models/transaction.model';

@Component({
    selector: 'timeline',
    templateUrl: './timeline.component.html',
    host: {
        '[class.timeline-container]': 'true',
        '[class.left]': 'true'
    }
})
export class TimeLineComponent implements OnInit {
    ngOnInit() {
        this.initialPageSize = this.pagination.pageSize;
    }

    @Input() data: Array<Transaction>;
    @Input() isLoading: boolean;
    @Input() pagination: Pagination;
    @Output() refresh: EventEmitter<any> = new EventEmitter();
    initialPageSize: number;
    internalPageIndex: number = 1;

    refreshGrid(event: any) {
        this.refresh.emit(event);
    }

    private loadMore() {
        this.internalPageIndex++;
        this.pagination.pageSize = (this.internalPageIndex * this.initialPageSize);
        this.refreshGrid(null);
    }
}