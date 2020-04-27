import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
// tslint:disable-next-line: import-blacklist
import { Observable } from 'rxjs';
import { School } from '../models/school';

@Injectable({
  providedIn: 'root'
})
export class SchoolService {

  constructor(private httpClient: HttpClient) { }

  private getOptions(myParams?: HttpParams) {
    const httpClientDefaultHeader: HttpHeaders = new HttpHeaders({ 'Content-Type': 'application/json' });
    const myOptions = { headers: httpClientDefaultHeader, params: myParams };
    return myOptions;
  }

  getAllSchools(): Observable<object> {
    return this.httpClient.get(`https://localhost:5001/api/School/GetAll`, this.getOptions());
  }

  addSchool(school: School ): Observable<object> {
    return this.httpClient.post(`https://localhost:5001/api/School/AddSchool`, JSON.stringify(school), this.getOptions());
  }

}



