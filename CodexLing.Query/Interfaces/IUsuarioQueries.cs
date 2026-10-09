using CodexLing.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodexLing.Query.Interfaces
{
    public interface IUsuarioQueries
    {
        Task<IEnumerable<Usuario>> ObtenerTodosAsync();
        Task<Usuario> ObtenerPorIdAsync(int id);
    }
}
