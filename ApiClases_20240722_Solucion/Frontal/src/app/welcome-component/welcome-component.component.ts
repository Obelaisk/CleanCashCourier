import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CabeceraComponent } from '../cabecera/cabecera.component'
import jwt from 'jsonwebtoken';
import { jwtDecode } from "jwt-decode";
import { DataService } from '../servicios/data.service';
import { SignalrService } from '../servicios/signalr.service';
import * as signalR from "@microsoft/signalr";
import { environment } from '../../environments/environment';
@Component({
  selector: 'welcome-component',
  templateUrl: './welcome-component.component.html',
  styleUrl: './welcome-component.component.css'
})
export class WelcomeComponentComponent implements OnInit {
  paisesConClientes: number | undefined;
  transaccionesUltimos10Anios: number | undefined;
  token: any;
  constructor(private router: Router, private dataService: DataService, private signalrService: SignalrService) { }
  ngOnInit(): void {
    // Llamar a los servicios para obtener los datos
    this.dataService.getPaisesConClientes().subscribe({
      next: (data) => this.paisesConClientes = data,
      error: (err) => console.error('Error obteniendo países:', err)
    });
    this.signalrService.startConnection(); // Iniciar conexión
    this.signalrService.addListener();

    this.dataService.getTransaccionesUltimos10Anios().subscribe({
      next: (data) => this.transaccionesUltimos10Anios = data,
      error: (err) => console.error('Error obteniendo transacciones:', err)
    });
  }

  navegarAEnvioDinero() {
    this.router.navigate(['/send-money'])
  }

  navegarARegistro() {
    this.router.navigate(['/registro'])
  }

  ngOnDestroy(): void {
    this.signalrService.stopConnection();
  }
}
