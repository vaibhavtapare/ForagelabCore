import { DataTableColumn, DataTableConfig, SortDirection } from './data-table-config.model';

export class WorkInstructionRework {
    id: number;
    workInstructionId: number;
    name: string;
}

export const workInstructionReworkFullDataTableConfig: DataTableConfig = new DataTableConfig({
    entityTypeName: 'reworks',
    //sortColumn: 'sequence',
    //sortDirection: SortDirection.asc,
    columns: [
        new DataTableColumn({
            propertyName: 'name',
            columnHeader: 'Rework'
        })
    ]
});