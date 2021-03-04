import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Users } from './app.interfaces';

@Injectable({
  providedIn: 'root'
})
export class AppService {

  constructor(private http: HttpClient) {
  }

  getUsers(limit = '10', page = '0'): Observable<Users> {
    const params = new HttpParams()
      .set('limit', limit)
      .set('page', page);
    return this.http.get<Users>(`users`, { params });
  }
}
