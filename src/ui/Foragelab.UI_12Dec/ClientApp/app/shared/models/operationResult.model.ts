
export class OperationResult {
    code: OperationResultCode;
    message: string;
}

export enum OperationResultCode {
    Success,
    Error,
    Warning
}