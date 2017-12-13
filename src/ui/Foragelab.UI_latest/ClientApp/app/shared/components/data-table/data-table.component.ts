import { Component, EventEmitter, Input, Output } from '@angular/core';
import { DataTableConfig, DataTableColumn, SortDirection } from "../../models/data-table-config";
import { Pagination } from "../../models/pagination.model";
import { ModalService } from "../../../core/services/modal.service";

@Component({
    selector: 'data-table',
    templateUrl: './data-table.component.html'
})
export class DataTableComponent {
    constructor(private modalService: ModalService) { }

    @Output() refresh: EventEmitter<any> = new EventEmitter();
    //@Output() delete: EventEmitter<any> = new EventEmitter();
    //@Output() select: EventEmitter<any> = new EventEmitter();
    //@Output() download: EventEmitter<any> = new EventEmitter();

    @Input() data: Array<any>;
    @Input() config: DataTableConfig;

    /* Row styling inputs */
    @Input() condenseRows: boolean = true;
    @Input() stripedRows: boolean = true;
    @Input() hoverRows: boolean = true;

    ///* Pagination inputs */
    //@Input() pagination: Pagination;
    //@Input() pagesToShow: number;
    //@Input() showFirstPage: boolean;
    //@Input() showLastPage: boolean;
    //@Input() allowDelete: boolean = false;
    //@Input() deleteTitle: string;
    //@Input() deleteMessage: string;

    refreshGrid(event: any) {
        this.refresh.emit(event);
    }

    //setSort(column: DataTableColumn) {
    //    if (column.allowSorting) {
    //        if (column.propertyName == this.config.sortColumn) {
    //            this.config.sortDirection = this.config.sortDirection == SortDirection.asc ? SortDirection.desc : SortDirection.asc;
    //        }
    //        else {
    //            this.config.sortColumn = column.propertyName;
    //            this.config.sortDirection = SortDirection.asc;
    //        }
    //        this.pagination.pageIndex = 0;
    //        this.refreshGrid(null);
    //    }
    //}

    //openModal(id: string, record: any) {
    //    this.modalService.open(id, record);
    //}

    //closeModal(id: string) {
    //    this.modalService.close(id);
    //}

    //deleteRecord(id: string, event: any) {
    //    let modal = this.modalService.get(id);
    //    this.delete.emit(modal.record);
    //    this.modalService.close(id);
    //}

    //selectRecord(record: any) {
    //    this.select.emit(record);
    //}

    //downloadFile(record: any) {
    //    this.download.emit(record);
    //}
}