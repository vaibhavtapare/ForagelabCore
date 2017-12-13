import { DataTableColumn, DataTableConfig, SortDirection } from './data-table-config.model';

export class Transaction {
    id: number;
    transactionTypeId: number;
    transactionDate: Date;
    userId: number;
    description: string;
    clientId?: number;
    locationId?: number;
    jobId?: number;
    employeeId?: number;
    contactId?: number;
    eventActionId?: number;
    isCompleted: boolean;
    expextedTransactionTypeId?: number;
    isUserSpecific: number;
    parentTransactionId?: number;
    objectTypeId?: number;
    resultingObject: string;
    isEscalated: boolean;
    isRead: boolean;

    fullName: string;
    iconClass: string;
    taskstatusClass: string;

} 


export const transactionFullDataTableConfig: DataTableConfig = new DataTableConfig({
    entityTypeName: 'transactions',
    sortColumn: 'transactionDate',
    sortDirection: SortDirection.desc,
    columns: [
        new DataTableColumn({
            propertyName: 'transactionDate',
            columnHeader: 'Date'
        }),
        new DataTableColumn({
            propertyName: 'description',
            columnHeader: 'Description'
        }),
        new DataTableColumn({
            propertyName: 'userId',
            columnHeader: 'User'
        })
    ]
});