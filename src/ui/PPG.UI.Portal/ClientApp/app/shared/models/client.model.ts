import { DataTableColumn, DataTableConfig } from './data-table-config.model';

export class Client {
    id: number;
    name: string;
    alias: string;
    corporateAddressId: number;
    billingAddressId: number;
    phoneNumber: string;
    faxNumber: string;
    website: string;
    arTermsId: number;
    isArchived: boolean;
    signedQuoteRequired?: boolean;
}

export const clientFullDataTableConfig: DataTableConfig = new DataTableConfig({
    entityTypeName: 'clients',
    columns: [
        new DataTableColumn({
            propertyName: 'name',
            columnHeader: 'Name',
            routerLink: (record: any) => {
                return ['/clients', record.id];
            }
        }),
        new DataTableColumn({
            propertyName: 'alias',
            columnHeader: 'Alias'
        })
    ]
});