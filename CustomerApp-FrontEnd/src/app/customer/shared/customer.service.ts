import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Customer } from 'src/app/models/customer';
import { FilterCustomer } from 'src/app/models/filter-customer';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {

  constructor(private httpClient: HttpClient) { }

  url = `${environment.api}/api/customer`;
  // Headers
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
    })
  }

  getAll(): Observable<any> {
    return this.httpClient.get<any>(this.url)
      .pipe(
        retry(2),
        catchError(this.handleError))
  }

  getAllInclude(): Observable<any> {
    return this.httpClient.get<any>(`${this.url}/include-all`)
      .pipe(
        retry(2),
        catchError(this.handleError))
  }

  filterAllInclude(filterCustomer: any): Observable<any> {
    const httpParams =  new HttpParams({ fromObject: filterCustomer });

    return this.httpClient.get<any>(`${this.url}/filter-all`, { params: httpParams })
      .pipe(
        retry(2),
        catchError(this.handleError))
  }

  getCommonAll(): Observable<any> {
    return this.httpClient.get<any>(`${this.url}/common-all`)
      .pipe(
        retry(2),
        catchError(this.handleError))
  }

  insert(customer: Customer): Observable<any> {
    return this.httpClient.post<any>(this.url, JSON.stringify(customer), this.httpOptions)
      .pipe(
        retry(2),
        catchError(this.handleError)
      )
  }

  update(customer: Customer): Observable<any> {
    return this.httpClient.put<any>(this.url, JSON.stringify(customer), this.httpOptions)
      .pipe(
        retry(1),
        catchError(this.handleError)
      )
  }

  // deleta
  delete(id: number) {
    return this.httpClient.delete<any>(this.url + '/' + id, this.httpOptions)
      .pipe(
        retry(1),
        catchError(this.handleError)
      )
  }

  getParams(data: any) {
    let httpParams = new HttpParams();
    Object.keys(data).forEach(function (key) {
         httpParams = httpParams.append(key, data[key]);
    });

    return httpParams;
  }

  // Manipulação de erros
  handleError(error: HttpErrorResponse) {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      // Erro ocorreu no lado do client
      errorMessage = error.error.message;
    } else {
      // Erro ocorreu no lado do servidor
      errorMessage = `Código do erro: ${error.status}, ` + `menssagem: ${error.message}`;
    }
    console.log(errorMessage);
    return throwError(errorMessage);
  };
}
