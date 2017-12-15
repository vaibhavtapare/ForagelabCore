import { Component, OnInit } from '@angular/core';
import { Response } from '@angular/http';
import { Observable } from 'rxjs'; 


import { Pagination } from "../model/pagination.model";
import { StateService } from "../../core/services/state.service";
export class AuthenticatedComponentBase implements OnInit {
    public currentUser: any; 

    constructor(    
        public stateService: StateService) {
    } 

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

    ///**
    // * Calls ModalService to open modal window
    // * @param {string} id Name of the modal to open
    // */
    //openModal(id: string) {
    //    this.modalService.open(id);
    //}

    ///**
    // * Calls ModalService to close modal window
    // * @param {string} id Name of the modal to close
    // */
    //closeModal(id: string) {
    //    this.modalService.close(id);
    //}

}