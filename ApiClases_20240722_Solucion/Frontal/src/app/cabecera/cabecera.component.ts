import { Component, ViewEncapsulation } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'cabecera',
  templateUrl: './cabecera.component.html',
  styleUrl: './cabecera.component.css',
  encapsulation: ViewEncapsulation.None
})
export class CabeceraComponent {
  constructor(private router: Router) { }

  cerrarSesion() {

    localStorage.removeItem('token');

  }
}
