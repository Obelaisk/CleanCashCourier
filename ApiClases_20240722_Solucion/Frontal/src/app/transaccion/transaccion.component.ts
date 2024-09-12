import { Component, OnDestroy, OnInit } from '@angular/core';
import { TransaccionService } from '../servicios/transaccion.service';
import { Transaccion, TransaccionTabla } from '../interfaces/transaccion';
import { ClienteService } from '../servicios/cliente.service';
import { format } from 'date-fns';
import { Subscription } from 'rxjs';

@Component({
  selector: 'pm-transaccion',
  templateUrl: './transaccion.component.html',
  styleUrls: ['./transaccion.component.css']
})
export class TransaccionComponent implements OnInit, OnDestroy {
  transacciones: Transaccion[] = [];
  transaccionesTabla: TransaccionTabla[] = [];
  fechaInicio: string | null = null;
  fechaFin: string | null = null;
  cantidadMin: number | null = null;
  cantidadMax: number | null = null;

  subcliente!: Subscription;
  subTransaccion!: Subscription;
  identificaciorCliente!: number;
  errorMessage: string = '';
  token!: string;

  constructor(private transaccionService: TransaccionService, private clienteService: ClienteService) { }

  ngOnInit(): void {
    this.token = localStorage['token'];

    this.subcliente = this.clienteService.getCliente(this.token).subscribe({
      next: cliente => {
        this.identificaciorCliente = cliente.id;
        this.subTransaccion = this.transaccionService.getTransacciones(this.identificaciorCliente).subscribe(
          async (data: Transaccion[]) => {
            this.transacciones = data;
            await Promise.all(this.transacciones.map(async (transaccion) => {
              const transaccionTabla = new TransaccionTabla();
              transaccionTabla.nombre = await this.obtenerIdUsuario(transaccion);
              transaccionTabla.monto = this.obtenerMonto(transaccion); // Calcula el monto
              transaccionTabla.moneda = this.obtenerMoneda(transaccion); // Calcula la moneda
              transaccionTabla.costeTransaccion = this.obtenerCosteTransaccion(transaccion); // Calcula el coste de transacción
              transaccionTabla.fecha = this.obtenerFecha(transaccion);
              transaccionTabla.tipo = this.obtenerTipoTransaccion(transaccion);
              this.transaccionesTabla.push(transaccionTabla);
            }));
          },
          error => console.error(error)
        );
      },
      error: err => this.errorMessage = err
    });
  }

  ngOnDestroy(): void {
    this.subcliente?.unsubscribe();
    this.subTransaccion?.unsubscribe();
  }

  obtenerIdUsuario(transaccion: Transaccion): Promise<string> {
    const clienteIdAux = transaccion.idRecibe === this.identificaciorCliente ? transaccion.idEnvia : transaccion.idRecibe;
    return new Promise((resolve, reject) => {
      this.subcliente = this.clienteService.getClienteById(clienteIdAux).subscribe({
        next: cliente => {
          resolve(cliente.usuario);
        },
        error: err => {
          this.errorMessage = err;
          reject('Desconocido');
        }
      });
    });
  }

  obtenerMonto(transaccion: Transaccion): number {
    // Si la transacción fue enviada, el monto es la cantidad enviada, si fue recibida, es la cantidad recibida
    return transaccion.idEnvia === this.identificaciorCliente ? transaccion.cantidadEnvia : transaccion.cantidadRecibe;
  }

  obtenerMoneda(transaccion: Transaccion): string {
    // Si la transacción fue enviada, la moneda es la moneda de origen, si fue recibida, es la moneda de destino
    return transaccion.idEnvia === this.identificaciorCliente ? transaccion.monedaOrigen : transaccion.monedaDestino;
  }

  obtenerCosteTransaccion(transaccion: Transaccion): number | null {
    // Solo devuelve el coste de la transacción si fue enviada, de lo contrario no aplica
    return transaccion.idEnvia === this.identificaciorCliente ? transaccion.costeTransaccion : null;
  }

  obtenerFecha(transaccion: Transaccion): string {
    return format(new Date(transaccion.fecha), 'dd/MM/yyyy');
  }

  obtenerTipoTransaccion(transaccion: Transaccion): string {
    return transaccion.idEnvia === this.identificaciorCliente ? 'Enviada' : 'Recibida';
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
    this.subTransaccion = this.transaccionService.getTransaccionesFiltradas({
      fechaInicio: this.fechaInicio,
      fechaFin: this.fechaFin,
      cantidadMin: this.cantidadMin,
      cantidadMax: this.cantidadMax
    }, this.identificaciorCliente).subscribe(
      async (data: Transaccion[]) => {
        this.transaccionesTabla = [];
        await Promise.all(data.map(async (transaccion) => {
          const transaccionTabla = new TransaccionTabla();
          transaccionTabla.nombre = await this.obtenerIdUsuario(transaccion);
          transaccionTabla.monto = this.obtenerMonto(transaccion);
          transaccionTabla.moneda = this.obtenerMoneda(transaccion);
          transaccionTabla.costeTransaccion = this.obtenerCosteTransaccion(transaccion);
          transaccionTabla.fecha = this.obtenerFecha(transaccion);
          transaccionTabla.tipo = this.obtenerTipoTransaccion(transaccion);
          this.transaccionesTabla.push(transaccionTabla);
        }));
      },
      error => console.error(error)
    );
  }

  evitarCaracteresNoPermitidos(event: KeyboardEvent): void {
    // Evitar el ingreso del signo "-" y la "e" (para evitar notación científica)
    if (event.key === '-' || event.key === 'e') {
      event.preventDefault();  // Bloquear el evento si intenta escribir "-" o "e"
    }
  }

  validarCantidad(event: any, tipo: string): void {
    const input = event.target;
    let valor = input.value;

    // Validar si hay más de un punto decimal
    const partes = valor.split('.');
    if (partes.length > 1 && partes[1].length > 2) {
      // Limitar a dos decimales
      valor = `${partes[0]}.${partes[1].substring(0, 2)}`;
      input.value = valor;
    }

    // Validar que el valor no sea negativo
    const numero = parseFloat(valor);
    if (numero < 0) {
      input.value = '';
      return;
    }

    // Actualizar los valores de cantidad mínima o máxima
    if (tipo === 'min') {
      this.cantidadMin = numero;
    } else if (tipo === 'max') {
      this.cantidadMax = numero;
    }
  }
}
