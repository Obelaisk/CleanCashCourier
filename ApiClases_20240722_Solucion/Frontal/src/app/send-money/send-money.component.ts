/* send-money.component.ts */
import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from "rxjs";
import { ICliente } from "../interfaces/cliente";
import { ClienteService } from "../servicios/cliente.service";
import { TransaccionService } from "../servicios/transaccion.service";
import { ITransaccion, Transaccion } from "../interfaces/transaccion";
import { ActivatedRoute, Router } from '@angular/router';
import { PaisService } from '../servicios/pais.service';
import { CabeceraComponent } from '../cabecera/cabecera.component'
import { jwtDecode } from 'jwt-decode';
import { ContactoService } from '../servicios/contacto.service';
import { Contacto } from '../interfaces/contactos';
declare var bootstrap: any;

@Component({
  selector: 'pm-send-money',
  templateUrl: './send-money.component.html',
  styleUrls: ['./send-money.component.css']
})
export class SendMoneyComponent implements OnInit, OnDestroy {
  errorMessage: string = '';
  subcliente!: Subscription;
  subPais!: Subscription;
  subTransaccion!: Subscription;
  subListaContactos!: Subscription;
  modalMessage: string = '';
  transaccion!: Transaccion;
  identificadorClienteEnvia!: number;
  identificadorClienteRecibe!: number;

  nombreClienteRecibe: string = '';
  cantidadEnviada: string = '';
  cantidadRecibida: string = '';
  currencyEnviada: string = '';
  currencyRecibida: string = ''; // Moneda por defecto para recibir
  factorConversion: number = 1.1; // Factor de conversión estático, debería obtenerse dinámicamente
  tarifaTransferencia: number = 0.00;
  totalTransferencia: string = '0.00';
  private timeout: any;

  //listaContactos: Contacto[] = [];

  token: any;
  nombre!: string;
  constructor(private clienteService: ClienteService, private transaccionService: TransaccionService, private paisService: PaisService, private contactoService: ContactoService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.token = localStorage['token'];

    this.subcliente = this.clienteService.getCliente(this.token).subscribe({
      next: cliente => {
        this.identificadorClienteEnvia = cliente.id;
        this.subPais = this.paisService.getPaisId(cliente.paisId).subscribe({
          next: pais => {
            this.currencyEnviada = pais.iso3;
          },
          error: err => this.errorMessage = err
        });
      },
      error: err => this.errorMessage = err
    });
    this.route.queryParams.subscribe(params => {
      if (params['nombreClienteRecibe']) {
        this.nombreClienteRecibe = params['nombreClienteRecibe'];
        this.prueba();
      }
    });
    //this.subListaContactos = this.contactoService.getListaContactosPorToken(this.token).subscribe({
    //  next: contactos => {
    //    this.listaContactos = contactos
    //  },
    //  error: err => this.errorMessage = err
    //});


  }
  prueba(): void {
    if (this.timeout) {
      clearTimeout(this.timeout);
    }
    this.timeout = setTimeout(() => {
      if (this.nombreClienteRecibe != '') {

        this.contactoService.checkIfExists(this.token, this.nombreClienteRecibe).subscribe({
          next: next => {
            this.subcliente = this.clienteService.getCliente(this.nombreClienteRecibe).subscribe({
              next: cliente => {
                this.identificadorClienteRecibe = cliente.id;
                this.subTransaccion = this.paisService.getPaisId(cliente.paisId).subscribe({
                  next: pais => {
                    this.currencyRecibida = pais.iso3;
                    this.subTransaccion = this.transaccionService.hacerConversion(this.currencyEnviada, this.currencyRecibida).subscribe({
                      next: factor => {
                        this.factorConversion = factor;
                        this.cantidadRecibida = this.cantidadEnviada ? (parseInt(this.cantidadEnviada) * factor).toString() : '';
                      },
                      error: err => this.errorMessage = err
                    });
                  },
                  error: err => this.errorMessage = err
                });

              },
              error: err => {
                this.errorMessage = err;
                this.resetearVariables();
              }
            });
          },
          error: err => {
            this.errorMessage = err;
            this.resetearVariables();
          }
        });
      } else {
        this.resetearVariables();
      }
      clearTimeout(this.timeout);
    }, 1000);
  }
  ngOnDestroy(): void {
    this.subcliente.unsubscribe();
    this.subPais.unsubscribe();
    this.subTransaccion?.unsubscribe();
    this.subListaContactos?.unsubscribe();
  }

