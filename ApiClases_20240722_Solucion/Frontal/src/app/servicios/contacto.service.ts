import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError, tap, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ContactoService{
  
  private url = 'https://localhost:7138/api/VContactos';
  constructor(private http: HttpClient) { }
  getListaContactosPorId(id: number) : Observable<Contacto[]>{
    return this.http.get<Contacto[]>(`${this.url}/${id}`).pipe(
      tap(data => data),
      catchError(this.handleError)
    );
  }

  //getListaContactosPorFiltro(id: number): Observable<IVistaContacto> {
  //  const parametrosFiltro: FiltroParametrosVistaContacto = {
  //    IdCliente: id,
  //    NombreUsuarioContacto: null,
  //    Pais: null,
  //    NumeroPaginas: 1,
  //    TamanoPagina: 30
  //  };
  //  return this.http.post<IVistaContacto>(`${this.url}/${id}`).pipe(
  //    tap(data => data),
  //    catchError(this.handleError)
  //  );
  //}


  private handleError(err: HttpErrorResponse) {
    // in a real world app, we may send the server to some remote logging infrastructure
    // instead of just logging it to the console
    let errorMessage = '';
    if (err.error instanceof ErrorEvent) {
      // A client-side or network error occurred. Handle it accordingly.
      errorMessage = `An error occurred (12345678): ${err.error.message}`;
    } else {
      // The backend returned an unsuccessful response code.
      // The response body may contain clues as to what went wrong,
      errorMessage = `Server returned code: ${err.status}, error message is: ${err.message}`;
    }
    console.error(errorMessage);
    return throwError(() => errorMessage);
  }

}

export interface FiltroParametrosVistaContacto {
  IdCliente: number;
  NombreUsuarioContacto: string | null;
  Pais: string | null;
  NumeroPaginas: number;
  TamanoPagina: number;
}

export interface Contacto {

  constructor(): void;
  IdCliente: number;
  NombreUsuarioContacto: string;
  Pais: string;
}
