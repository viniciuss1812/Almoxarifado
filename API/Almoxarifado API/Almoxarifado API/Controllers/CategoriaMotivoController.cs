using Almoxarifado_API.Models;
using Almoxarifado_API.Repository;
using Almoxarifado_API.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Almoxarifado_API.Controllers
{
    public class CategoriaMotivoController : ControllerBase
    {

        private readonly ICategoriaRepository _categoriaRepository;
        public CategoriaMotivoController(ICategoriaRepository categoria)
        {
            _categoriaRepository = categoria;
        }
        [HttpGet]
        [Route("TodasasCategoria")]
        public IActionResult TodasasCategorias()
        {
            return Ok(_categoriaRepository.GetTodasasCategorias());
        }
        [HttpGet]
        [Route("{id}/GetCategoria")]
        public IActionResult GetCategoria(int id)
        {
            try
            {
                var categoria = _categoriaRepository.GetTodasasCategorias().Find(x => x.id == id);
                if (categoria.descricao == null)
                {
                    return Ok("Categoria não existe");
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
        [HttpPost]
        [Route("AdicionarCategoria")]
        public IActionResult AdicionarCategoria(CategoriaViewModel categoria)
        {
            try
            {
                _categoriaRepository.Add(
                    new CategoriaMotivo() { descricao = categoria.descricao }
                 );
                return Ok("Cadastrado com Sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest("Erro em recuperar a descrição: " + ex.Message);
            }

        }
        [HttpDelete]
        [Route("Deletecategoria")]
        public  IActionResult Deletecategoria(string categoria)
        {
            try
            {

                var categoriaencontrada = _categoriaRepository.GetTodasasCategorias().Find(x => x.descricao == categoria);
                if (categoriaencontrada != null)
                {
                    _categoriaRepository.Delete(categoriaencontrada);
                    return Ok("Categoria deletada");

                }
                else
                {
                    return NotFound("Categoria não encontrada");

                }
            }
            catch (Exception ex)
            {
                return BadRequest("erro: " + ex.Message);
            }

        }
        [HttpPut]
        [Route("UpdateCategoria")]
        public IActionResult UpdateCategoria(CategoriaMotivo categoria)
        {

            try
            {
                CategoriaMotivo categoriaAtualizar = new CategoriaMotivo
                {
                    id = categoria.id,  
                    descricao = categoria.descricao,
                 
                };

                _categoriaRepository.Update(categoriaAtualizar);
                var categoriaatualizada = _categoriaRepository.GetTodasasCategorias().Find(x => x.descricao == categoria.descricao);
                return Ok(categoriaatualizada);
            }
            catch (Exception ex)
            {
                return BadRequest("erro: " + ex.Message);
            }

        }
    }
}
