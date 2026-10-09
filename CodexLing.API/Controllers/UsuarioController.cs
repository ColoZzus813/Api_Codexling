using Microsoft.AspNetCore.Mvc;
using CodexLing.Query.Interfaces;
using CodexLing.Repository.Interfaces;
using CodexLing.Models;
using System.Threading.Tasks;

namespace CodexLing.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioQueries _queries;
        private readonly IUsuarioRepository _repository;

        public UsuarioController(IUsuarioQueries queries, IUsuarioRepository repository)
        {
            _queries = queries;
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _queries.ObtenerTodosAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Usuario usuario)
        {
            var result = await _repository.CrearAsync(usuario);
            return Ok(result);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, [FromBody] Usuario usuario)
        {
            if (usuario == null)
            {
                return BadRequest();
            }

            usuario.Id = id;
            var updated = await _repository.ActualizarAsync(usuario);
            return updated ? NoContent() : NotFound();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _repository.EliminarAsync(id);
            return deleted ? NoContent() : NotFound();
        }
    }
}
