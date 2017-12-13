import { DataTableColumn, DataTableConfig } from './data-table-config.model';

export class ARTerm {

    id: number;
    name: string;
    days: number;
}

export const arTermsFullDataTableConfig: DataTableConfig = new DataTableConfig({
    entityTypeName: 'terms',
    columns: [
        new DataTableColumn({
            propertyName: 'name',
            columnHeader: 'Name',
            routerLink: (record: any) => {
                return ['/admin/ar-terms/detail', record.id];
            }
        }),
        new DataTableColumn({
            propertyName: 'days',
            columnHeader: 'Term Days'
        })
    ]
});