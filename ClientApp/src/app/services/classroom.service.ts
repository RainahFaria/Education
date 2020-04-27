import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
// tslint:disable-next-line: import-blacklist
import { Observable } from 'rxjs';
import { Classroom } from '../models/classroom';

@Injectable({
  providedIn: 'root'
})
export class ClassroomService {

  constructor(private httpClient: HttpClient) { }

  private getOptions(myParams?: HttpParams) {
    const httpClientDefaultHeader: HttpHeaders = new HttpHeaders({ 'Content-Type': 'application/json' });
    const myOptions = { headers: httpClientDefaultHeader, params: myParams };
    return myOptions;
  }

  getAllClassrooms(): Observable<object> {
    return this.httpClient.get(`https://localhost:5001/api/Classroom/GetAll`, this.getOptions());
  }

  addClassroom(classroom: Classroom): Observable<object> {
    return this.httpClient.post(`https://localhost:5001/api/Classroom/AddClassroom`, JSON.stringify(classroom), this.getOptions());
  }

}



