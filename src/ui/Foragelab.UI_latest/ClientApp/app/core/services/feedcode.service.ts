import { Injectable } from '@angular/core';
import { Http } from "@angular/http";
import { DataTableConfig } from "../../shared/models/data-table-config";


@Injectable()
export class FeedCodeService {

    private globalVariables: string;   


    constructor(private _http: Http) {
        this.globalVariables = 'http://localhost:62062/api/';
    }   

    public getFeedcode(config?: DataTableConfig) {
        console.log(this.globalVariables.toString() + 'Feedcode');
        return this._http.get(this.globalVariables.toString() + 'Feedcode');                        
    }
}

