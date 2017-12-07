import { DataTableConfig, DataTableColumn } from "./data-table-config.model";

export class FeedCode {

    feedcodeid: number; 
    feedcode: string; 
    feedtype: string; 
    generalclass: string; 
    designator: string; 
    createddate: string; 
    isquickfeedtype: boolean; 

}

export const FullDataTableConfig: DataTableConfig = new DataTableConfig({
    entityTypeName: 'feedcode',
    columns: [
        new DataTableColumn({
            propertyName: 'feedcode',
            columnHeader: 'FeedCode',
            routerLink: (record: any) => {
                return ['/feedcode', record.feedcodeid];
            }
        }),
        new DataTableColumn({
            propertyName: 'generalclass',
            columnHeader: 'General Class'
        })
    ]
});