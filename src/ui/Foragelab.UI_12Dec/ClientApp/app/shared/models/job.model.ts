import { DataTableColumn, DataTableConfig } from './data-table-config.model';

export class Job {
    id: number;
    jobTypeId: number;
    jobStatusId: number;
    clientId: number;
    locationId: number;
    createdByUserId: number;
    isArchived: boolean;
    jobCode: string;
    dateCreated: Date;
    description: string;
    quoteApprovalContactId?: number;
    quoteApprovalNotificationEmployeeId?: number;
    workInstructionApprovalContactId?: number;
    startDate?: Date;
    poNumber: string;
    partDescription: string;   
    warehouseFee?: number;
    shift1InspectorNumbers: string;
    shift2InspectorNumbers: string;
    shift3InspectorNumbers: string;
    numberOfShifts?: number;
    notes: string;
    useIdentifiers: boolean;
}

export enum jobstatuses {
    New = 0,
    Requested = 10,
    QuoteNeeded = 40,
    QuotePending = 45,
    Active=100
}

export enum jobtypes {
    Sort_Rework = 10,
    Sort = 20,
    Rework = 30,
    Representation = 40
}

export const jobStatuses = [
    { 'id': 0, 'name': 'New' },
    { 'id': 10, 'name': 'Requested' },
    { 'id': 40, 'name': 'Quote Needed' },
    { 'id': 45, 'name': 'Quote Pending' },
    { 'id': 100, 'name': 'Active' }
];

export const jobTypes = [
    { 'id': 10, 'name': 'Sort/Rework' },
    { 'id': 20, 'name': 'Sort' },
    { 'id': 30, 'name': 'Rework' },
    { 'id': 40, 'name': 'Representation' }
];

export const jobFullDataTableConfig: DataTableConfig = new DataTableConfig({
    entityTypeName: 'jobs',
    columns: [
        new DataTableColumn({
            propertyName: 'jobCode',
            columnHeader: 'Code',
            routerLink: (record: Job) => {
                return ['/jobs', record.id];
            }
        }),
        new DataTableColumn({
            propertyName: 'jobTypeId',
            columnHeader: 'Type',
            formatter: (record: Job) => {
                if (record.jobTypeId) {
                    let val = jobTypes.filter(function (o) {
                        return o.id == record.jobTypeId;
                    });
                    if (val) {
                        return val[0].name;
                    }
                }
                return '';
            }
        }),
        new DataTableColumn({
            propertyName: 'jobStatusId',
            columnHeader: 'Status',
            formatter: (record: Job) => {
                if (record.jobStatusId != null) {
                    let val = jobStatuses.filter(function (o) {
                        return o.id == record.jobStatusId;
                    });
                    if (val) {
                        return val[0].name;
                    }
                }
                return '';
            }
        })
    ]
});