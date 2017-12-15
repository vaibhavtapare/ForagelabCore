import { Inject, Injectable } from '@angular/core';
import { Headers, Http, Response } from '@angular/http';
import { Title } from '@angular/platform-browser';
import { ActivatedRouteSnapshot, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { CookieService } from 'ngx-cookie-service';

@Injectable()
export class StateService {

    private apiUrl: string;
    /**
    * If authenticated, the current user object
    */
    public currentUser: any;
    constructor(
        @Inject('API_BASE') API_BASE: string,
        @Inject('API_VERSION') private API_VERSION: string,
        private _cookieService: CookieService,
        private _http: Http,
        private _router: Router,
        private _title: Title       ) {
        this.apiUrl = API_BASE + '/api';
        let userToken: string = this._cookieService.get('user_token');

        if (userToken) {
            let parsedToken: any = this.parseToken(userToken);
            this.currentUser = parsedToken;
        }
    }

    private parseToken(jwt: any) {
        let base64Url = jwt.split('.')[1];
        if (base64Url != null) {
            let base64 = base64Url.replace('-', '+').replace('_', '/');
            return JSON.parse(window.atob(base64));
        }
        return null;
    }


    /**
     * Gets a Header object with the Authorization: Bearer {token}
     */
    public getAuthHeader(): Observable<any> {
        let token: string = this._cookieService.get('user_token');

        if (token) {
            let params = this.parseToken(token);
            if (params && Math.round(new Date().getTime() / 1000) <= params.exp) {
                let headers = new Headers();
                headers.append("content-type", "application/json");
                headers.append("api-version", this.API_VERSION);
                headers.append('Authorization', 'Bearer ' + token);
                return Observable.of(headers);
            }
        }
        return this.refreshToken();
    }

    /**
    * Attempts to refresh the JWT auth token with the refresh token
    */
    public refreshToken(): Observable<Headers> {
        let refreshToken = this._cookieService.get('refresh_token');
        if (refreshToken) {
            let refreshHeader = new Headers();
            refreshHeader.append('Authorization', 'Bearer ' + refreshToken);
            refreshHeader.append("api-version", this.API_VERSION);

            return this._http.post(this.apiUrl + '/auth/refresh/' + refreshToken, null, { headers: refreshHeader })
                .map(res => {
                    let jwt = res.json();
                    this.setToken(jwt).subscribe(
                        s => {
                            let headers = new Headers();
                            headers.append("content-type", "application/json");
                            headers.append("api-version", this.API_VERSION);
                            headers.append('Authorization', 'Bearer ' + jwt.access_token);
                            return headers;
                        });
                }).catch(err => {
                    this.removeToken();
                    return Observable.throw(err);
                });
        }
        else {
            return new Observable<Headers>((obs: any) => {
                this.removeToken();
                obs.error(new Error('No refresh token available.'));
            });
        }
    }

    /**
     * Saves JWT authentication/authorization token to cookies and sets
     * current user object.
     * @param jwt
     */
    public setToken(jwt: any): Observable<any> {
        let oneYearFromNow = new Date();
        oneYearFromNow.setFullYear(oneYearFromNow.getFullYear() + 1);
        this.currentUser = this.parseToken(jwt.access_token);
        this._cookieService.set('user_token', jwt.access_token, oneYearFromNow);
        if (jwt.refresh_token) {
            this._cookieService.set('refresh_token', jwt.refresh_token,  oneYearFromNow);        
        }
        return Observable.of(true);
        //return this.loadPermissions();
    }

    /**
     * Removes the current token to de-authenticate the current user
     */
    public removeToken() {
        this.currentUser = null;      
        this._cookieService.deleteAll(); 
        this._router.navigate(['/auth']);
    }

}