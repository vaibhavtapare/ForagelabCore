import { DataTableColumn, DataTableConfig } from './data-table-config.model';

export class DocumentRevision {
    id: number;
    documentId: number;
    revisionNumber?: number;
    dateCreated: Date;
    createdbyuserId: number;
    azurePath: string;
    statusId: number;
    documentName: string;
    documenttypeId: number;
}

export enum documentType {
    New = 0,
    Active = 10,
    Archive = 20
}

export const jobDocumentRevisionFullDataTableConfig: DataTableConfig = new DataTableConfig({
    entityTypeName: 'documents',
    columns: [
        new DataTableColumn({
            propertyName: 'documentName',
            columnHeader: 'Document',
            allowDownloadFile:true
        }),
        new DataTableColumn({
            propertyName: 'revisionNumber',
            columnHeader: 'Revision'
        })
    ]
});