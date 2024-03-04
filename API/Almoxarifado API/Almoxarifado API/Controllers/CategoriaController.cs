using Almoxarifado_API.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Almoxarifado_API.Controllers
{
    public class CategoriaController : ControllerBase
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly ICategoriaRepository _categoriaRepository;
        public CategoriaController(IProdutoRepository repositorio, ICategoriaRepository categoria)
        {
            _produtoRepository = repositorio;
            _categoriaRepository = categoria;
        }
        [HttpGet]
        [Route("{id}/GetCategoria")]
        public IActionResult GetCategoria(int id)
        {
            try
            {
                var categoria = _categoriaRepository.GetAll().Find(x => x.id == id);
                if (categoria.descricao == null)
                {
                    return Ok("Produto não existe");
                }
                else
                {

                    return Ok(categoria);
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Erro em recuperar a descrição: " + ex.Message);
            }

        }
    }
}
