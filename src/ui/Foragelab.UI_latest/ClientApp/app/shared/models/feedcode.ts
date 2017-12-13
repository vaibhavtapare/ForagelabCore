import { DataTableConfig, DataTableColumn } from "./data-table-config";

export class FeedCodeModel {
    FeedCodeId: number;    
    FeedCode: string;
    FeedType: string;  
    GeneralClass: string; 
    Designator: string;  
    IsQuickFeedType: boolean;
}  


export const feedcodeFullDataTableConfig: DataTableConfig = new DataTableConfig({
    entityTypeName: 'feedcode',
    columns: [
        new DataTableColumn({
            propertyName: 'feedtype',
            columnHeader: 'FeedType',
            routerLink: (record: any) => {
                return ['/clients', record.FeedCodeId];
            }
        }),
        new DataTableColumn({
            propertyName: 'generalclass',
            columnHeader: 'GeneralClass'
        })
    ]
});