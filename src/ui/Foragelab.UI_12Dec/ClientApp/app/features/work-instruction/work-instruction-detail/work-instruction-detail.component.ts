import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import * as _ from 'lodash';
import * as FileSaver from 'file-saver';

import { AuthenticatedComponentBase } from '../../../shared/bases/authenticated.component.base';

import { ModalService } from '../../../core/services/modal.service';
import { NotificationService } from '../../../core/services/notification.service';
import { StateService } from '../../../core/services/state.service';
import { WorkInstructionService } from "../../../core/services/workinstruction.service";
import { JobServices } from "../../../core/services/job.service";
import { RiskAssessmentService } from "../../../core/services/riskassessment.service"

import { WorkInstruction, workinstructionstatuses } from "../../../shared/models/workInstruction.model";
import { WorkInstructionPartNumber, workInstructionPartNumberFullDataTableConfig } from "../../../shared/models/workInstruction-partnumber.model";
import { WorkInstructionDefect, workInstructionDefectFullDataTableConfig } from "../../../shared/models/workInstruction-defect.model";
import { Pagination } from "../../../shared/models/pagination.model";
import { DataTableConfig } from "../../../shared/models/data-table-config.model";
import { transactionFullDataTableConfig, Transaction } from "../../../shared/models/transaction.model";
import { Job, jobstatuses, jobtypes } from "../../../shared/models/job.model";
import { DocumentRevision } from "../../../shared/models/job-documentrevision.model";
import { RiskAssessment, riskAssessmentDataTableConfig } from "../../../shared/models/risk-assessment.model";

import { DragulaService } from 'ng2-dragula/ng2-dragula';
import { RequestOptions, ResponseContentType } from "@angular/http";
import { WorkInstructionRework, workInstructionReworkFullDataTableConfig } from "../../../shared/models/workinstruction-rework.model";
import { WorkInstructionStep, workInstructionStepFullDataTableConfig } from "../../../shared/models/workInstruction-step-model";

@Component({
    templateUrl: './work-instruction-detail.component.html',
    styles: [
        `
.tagline {
  position: relative;
  margin-top: 0;
}
.tagline-text {
  vertical-align: middle;
}
.__slackin {
  float: right;
  margin-left: 10px;
  vertical-align: middle;
}

.promo {
  margin-bottom: 0;
  font-style: italic;
  padding: 10px;
  background-color: #ff4020;
  border-bottom: 5px solid #c00;
}

.gh-fork {
  position: fixed;
  top: 0;
  right: 0;
  border: 0;
}

/* dragula-specific example page styles */
.wrapper {
  display: table;
}
.container {
  display: table-cell;
  background-color: rgba(255, 255, 255, 0.2);
  width: 50%;
}
.container:nth-child(odd) {
  background-color: rgba(0, 0, 0, 0.2);
}
/*
 * note that styling gu-mirror directly is a bad practice because it's too generic.
 * you're better off giving the draggable elements a unique class and styling that directly!
 */
.container > div,
.gu-mirror {
  margin: 10px;
  padding: 10px;
  background-color: rgba(0, 0, 0, 0.2);
  transition: opacity 0.4s ease-in-out;
}
.container > div {
  cursor: move;
  cursor: grab;
  cursor: -moz-grab;
  cursor: -webkit-grab;
}
.gu-mirror {
  cursor: grabbing;
  cursor: -moz-grabbing;
  cursor: -webkit-grabbing;
}
.container .ex-moved {
  background-color: #e74c3c;
}
.container.ex-over {
  background-color: rgba(255, 255, 255, 0.3);
}
#left-lovehandles > div,
#right-lovehandles > div {
  cursor: initial;
}
.handle {
  padding: 0 5px;
  margin-right: 5px;
  background-color: rgba(0, 0, 0, 0.4);
  cursor: move;
}
.image-thing {
  margin: 20px 0;
  display: block;
  text-align: center;
}
.slack-join {
  position: absolute;
  font-weight: normal;
  font-size: 14px;
  right: 10px;
  top: 50%;
  margin-top: -8px;
  line-height: 16px;
}

/* Carbon */

#carbonads {
  position: absolute;
  display: block;
  overflow: hidden;
  margin-left: -180px;
  padding: 1em;
  max-width: calc(130px + 2em);
  background-color: #aa5579;
  text-align: center;
  font-size: 12px;
  font-family: Verdana, "Helvetica Neue", Helvetica, sans-serif;
  line-height: 1.5;
}

#carbonads a {
  color: inherit;
  text-decoration: none;
  font-weight: 400;
  transition: color .2s ease-in-out;
}

#carbonads a:hover {
  color: #221c3b;
}

#carbonads span {
  display: block;
  overflow: hidden;
}

.carbon-img {
  display: block;
  margin: 0 auto 1em;
}

.carbon-text {
  display: block;
  margin-bottom: 1em;
}

.carbon-poweredby {
  display: block;
  text-transform: uppercase;
  letter-spacing: 1px;
  font-size: 9px;
}

@media only screen and (min-width: 320px) and (max-width: 960px) {
  #carbonads {
    position: relative;
    float: none;
    margin: 0 auto -2em;
    max-width: 330px;
  }
  #carbonads span {
    position: relative;
  }
  #carbonads > span {
    max-width: none;
  }
  .carbon-img {
    float: left;
    margin: 0 1em 0 0;
  }
  .carbon-text {
    float: left;
    margin-bottom: 0;
    max-width: calc(100% - 130px - 1em);
    text-align: left;
  }
  .carbon-poweredby {
    position: absolute;
    right: 0;
    bottom: 0;
    display: block;
  }
}`
    ]
})
export class WorkInstructionDetailComponent extends AuthenticatedComponentBase implements OnInit {
    constructor(
        public modalService: ModalService,
        private route: ActivatedRoute,
        private router: Router,
        public notificationService: NotificationService,
        private workInstructionService: WorkInstructionService,
        private dragulaService: DragulaService,
        private jobService: JobServices,
        private riskAssessmentService: RiskAssessmentService,
        stateService: StateService) {
        super(modalService, notificationService, stateService);
    }

