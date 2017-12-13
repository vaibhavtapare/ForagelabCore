import { DataTableColumn, DataTableConfig } from './data-table-config.model';

export class Document {
    id: number;
    documenttypeId: number;
    name: string;
    dateCreated: Date;
    createdbyuserId: number;
    description: string;
    clientId?: number;
    locationId?: number;
    jobId?: number;
}
