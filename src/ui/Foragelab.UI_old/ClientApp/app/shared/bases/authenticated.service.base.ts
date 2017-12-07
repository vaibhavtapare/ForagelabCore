
/**
 * Base class for services used by other services accessible after authentication
 */
import { Injectable, Inject } from "@angular/core";
import { Headers, Http, RequestOptionsArgs, Response, RequestOptions, ResponseContentType } from '@angular/http';
import { StateService } from "../../core/services/state.service";
import { DataTableConfig } from "../models/data-table-config.model";
import { Pagination } from "../models/pagination.model";
import { Observable } from "rxjs";

@Injectable()
export class AuthenticatedServiceBase {
    constructor(
        @Inject('API_BASE') API_BASE: string,
        @Inject('API_VERSION') API_VERSION: string,
        public http: Http,
        public stateService: StateService) {

        this.headers.append("content-type", "application/json");
        this.headers.append("api-version", API_VERSION);
        this.apiUrl = API_BASE + '/api';
    }

    public apiUrl: string;
    private headers: Headers = new Headers();

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

    /**
     * Performs a PATCH request on the provided URL and appends JWT to the header.
     * @param {string} url URL to call
     * @param {any} body Object to pass in body of request
     * @param {Headers} [headers = new Headers] Optional headers to include in request
     */
    patch(url: string, body: any, headers: Headers = new Headers()): Observable<Response> {
        return this.stateService.getAuthHeader()
            .map(res => res)
            .flatMap((authHeaders) => {
                headers.forEach((val, name) => authHeaders.append(name, val[0]));
                return this.http
                    .patch(this.apiUrl + url, body, { headers: authHeaders })
            });
    }

    /**
     * Performs a POST request on the provided URL and appends JWT to the header.
     * @param {string} url URL to call
     * @param {any} body Object to pass in body of request
     * @param {Headers} [headers = new Headers] Optional headers to include in request
     */
    post(url: string, body: any, headers: Headers = new Headers()): Observable<Response> {
        return this.stateService.getAuthHeader()
            .map(res => res)
            .flatMap((authHeaders) => {
                headers.forEach((val, name) => authHeaders.append(name, val[0]));
                return this.http
                    .post(this.apiUrl + url, body, { headers: authHeaders })
            });
    }

    /**
     * Performs a PUT request on the provided URL and appends JWT to the header.
     * @param {string} url URL to call
     * @param {any} body Object to pass in body of request
     * @param {Headers} [headers = new Headers] Optional headers to include in request
     */
    put(url: string, body: any, headers: Headers = new Headers()): Observable<Response> {
        return this.stateService.getAuthHeader()
            .map(res => res)
            .flatMap((authHeaders) => {
                headers.forEach((val, name) => authHeaders.append(name, val[0]));
                return this.http
                    .put(this.apiUrl + url, body, { headers: authHeaders })
            });
    }

    /**
     * Performs a PUT request on the provided URL and appends JWT to the header.
     * @param {string} url URL to call
     * @param {any} body Object to pass in body of request
     * @param {any} file Object to pass in body of request
     * @param {Headers} [headers = new Headers] Optional headers to include in request
     */
    putWithFile(url: string, body: any, file: any, headers: Headers = new Headers()): Observable<Response> {
        return this.stateService.getAuthHeader()
            .map(res => res)
            .flatMap((authHeaders) => {
                headers.forEach((val, name) => authHeaders.append(name, val[0]));
                authHeaders.delete('content-type');
                let formData: FormData = new FormData();
                formData.append('model', body);
                formData.append('file', file);
                return this.http
                    .put(this.apiUrl + url, formData, { headers: authHeaders })
            });
    }

    /**
     * Performs a DELETE request on the provided URL and appends JWT to the header.
     * @param {string} url URL to call
     * @param {Headers} [headers = new Headers] Optional headers to include in request
     */
    delete(url: string, headers: Headers = new Headers()): Observable<Response> {
        return this.stateService.getAuthHeader()
            .map(res => res)
            .flatMap((authHeaders) => {
                headers.forEach((val, name) => authHeaders.append(name, val[0]));
                return this.http
                    .delete(this.apiUrl + url, { headers: authHeaders })
            });
    }

    /**
     * Performs a POST request on the provided URL, appends JWT to the header and includes
     * the provided file.
     * @param {string} url URL to call
     * @param {any} file File to upload with request
     * @param {Headers} [headers = new Headers] Optional headers to include in request
     */
    file(url: string, file: any, headers: Headers = new Headers()): Observable<any> {
        return this.stateService.getAuthHeader()
            .map(res => res)
            .flatMap((authHeaders) => {
                headers.forEach((val, name) => authHeaders.append(name, val[0]));
                authHeaders.delete('content-type');
                let formData: FormData = new FormData();
                formData.append('file', file);
                return this.http
                    .post(this.apiUrl + url, formData, { headers: authHeaders })
            });
    }

    DownloadFile(url: string, filetype: string, headers: Headers = new Headers()): Observable<any> {
        return this.stateService.getAuthHeader()
            .map(res => res)
            .flatMap((authHeaders) => {
                let requestUrl: string = this.apiUrl + url;
                headers.forEach((val, name) => authHeaders.append(name, val[0]));
                let options = new RequestOptions({ headers: authHeaders, responseType: ResponseContentType.Blob });
                return this.http
                    .get(requestUrl, options).map((res) => {
                        return new Blob([res.blob()], { type: filetype })
                    })
            });
    }
}
