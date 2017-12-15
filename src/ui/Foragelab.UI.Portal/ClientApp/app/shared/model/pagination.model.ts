import { Headers, Response } from '@angular/http';

export class Pagination {
    constructor(response: Response) {
        if (response) {
            if (response.headers != null) {
                let headers: Headers = response.headers;
                if (headers.get('X-Pagination') != null) {
                    let paginationHeader = JSON.parse(headers.get('X-Pagination') || "");
                    this.totalCount = paginationHeader.totalCount;
                    this.pageSize = paginationHeader.pageSize;
                    this.pageIndex = paginationHeader.pageIndex;
                    this.totalPages = paginationHeader.totalPages;

                    this.calcStartingRecordNumber();
                    this.calcEndingRecordNumber();
                }
            }
        }
    }

    totalCount: number;
    pageSize: number = 20;
    pageIndex: number = 0;
    totalPages: number;

    startingRecordNumber: number;
    endingRecordNumber: number;

    private calcStartingRecordNumber() {
        this.startingRecordNumber = (this.pageIndex * this.pageSize) + 1;
    }

    private calcEndingRecordNumber() {
        let maxCurrentPageCount = (this.pageIndex * this.pageSize) + this.pageSize;
        this.endingRecordNumber = Math.min(this.totalCount, maxCurrentPageCount);
    }
}