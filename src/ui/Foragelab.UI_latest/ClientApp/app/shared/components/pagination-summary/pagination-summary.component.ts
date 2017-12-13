import { Component, Input } from '@angular/core';

import { Pagination } from '../../models/pagination.model';
import { DataTableConfig } from "../../models/data-table-config";

@Component({
    selector: 'pagination-summary',
    templateUrl: './pagination-summary.component.html'
})
export class PaginationSummaryComponent {
    @Input() pagination: Pagination;
    @Input() config: DataTableConfig;
}