import { DataTableColumn, DataTableConfig, SortDirection } from './data-table-config.model';

export class WorkInstructionDefect {
    id: number;
    workInstructionId: number;
    name: string;
}

export const workInstructionDefectFullDataTableConfig: DataTableConfig = new DataTableConfig({
    entityTypeName: 'defects',
    columns: [
        new DataTableColumn({
            propertyName: 'name',
            columnHeader: 'Defect'
        })
    ]
});