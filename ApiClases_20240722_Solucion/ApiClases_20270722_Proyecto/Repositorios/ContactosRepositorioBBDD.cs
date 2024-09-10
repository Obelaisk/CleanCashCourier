
using ApiClases_20270722_Proyecto.Entidades;

namespace ApiClases_20270722_Proyecto.Repositorios
{
    public class ContactosRepositorioBBDD<T> : IRepositorioGenerico<T> where T : Contacto
    {
        private readonly Contexto _contexto;
        public ContactosRepositorioBBDD(Contexto contexto)
        {
            _contexto = contexto;
        }
        public void Actualizar(int id, T contacto)
        {
            contacto.Id = id;
            _contexto.Contactos.Update(contacto);
        }

        public void Agregar(T contacto)
        {
            _contexto.Contactos.Add(contacto);
        }

        public void Borrar(int id)
        {
            var contacto = _contexto.Contactos.FirstOrDefault(c => c.Id == id);
            _contexto.Contactos.Remove(contacto);
        }

        public async Task<bool> GuardarCambios()
        {
            return await _contexto.SaveChangesAsync() > 0;
        }

        public async Task<List<T>> Obtener() => await _contexto.Set<T>().ToListAsync();

        public T ObtenerPorId(int id) => _contexto.Set<T>().FirstOrDefault(c => c.Id == id);

        public T ObtenerPorNombre(string username) => throw new NotImplementedException();

        public Task<List<T>> ObtenerTodosFiltrado(FiltroTransacciones filtro)
        {
            throw new NotImplementedException();
        }

        public T ObtenerTransaccionId(int id_cliente, int id_transaccion)
        {
            throw new NotImplementedException();
        }

        public T ObtenerPorIds(int id1, int id2) {

            return _contexto.Set<T>().FirstOrDefault(c => c.ClienteOrigenId == id1 && c.ClienteDestinoId == id2);
        }
    }
}
