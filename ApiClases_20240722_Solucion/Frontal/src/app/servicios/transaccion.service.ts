import { HttpClient, HttpErrorResponse, HttpHeaders } from "@angular/common/http";
import { Injectable } from '@angular/core';
import { Observable, catchError, map, tap, throwError } from "rxjs";
import { ITransaccion, Transaccion } from "../interfaces/transaccion";

@Injectable({
  providedIn: 'root'
})
export class TransaccionService {
  // private clientesUrl = 'api/clientes/clientes.json';
  private url = 'https://localhost:7138/api/Clientes';
  private urlConversor = 'https://api.getgeoapi.com/v2/currency/convert?api_key=fa412676602886da01c7aab7dc3ffc8645840ace&from='
  constructor(private http: HttpClient) { }


  crearTransaccion(transaccion: Transaccion): Observable<Transaccion> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json', 'Access-Control-Allow-Origin':'*'});
    const urlConId = `${this.url}/${transaccion.idEnvia}/Transacciones`;
    return this.http.post<Transaccion>(urlConId, transaccion, { headers })
      .pipe(
        catchError(this.handleError)
      );
  }
  hacerConversion(divisaOrigen: string, divisaDestino: string): Observable<number> {
    const urlConId = `${this.urlConversor}${divisaOrigen}&to=${divisaDestino}`;
    return this.http.get<any>(urlConId) // Cambia el tipo a 'any' para manejar la respuesta completa
      .pipe(
        map(response => response.rates[divisaDestino].rate), // Extrae el ratio
        catchError(this.handleError)
      );
  }


  getTransacciones(id_cliente: number): Observable<Transaccion[]> {
    return this.http.get<Transaccion[]>(`${this.url}/${id_cliente}/Transacciones`).pipe(
      
      catchError(this.handleError)
    );
  }


  getTransaccionesFiltradas(filtros: any, id_cliente: number): Observable<Transaccion[]> {
    let urlConFiltros = `${this.url}/${id_cliente}/Transacciones`;


    const parametros = [];

    if (filtros.fechaInicio) {
      parametros.push(`fechaInicio=${filtros.fechaInicio}`);
    }
    if (filtros.fechaFin) {
      parametros.push(`fechaFin=${filtros.fechaFin}`);
    }
    if (filtros.cantidadMin) {
      parametros.push(`cantidadEnviadaMin=${filtros.cantidadMin}`);
    }
    if (filtros.cantidadMax) {
      parametros.push(`cantidadEnviadaMax=${filtros.cantidadMax}`);
    }

    if (parametros.length > 0) {
      urlConFiltros += '?' + parametros.join('&');
    }

    return this.http.get<Transaccion[]>(urlConFiltros).pipe(
     
      catchError(this.handleError)
    );
  }


  private handleError(err: HttpErrorResponse) {
    let errorMessage = '';
    if (err.error instanceof ErrorEvent) {
      errorMessage = `An error occurred (12345678): ${err.error.message}`;
    } else {
      errorMessage = `Server returned code: ${err.status}, error message is: ${err.message}`;
    }
    console.error(errorMessage);
    return throwError(() => errorMessage);
  }
}
