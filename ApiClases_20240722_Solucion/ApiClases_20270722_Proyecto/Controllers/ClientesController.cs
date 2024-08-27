﻿using ApiClases_20270722_Proyecto.Entidades;
using ApiClases_20270722_Proyecto.Repositorios;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using static ApiClases_20270722_Proyecto.Modelos.ModeloInicioSesion;

namespace ApiClases_20270722_Proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IRepositorioGenerico<Cliente> _clienteRepositorio;
        private readonly IRepositorioGenerico<Pais> _paisRepositorio;
        private readonly IServicioToken _servicioToken;
        private readonly IMapper _mapper;
        private readonly UserManager<UsuarioAplicacion> _userManager;
        private readonly SignInManager<UsuarioAplicacion> _signInManager;

        public ClientesController(
            IRepositorioGenerico<Cliente> clienteRepositorio,
            IRepositorioGenerico<Pais> paisRepositorio,
            IServicioToken servicioToken,
            IMapper mapper,
            UserManager<UsuarioAplicacion> userManager,
            SignInManager<UsuarioAplicacion> signInManager)
        {
            _clienteRepositorio = clienteRepositorio;
            _paisRepositorio = paisRepositorio;
            _servicioToken = servicioToken;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteBaseDto>>> Get()
        {
            var clientes = await _clienteRepositorio.Obtener();
            var clientesDto = _mapper.Map<IEnumerable<ClienteBaseDto>>(clientes);
            return Ok(clientesDto);
        }

        [HttpGet("{id:int}", Name = "getCliente")]
        public async Task<ActionResult<ClienteGetDto>> Get(int id)
        {
            var cliente =  _clienteRepositorio.ObtenerPorId(id);
            if (cliente == null) return NotFound();

            var finalClienteDto = _mapper.Map<ClienteGetDto>(cliente);
            return Ok(finalClienteDto);
        }
        
        [HttpGet("{name:alpha}", Name = "getClientePorNombre")]
        public async Task<ActionResult<ClienteGetDto>> Get(string name)
        {
            var cliente =  _clienteRepositorio.ObtenerPorNombre(name);
            if (cliente == null) return NotFound();

            var finalClienteDto = _mapper.Map<ClienteGetDto>(cliente);
            return Ok(finalClienteDto);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] ModeloInicioSesion modelo)
        {
            var result = await _signInManager.PasswordSignInAsync(
                modelo.Usuario,
                modelo.Contrasena,
                modelo.Recuerdame,
                lockoutOnFailure: false);

            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(modelo.Usuario);
                var token = _servicioToken.GenerateJwtToken(user);
                return Ok(new { Token = token });
            }

            return Unauthorized();
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] ModeloRegistro modelo)
        {
            var usuario = new UsuarioAplicacion
            {
                Nombre = modelo.Nombre,
                Apellido = modelo.Apellido,
                UserName = modelo.Email.Split('@')[0],
                Email = modelo.Email,
                FechaNacimiento = modelo.FechaNacimiento,
                Empleo = modelo.Empleo,
            };

            var result = await _userManager.CreateAsync(usuario, modelo.Contrasena);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            var cliente = _mapper.Map<Cliente>(modelo);
            cliente.Email = modelo.Email;  // Mapeo adicional de email
            cliente.Usuario = modelo.Email.Split('@')[0];

            _clienteRepositorio.Agregar(cliente);
            var addClienteResult = await _clienteRepositorio.GuardarCambios();

            if (!addClienteResult)
            {
                return BadRequest("Error al guardar en la tabla Clientes");
            }

            var addRoleResult = await _userManager.AddToRoleAsync(usuario, "Cliente");
            if (!addRoleResult.Succeeded)
            {
                return BadRequest(new { Message = "Fallo al añadir el nuevo rol." });
            }

            var token = _servicioToken.GenerateJwtToken(usuario);
            return Ok(new { Token = token });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutAsync(int id, ClientePutDto clienteDto)
        {
            var clienteExistente = _clienteRepositorio.ObtenerPorId(id);
            if (clienteExistente == null) return NotFound();

            clienteExistente.PaisId = clienteDto.PaisId;
            clienteExistente.Empleo = clienteDto.Empleo;

            _clienteRepositorio.Actualizar(id, clienteExistente);

            if (await _clienteRepositorio.GuardarCambios())
            {
                return NoContent();
            }

            return BadRequest("Error al actualizar el cliente");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var clienteExistente = _clienteRepositorio.ObtenerPorId(id);
            if (clienteExistente == null) return NotFound();

            _clienteRepositorio.Borrar(id);

            if (await _clienteRepositorio.GuardarCambios())
            {
                return NoContent();
            }

            return BadRequest("Error al borrar el cliente");
        }
    }
}
