import { Inject, Injectable } from '@angular/core';
import { Subject } from "rxjs/Subject";
import { Http } from '@angular/http';
import { Observable } from 'rxjs/Rx';

import { AuthenticatedServiceBase } from '../../shared/bases/authenticated.service.base';

import { StateService } from './state.service';

import { Transaction } from '../../shared/models/transaction.model';
import { CommonStyles } from "../../shared/models/common-styles.model";


@Injectable()
export class TransactionService extends AuthenticatedServiceBase {
    constructor(
        @Inject('API_BASE') API_BASE: string,
        @Inject('API_VERSION') API_VERSION: string,
        http: Http,
        stateService: StateService) {
        super(API_BASE, API_VERSION, http, stateService);
        Observable.interval(300000)
            .subscribe(() => {
                this.getTransactions();
            })
    }

    baseUrl: string = '/transactions';

    transactionArr: Array<Transaction>;
    oldtransactions: Array<Transaction> = new Array<Transaction>();

    private transactionSource = new Subject<Array<Transaction>>();

    transactions = this.transactionSource.asObservable();

    /**
     * Gets all open transactions for the current user
     */
    getTransactions(){
        this.get(this.baseUrl).subscribe(trans => {
            this.transactionArr = trans.json();

            this.transactionSource.subscribe(x => {
                this.oldtransactions = x as Array<Transaction>;
            });
            
            this.transactionArr.forEach(x => {
                let style = CommonStyles.pointStyles.filter((f) => {
                    return f.id == x.transactionTypeId;
                });
                x.iconClass = (style[0]) ? style[0].icon : '';
                x.taskstatusClass = (style[0]) ? style[0].class : '';

                let filteredTransaction: Transaction = this.oldtransactions.filter(ot => ot.id == x.id)[0];
                if (filteredTransaction) {
                    if (filteredTransaction.taskstatusClass == '')
                    { x.taskstatusClass = ''; }
                }
            });

            this.transactionSource.next(this.transactionArr);
        });
    }

    /**
     * Marks a transaction as read via the API
     * @param id {number} Unique identifier of the transaction
     */
    markTransactionAsRead(id: number) {
        let body = JSON.stringify(id);
        return this.put(this.baseUrl + '/' + id, body); 
    }
}