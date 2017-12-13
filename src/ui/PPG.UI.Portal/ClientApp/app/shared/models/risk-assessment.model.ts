import { DataTableColumn, DataTableConfig, SortDirection } from './data-table-config.model';

export class RiskAssessment {
    id: number;
    WorkInstructionsId: number;
    statusId: number;
    revision: string
}

export enum riskAssessmentstatuses {
    New = 0,
    Requested = 10,
    Submitted = 20
}

export const riskAssessmentDataTableConfig: DataTableConfig = new DataTableConfig({
    entityTypeName: 'risk assessments',
    sortColumn: 'revision',
    sortDirection: SortDirection.desc,
    columns: [
        new DataTableColumn({
            propertyName: 'revision',
            columnHeader: 'Revision'
        }),
        new DataTableColumn({
            propertyName: 'statusId',
            columnHeader: 'Status',
            formatter: (record: RiskAssessment) => {
                return riskAssessmentstatuses[record.statusId];
            }
        })
    ]
});