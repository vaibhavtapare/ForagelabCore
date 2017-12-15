import { Injectable, Inject } from "@angular/core";
import { Headers, Http, RequestOptionsArgs, Response, RequestOptions, ResponseContentType } from '@angular/http';
import { StateService } from "../../core/services/state.service";
import { DataTableConfig } from "../model/data-table-config.model";
import { Pagination } from "../model/pagination.model";
import { Observable } from 'rxjs';

@Injectable()
export class AuthenticatedServiceBase {

    public apiUrl: string;
    private headers: Headers = new Headers(); 


    constructor(
        @Inject('API_BASE') API_BASE: string,
        @Inject('API_VERSION') API_VERSION: string,
        public http: Http,
        public stateService: StateService) {

        this.headers.append("content-type", "application/json");
        this.headers.append("api-version", API_VERSION);
        this.apiUrl = API_BASE + '/api';
    }

    /**
    * Performs a GET request on the provided URL and appends JWT to the header.
    * @param {string} url URL to call
    * @param {DataTableConfig} [config] Optional configuration for data tables
    * @param {Pagination} [pagination] Optional pagination info for data tables
    * @param {Headers} [headers = new Headers] Optional headers to include in request
    */
    get(url: string, config?: DataTableConfig, pagination?: Pagination, headers: Headers = new Headers()): Observable<Response> {

        return this.stateService.getAuthHeader()
            .map(res => res)
            .flatMap((authHeaders) => {
                headers.forEach((val, name) => authHeaders.append(name, val[0]));
                let requestUrl: string = this.apiUrl + url;
                let query: string = '';

                if (pagination) {
                    query = query + '?pageIndex=' + pagination.pageIndex + '&pageSize=' + pagination.pageSize;
                }

                if (config) {
                    query = query + (query.length > 0 ? '&' : '?') + 'sortBy=' + config.sortColumn + '&sortDirection=' + (config.sortDirection == 0 ? 'asc' : 'desc');
                    if (config.filter) {
                        let filterRequest: string = config.filter();
                        if (filterRequest) {
                            query = query + '&filter=' + filterRequest;
                        }
                    }
                }

                return this.http
                    .get(requestUrl + query, { headers: authHeaders })
            });
    }
}