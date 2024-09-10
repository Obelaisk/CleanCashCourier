import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError, tap, throwError } from 'rxjs';
import { Contacto } from '../interfaces/contactos';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ContactoService{
  
  //private url = 'https://localhost:7138/api/Contactos';
  private url = environment.apiContactos;
  constructor(private http: HttpClient) { }

  checkIfExists(token: string, nombreClienteABuscar: string): Observable<any> {
  const modelo : ModeloBusquedaContacto = {
    tokenCliente: token,
    NombreUsuarioClienteABuscar: nombreClienteABuscar
  }
    return this.http.post<any>(`${this.url}/checkIfExists`, modelo);
  }
  getListaContactosPorToken(token: string): Observable<Contacto[]>{
    return this.http.get<Contacto[]>(`${this.url}/${token}`).pipe(
      tap(data => console.log(data)),
      catchError(this.handleError)
    );
  }

  getListaContactosPorId(id: number): Observable<Contacto[]> {
    return this.http.get<Contacto[]>(`${this.url}/getAllContactsByToken/${id}`).pipe(
      tap(data => data),
      catchError(this.handleError)
    );
  }

  eliminarContacto(nombre: string, token: string) {

    const url = `${this.url}?nombreAEliminar=${nombre}&token=${token}`;
    return this.http.delete<void>(url).pipe(
      tap(() => console.log(`Contacto eliminado: ${nombre}`)),
      catchError(this.handleError)
    );
  }

  aniadirContacto(nombreNuevoContacto: string, token: string) {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json', 'Access-Control-Allow-Origin': '*' });

    const body = { nombreNuevoContacto,token };
    return this.http.post<void>(this.url, body, {headers}).pipe(
      tap(() => console.log(`Contacto añadido: ${nombreNuevoContacto}`)),
      catchError(this.handleError)
    );
  }


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
export interface ModeloBusquedaContacto {
  tokenCliente: string;
  NombreUsuarioClienteABuscar: string;
}
