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
declare var bootstrap: any;
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
    this.subPaises = this.paisService.getPaises().subscribe({
      next: (paises) => {
        this.paises = paises;
   
        this.subClientes = this.clienteService.getCliente(this.token).subscribe({
          next: (data) => {
            this.cliente = data;
            this.isLoading = false;
            this.perfilForm = this.fb.group({
              Nombre: [this.cliente.nombre, [Validators.required, Validators.minLength(3)]],
              Apellido: [this.cliente.apellido, [Validators.required, Validators.minLength(3)]],
              Correo: [this.cliente.email, [Validators.required, Validators.email]],
              PaisNombre: [this.selectPaisById(this.cliente.paisId), Validators.required], // Mostrar el país actual
              Empleo: [this.cliente.empleo], // Mostrar el empleo actual
              FechaNac: [this.cliente.fechaNacimiento, Validators.required]
            });
          },
          error: (err) => {
            console.error(err);
            this.isLoading = false;
          }
        });
      },
      error: (err) => (this.errorMessage = err),
    });
    this.empleos = this.datosService.getTrabajos();
    
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
      PaisId: this.selectPais(this.perfilForm.value.PaisNombre),
      Empleo: this.perfilForm.value.Empleo,
      NombrePais: this.perfilForm.value.PaisNombre,
      FechaNacimiento: new Date(this.perfilForm.value.FechaNac),
      Id: this.cliente.id

    }

    this.clienteService.updateCliente(this.cliente.id, clieteActualizar).subscribe({
      next: (data) => {
        this.modal();
        },
        error: (err) => console.error(err)
      });
    
  }
  selectPais(paisNombre: string):number {
    this.perfilForm.patchValue({ PaisNombre: paisNombre })

    var resultado = this.paises.find(pais => pais.nombre === paisNombre)?.id;
    return resultado == undefined ? -1 : resultado;
  }
  selectPaisById(id: number): string {
    var resultado = this.paises.find(pais => pais.id === id)?.nombre;
    return resultado == undefined ? '' : resultado;
  }

  modal() {
    const modalElement = document.getElementById('modal');
    const modal = new bootstrap.Modal(modalElement);
    modal.show();
  }
}
