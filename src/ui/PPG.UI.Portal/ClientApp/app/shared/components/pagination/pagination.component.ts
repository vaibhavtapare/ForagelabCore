import { Component, EventEmitter, Input, OnChanges, OnInit, Output, SimpleChange } from '@angular/core';

import { Pagination } from '../../models/pagination.model';

@Component({
    selector: 'pagination',
    templateUrl: './pagination.component.html'
})

export class PaginationComponent implements OnInit {

    @Input() pagination: Pagination;
    @Input() pagesToShow: number = 3;
    @Input() showFirstPage: boolean = true;
    @Input() showLastPage: boolean = true;

    @Output() refresh: EventEmitter<any> = new EventEmitter();

    pages: Array<number> = new Array<number>();

    ngOnInit() {
        this.calculatePageButtons();
    }

    ngOnChanges(changes: { [propKey: string]: SimpleChange }) {
        this.calculatePageButtons()
    }

    private changePageIndex(index: number) {
        if (index != this.pagination.pageIndex) {
            this.pagination.pageIndex = index;
            this.refresh.emit(null);
            this.calculatePageButtons();
        }
    }

    private nextPage() {
        let newPageIndex: number = Math.min(this.pagination.pageIndex + 1, this.pagination.totalPages - 1);
        if (newPageIndex < this.pagination.totalPages) {
            this.changePageIndex(newPageIndex);
        }
    }

    private previousPage() {
        let newPageIndex: number = Math.max(this.pagination.pageIndex - 1, 0);
        if (this.pagination.pageIndex > 0) {
            this.changePageIndex(newPageIndex);
        }
    }

    private calculatePageButtons() {
        this.pages = new Array<number>();
        if (this.pagesToShow && this.pagesToShow > 0 && this.pagination.totalPages > 0) {

            let pageIndex: number = Math.max(0, this.pagination.pageIndex);
            let startIndex: number = null||0;
            let actualShow: number = Math.min(this.pagesToShow, this.pagination.totalPages);

            if (this.pagination.totalPages == this.pagesToShow) {
                startIndex = 0;
            }

            if (!startIndex) {
                if (actualShow % 2 == 0) {
                    startIndex = pageIndex - ((this.pagesToShow / 2) + 1);
                }
                else {
                    let halfPagesToShow: number = (actualShow - 1) / 2;
                    startIndex = pageIndex - halfPagesToShow;
                }
            }

            startIndex = Math.min(startIndex, (this.pagination.totalPages - 1));

            if (startIndex < 0) {
                startIndex = 0;
            }

            if (startIndex == 0 && this.showFirstPage && this.pagination.totalPages > 1) {
                startIndex = 1;
            }

            if (this.showLastPage && (this.pagination.totalPages - 1) >= startIndex &&
                (this.pagination.totalPages - 1) <= (startIndex + actualShow - 1)) {

                if (pageIndex == (this.pagination.totalPages - 1)) {
                    startIndex = pageIndex - actualShow;
                }
                else {
                    startIndex--;
                }
            }

            if (startIndex < 0) {
                startIndex = 0;
            }

            for (let i = startIndex; i < startIndex + actualShow; i++) {
                this.pages.push(i);
            }

            if (this.showFirstPage && this.pagination.totalPages > 1) {
                if (this.pages.indexOf(0) == -1) {
                    this.pages.unshift(0)
                }
            };

            if (this.showLastPage && this.pagination.totalPages > 1) {
                if (this.pages.indexOf(this.pagination.totalPages - 1) == -1) {
                    this.pages.push(this.pagination.totalPages - 1);
                }
            }
        }
    }
}