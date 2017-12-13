import { DataTableColumn, DataTableConfig } from './data-table-config.model';

export class Location {
    id: number;
    clientId: number;
    name: string;
    alias: string;
    addressId: number;
    createdByUserId: number;
    isArchived: boolean;
}

export const locationFullDataTableConfig: DataTableConfig = new DataTableConfig({
    entityTypeName: 'locations',
    columns: [
        new DataTableColumn({
            propertyName: 'name',
            columnHeader: 'Name',
            routerLink: (record: Location) => {
                return ['/clients', record.clientId, 'locations', record.id];
            }
        }),
        new DataTableColumn({
            propertyName: 'alias',
            columnHeader: 'Alias'
        })
    ]
});