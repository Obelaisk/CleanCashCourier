import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CabeceraComponent } from '../cabecera/cabecera.component'
import jwt from 'jsonwebtoken';
import { jwtDecode } from "jwt-decode";
import { DataService } from '../servicios/data.service';
@Component({
  selector: 'welcome-component',
  templateUrl: './welcome-component.component.html',
  styleUrl: './welcome-component.component.css'
})
export class WelcomeComponentComponent implements OnInit {
  paisesConClientes: number | undefined;
  transaccionesUltimos10Anios: number | undefined;
  token: any;
  constructor(private router: Router, private dataService: DataService) { }
  ngOnInit(): void {
    // Llamar a los servicios para obtener los datos
    this.dataService.getPaisesConClientes().subscribe({
      next: (data) => this.paisesConClientes = data,
      error: (err) => console.error('Error obteniendo países:', err)
    });

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
}
