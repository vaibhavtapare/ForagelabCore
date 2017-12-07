import { Injectable } from '@angular/core';
import * as _ from 'lodash';

/**
 * The modal service is used for modal windows throughout the UI
 */
@Injectable()
export class ModalService {
    private modals: any[] = [];

    /**
     * Adds a modal window to the service
     * @param modal Modal to add
     */
    add(modal: any) {
        // add modal to array of active modals
        this.modals.push(modal);
    }

    /**
     * Removes a modal window from the service
     * @param id Unique identifier of the modal to remove
     */
    remove(id: string) {
        // remove modal from array of active modals
        let modalToRemove = this.get(id);
        this.modals = _.without(this.modals, modalToRemove);
    }

    /**
     * Opens a modal window with the record provided
     * @param {string} id Unique identifier of the modal to display
     * @param {any} [record] Optional record to use in modal
     */
    open(id: string, record?: any) {
        // open modal specified by id
        let modal = this.get(id);
        modal.record = record;
        modal.open();
    }

    /**
     * Close a modal window
     * @param {string} id Unique identifier of the modal to close
     */
    close(id: string) {
        // close modal specified by id
        let modal = this.get(id);
        modal.record = null;
        modal.close();
    }

    /**
     * Retrieves a modal from the service
     * @param {string} id Unique identifier of the modal to retrieve
     */
    get(id: string) {
        return _.find(this.modals, function (o) { return o.id == id; });
    }
}