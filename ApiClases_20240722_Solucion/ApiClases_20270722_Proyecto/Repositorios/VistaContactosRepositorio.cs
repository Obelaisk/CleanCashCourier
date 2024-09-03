namespace ApiClases_20270722_Proyecto.Repositorios
{
    public class VistaContactosRepositorio : IVistaContactoRepositorio<VContacto>
    {
        private readonly Contexto _contexto;
        public VistaContactosRepositorio(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<bool> CheckIfExistsInView(int? idCliente, string nombreUsuarioClienteABuscar)
        {
            var query = _contexto.VContactos.AsQueryable();
            if (!idCliente.HasValue || string.IsNullOrEmpty(nombreUsuarioClienteABuscar))
            {
                return false;
            }
            query = query = query.Where(v => v.IdCliente == idCliente);
            query = query.Where(v => v.NombreUsuarioContacto == nombreUsuarioClienteABuscar);
            var nuevaConsulta = query.Select(v => new VContacto
            {
                IdCliente = v.IdCliente,
                NombreUsuarioContacto = v.NombreUsuarioContacto,
                Pais = v.Pais,
            });
            var datos = new List<VContacto>();
            datos = await nuevaConsulta.ToListAsync();
            return datos.Any();
        }

        public async Task<(IEnumerable<VContacto> Data, int TotalCount)> GetVContactosAsync(VContactoParametrosFiltradoDto parametrosfiltro)
        {
            var query = _contexto.VContactos.AsQueryable();
            if (!string.IsNullOrEmpty(parametrosfiltro.NombreUsuarioContacto))
            {
                query = query.Where(v => v.NombreUsuarioContacto == parametrosfiltro.NombreUsuarioContacto);
            }
            if (parametrosfiltro.IdCliente.HasValue)
            {
                query = query.Where(v => v.IdCliente == parametrosfiltro.IdCliente);
            }
            if (!string.IsNullOrEmpty(parametrosfiltro.Pais))
            {
                query = query.Where(v => v.Pais == parametrosfiltro.Pais);
            }
            var nuevaConsulta = query.Select(v => new VContacto
            {
                IdCliente = v.IdCliente,
                NombreUsuarioContacto = v.NombreUsuarioContacto,
                Pais = v.Pais,
            });
            var pageSize = parametrosfiltro.TamanoPagina;
            if (nuevaConsulta.Count() < 10)
            {
                pageSize = nuevaConsulta.Count();
            }
            var datos = new List<VContacto>();
            datos = await nuevaConsulta.Take(pageSize).ToListAsync();
            return (datos.AsQueryable(), 0);
        }
    }
}
