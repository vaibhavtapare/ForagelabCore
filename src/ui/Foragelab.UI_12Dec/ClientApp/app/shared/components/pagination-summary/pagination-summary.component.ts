import { Component, Input } from '@angular/core';

import { DataTableConfig } from '../../models/data-table-config.model';
import { Pagination } from '../../models/pagination.model';

@Component({
    selector: 'pagination-summary',
    templateUrl: './pagination-summary.component.html'
})
export class PaginationSummaryComponent {
    @Input() pagination: Pagination;
    @Input() config: DataTableConfig;
}