  validateAmount(event: Event, isEnviada: boolean) {
    const input = event.target as HTMLInputElement;
    let value = input.value;

    // Replace commas with periods and remove invalid characters
    value = value.replace(/,/g, '.').replace(/[^0-9.]/g, '');

    const parts = value.split('.');
    if (parts.length > 2) {
      value = parts[0] + '.' + parts.slice(1).join('');
    }

    if (value.startsWith('.')) {
      value = '0' + value;
    }

    // Limit to two decimal places
    if (parts.length > 1 && parts[1].length > 2) {
      value = `${parts[0]}.${parts[1].substring(0, 2)}`;
    }

    if (isEnviada) {
      this.cantidadEnviada = value;
      this.cantidadRecibida = value ? (parseFloat(value) * this.factorConversion).toFixed(2) : '';
    } else {
      this.cantidadRecibida = value;
      this.cantidadEnviada = value ? (parseFloat(value) / this.factorConversion).toFixed(2) : '';
    }
    this.tarifaTransferencia = parseFloat(this.calcularCosteAleatorio(1, 10));
    // Calcular el total de la transferencia
    this.totalTransferencia = (parseFloat(this.cantidadEnviada) + this.tarifaTransferencia).toFixed(2);

    input.value = value;
  }
  calcularCosteAleatorio(min: number, max: number) {
    return (Math.random() * (max - min) + min).toFixed();
  }

  crearTransaccion() {
    this.transaccion = new Transaccion();

    this.transaccion.cantidadEnvia = parseFloat(this.cantidadEnviada.replace(',', '.'));
    this.transaccion.cantidadRecibe = parseFloat(this.cantidadRecibida.replace(',', '.'));
    this.transaccion.idEnvia = this.identificadorClienteEnvia;
    this.transaccion.idRecibe = this.identificadorClienteRecibe === null ? 0 : this.identificadorClienteRecibe || 0;
    this.transaccion.fecha = new Date(Date.now()).toJSON();
    this.transaccion.monedaOrigen = this.currencyEnviada;
    this.transaccion.monedaDestino = this.currencyRecibida;
    this.transaccion.costeTransaccion = this.tarifaTransferencia;
  }

  sendMoney() {
    // Validación de coincidencia exacta del usuario
    if (this.identificadorClienteRecibe == 0) {
      this.showInvalidUserModal();
      return;
    }
    this.contactoService.checkIfExists(this.token, this.nombreClienteRecibe).subscribe({
      next: next => {
        //Continua sin problema
        if (this.identificadorClienteRecibe === this.identificadorClienteEnvia) {
          this.showInvalidUserModal();
          return;
        }

        const numericAmount = parseFloat(this.cantidadEnviada.replace(',', '.'));
        if (!this.cantidadEnviada || this.cantidadEnviada.trim().length === 0) {
          this.showInvalidAmountModal();
          return;
        } else if (numericAmount < 0.5) {
          this.showAmountTooLowModal();
          return;
        }

        this.crearTransaccion();
        this.transaccionService.crearTransaccion(this.transaccion).subscribe({
          next: (transaccion) => {
          },
          error: (err) => {
            console.error('Error creando la transacción: ', err);
          }
        });

        const user = this.nombreClienteRecibe === undefined ? 'unknown' : this.nombreClienteRecibe;
        this.modalMessage = `Enviando ${numericAmount.toFixed(2)} ${this.currencyEnviada} al destinatario ${user}.`;
        this.showModal();
      },
      error: err => {
        this.errorMessage = err;
        this.showNotAContactModal();
        return;
      }
    });


  }

  showInvalidUserModal() {
    const modalElement = document.getElementById('invalidUserModal');
    const modal = new bootstrap.Modal(modalElement);
    modal.show();
  }

  showNotAContactModal() {
    const modalElement = document.getElementById('notAContactModal');
    const modal = new bootstrap.Modal(modalElement);
    modal.show();
  }

  showInvalidAmountModal() {
    const modalElement = document.getElementById('invalidAmountModal');
    const modal = new bootstrap.Modal(modalElement);
    modal.show();
  }

  showAmountTooLowModal() {
    const modalElement = document.getElementById('amountTooLowModal');
    const modal = new bootstrap.Modal(modalElement);
    modal.show();
  }

  showModal() {
    const modalElement = document.getElementById('transactionModal');
    const modal = new bootstrap.Modal(modalElement);
    modal.show();
  }

  navegarATransacciones() {
    this.router.navigate(['/transaction-history']);
  }

  resetearVariables() {
    this.currencyRecibida = '';
    this.factorConversion = 0;
    this.identificadorClienteRecibe = 0;
    this.cantidadRecibida = '';
  }
}
