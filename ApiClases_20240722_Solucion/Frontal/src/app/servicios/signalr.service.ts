import { Injectable } from '@angular/core';
import * as signalR from '@microsoft/signalr';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class SignalrService {
  private hubConnection: signalR.HubConnection;

  constructor() {
    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl(environment.apiHub, {
        withCredentials: true  // Permitir envío de credenciales (cookies, encabezados de autenticación, etc.)
      })
      .build();
  }

  public startConnection(): void {
    this.hubConnection
      .start()
      .then(() => console.log('SignalR Connected'))
      .catch((err) => console.error('Error al conectar con SignalR:', err));
  }

  public addListener(): void {
    this.hubConnection.on('newtransaction', (message) => {
      console.log('Nueva transaccion:', message);
    });
    this.hubConnection.on('newlogin', (message) => {
      console.log('Nuevo inicio de sesion:', message);
    });
    this.hubConnection.on('newregister', (message) => {
      console.log('Nuevo registro:', message);
    });
  }
  public stopConnection = () => {
    if (this.hubConnection) {
      this.hubConnection
        .stop()
        .then(() => console.log('Conexión detenida'))
        .catch(err => console.log('Error al detener la conexión: ', err));
    }
  };
}
