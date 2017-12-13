import { DataTableColumn, DataTableConfig, SortDirection } from './data-table-config.model';
import * as moment from 'moment';

export class WorkInstruction {
    id: number;
    jobId: number;
    revision: number;
    workInstructionStatusId: number;
    dateCreated: Date;
    activatedDateTime?: Date;
    deactivatedDateTime: Date;
    isActive: boolean;
}

export enum workinstructionstatuses {
    Draft = 10,
    Requested = 15,
    Active = 20,
    Inactive = 30    
}

export const workInstructionFullDataTableConfig: DataTableConfig = new DataTableConfig({
    entityTypeName: 'work instructions',
    sortColumn: 'revision',
    sortDirection: SortDirection.desc,
    columns: [
        new DataTableColumn({
            propertyName: 'revision',
            columnHeader: 'Revision',
            routerLink: (record: WorkInstruction) => {
                return ['/jobs/', record.jobId,'work-instructions',record.id];
            }
        }),
        new DataTableColumn({
            propertyName: 'WorkInstructionStatusId',
            columnHeader: 'Status',
            formatter: (record: WorkInstruction) => {
                if (record.workInstructionStatusId) {
                    return workinstructionstatuses[record.workInstructionStatusId];
                }
                return '';
            }
        }),
        new DataTableColumn({
            propertyName: 'activatedDateTime',
            columnHeader: 'Activated Date',
            formatter: (record: WorkInstruction) => {
                if (record.activatedDateTime) {
                    return moment(record.activatedDateTime).format('MM/DD/YYYY hh:mm A');
                   
                }
                return '';
            }
        })
    ]
});