    workinstruction: WorkInstruction = new WorkInstruction();
    newPartNumber: WorkInstructionPartNumber = new WorkInstructionPartNumber();
    newDefect: WorkInstructionDefect = new WorkInstructionDefect();
    newRework: WorkInstructionRework = new WorkInstructionRework();
    newStep: WorkInstructionStep = new WorkInstructionStep();
    job: Job;
    processing: boolean = false;
    showPartnumber: boolean = false;
    alllowDeletePartnumber: boolean = false;
    workInstructionStatus: string;
    isAnyDraftWorkInstruction: boolean = true;
    cloneWorkInstructionLoading: boolean = false;
    isDraftWorkInstructionStatus: boolean = false;
    isRequestedWorkInstructionStatus: boolean = false;
    showCloneWorkInstruction: boolean = false;
    showDefect: boolean = false;
    showRework: boolean = false;

    workInstructionPartNumbersLoading: boolean = false;
    workInstructionPartNumbersPagination: Pagination = new Pagination(null);
    workInstructionPartNumbersConfig: DataTableConfig = workInstructionPartNumberFullDataTableConfig;
    workInstructionPartNumbers: Array<WorkInstructionPartNumber>;

    workInstructionStepsLoading: boolean = false;
    workInstructionStepPagination: Pagination = new Pagination(null);
    workInstructionStepsConfig: DataTableConfig = workInstructionStepFullDataTableConfig;
    workInstructionSteps: Array<WorkInstructionStep>;

    jobDefectsLoading: boolean = false;
    jobDefectPagination: Pagination = new Pagination(null);
    jobDefectsConfig: DataTableConfig = workInstructionDefectFullDataTableConfig;
    jobDefects: Array<WorkInstructionDefect>;

    workInstructionReworkLoading: boolean = false;
    workInstructionReworkPagination: Pagination = new Pagination(null);
    workInstructionReworkConfig: DataTableConfig = workInstructionReworkFullDataTableConfig;
    workInstructionReworks: Array<WorkInstructionRework>;

    transactionsLoading: boolean = false;
    transactionPagination: Pagination = new Pagination(null);
    transactionsConfig: DataTableConfig = transactionFullDataTableConfig;
    transactions: Array<Transaction>;

