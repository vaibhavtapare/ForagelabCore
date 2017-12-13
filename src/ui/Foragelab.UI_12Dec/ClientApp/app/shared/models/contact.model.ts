import { DataTableColumn, DataTableConfig } from './data-table-config.model';

export class Contact {
    id: number;
    clientId: number;
    locationId?: number;
    userId: number;
    title: string;
    fullName: string;
    firstName: string;
    lastName: string;
    officePhoneNumber: string;
    faxNumber: string;
    mobilePhoneNumber: string;
    pagerNumber: string;
    emailAddress: string;
    isDeleted: boolean;
    createdByUserId: number;
    dateCreated: Date;
    status: string;
}

export const contactFullDataTableConfig: DataTableConfig = new DataTableConfig({
    entityTypeName: 'contacts',
    columns: [
        new DataTableColumn({
            propertyName: 'lastName',
            columnHeader: 'Name',
            allowSelect: true,
            routerLink: (record: any) => {
                return ['/clients', record.clientId, 'contacts', record.id];
            },
            formatter: (record: Contact) => {
                return record.fullName;
            }
        }),
        new DataTableColumn({
            propertyName: 'title',
            columnHeader: 'Title'
        }),
        new DataTableColumn({
            propertyName: 'officePhoneNumber',
            columnHeader: 'Office Phone'
        }),
        new DataTableColumn({
            propertyName: 'state',
            columnHeader: 'State'
        }),
    ]
});