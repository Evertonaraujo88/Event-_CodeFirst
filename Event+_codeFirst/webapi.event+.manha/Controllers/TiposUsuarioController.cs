using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.event_.manha.Domains;
using webapi.event_.manha.Interfaces;
using webapi.event_.manha.Repositories;

namespace webapi.event_.manha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class TiposUsuarioController : ControllerBase
    {
        private ITiposUsuarioRepository _tiposUsuarioRepository;

        public TiposUsuarioController()
        {
            _tiposUsuarioRepository = new TiposUsuarioRepository();
        }
        /// <summary>
        /// End Point que aciona o metodo de Cadastrar tipos de Usuario
        /// </summary>
        /// <param name="tiposUsuario"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(TiposUsuarioDomain tiposUsuario)
        {
            try
            {
                _tiposUsuarioRepository.Cadastrar(tiposUsuario);

                return StatusCode(201);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// EndPoint que aciona o metodo de listar todos os tipos de usuario
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {

            try
            {
                List<TiposUsuarioDomain> ListarTiposUsuario = _tiposUsuarioRepository.Listar();

                return Ok(ListarTiposUsuario);

            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// End Point que busca tipo de usuario por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(_tiposUsuarioRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }


        /// <summary>
        /// End Point que Deleta o tipo de Usuario
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _tiposUsuarioRepository.Deletar(id);

                return Ok();
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// EndPoint que atualiza o tipo do usuario
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tipoUsuario"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, TiposUsuarioDomain tipoUsuario)
        {
            try
            {
                _tiposUsuarioRepository.Atualizar(id, tipoUsuario);

                return Ok();
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }

        }
    }
}
