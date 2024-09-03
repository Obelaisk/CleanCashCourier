import { Component } from '@angular/core';
import { Usuario } from '../interfaces/usuario';
import { Router } from '@angular/router';
import { ClienteService } from '../servicios/cliente.service';

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
    this.clienteService.autenticarUsuario(this.email, this.contrase, true).subscribe(response => {
      if (response && response.token) {
        localStorage.setItem('token', response.token);
        //alert("funciona");
        this.route.navigate(['/welcome']); // Redirige a la ruta protegida
      } else {
        alert('Credenciales incorrectas');
      }
    });
  }
  
  
}
