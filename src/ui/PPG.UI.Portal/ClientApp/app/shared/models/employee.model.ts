import { DataTableColumn, DataTableConfig } from './data-table-config.model';

export class Employee {
    id: number;
    userId?: number;
    alias: string;
    title: string;
    firstName: string;
    lastName: string;
    ssn: string;
    addressId: number;
    homePhoneNumber: string;
    mobilePhoneNumber: string;
    emailAddress: string;
    employeeTypeId: number;
    employeeStatusId: number;
    createdByUserId: number;
    isArchived: boolean;
}

export const employeeStatuses = [
    { 'id': 10, 'name': 'Applied' },
    { 'id': 30, 'name': 'Interviewed' },
    { 'id': 50, 'name': 'Active' },
    { 'id': 90, 'name': 'Do Not Hire' },
    { 'id': 95, 'name': 'Dismissed' }
];

export const employeeTypes = [
    { 'id': 0, 'name': 'None' },
    { 'id': 10, 'name': 'Full Time' },
    { 'id': 20, 'name': 'Part Time' },
    { 'id': 30, 'name': 'Contract' },
    { 'id': 40, 'name': 'Temp' }
];

export const employeeFullDataTableConfig: DataTableConfig = new DataTableConfig({
    entityTypeName: 'employees',
    columns: [
        new DataTableColumn({
            propertyName: 'lastName',
            columnHeader: 'Name',
            routerLink: (record: any) => {
                return ['/employees/detail', record.id];
            },
            formatter: (record: Employee) => {
                return record.firstName + ' ' + record.lastName; 
            }
        }),
        new DataTableColumn({
            propertyName: 'alias',
            columnHeader: 'Alias'
        }),
        new DataTableColumn({
            propertyName: 'employeeTypeId',
            columnHeader: 'Type',
            formatter: (record: Employee) => {
                if (record.employeeTypeId) {
                    let val = employeeTypes.filter(function (o) {
                        return o.id == record.employeeTypeId;
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