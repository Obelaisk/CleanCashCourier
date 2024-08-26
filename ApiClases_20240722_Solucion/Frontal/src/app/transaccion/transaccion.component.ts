import { Component, OnInit } from '@angular/core';
import { TransaccionService } from './transaccion.service';
import { Transaccion } from './transaccion';
import { ICliente } from '../clientes/cliente';
import { ClienteService } from '../clientes/cliente.service';
import { format } from 'date-fns';
import {CabeceraComponent } from '../cabecera/cabecera.component'

@Component({
  selector: 'pm-transaccion',
  templateUrl: './transaccion.component.html',
  styleUrls: ['./transaccion.component.css']
})
export class TransaccionComponent implements OnInit {
  transacciones: Transaccion[] = [];

  fechaInicio: string | null = null;
  fechaFin: string | null = null;
  cantidadMin: number | null = null;
  cantidadMax: number | null = null;

  constructor(private transaccionService: TransaccionService, private clienteService: ClienteService) { }


  clientes: ICliente[] = [];

  clienteId: number = 6;

  errorMessage: string = '';

  ngOnInit(): void {
    this.obtenerTransacciones();
    this.obtenerClientes();
    this.filtrarTransacciones();
  }
  obtenerClientes(): void {
    this.clienteService.getClientes().subscribe({
      next: clientes => {
        this.clientes = clientes;
      },
      error: err => this.errorMessage = err
    });
  }

  obtenerTransacciones(): void {
    this.transaccionService.getTransacciones(this.clienteId).subscribe(
      (data: Transaccion[]) => this.transacciones = data,
      error => console.error(error)
    );
  }

  obtenerIdUsuario(transaccion: Transaccion): string {
    // Si la transacción es recibida (idRecibe es 1), muestra el idEnvia, de lo contrario, muestra idRecibe
    var clienteIdAux = transaccion.idRecibe === this.clienteId ? transaccion.idEnvia : transaccion.idRecibe;
    const cliente = this.clientes.find(c => c.id === clienteIdAux);
    if (cliente) {
      const usuario = cliente.usuario;
      return usuario;
    } else {
      return 'Unknown';
    }
    //return clienteIdAux;
    //return transaccion.idRecibe === 1 ? transaccion.idEnvia : transaccion.idRecibe;
  }

  obtenerCantidad(transaccion: Transaccion): number {
    return transaccion.idEnvia === 1 ? transaccion.cantidadEnvia : transaccion.cantidadRecibe;
  }

  obtenerTipoTransaccion(transaccion: Transaccion): string {
    return transaccion.idEnvia === this.clienteId ? 'Enviada' : 'Recibida';
  }

  obtenerFecha(transaccion: Transaccion): string {
    return format(new Date(transaccion.fecha), 'dd/MM/yyyy');
  }

  actualizarFechaInicio(event: any): void {
    this.fechaInicio = event.target.value || null;
  }

  actualizarFechaFin(event: any): void {
    this.fechaFin = event.target.value || null;
  }

  actualizarCantidadMin(event: any): void {
    this.cantidadMin = event.target.value ? parseFloat(event.target.value) : null;
  }

  actualizarCantidadMax(event: any): void {
    this.cantidadMax = event.target.value ? parseFloat(event.target.value) : null;
  }

  borrarCantidadMin(): void {
    this.cantidadMin = null;
    const cantidadMinElement = document.getElementById('cantidadMin') as HTMLInputElement;
    if (cantidadMinElement) {
      cantidadMinElement.value = '';
    }
  }

  borrarCantidadMax(): void {
    this.cantidadMax = null;
    const cantidadMaxElement = document.getElementById('cantidadMax') as HTMLInputElement;
    if (cantidadMaxElement) {
      cantidadMaxElement.value = '';
    }
  }

  filtrarTransacciones(): void {
    // Aquí puedes construir los parámetros de la consulta con base en los filtros aplicados.
    // Luego, realiza la llamada al servicio para obtener las transacciones filtradas.
    // Por ejemplo:
    this.transaccionService.getTransaccionesFiltradas({
      fechaInicio: this.fechaInicio,
      fechaFin: this.fechaFin,
      cantidadMin: this.cantidadMin,
      cantidadMax: this.cantidadMax
    },this.clienteId).subscribe(
      (data: Transaccion[]) => this.transacciones = data,
      error => console.error(error)
    );
  }
}
