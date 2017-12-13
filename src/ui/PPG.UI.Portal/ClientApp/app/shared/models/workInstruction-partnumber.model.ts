import { DataTableColumn, DataTableConfig } from './data-table-config.model';

export class WorkInstructionPartNumber {
    id: number;
    workInstructionId: number;
    partNumber: string;
}

export const workInstructionPartNumberFullDataTableConfig: DataTableConfig = new DataTableConfig({
    entityTypeName: 'part numbers',
    columns: [
        new DataTableColumn({
            propertyName: 'partNumber',
            columnHeader: 'Part Number'
        })
    ]
});