    workInstructionDocuments: Array<DocumentRevision>;
    workInstructionDocumentsLoading: boolean = false;

    riskassessmentsLoading: boolean = false;
    riskassessmentsPagination: Pagination = new Pagination(null);
    riskassessmentsConfig: DataTableConfig = riskAssessmentDataTableConfig;
    riskAssessments: Array<RiskAssessment>;

    ngOnInit() {
        this.loadWorkInstructions();
        
        this.transactionPagination.pageSize = 3;
        this.transactionPagination.pageIndex = 0;

        this.dragulaService.drop.subscribe((value: any[]) => {
            const [bagName, e, el] = value;
            let children: Array<any> = el.children;
            for (var i = 0; i < children.length; i++) {
                var child = this.workInstructionSteps.find(c => c.id == children[i].dataset.id);
                child.sequence = i + 1;
            }

            this.updateWorkInstructionStepSequence();
        });
    }

    /**
    * Loads the work-instruction record and associated record sets
    */
    loadWorkInstructions() {
        this.processing = true;
        this.route.params
            .switchMap((params: Params) => this.workInstructionService.getWorkInstruction(+params['id'], +params['workInstructionId']))
            .subscribe(
            workinstruction => {                
                this.workinstruction = workinstruction.json();
                this.showPartnumber = this.workinstruction.workInstructionStatusId == workinstructionstatuses.Draft;
                this.workInstructionStatus = workinstructionstatuses[this.workinstruction.workInstructionStatusId];
                this.isDraftWorkInstructionStatus = this.workinstruction.workInstructionStatusId == workinstructionstatuses.Draft;
                this.isRequestedWorkInstructionStatus = this.workinstruction.workInstructionStatusId == workinstructionstatuses.Requested;
                this.alllowDeletePartnumber = this.workinstruction.workInstructionStatusId == workinstructionstatuses.Draft &&
                    this.stateService.hasPrivilege('workinstructions-edit') ? true : false;
                this.loadJob();
                this.loadDocuments();
                this.loadPartNumbers();
                this.loadTransactions();
                this.loadRiskAssessments();
                this.processing = false;
            },
            error => {
                this.router.navigate(['/jobs/', this.workinstruction.jobId]);
                this.processing = false;
            });
    }

    /**
    * Loads the job record and associated with the workinstruction
    */
    loadJob() {        
        this.processing = true;
        this.route.params
            .switchMap((params: Params) => this.jobService.getJob(+params['id']))
            .subscribe(
            response => {                
                this.job = response.json();
                this.checkDraftWorkInstruction();
                this.showDefect = this.job.jobTypeId == jobtypes.Sort || this.job.jobTypeId == jobtypes.Sort_Rework ? true : false;
                this.showRework = this.job.jobTypeId == jobtypes.Sort_Rework || this.job.jobTypeId == jobtypes.Rework ? true : false;
                if (this.showDefect) {
                    this.loadDefects();
                }
                if (this.showRework) {
                    this.loadWorkIstructionRework();
                }
                
                this.loadSteps();
                this.processing = false;
            },
            error => {
                this.notificationService.notify('error', error);
                this.processing = false;
            });
    }

    /**
    * Loads workinstruction defects associated with the job for the defect grid in the UI
    */
    loadDefects() {
        this.jobDefectsLoading = true;
        this.workInstructionService.getDefects(this.workinstruction.jobId, this.workinstruction.id, this.jobDefectsConfig, this.jobDefectPagination)
            .subscribe(
            response => {
                this.jobDefects = response.json();
                this.jobDefectPagination = this.getPagination(response);
                this.jobDefectsLoading = false;
            },
            error => {
                this.notificationService.notify('error', error);
                this.jobDefectsLoading = false;
            });
    }


    /**
   * Loads workinstruction steps associated with the job for the step grid in the UI
   */
    loadSteps() {
        this.workInstructionStepsLoading = true;
        this.workInstructionService.getSteps(this.workinstruction.jobId, this.workinstruction.id, this.workInstructionStepsConfig, this.workInstructionStepPagination)
            .subscribe(
            response => {
                this.workInstructionSteps = response.json();
                this.workInstructionStepPagination = this.getPagination(response);
                this.workInstructionStepsLoading = false;
            },
            error => {
                this.notificationService.notify('error', error);
                this.workInstructionStepsLoading = false;
            });
    }


