import { Injectable, Inject } from "@angular/core";
import { Headers, Http, Response, Request } from '@angular/http';
import { Router } from "@angular/router";
import { StateService } from "./state.service";
import { Observable } from "rxjs";

@Injectable()
export class AuthService {

        private apiBase: string;
        private apiAuthUrl: string;
        private headers: Headers = new Headers(); 

        constructor(
            @Inject('API_BASE') API_BASE: string,
            @Inject('API_VERSION') private API_VERSION: string,
            private http: Http,        
            private router: Router,
            private stateService: StateService)

        {
            this.headers.append("content-type", "application/json");
            this.headers.append("api-version", API_VERSION);
            this.apiBase = API_BASE;
            this.apiAuthUrl = API_BASE + '/api/auth';
        } 

    /**
   * Calls the API to validate a users provided credentials
   * @param {string} username User provided username to use in authentication
   * @param {string} password User provided password to use in authentication
   */
    login(username: string, password: string): Observable<boolean> {
        let head: Headers = new Headers({
            'Content-Type': 'application/x-www-form-urlencoded',
            'api-version': this.API_VERSION
        });
        return this.http.post(
            this.apiAuthUrl + '/token',
            'username=' + username + '&password=' + password,
            { headers: head })
            .flatMap((response) => {
                let token = response.json();
                if (token) {
                    return this.stateService.setToken(token);
                } else {
                    //this.notificationService.notify('error', response.statusText);
                    return Observable.of(false);
                }
            });
    }


    /**
     * Removes any cookies and authorization for the currently logged in user
     */
    logout() {
        this.stateService.removeToken();
    }

}
