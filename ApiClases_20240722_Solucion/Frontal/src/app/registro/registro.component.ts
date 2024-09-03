import { Component, ElementRef, OnInit, QueryList, ViewChild, ViewChildren } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { RegistroCliente } from '../interfaces/registroCliente';
import { Router } from '@angular/router';
import { IPais, PaisService } from '../servicios/pais.service';
import { ClienteService } from '../servicios/cliente.service';

@Component({
  selector: 'app-registro',
  templateUrl: './registro.component.html',
  styleUrls: ['./registro.component.css']
})
export class RegistroComponent implements OnInit {
  @ViewChild('dropdownMenu') dropdownMenu!: ElementRef;
  @ViewChildren('paisItem') paisItems!: QueryList<ElementRef>;

  registroForm!: FormGroup;
  errorMessage: string | null = null; // Mensaje de error general
  paises: IPais[] = [];
  paisesFiltrado: IPais[] = [];
  paisSeleccionado: number = -1;
  isDropdownVisible = false;



  constructor(private fb: FormBuilder, private clienteService: ClienteService, private paisService: PaisService, private router: Router) { }
  showDropdown() {
    this.isDropdownVisible = true;
  }

  hideDropdown() {
    this.isDropdownVisible = false;
  }
  ngOnInit(): void {
    this.paisSeleccionado = 1;
    this.registroForm = this.fb.group({
      Nombre: ['', [Validators.required, Validators.minLength(3)]],
      Apellido: ['', [Validators.required, Validators.minLength(3)]],
      Correo: ['', [Validators.required, Validators.email]],
      Contraseña: ['', [Validators.required, Validators.minLength(6)]],
      Contraseña2: ['', [Validators.required]],
      Rol: ['Client', Validators.required],
      PaisNombre: ['', Validators.required],
      Empleo: [''],
      FechaNac: ['', Validators.required]
    }, {
      validator: this.passwordMatchValidator('Contraseña', 'Contraseña2')
    });
    this.paisService.getPaises().subscribe({
      next: paises => {
        this.paises = paises;
        this.paisesFiltrado = paises;
      },
      error: err => this.errorMessage = err
    });
  }

  passwordMatchValidator(password: string, confirmPassword: string) {
    return (formGroup: FormGroup) => {
      const passwordControl = formGroup.get(password);
      const confirmPasswordControl = formGroup.get(confirmPassword);

      if (confirmPasswordControl?.errors && !confirmPasswordControl.errors['passwordMismatch']) {
        return;
      }

      if (passwordControl?.value !== confirmPasswordControl?.value) {
        confirmPasswordControl?.setErrors({ passwordMismatch: true });
      } else {
        confirmPasswordControl?.setErrors(null);
      }
    };
  }

  onSubmit(): void {
    if (this.registroForm.invalid) {
      this.showValidationErrors();
      return;
    }

    if (this.registroForm.value.Contraseña !== this.registroForm.value.Contraseña2) {
      alert('Las contraseñas no coinciden.');
      return;
    }

    const fechaNac = new Date(this.registroForm.value.FechaNac);

    this.paisSeleccionado = this.paises.find(pais => pais.id === this.paisSeleccionado) == undefined ? -1 : this.paisSeleccionado;
    const clienteRegistro: RegistroCliente = {
      Nombre: this.registroForm.value.Nombre,
      Apellido: this.registroForm.value.Apellido,
      Email: this.registroForm.value.Correo,
      Contrasena: this.registroForm.value.Contraseña,
      PaisId: this.paisSeleccionado,
      Empleo: this.registroForm.value.Empleo,
      NombrePais: this.registroForm.value.PaisNombre,

      FechaNacimiento: fechaNac
    }


    this.clienteService.registrarCliente(clienteRegistro).subscribe(
      next => {
       
        this.router.navigate(['/login']);

      },
      error => {
        if (error.status === 400) {
          console.error('Error de validación', error);
          alert('Error al registrar usuario: ' + error.error);
        } else if (error.status === 0) {
          console.error('No se pudo conectar al servidor.');
          alert('No se pudo conectar al servidor.');
        } else {
          console.error(`Error ${error.status}: ${error.message}`);
          alert('Error al registrar usuario: ' + error.message);
        }
      },
      
    );
  }

  private showValidationErrors(): void {
    let errorMessage = 'Por favor corrige los siguientes errores:\n';
    const controls = this.registroForm.controls;

    for (const key in controls) {
      if (controls.hasOwnProperty(key)) {
        const control = controls[key];
        if (control.invalid) {
          if (control.errors) {
            if (control.errors['required']) {
              errorMessage += `- El campo ${key} es requerido.\n`;
            }
            if (control.errors['minlength']) {
              errorMessage += `- El campo ${key} debe tener al menos ${control.errors['minlength'].requiredLength} caracteres.\n`;
            }
            if (control.errors['email']) {
              errorMessage += `- El campo ${key} debe ser un email válido.\n`;
            }
            if (control.errors['passwordMismatch']) {
              errorMessage += `- Las contraseñas no coinciden.\n`;
            }
          }
        }
      }
    }

    if (errorMessage === 'Por favor corrige los siguientes errores:\n') {
      errorMessage = 'Hay errores en el formulario. Por favor, corrígelos antes de enviar.';
    }

    alert(errorMessage);
  }

  

  selectPais(paisNombre: string) {
    this.registroForm.patchValue({ PaisNombre: paisNombre })

    var resultado = this.paises.find(pais => pais.nombre === paisNombre)?.id;
    if (resultado != undefined) {
      this.paisSeleccionado = resultado;
      this.hideDropdown();
    }
  }




  filterPaises(event: Event) {
    const query = (event.target as HTMLInputElement).value;
    this.paisesFiltrado = this.paises.filter(pais =>
      pais.nombre.toLowerCase().startsWith(query.toLowerCase())
    );

    if (this.paisesFiltrado.length == 1) { // Para que, al autorrellenar 
      setTimeout(() => {
        if (query === this.paisesFiltrado[0].nombre) {
          this.hideDropdown();
        }
      }, 0);
    }
    else if (this.paisesFiltrado.length > 1) {
      setTimeout(() => {
        const firstMatch = this.paisItems.first;
        if (firstMatch) {
          firstMatch.nativeElement.scrollIntoView({ behavior: 'smooth', block: 'nearest' });
        }
      }, 0);
    }
  }
}
