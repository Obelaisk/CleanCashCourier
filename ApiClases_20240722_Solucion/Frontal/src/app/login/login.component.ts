import { Component } from '@angular/core';
import { Usuario } from '../interfaces/usuario';
import { Router } from '@angular/router';
import { ClienteService } from '../servicios/cliente.service';
declare var bootstrap: any;

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  email: string = '';

  contrase: string = '';
  password: any;
  username: any;

  constructor(private clienteService: ClienteService, private route: Router) { }

  authentication() {
    this.clienteService.autenticarUsuario(this.email, this.contrase, true).subscribe(
      response => {
        if (response && response.token) {
        localStorage.setItem('token', response.token);
        this.route.navigate(['/welcome']); // Redirige a la ruta protegida
      } else {
        alert('Credenciales incorrectas');
        console.log(response);
      }
      },
      error => {
        if (error.status === 404) {
          //alert('No existe el usuario');
          this.showUserDoesntExistModal();
        } else if (error.status === 401) {
          this.showIncorrectPasswordModal();
          //alert('Contraseña incorrecta');
        } else if (error.status === 0) {
          alert('No se pudo conectar al servidor.');
        } else {
          console.error(`Error ${error.status}: ${error.message} --- ${error.error.message}`);
          alert('Error en el proceso de inicio de sesion: ' + error.message);
        }
      });
  }

  showUserDoesntExistModal() {
    const modalElement = document.getElementById('userNoExists');
    const modal = new bootstrap.Modal(modalElement);
    modal.show();
  }
  showIncorrectPasswordModal() {
    const modalElement = document.getElementById('incorrectPassword');
    const modal = new bootstrap.Modal(modalElement);
    modal.show();
  }
}
