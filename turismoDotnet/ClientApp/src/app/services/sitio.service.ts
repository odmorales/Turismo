import { Inject, Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { HandleHttpErrorService } from '../@base/handle-http-error.service';
import { Sitio } from '../lugar/models/sitio';

const httpOptions = {
  headers: new HttpHeaders({'Content-Type': 'application/json'}),
};

@Injectable({
  providedIn: 'root'
})
export class SitioService {

  baseUrl: string;
  constructor(private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private handleErrorService: HandleHttpErrorService) {
    this.baseUrl = baseUrl;
  }
  get(): Observable<Sitio[]> {
    return this.http.get<Sitio[]>(this.baseUrl + 'api/Sitio')
      .pipe(
        tap(_ => this.handleErrorService.log('datos enviados')),
        catchError(this.handleErrorService.handleError<Sitio[]>('Consulta Persona', null))
      );
  }

  getIndivdual(ciudad:string): Observable<Sitio> {
    const url = `${this.baseUrl}api/Sitio/${ciudad}`; 
    return this.http.get<Sitio>(url).pipe(
    tap(_ => this.handleErrorService.log(`fetched hero id=${ciudad}`)),
    catchError(this.handleErrorService.handleError<Sitio>(`getHero id=${ciudad}`))
  );
  }

  post(sitio: Sitio): Observable<Sitio> {
    return this.http.post<Sitio>(this.baseUrl + 'api/Sitio', sitio)
      .pipe(
        tap(_ => this.handleErrorService.log('datos enviados')),
        catchError(this.handleErrorService.handleError<Sitio>('Registrar Sitio', null))
      );
  }
}
