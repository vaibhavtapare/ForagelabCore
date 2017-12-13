export class RiskAssessmentResponse {
    id: number;
    actionsTaken: string;
    recommendedActions: string;
    revisedScore: number;
    riskAssessmentId: number;
    riskAssessmentQuestionId: number;
    score: number;
    statusId: number;
    targetDate: Date;
}