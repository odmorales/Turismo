import { Injectable } from '@angular/core';
import { Observable,of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class HandleHttpErrorService {
  public handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      if (error.status == "400") {
        this.mostrarError400(error);
      }
      return of(result as T);
    };
  }
  public log(message: string) {
    console.log(message);
  }
  private mostrarError400(error: any): void {
    console.error(error);
    let contadorValidaciones: number = 0;
    let mensajeValidaciones: string =
    ``;

    for (const prop in error.error.errors) {
      contadorValidaciones++;
      mensajeValidaciones += ``;

      error.error.errors[prop].forEach(element => {
        mensajeValidaciones += `${element}`;
      });

      alert(mensajeValidaciones += ``);
    }
  }
  constructor() { }
}
