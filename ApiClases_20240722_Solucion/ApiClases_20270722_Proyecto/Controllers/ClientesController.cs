﻿using ApiClases_20270722_Proyecto.Repositorios;
using System.Collections.Generic;
namespace ApiClases_20270722_Proyecto.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClientesController : ControllerBase{
    public readonly IClienteRepositorio repositorio;
    private readonly IMapper _mapper;
    public ClientesController(IClienteRepositorio repositorio,IMapper mapper){
        this.repositorio = repositorio;
        _mapper = mapper ??
               throw new ArgumentNullException(nameof(mapper));
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ClienteDto>>> Get(){
        return Ok(_mapper.Map < IEnumerable < ClienteDto >>(await repositorio.ObtenerClientes()));
    }

    //[HttpGet("{id}", Name = "getCliente")]
    //public ActionResult<ClienteDto> Get(int id){
    //    var cliente = repositorio.ObtenerClienteId(id);
    //    var finalClienteDto = _mapper.Map<ClienteDto>(cliente);
    //    return finalClienteDto == null ? NotFound(): Ok(finalClienteDto);
    //}

    //[HttpGet("{user_id}", Name = "getTransaccionPorUserId")]
    //public async Task<ActionResult<IEnumerable<TransaccionDto>>> GetByUserId(int user_id)
    //{
    //    return Ok(_mapper.Map<IEnumerable<TransaccionDto>>(await repositorio.ObtenerTransaccionesPorCliente(user_id)));
    //    //var transaccion = repositorio.ObtenerTransaccionesPorCliente(user_id);
    //    //var finalTransaccionDto = _mapper.Map<TransaccionDto>(transaccion);
    //    //return await finalTransaccionDto == null ? NotFound() : Ok(finalTransaccionDto);
    //}

    [HttpGet("{username}", Name = "getTransaccionPorUserId")]
    public async Task<ActionResult<IEnumerable<TransaccionDto>>> GetByUserId(string username)
    {
        return Ok(_mapper.Map<IEnumerable<TransaccionDto>>(await repositorio.ObtenerTransaccionesPorCliente(username)));
        //var transaccion = repositorio.ObtenerTransaccionesPorCliente(user_id);
        //var finalTransaccionDto = _mapper.Map<TransaccionDto>(transaccion);
        //return await finalTransaccionDto == null ? NotFound() : Ok(finalTransaccionDto);
    }

    [HttpPost]
    public async Task<ActionResult<ClienteDto>> PostAsync(ClienteDto cliente) {
        var finalClienteNuevo =_mapper.Map<ClienteDto,Cliente>(cliente);
        repositorio.Agregar(finalClienteNuevo);
       
        return await repositorio.GuardarCambios()? Ok("Cliente añadido correctamente"): BadRequest();

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