    /**
    * Loads workinstruction part number associated with the job for the partnumber grid in the UI
    */
    loadPartNumbers() {
        this.workInstructionPartNumbersLoading = true;
        this.workInstructionService.getPartNumbers(this.workinstruction.jobId, this.workinstruction.id, this.workInstructionPartNumbersConfig, this.workInstructionPartNumbersPagination)
            .subscribe(
            response => {        
                this.workInstructionPartNumbers = response.json();
                this.workInstructionPartNumbersPagination = this.getPagination(response);
                this.workInstructionPartNumbersLoading = false;
            },
            error => {
                this.notificationService.notify('error', error);
                this.workInstructionPartNumbersLoading = false;
            });
    }

    /**
    * Loads all transactions associated with the user for the timeline interface
    */
    loadTransactions() {
        this.transactionsLoading = true;
        this.workInstructionService.getTransactions(this.workinstruction.jobId, this.workinstruction.id, this.transactionsConfig, this.transactionPagination)
            .subscribe(
            response => {
                this.transactions = response.json();
                this.transactionPagination = this.getPagination(response);
                this.transactionsLoading = false;
            },
            error => {
                this.notificationService.notify('error', error);
                this.transactionsLoading = false;
            });
    }

    /**
     * Loads WorkInstruction Reworks associated with the job for the partnumber grid in the UI
     */
    loadWorkIstructionRework() {
        this.workInstructionReworkLoading = true;
        this.workInstructionService.getReworks(this.job.id, this.workinstruction.id, this.workInstructionReworkConfig, this.workInstructionReworkPagination)
            .subscribe(
            response => {
                this.workInstructionReworks = response.json();
                this.workInstructionReworkPagination = this.getPagination(response);
                this.workInstructionReworkLoading = false;
            },
            error => {
                this.notificationService.notify('error', error);
                this.workInstructionReworkLoading = false;
            });
    }

    /**
     * Checks any draft workinstructions for the job
     */
    checkDraftWorkInstruction() {
        this.processing = true;
        this.workInstructionService.getWorkInstructions(this.workinstruction.jobId)
            .subscribe(
            response => {
                let workInstructions: Array<WorkInstruction> = response.json();
                if (workInstructions) {
                    this.isAnyDraftWorkInstruction = _.some(workInstructions, ['workInstructionStatusId', workinstructionstatuses.Draft]);
                }
                this.processing = false;
                this.showCloneWorkInstruction = (!this.isAnyDraftWorkInstruction) && this.job.jobStatusId >= jobstatuses.Active ? true : false;
            },
            error => {
                this.notificationService.notify('error', error);
                this.processing = false;
            });
    }

    /**
     * Updates work-instruction defects sequences
     */
    //updateWorkInstructionDefectSequence() {
    //    this.workInstructionDefectsLoading = true;
    //    this.workInstructionService.updateWorkInstructionStepSequence(this.workinstruction.jobId, this.workinstruction.id, this.workInstructionDefects)
    //        .subscribe(
    //        response => {
    //            this.notificationService.notify('success', 'Defect sequence updated successfully.');
    //            this.workInstructionDefectsLoading = false;
    //        },
    //        error => {
    //            this.notificationService.notify('error', error._body);
    //            this.workInstructionDefectsLoading = false;
    //        });
    //}

    /**
   * Updates work-instruction step sequences
   */
    updateWorkInstructionStepSequence() {
        this.workInstructionStepsLoading = true;
        this.workInstructionService.updateWorkInstructionStepSequence(this.workinstruction.jobId, this.workinstruction.id, this.workInstructionSteps)
            .subscribe(
            response => {
                this.notificationService.notify('success', 'Step sequence updated successfully.');
                this.workInstructionStepsLoading = false;
            },
            error => {
                this.notificationService.notify('error', error._body);
                this.workInstructionStepsLoading = false;
            });
    }

