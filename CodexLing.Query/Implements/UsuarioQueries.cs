using CodexLing.Models;
using CodexLing.Query.Interfaces;
using CodexLing.Repository.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodexLing.Query.Implements
{
    public class UsuarioQueries : IUsuarioQueries
    {
        private readonly IUsuarioRepository _repository;

        public UsuarioQueries(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<Usuario>> ObtenerTodosAsync()
        {
            return _repository.ObtenerTodosAsync();
        }

        public Task<Usuario> ObtenerPorIdAsync(int id)
        {
            return _repository.ObtenerPorIdAsync(id);
        }
    }
}
