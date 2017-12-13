import { DataTableColumn, DataTableConfig } from './data-table-config.model';

export class Permission {
    id: number;
    name: string;
}

export const permissionFullDataTableConfig: DataTableConfig = new DataTableConfig({
    entityTypeName: 'permissions',
    columns: [
        new DataTableColumn({
            propertyName: 'name',
            columnHeader: 'Name'
        })
    ]
});