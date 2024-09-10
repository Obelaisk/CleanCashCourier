export interface ITransaccion {
  id: number;
  idEnvia: number;
  idRecibe: number;
  cantidadEnvia: number;
  cantidadRecibe: number;
  fecha: string;
  monedaOrigen: string;   // Moneda de origen de la transacción
  monedaDestino: string;  // Moneda de destino de la transacción
  costeTransaccion: number; // Coste de la transacción (solo para transacciones enviadas)
}

export class Transaccion implements ITransaccion {
  id!: number;
  idEnvia!: number;
  idRecibe!: number;
  cantidadEnvia!: number;
  cantidadRecibe!: number;
  fecha!: string;
  monedaOrigen!: string;
  monedaDestino!: string;
  costeTransaccion!: number;
  ["constructor"](): void {
        
    }
}

export interface ITransaccionTabla {
  nombre: string;        // Nombre del usuario asociado a la transacción
  fecha: string;         // Fecha de la transacción
  monto: number;         // Monto de la transacción (depende de si es enviada o recibida)
  moneda: string;        // Moneda de la transacción (depende de si es enviada o recibida)
  costeTransaccion: number | null;  // Coste de la transacción (solo para transacciones enviadas)
  tipo: string;          // Tipo de transacción (enviada o recibida)
}

export class TransaccionTabla implements ITransaccionTabla {
  nombre!: string;
  fecha!: string;
  monto!: number;
  moneda!: string;
  costeTransaccion!: number | null;
  tipo!: string;

  ["constructor"](): void {

  }
}
