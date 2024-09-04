
export interface FiltroParametrosVistaContacto {
  IdCliente: number;
  NombreUsuarioContacto: string | null;
  Pais: string | null;
  NumeroPaginas: number;
  TamanoPagina: number;
}

export interface Contacto {

  constructor(): void;
  idCliente: number;
  nombreUsuarioContacto: string;
  pais: string;
}
