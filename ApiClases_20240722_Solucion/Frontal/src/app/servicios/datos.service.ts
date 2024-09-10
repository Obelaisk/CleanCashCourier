import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class DatosService {
 
  constructor() { }

  getTrabajos(): string[] {
    return [
      'Desarrollador de Software', 'Ingeniero Civil', 'Diseñador Gráfico',
      'Médico', 'Abogado', 'Profesor', 'Contador', 'Consultor de Negocios',
      'Arquitecto', 'Marketing Digital','Otros'
    ];
  }
}
