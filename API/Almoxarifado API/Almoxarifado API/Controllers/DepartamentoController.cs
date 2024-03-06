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
        public IActionResult DepartamentoFuncionario(int id)
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
    }
}
