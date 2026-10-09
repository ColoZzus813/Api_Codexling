using CodexLing.Models;
using CodexLing.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodexLing.Repository.Implements
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private static readonly List<Usuario> _usuarios = new()
        {
            new Usuario
            {
                Id = 1,
                Nombre = "Ana",
                Apellido = "García",
                Email = "ana@codexling.com",
                ContrasenaHash = "hash-demo",
                FechaCreacion = System.DateTime.UtcNow,
                Activo = true
            },
            new Usuario
            {
                Id = 2,
                Nombre = "Luis",
                Apellido = "Pérez",
                Email = "luis@codexling.com",
                ContrasenaHash = "hash-demo",
                FechaCreacion = System.DateTime.UtcNow,
                Activo = true
            }
        };

        public Task<IEnumerable<Usuario>> ObtenerTodosAsync()
        {
            return Task.FromResult<IEnumerable<Usuario>>(_usuarios);
        }

        public Task<Usuario> ObtenerPorIdAsync(int id)
        {
            return Task.FromResult(_usuarios.FirstOrDefault(u => u.Id == id));
        }

        public async Task<int> CrearAsync(Usuario usuario)
        {
            await Task.CompletedTask;

            if (usuario == null)
            {
                return 0;
            }

            if (usuario.Id <= 0)
            {
                usuario.Id = _usuarios.Count == 0 ? 1 : _usuarios.Max(u => u.Id) + 1;
            }

            if (!_usuarios.Any(u => u.Id == usuario.Id))
            {
                _usuarios.Add(usuario);
            }

            return usuario.Id;
        }

        public async Task<bool> ActualizarAsync(Usuario usuario)
        {
            await Task.CompletedTask;

            if (usuario == null)
            {
                return false;
            }

            var index = _usuarios.FindIndex(u => u.Id == usuario.Id);
            if (index < 0)
            {
                return false;
            }

            _usuarios[index] = usuario;
            return true;
        }

        public async Task<bool> EliminarAsync(int id)
        {
            await Task.CompletedTask;

            var usuario = _usuarios.FirstOrDefault(u => u.Id == id);
            if (usuario == null)
            {
                return false;
            }

            _usuarios.Remove(usuario);
            return true;
        }
    }
}