    /**
     * Adds workinstruction part number
     */
    addPartNumber() {
        this.processing = true;
        this.workInstructionService.addPartNumber(this.workinstruction.jobId, this.workinstruction.id, this.newPartNumber)
            .subscribe(
            response => {
                this.notificationService.notify('success', this.newPartNumber.partNumber + ' added successfully.');
                this.newPartNumber = new WorkInstructionPartNumber();
                this.processing = false;
                this.loadPartNumbers();
                this.closeModal('addPartNumber');
                this.loadTransactions();
            },
            error => {
                this.notificationService.notify('error', error._body);
                this.processing = false;
                this.closeModal('addPartNumber');
            });
    }

    /**
     * Removes workinstruction part number
     */
    deletePartNumber(partnumber: WorkInstructionPartNumber) {
        this.workInstructionPartNumbersLoading = true;
        this.workInstructionService.removePartNumber(this.workinstruction.jobId, this.workinstruction.id, partnumber.id)
            .subscribe(
            response => {
                this.notificationService.notify('success', partnumber.partNumber + ' deleted successfully.');
                this.loadPartNumbers();
                this.workInstructionPartNumbersLoading = false;
                this.loadTransactions();
            },
            error => {
                this.notificationService.notify('error', error);
                this.workInstructionPartNumbersLoading = false;
            });
    }

    /**
     * Adds workinstruction defect
     */
    addDefect() {
        this.processing = true;
        this.workInstructionService.addDefect(this.workinstruction.jobId, this.workinstruction.id, this.newDefect)
            .subscribe(
            response => {
                this.notificationService.notify('success', 'New defect added successfully.');
                this.newDefect = new WorkInstructionDefect();
                this.processing = false;
                this.loadDefects();
                this.loadTransactions();
                this.closeModal('addDefect');
            },
            error => {
                this.notificationService.notify('error', error._body);
                this.processing = false;
                this.closeModal('addDefect');
            });
    }

    /**
     *  Removes WorkInstruction Defect
     */
    deleteDefect(defect: WorkInstructionDefect) {
        this.jobDefectsLoading = true;
        this.workInstructionService.removeDefect(this.job.id, this.workinstruction.id, defect.id)
            .subscribe(
            response => {
                this.notificationService.notify('success', defect.name + ' deleted successfully.');
                this.loadDefects();
                this.jobDefectsLoading = false;
            },
            error => {
                this.notificationService.notify('error', error);
                this.jobDefectsLoading = false;
            });
    }

    /**
     * Adds workInstruction Rework
     */
    addWorkInstructionReWork() {
        this.processing = true;
        this.workInstructionService.addRework(this.job.id, this.workinstruction.id, this.newRework)
            .subscribe(
            response => {
                this.notificationService.notify('success', 'New rework added successfully.');
                this.newRework = new WorkInstructionRework();
                this.processing = false;
                this.loadWorkIstructionRework();
                this.closeModal('addRework');
            },
            error => {
                this.notificationService.notify('error', error._body);
                this.processing = false;
                this.closeModal('addRework');
            });
    }

    /**
     * Removes workInstruction Rework
     */
    deleteWorkInstructionRework(rework: WorkInstructionRework) {
        this.workInstructionReworkLoading = true;
        this.workInstructionService.removeRework(this.job.id, this.workinstruction.id, rework.id)
            .subscribe(
            response => {
                this.notificationService.notify('success', rework.name + ' deleted successfully.');
                this.loadWorkIstructionRework();
                this.workInstructionReworkLoading = false;
            },
            error => {
                this.notificationService.notify('error', error);
                this.workInstructionReworkLoading = false;
            });
    }


    /**
    * Adds workinstruction step
    */
    addStep() {
        this.processing = true;
        this.workInstructionService.addStep(this.workinstruction.jobId, this.workinstruction.id, this.newStep)
            .subscribe(
            response => {
                this.notificationService.notify('success', 'New step added successfully.');
                this.newStep = new WorkInstructionStep();
                this.loadSteps();
                this.loadTransactions();
                this.closeModal('addStep');
                this.processing = false;
            },
            error => {
                this.notificationService.notify('error', error._body);
                this.processing = false;
                this.closeModal('addStep');
            });
    }

