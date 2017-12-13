import { DataTableColumn, DataTableConfig, SortDirection } from './data-table-config.model';

export class WorkInstructionStep {
    id: number;
    workInstructionId: number;
    description: string;
    pictureAzurePath: string;
    sequence: number;
}

export const workInstructionStepFullDataTableConfig: DataTableConfig = new DataTableConfig({
    entityTypeName: 'steps',
    sortColumn: 'sequence',
    sortDirection: SortDirection.asc,
    columns: [
        new DataTableColumn({
            propertyName: 'description',
            columnHeader: 'Step'
        })
    ]
});