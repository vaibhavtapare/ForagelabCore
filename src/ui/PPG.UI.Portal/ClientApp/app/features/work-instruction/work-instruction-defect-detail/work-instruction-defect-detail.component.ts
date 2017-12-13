import { Component, OnInit, Input, ViewChild, Inject } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import * as _ from 'lodash';
import * as FileSaver from 'file-saver';
import { DomSanitizer } from "@angular/platform-browser";

import { AuthenticatedComponentBase } from '../../../shared/bases/authenticated.component.base';

import { ModalService } from '../../../core/services/modal.service';
import { NotificationService } from '../../../core/services/notification.service';
import { StateService } from '../../../core/services/state.service';
import { WorkInstructionService } from "../../../core/services/workinstruction.service";
import { JobServices } from "../../../core/services/job.service";

import { WorkInstruction, workinstructionstatuses } from "../../../shared/models/workInstruction.model";
import { WorkInstructionPartNumber, workInstructionPartNumberFullDataTableConfig } from "../../../shared/models/workInstruction-partnumber.model";
import { WorkInstructionDefect, workInstructionDefectFullDataTableConfig } from "../../../shared/models/workInstruction-defect.model";
import { Pagination } from "../../../shared/models/pagination.model";
import { DataTableConfig } from "../../../shared/models/data-table-config.model";
import { transactionFullDataTableConfig, Transaction } from "../../../shared/models/transaction.model";
import { Job } from "../../../shared/models/job.model";
import { WorkInstructionStep, workInstructionStepFullDataTableConfig } from "../../../shared/models/workInstruction-step-model";

@Component({
    templateUrl: './work-instruction-defect-detail.component.html'
})
export class WorkInstructionStepDetailComponent extends AuthenticatedComponentBase implements OnInit {
    constructor(
        @Inject('AZURE_FILE_PATH') private AZURE_FILE_PATH: string,
        private sanitizer: DomSanitizer,
        public modalService: ModalService,
        private route: ActivatedRoute,
        private router: Router,
        public notificationService: NotificationService,
        private workInstructionService: WorkInstructionService,
        private jobService: JobServices,
        stateService: StateService) {
        super(modalService, notificationService, stateService);
    }

    @ViewChild("fileInput") fileInput;

    processing: boolean = false;
    jobId: number;
    workInstructionId: number;
    workInstructionStep: WorkInstructionStep;
    isAllowWorkInstruction: boolean = false;
    showArchive: boolean = false;
    stepImage: any;

    ngOnInit() {
        this.loadWorkInstructionStep();
        this.checkDraftWorkInstruction();
    }

    /**
    * Loads the work-instruction defect record and associated record sets
    */
    loadWorkInstructionStep() {
        this.route.params.subscribe(params => {
            this.jobId = +params['id'];
            this.workInstructionId = +params['workInstructionId'];
        });
        this.processing = true;
        this.route.params
            .switchMap((params: Params) => this.workInstructionService.getStep(this.jobId, this.workInstructionId, +params['stepId']))
            .subscribe(
            response => {
                this.workInstructionStep = response.json();
                this.stepImage = this.sanitizer.bypassSecurityTrustUrl(this.AZURE_FILE_PATH + this.workInstructionStep.pictureAzurePath);
                this.processing = false;
            },
            error => {
                this.router.navigate(['/jobs/', this.jobId, 'work-instructions', this.workInstructionId]);
                this.processing = false;
            });
    }

    /**
    * Checks any draft workinstructions for the job
    */
    checkDraftWorkInstruction() {
        this.processing = true;
        this.workInstructionService.getWorkInstruction(this.jobId,this.workInstructionId)
            .subscribe(
            response => {
                let workInstruction: WorkInstruction = response.json();
                if (workInstruction.workInstructionStatusId < workinstructionstatuses.Active) {
                    this.isAllowWorkInstruction = true;
                }
                this.processing = false;
                this.showArchive = this.stateService.hasPrivilege('workinstructions-archive') && this.isAllowWorkInstruction ? true : false;
            },
            error => {
                this.notificationService.notify('error', error);
                this.processing = false;
            });
    }

    /**
     * Saves the workinstruction defect record
     */
    saveWorkInstructionStep() {
        this.processing = true;
        let fileToUpload = null;
        let fi = this.fileInput.nativeElement;
        if (fi.files && fi.files[0]) {
            fileToUpload = fi.files[0];
        }
        this.workInstructionService.saveStep(this.jobId, this.workInstructionId, this.workInstructionStep,fileToUpload)
            .subscribe(
            response => {
                this.notificationService.notify('success', 'saved successfully.');
                this.loadWorkInstructionStep();
                this.processing = false;
                window.scrollTo(0, 0);
            },
            error => {
                this.notificationService.notify('error', error);
                this.processing = false;
                window.scrollTo(0, 0);
            });
    }

    /**
     * Archives an workinstruction defect (and closes the user account if one exists)
     */
    archiveWorkInstructionStep() {
        this.processing = true;
        this.workInstructionService.removeStep(this.jobId, this.workInstructionStep.workInstructionId, this.workInstructionStep.id)
            .subscribe(
            response => {
                this.notificationService.notify('warning', "'data has been archived.");
                this.closeModal('archiveDefect');
                this.processing = false;
                this.router.navigate(['/jobs/', this.jobId, 'work-instructions', this.workInstructionStep.workInstructionId]);
            },
            error => {
                this.notificationService.notify('error', error._body);
                this.processing = false;
                this.closeModal('archiveDefect');
            });
    }

    
}