    /**
    * Removes workinstruction step
    */
    deleteStep(Step: WorkInstructionStep) {
        this.workInstructionStepsLoading = true;
        this.workInstructionService.removeStep(this.workinstruction.jobId, this.workinstruction.id, Step.id)
            .subscribe(
            response => {
                this.notificationService.notify('success', Step.description + ' deleted successfully.');
                this.loadSteps();
                this.loadTransactions();
                window.scrollTo(0, 0);
                this.workInstructionStepsLoading = false;
            },
            error => {
                this.notificationService.notify('error', error);
                this.workInstructionStepsLoading = false;
            });
    }

    /**
     * Clone work-instruction of current work-instruction
     */
    cloneWorkInstruction() {
        this.cloneWorkInstructionLoading = true;
        this.workInstructionService.cloneWorkInstruction(this.workinstruction.jobId, this.workinstruction.id)
            .subscribe(
            response => {
                let newWorkInstruction: WorkInstruction = response.json();
                this.notificationService.notify('success', 'Work-Instruction clone successfully.');
                this.checkDraftWorkInstruction();
                this.loadTransactions();
                this.cloneWorkInstructionLoading = false;
                this.router.navigate(['/jobs/', newWorkInstruction.jobId, 'work-instructions', newWorkInstruction.id]);
            },
            error => {
                this.notificationService.notify('error', error);
                this.cloneWorkInstructionLoading = false;
            });
    }

    /**
     * Loads all workinstruction documents
     */
    loadDocuments() {
        this.workInstructionDocumentsLoading = true;
        this.workInstructionService.getWorkInstructionDocuments(this.workinstruction.jobId, this.workinstruction.id)
            .subscribe(
            response => {
                this.workInstructionDocuments = response.json();
                this.workInstructionDocumentsLoading = false;
            },
            error => {
                this.notificationService.notify('error', error);
                this.workInstructionDocumentsLoading = false;
            });
    }

    /**
     * Fetches document from selected document
     */
    fetchDocument(documentrevision: DocumentRevision) {
        this.workInstructionDocumentsLoading = true;
        let options = new RequestOptions({ responseType: ResponseContentType.Blob });
        this.workInstructionService.fetchWorkInstructionDocument(this.job.id, this.workinstruction.id, documentrevision.documentId)
            .subscribe(
            response => {
                FileSaver.saveAs(response, documentrevision.documentName + '.pdf');
                let fileURL = URL.createObjectURL(response);
                window.open(fileURL);
                this.workInstructionDocumentsLoading = false;
            },
            error => {
                this.notificationService.notify('error', error);
                this.workInstructionDocumentsLoading = false;
            });
    }

    /**
     * Approval request of the work instruction for job
     */
    workInstructionRequest() {
        this.workInstructionService.createWorkInstructionRequest(this.job.id, this.workinstruction.id)
            .subscribe(workinstruction => {
                this.workinstruction = workinstruction.json();
            });
    }

    /**
     * Approve workinstruction for job
     */
    workInstructionApprove() {
        this.workInstructionService.approveWorkInstructionRequest(this.job.id, this.workinstruction.id)
            .subscribe(workinstruction => {
                this.workinstruction = workinstruction.json()
                this.notificationService.notify('success', 'Approval request sent.');
            });
    }

    /**
     * Decline workinstruction for job
     */
    workInstructionDecline() {
        this.workInstructionService.declineWorkInstructionRequest(this.job.id, this.workinstruction.id)
            .subscribe(workinstruction => {
                this.workinstruction = workinstruction.json()
                this.notificationService.notify('warning', 'Request declined successfully.');
            });
    }

    /**
    * loads risk assessment for workinstruction 
    */
    loadRiskAssessments() {
        this.riskassessmentsLoading = true;
        this.riskAssessmentService.getRiskAssessments(this.workinstruction.jobId, this.workinstruction.id, this.riskassessmentsConfig, this.riskassessmentsPagination)
            .subscribe(
            response => {
                this.riskAssessments = response.json();
                this.riskassessmentsPagination = this.getPagination(response);
                this.riskassessmentsLoading = false;
            },
            error => {
                this.notificationService.notify('error', error);
                this.riskassessmentsLoading = false;
            });
    }
}