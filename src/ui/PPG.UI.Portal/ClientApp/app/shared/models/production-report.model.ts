import { DataTableColumn, DataTableConfig, SortDirection } from './data-table-config.model';
import * as moment from 'moment';

export class ProductionReport {
    id: number;
    workInstructionId: number;
    shiftId: number;
    statusId: number;
    productionDate: Date;
    UsesIdentifiers: boolean;
  }

export enum productionReportStatuses {
    ProductionReportStatus1 = 1,
    ProductionReportStatus2 = 2,
    ProductionReportStatus3 = 3
}

export const productionReportFullDataTableConfig: DataTableConfig = new DataTableConfig({
    entityTypeName: 'production report',
    columns: [
        new DataTableColumn({
            propertyName: 'productionDate',
            columnHeader: 'Date',
            formatter: (record: ProductionReport) => {
                if (record.productionDate) {
                    return moment(record.productionDate).format('MM/DD/YYYY');
                }
                return '';
            }
        }),
        new DataTableColumn({
            propertyName: 'shiftId',
            columnHeader: 'Shift'
        }),
        new DataTableColumn({
            propertyName: 'statusId',
            columnHeader: 'Status',
            formatter: (record: ProductionReport) => {
                if (record.statusId) {
                    return productionReportStatuses[record.statusId];
                }
                return '';
            }
        })
    ]
});