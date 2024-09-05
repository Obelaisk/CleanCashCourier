import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class DataService {
  //private apiBaseUrl = 'https://localhost:7138/api';
  private apiBaseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  // Obtener el número de países con clientes
  getPaisesConClientes(): Observable<number> {
    return this.http.get<number>(`${this.apiBaseUrl}/ContarPaisesConClientes`);
  }

  // Obtener el número de transacciones en los últimos 10 años
  getTransaccionesUltimos10Anios(): Observable<number> {
    return this.http.get<number>(`${this.apiBaseUrl}/ContarTransaccionesUltimos10Anios`);
  }
}
