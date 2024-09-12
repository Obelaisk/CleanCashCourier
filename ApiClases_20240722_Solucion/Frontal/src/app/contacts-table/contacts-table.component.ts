import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { ContactoService } from '../servicios/contacto.service';
import { Contacto } from '../interfaces/contactos';
import { switchMap } from 'rxjs';
import { Router } from '@angular/router';
declare var bootstrap: any;

@Component({
  selector: 'pm-contacts-table',
  templateUrl: './contacts-table.component.html',
  styleUrls: ['./contacts-table.component.css']
})
export class ContactsTableComponent implements OnInit {
  contacts: Contacto[] = [];
  nombreNuevoContacto: string = '';

  constructor(
    private contactService: ContactoService,
    private cdr: ChangeDetectorRef,
    private router: Router
  ) { }

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
        console.error('Error al eliminar el contacto', error);
      }
    );
  }

  aniadirContacto(): void {
    // Verificar si el campo está vacío
    if (this.nombreNuevoContacto.trim() === '') {
      this.showInvalidContactModal();
      return;
    }

    // Hacer la llamada al servicio para añadir el contacto
    this.contactService.aniadirContacto(this.nombreNuevoContacto.trim(), localStorage['token']).subscribe(
      () => {
        this.contactService.getListaContactosPorToken(localStorage['token']).subscribe(
          (data: Contacto[]) => {
            this.contacts = data;
          },
          (error) => {
            console.error('Error al obtener los contactos después de añadir', error);
          }
        );
      },
      (error) => {
        if (error.status === 400) {
          const errorMessage = error.error.Message;
          if (errorMessage === "Not yourself.") {
            this.showSelfAdditionModal();
          } else {
            this.showExistingContactModal();
          }
        } else {
          console.error('Error al añadir el contacto', error);
          this.showInvalidContactModal();
        }
      }
    );
  }


  enviarDinero(contacto: Contacto): void {
    this.router.navigate(['/send-money'], {
      queryParams: { nombreClienteRecibe: contacto.nombreUsuarioContacto }
    });
  }

  showInvalidContactModal() {
    const modalElement = document.getElementById('invalidContactModal');
    const modal = new bootstrap.Modal(modalElement);
    modal.show();
  }

  showSelfAdditionModal() {
    const modalElement = document.getElementById('selfAdditionModal');
    const modal = new bootstrap.Modal(modalElement);
    modal.show();
  }

  showExistingContactModal() {
    const modalElement = document.getElementById('existingContactModal');
    const modal = new bootstrap.Modal(modalElement);
    modal.show();
  }
}
