import { DataTableColumn, DataTableConfig } from './data-table-config.model';

export class Address {
    id: number;
    attention: string;
    streetAddress1: string;
    streetAddress2: string;
    city: string;
    stateId: number;
    postalCode: string;
    isDeleted: boolean;
    latitude: number;
    longitude: number;
    condensedName: string;
    stateName: string;
}

export const addressFullDataTableConfig: DataTableConfig = new DataTableConfig({
    entityTypeName: 'addresses',
    columns: [
        new DataTableColumn({
            propertyName: 'streetAddress1',
            columnHeader: 'Address',
            allowSelect: true
        }),
        new DataTableColumn({
            propertyName: 'city',
            columnHeader: 'City'
        }),
        new DataTableColumn({
            propertyName: 'stateName',
            columnHeader: 'State'
        }),
        new DataTableColumn({
            propertyName: 'postalCode',
            columnHeader: 'Postal Code'
        })
    ]
});

export const adminaddressFullDataTableConfig: DataTableConfig = new DataTableConfig({
    entityTypeName: 'addresses',
    columns: [
        new DataTableColumn({
            propertyName: 'streetAddress1',
            columnHeader: 'Address',
            routerLink: (record: Address) => {
                return ['/admin/addresses/', record.id];
            }
        }),
        new DataTableColumn({
            propertyName: 'city',
            columnHeader: 'City'
        }),
        new DataTableColumn({
            propertyName: 'postalCode',
            columnHeader: 'Postal Code'
        })
    ]
});