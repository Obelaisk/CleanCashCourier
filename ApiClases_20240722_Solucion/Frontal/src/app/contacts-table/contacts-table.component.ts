import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { ContactoService } from '../servicios/contacto.service';
import { Contacto } from '../interfaces/contactos';
import { switchMap } from 'rxjs';
import { Router } from '@angular/router';

@Component({
  selector: 'pm-contacts-table',
  templateUrl: './contacts-table.component.html',
  styleUrl: './contacts-table.component.css'
})
export class ContactsTableComponent implements OnInit {
  contacts: Contacto[] = [];
  nombreNuevoContacto: string = '';

  constructor(private contactService: ContactoService, private cdr: ChangeDetectorRef, private router: Router) { }

  ngOnInit(): void {
    this.contactService.getListaContactosPorToken(localStorage['token']).subscribe(
      (data: Contacto[]) => {
        this.contacts = data;
      },
      (error) => {
        console.error('Error al obtener los contactos', error);
      }
    );
  }
  deleteContact(nombre: string): void {
    this.contactService.eliminarContacto(nombre, localStorage['token']).pipe(
      switchMap(() => this.contactService.getListaContactosPorToken(localStorage['token']))
    ).subscribe(
      (data: Contacto[]) => {
        this.contacts = data;
        this.cdr.detectChanges(); // Forzar la detección de cambios
      },
      (error) => {
        console.error('Error al obtener los contactos', error);
      }
    );
  }
  aniadirContacto(): void  {
    this.contactService.aniadirContacto(this.nombreNuevoContacto.trim(), localStorage['token']).pipe(
      switchMap(() => this.contactService.getListaContactosPorToken(localStorage['token']))
    ).subscribe(
      (data: Contacto[]) => {
        this.contacts = data;
        this.cdr.detectChanges(); // Forzar la detección de cambios
      },
      (error) => {
        console.error('Error al obtener los contactos', error);
      }
    );

  }
  enviarDinero(contacto: Contacto): void {
    this.router.navigate(['/send-money'], {
      queryParams: { nombreClienteRecibe: contacto.nombreUsuarioContacto }
    });
  }
}


