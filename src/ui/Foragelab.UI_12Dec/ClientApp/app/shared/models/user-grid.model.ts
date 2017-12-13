import { DataTableColumn, DataTableConfig } from './data-table-config.model';

export class UserGrid {
    id: number;
    name: string;
    emailAddress: string;
    lastLogin: Date;
    type: string;
}

export const userFullDataTableConfig: DataTableConfig = new DataTableConfig({
    entityTypeName: 'users',
    columns: [
        new DataTableColumn({
            propertyName: 'name',
            columnHeader: 'Name',
            //routerLink: (record: UserGrid) => {
            //    if (record.type == 'Employee') {
            //        return ['/employees/detail', record.id];
            //    }
            //    else {
            //        return ['/contacts/detail', record.id];
            //    }
            //}
        }),
        new DataTableColumn({
            propertyName: 'emailAddress',
            columnHeader: 'Email Address'
        }),
        new DataTableColumn({
            propertyName: 'type',
            columnHeader: 'Type'
        }),
        new DataTableColumn({
            propertyName: 'lastLogin',
            columnHeader: 'Last Login'
        })
    ]
});