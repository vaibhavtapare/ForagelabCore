/**
 * Base class for components accessible by authenticated users
 */
import { OnInit } from "@angular/core";
import { ModalService } from "../../core/services/modal.service";
import { NotificationService } from "../../core/services/notification.service";
import { StateService } from "../../core/services/state.service";
import { Pagination } from "../models/pagination.model";
import { Response } from '@angular/http'; 

export class AuthenticatedComponentBase implements OnInit {
    constructor(
        public modalService: ModalService,
        public notificationService: NotificationService,
        public stateService: StateService) {
    }

    public currentUser: any;

    ngOnInit() {
        this.currentUser = this.stateService.currentUser;
    }

    /**
     * Method for getting pagination out of a Response object
     * @param {Response} response Response object to pull pagination from
     */
    getPagination(response: Response): Pagination {
        return new Pagination(response);
    }

    /**
     * Calls ModalService to open modal window
     * @param {string} id Name of the modal to open
     */
    openModal(id: string) {
        this.modalService.open(id);
    }

    /**
     * Calls ModalService to close modal window
     * @param {string} id Name of the modal to close
     */
    closeModal(id: string) {
        this.modalService.close(id);
    }
}