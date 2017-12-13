import { DataTableColumn, DataTableConfig } from './data-table-config.model';

export class JobService {
    id: number;
    jobId: number;
    serviceId: number;
    shift1Rate?: number;
    shift2Rate?: number;
    shift3Rate?: number;
    overtimeRate?: number;
    saturdayRate?: number;
    sundayRate?: number;
    holidayRate?: number;
    shift1Count?: number;
    shift2Count?: number;
    shift3Count?: number;

}

export const serviceTypes = [
    { 'id': 1, 'name': 'Manager' },
    { 'id': 2, 'name': 'Supervisor' },
    { 'id': 3, 'name': 'Inspector' },
    { 'id': 4, 'name': 'Quality Tech' },
    { 'id': 5, 'name': 'Auditor' },
    { 'id': 6, 'name': 'Fork Lift Operator' },
    { 'id': 7, 'name': 'Truck' },
    { 'id': 8, 'name': 'Liaison' },
];

export const jobServiceFullDataTableConfig: DataTableConfig = new DataTableConfig({
    entityTypeName: 'job rates',
    columns: [
        new DataTableColumn({
            propertyName: 'serviceId',
            columnHeader: 'Service',
            formatter: (record: JobService) => {
                if (record) {
                    let val = serviceTypes.filter(function (s) {
                        return s.id == record.serviceId;
                    });
                    if (val) {
                        return val[0].name;
                    }
                }
                return '';
            }
        }),
        new DataTableColumn({
            propertyName: 'shift1Count',
            columnHeader: 'Shift1'
        }),
        new DataTableColumn({
            propertyName: 'shift2Count',
            columnHeader: 'Shift2'
        }),
        new DataTableColumn({
            propertyName: 'shift3Count',
            columnHeader: 'Shift3'
        }),
    ]
});

export const jobServiceRateFullDataTableConfig: DataTableConfig = new DataTableConfig({
    entityTypeName: 'job rates',
    columns: [
        new DataTableColumn({
            propertyName: 'serviceId',
            columnHeader: 'Service',
            formatter: (record: JobService) => {
                if (record) {
                    let val = serviceTypes.filter(function (s) {
                        return s.id == record.serviceId;
                    });
                    if (val) {
                        return val[0].name;
                    }
                }
                return '';
            }
        }),
        new DataTableColumn({
            propertyName: 'shift1Rate',
            columnHeader: 'Shift1'
        }),
        new DataTableColumn({
            propertyName: 'shift2Rate',
            columnHeader: 'Shift2'
        }),
        new DataTableColumn({
            propertyName: 'shift3Rate',
            columnHeader: 'Shift3'
        }),
        new DataTableColumn({
            propertyName: 'saturdayRate',
            columnHeader: 'Saturday'
        }),
        new DataTableColumn({
            propertyName: 'sundayRate',
            columnHeader: 'Sunday'
        }),
        new DataTableColumn({
            propertyName: 'holidayRate',
            columnHeader: 'Holiday'
        }),
        new DataTableColumn({
            propertyName: 'overtimeRate',
            columnHeader: 'Overtime'
        })
    ]
});