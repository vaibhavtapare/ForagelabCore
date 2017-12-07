
export class DataTableConfig {
    public constructor(init?: Partial<DataTableConfig>) {
        Object.assign(this, init);
    }

    entityTypeName: string = "entities";
    showPaging: boolean = true;
    showPager: boolean = true;

    filter?: () => string;
    sortDirection: SortDirection = SortDirection.asc;
    sortColumn: string = 'id';

    columns: Array<DataTableColumn> = new Array<DataTableColumn>();
}

export class DataTableColumn {
    public constructor(init?: Partial<DataTableColumn>) {
        Object.assign(this, init);
    }

    allowSorting: boolean = true;
    propertyName: string;
    columnHeader: string;
    routerLink?: (record: any, index?: number) => any;
    formatter?: (record: any, index?: number) => string;
    allowDownloadFile: boolean = false;
    allowSelect: boolean = false;
}

export enum SortDirection {
    asc,
    desc
}