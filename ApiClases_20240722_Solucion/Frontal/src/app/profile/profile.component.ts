import { Component, ElementRef, OnInit, QueryList, ViewChild, ViewChildren } from '@angular/core';
import { ClienteService } from "../servicios/cliente.service";
import { ICliente } from "../interfaces/cliente";
import { DatosService } from "../servicios/datos.service";
import { IPais, PaisService } from '../servicios/pais.service';
import { Subscription } from 'rxjs';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CabeceraComponent } from '../cabecera/cabecera.component';
import { jwtDecode }  from 'jwt-decode';
import { ActualizarPerfilCliente } from '../interfaces/registroCliente';

@Component({
  selector: 'pm-profile-component',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})


export class ProfileComponent implements OnInit {

  @ViewChild('dropdownMenuPais') dropdownMenu!: ElementRef;
  @ViewChildren('paisItem') paisItems!: QueryList<ElementRef>;

  @ViewChild('dropdownMenuEmpleo') dropdownMenuEmpleos!: ElementRef;
  @ViewChildren('empleoItem') empleoItems!: QueryList<ElementRef>;
  errorMessage: string = '';
  perfilForm!: FormGroup;

  cliente!: ICliente;
  isEditing = {
    usuario: false,
    pais: false,
    trabajo: false
  };
  
  trabajos: string[] = [];
  subPaises!: Subscription;
  subClientes!: Subscription;
  isDropdownPaisesVisible: boolean = false;
  isDropdownEmpleosVisible: boolean = false;
  paises: IPais[] = [];
  paisesFiltrado: IPais[] = [];
  paisSeleccionado: number = -1;
  empleos: string[] = [];
  empleosFiltrados: string[] = [];
  token!: string;
  nombre!: string;

  isLoading: boolean = true;
  constructor(private fb: FormBuilder, private clienteService: ClienteService,private paisService:PaisService, private datosService: DatosService) { }
  showDropdownPais() {
    this.isDropdownPaisesVisible = true;
  }

  hideDropdownPais() {
    this.isDropdownPaisesVisible = false;
  }
  showDropdownEmpleo() {
    this.isDropdownEmpleosVisible = true;
  }

  hideDropdownEmpleo() {
    this.isDropdownEmpleosVisible = false;
  }
  ngOnInit(): void {
    this.token = localStorage['token'];

    this.subClientes = this.clienteService.getCliente(this.token).subscribe({
      next: (data) => {
        this.cliente = data;
        this.isLoading = false;
        this.perfilForm = this.fb.group({
          Nombre: [this.cliente.nombre, [Validators.required, Validators.minLength(3)]],
          Apellido: [this.cliente.apellido, [Validators.required, Validators.minLength(3)]],
          Correo: [this.cliente.email, [Validators.required, Validators.email]],
          Contraseña: ['', [Validators.required, Validators.minLength(6)]],
          Contraseña2: ['', [Validators.required]],
          Rol: ['Client', Validators.required],
          PaisNombre: [this.cliente.nombrePais, Validators.required], // Mostrar el país actual
          Empleo: [this.cliente.trabajo], // Mostrar el empleo actual
          FechaNac: [this.cliente.fechaNacimiento, Validators.required]
        });
      },
      error: (err) => {
        console.error(err);
        this.isLoading = false;
      }
    });

    this.subPaises = this.paisService.getPaises().subscribe({
      next: (paises) => {
        this.paises = paises;
        this.paisesFiltrado = paises;
      },
      error: (err) => (this.errorMessage = err),
    });

    this.empleos = this.datosService.getTrabajos();
    this.empleosFiltrados = this.datosService.getTrabajos();
  }


  enableEdit(field: keyof ICliente): void {
    if (field in this.isEditing) {
      this.isEditing[field as keyof typeof this.isEditing] = true;
    }
  }

  disableEdit(field: keyof ICliente): void {
    if (field in this.isEditing) {
      this.isEditing[field as keyof typeof this.isEditing] = false;
    }
  }
  onSubmit(): void {

    const clieteActualizar: ActualizarPerfilCliente = {
      Nombre: this.perfilForm.value.Nombre,
      Apellido: this.perfilForm.value.Apellido,
      Email: this.perfilForm.value.Correo,
      Contrasena: this.perfilForm.value.Contraseña,
      PaisId: this.paisSeleccionado,
      Empleo: this.perfilForm.value.Empleo,
      NombrePais: this.perfilForm.value.PaisNombre,
      FechaNacimiento: new Date(this.perfilForm.value.FechaNac),
      Id: this.cliente.id

    }

    this.clienteService.updateCliente(this.cliente.id, clieteActualizar).subscribe({
        next: (data) => {
          //this.cliente = data;
          alert('Cambios guardados exitosamente.');
        },
        error: (err) => console.error(err)
      });
    
  }
  selectPais(paisNombre: string) {
    this.perfilForm.patchValue({ PaisNombre: paisNombre })

    var resultado = this.paises.find(pais => pais.nombre === paisNombre)?.id;
    if (resultado != undefined) {
      this.paisSeleccionado = resultado;
      this.hideDropdownPais();
    }
  }
  selectEmpleo(empleoNombre: string) {
    this.perfilForm.patchValue({ Empleo: empleoNombre });
    this.hideDropdownEmpleo();
  }

  filterPaises(event: Event) {
    const query = (event.target as HTMLInputElement).value.toLowerCase();
    this.paisesFiltrado = this.paises.filter(pais =>
      pais.nombre.toLowerCase().startsWith(query)
    );

    if (this.paisesFiltrado.length > 0) {
      setTimeout(() => {
        const firstMatch = this.paisItems.first;
        if (firstMatch) {
          firstMatch.nativeElement.scrollIntoView({ behavior: 'smooth', block: 'nearest' });
        }
      }, 0);
    }

  }

  filterEmpleos(event: Event) {
    const query = (event.target as HTMLInputElement).value.toLowerCase();
    this.empleosFiltrados = this.empleos.filter(empleo =>
      empleo.toLowerCase().startsWith(query)
    );

    if (this.empleosFiltrados.length > 0) {
      setTimeout(() => {
        const firstMatch = this.empleoItems.first;
        if (firstMatch) {
          firstMatch.nativeElement.scrollIntoView({ behavior: 'smooth', block: 'nearest' });
        }
      }, 0);
    }
  }
}
