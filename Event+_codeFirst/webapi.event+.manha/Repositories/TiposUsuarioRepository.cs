using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using webapi.event_.manha.Context;
using webapi.event_.manha.Domains;
using webapi.event_.manha.Interfaces;

namespace webapi.event_.manha.Repositories
{
    public class TiposUsuarioRepository : ITiposUsuarioRepository
    {
        private readonly EventContext _eventContext;

        public TiposUsuarioRepository()
        {
            _eventContext = new EventContext();
        }


        public void Atualizar(Guid id, TiposUsuarioDomain tiposUsuario)
        {
            TiposUsuarioDomain buscarTiposUsuario = _eventContext.TiposUsuario.Find(id)!;
            if (buscarTiposUsuario != null)
            {
                buscarTiposUsuario!.Titulo = tiposUsuario.Titulo;

                _eventContext.Update(buscarTiposUsuario);

                _eventContext.SaveChanges();
            }
        }

        public TiposUsuarioDomain BuscarPorId(Guid id)
        {
           
                return _eventContext.TiposUsuario.FirstOrDefault(t => t.IdTiposUsuario == id);            
      
        }

        public void Cadastrar(TiposUsuarioDomain tipoUsuario)
        {
            
            _eventContext.TiposUsuario.Add(tipoUsuario);

            _eventContext.SaveChanges();


        }

        public void Deletar(Guid id)
        {
            
            
                _eventContext.TiposUsuario.Where(t => t.IdTiposUsuario == id).ExecuteDelete();

                _eventContext.SaveChanges();
            
        }

        public List<TiposUsuarioDomain> Listar()
        {
            
                List<TiposUsuarioDomain> ListaTiposUsuario = new List<TiposUsuarioDomain>();

                ListaTiposUsuario = _eventContext.TiposUsuario.ToList();

                return (ListaTiposUsuario);
         
        }
    }
}
