import { DataTableColumn, DataTableConfig } from './data-table-config.model';

export class Role {
    id: number;
    name: string;
}

export const roleFullDataTableConfig: DataTableConfig = new DataTableConfig({
    entityTypeName: 'roles',
    columns: [
        new DataTableColumn({
            propertyName: 'name',
            columnHeader: 'Name',
            routerLink: (record: any) => {
                return ['/admin/roles/detail', record.id];
            }
        })
    ]
});