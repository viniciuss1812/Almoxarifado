using Almoxarifado_API.Models;
using Almoxarifado_API.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Almoxarifado_API.Controllers
{
    public class DepartamentoController : ControllerBase
    {
        private readonly IDepartamentoRepository departamentoRepository;
    

        public DepartamentoController(IDepartamentoRepository repositorio)
        {
            departamentoRepository = repositorio;
            
        }
        [HttpGet]
        [Route("{id}/Departamento")]
        public IActionResult Departamento(int id)
        {
        
            try
            {
                Funcionario funcionario = new Funcionario();
                funcionario.idDepartamento = id;
                return Ok(departamentoRepository.GetDepartamento().Find(x => x.id == funcionario.idDepartamento));
            }
            catch (Exception ex) 
            {
                return BadRequest("Erro " + ex.Message);
            }
           
        }
        
        [HttpGet]
        [Route("{id}/SituacaoDepartamento")]
        public IActionResult DepartamentoSituacao(int id)
        {

            try
            {
 
                var departamento = (departamentoRepository.GetDepartamento().Find(x => x.id == id));
                return Ok(departamento.situacao);

            }
            catch (Exception ex)
            {
                return BadRequest("Erro " + ex.Message);
            }

        }
        [HttpPost]
        [Route("NovoDepartamento")]
        public IActionResult NovoDepartamento(string descricao, string situacao)
        {
            try
            {
                departamentoRepository.Add(
                  new Departamento() { descricao = descricao, situacao = situacao }
                );

                return Ok("Cadastrado com Sucesso");
            }
            catch(Exception ex) { return BadRequest("Erro " + ex.Message); }
        }
        [HttpDelete]
        [Route("{id}/DeleteDepartamento")]
        public IActionResult DeleteDepartamento(string id)
        {
            var departamento = departamentoRepository.GetDepartamento().Find(x => x.descricao == id).id;

            try
            {
                if (departamento != null)
                {
                    // Excluir o departamento usando o ID
                    departamentoRepository.Delete(new Departamento() { id = departamento });

                    return Ok("Deletado com Sucesso");
                }
                else
                {
                    // Lidar com o caso em que nenhum departamento é encontrado
                    return NotFound("Departamento não encontrado com a descrição fornecida");
                }

            }  
            catch(Exception ex) { return BadRequest("Erro " + ex.Message); }
        }

    }
}
