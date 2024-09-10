import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import { Injectable } from '@angular/core';
import { Observable, catchError, tap, throwError } from "rxjs";
import { ICliente } from "../interfaces/cliente";
import { ActualizarPerfilCliente, InicioSesionCliente, RegistroCliente } from "../interfaces/registroCliente";
import { environment } from "../../environments/environment";

@Injectable({
  providedIn: 'root'
})
export class ClienteService {
  //private clientesUrl = 'https://localhost:7138/api/Clientes';
  private clientesUrl = environment.apiClientes;
  
  constructor(private http: HttpClient) { }
  
  getClientes(): Observable<ICliente[]> {
    return this.http.get<ICliente[]>(this.clientesUrl).pipe(
      tap(data => data),
      catchError(this.handleError)
    );
  }

  autenticarUsuario(usuario: string, contrasena: string, recuerdame: boolean): Observable<any> {
    recuerdame = false;

    const clienteInicioSesion: InicioSesionCliente = {
      Usuario: usuario,
      Contrasena: contrasena,
      Recuerdame: recuerdame
    }
    return this.http.post<any>(`${this.clientesUrl}/login`, clienteInicioSesion);
  }

  registrarCliente(cliente: RegistroCliente): Observable<any> {
    
    return this.http.post<any>(`${this.clientesUrl}/register`, cliente);
  }

  getClienteById(id: number): Observable<ICliente> {
    return this.http.get<ICliente>(`${this.clientesUrl}/${id}`).pipe(
     
      catchError(this.handleError)
    );
  }
  getCliente(nombreOToken:any): Observable<ICliente> {
    return this.http.get<ICliente>(`${this.clientesUrl}/${nombreOToken}`).pipe(
      catchError(this.handleError)
    );
  }

  updateCliente(id: number, cliente: ActualizarPerfilCliente): Observable<ICliente> {
    return this.http.put<ICliente>(`${this.clientesUrl}/${id}`, cliente).pipe(
      catchError(this.handleError)
    );
  }
  private handleError(err: HttpErrorResponse){
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
