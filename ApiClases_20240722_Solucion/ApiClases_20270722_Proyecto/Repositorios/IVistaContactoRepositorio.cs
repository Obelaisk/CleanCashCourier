namespace ApiClases_20270722_Proyecto.Repositorios
{
    public interface IVistaContactoRepositorio<VContacto>
    {
        Task<(IEnumerable<VContacto> Data, int TotalCount)> GetVContactosAsync(VContactoParametrosFiltradoDto parametrosfiltro);
        Task<bool> CheckIfExistsInView(int? idCliente, string nombreUsuarioClienteABuscar);
    }
}
