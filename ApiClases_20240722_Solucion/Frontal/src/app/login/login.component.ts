import { Component } from '@angular/core';
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

  ngOnInit() {
    const togglePassword = document.querySelector('#togglePassword');
    const passwordInput = document.querySelector('#passwordInput');

    if (togglePassword && passwordInput) {
      togglePassword.addEventListener('click', () => {
        const type = passwordInput.getAttribute('type') === 'password' ? 'text' : 'password';
        passwordInput.setAttribute('type', type);
        togglePassword.classList.toggle('fa-eye-slash');
      });
    }
  }


  authentication() {
    this.clienteService.autenticarUsuario(this.obtenerPrimeraParte(this.email), this.contrase, true).subscribe(
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
          this.showModal();
        } else if (error.status === 401) {
          this.showModal();
        } else if (error.status === 0) {
          alert('No se pudo conectar al servidor.');
        } else {
          console.error(`Error ${error.status}: ${error.message} --- ${error.error.message}`);
          alert('Error en el proceso de inicio de sesion: ' + error.message);
        }
      });
  }

  showModal() {
    const modalElement = document.getElementById('modal');
    const modal = new bootstrap.Modal(modalElement);
    modal.show();
  }

  obtenerPrimeraParte(cadena:string) :string{
    if (cadena.includes('@')) {
      return cadena.split('@')[0];
    }
    return cadena;
  }
}
