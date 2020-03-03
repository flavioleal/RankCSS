import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ServicoPadraoService<T> {

  constructor(protected http: HttpClient,
    protected url) { }

  httpGet(): Observable<T[]> {
    return this.http.get<T[]>(this.url);
  }

  httpGetId(id: any): Observable<T> {
    return this.http.get<T>(this.url + '/' + id);
  }

  httpPost(registro: T, action?: string): Observable<T> {
    let urlservice = this.url;
    if (!!action) {
      urlservice += '/' + action;
    }
    return this.http.post<T>(urlservice, registro);
  }

  httpPut(registro: T): Observable<T> {
    return this.http.put<T>(this.url, registro);
  }

  httpDelete(id: number): Observable<T> {
    const params = new HttpParams().set('id', id.toString());
    return this.http.delete<T>(this.url, { params });
  }
}

