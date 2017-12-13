export class JobClosure
{
    id: number;
    jobId: number;
    closureDateTime: Date;
    efficiencySuggestions: string;
    areasDoneWell: string;
    areasNeedingImprovement: string;
    documentsCollected: boolean;
    boundrySamplesReturned: boolean;
    boundriesRemoved: boolean;
    areaCleaned: boolean;
    ppgMaterialsCollected: boolean;
    clientFixturesReturned: boolean;
    statusId: number;
}

export enum jobClosureStatuses {
    New = 0,
    Requested = 10,
    Active = 20
}