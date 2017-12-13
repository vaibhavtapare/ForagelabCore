export class ProcessAudit {
    id: number;
    workInstructionsId: number;
    shiftDate: Date;
    shiftId: number;
    statusId: number;
    dateCreated: Date;
    inspectorEmployeeId: number;
    auditorEmployeeId: number;
    partNumberId: number;
    paperWorkFailureNote: string;
    requirementsToolsFailureNote: string;
    workAreaFailureNote: string;
    documentsFailureNote: string;
    revision: number;
    comments: string;
}