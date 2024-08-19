﻿using ApiClases_20270722_Proyecto.Repositorios;
using System.Collections.Generic;
namespace ApiClases_20270722_Proyecto.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClientesController : ControllerBase
{
    public readonly IRepositorioGenerico<Cliente> repositorio;
    private readonly IMapper _mapper;
    public ClientesController(IRepositorioGenerico<Cliente> repositorio, IMapper mapper) {
        this.repositorio = repositorio;
        _mapper = mapper ??
               throw new ArgumentNullException(nameof(mapper));
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ClienteDto>>> Get() {


       

        return Ok(_mapper.Map<IEnumerable<ClienteDto>>(await repositorio.Obtener()));
    }


    [HttpGet("{id}", Name = "getCliente")]
    public ActionResult<ClienteDto> Get(int id) {
        var cliente = repositorio.ObtenerPorId(id);
        var finalClienteDto = _mapper.Map<ClienteDto>(cliente);
        return finalClienteDto == null ? NotFound() : Ok(finalClienteDto);
    }

    [HttpPost]
    public async Task<ActionResult<ClienteDto>> PostAsync(ClienteDto cliente) {
        var finalClienteNuevo = _mapper.Map<ClienteDto, Cliente>(cliente);
        repositorio.Agregar(finalClienteNuevo);

        return await repositorio.GuardarCambios() ? Ok("Cliente añadido correctamente") : BadRequest();

    }

    [HttpPut]
    public async Task<ActionResult<ClienteDto>> PutAsync(int id, ClienteDto cliente) {
        var finalClienteActualizado = _mapper.Map<Cliente>(cliente);
        repositorio.Actualizar(id, finalClienteActualizado);
        return await repositorio.GuardarCambios() ? Ok("Cliente actualizado correctamente") : BadRequest();
    }

    [HttpDelete]
    public async Task<ActionResult<ClienteDto>> DeleteAsync(int id) {
        repositorio.Borrar(id);
        return await repositorio.GuardarCambios() ? Ok("Cliente borrado correctamente") : BadRequest();
    }
}
