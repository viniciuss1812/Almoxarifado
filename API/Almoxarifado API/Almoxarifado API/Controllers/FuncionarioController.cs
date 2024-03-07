using Almoxarifado_API.Models;
using Almoxarifado_API.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Almoxarifado_API.Controllers
{
    public class FuncionarioController : ControllerBase
    {
        private readonly IFuncionarioRepository funcionarioRepository;
        private readonly IDepartamentoRepository departamentorepository;

        public FuncionarioController(IFuncionarioRepository repositorio, IDepartamentoRepository repository)
        {
            funcionarioRepository = repositorio;
            departamentorepository = repository;

        }
        [HttpGet]
        [Route("{id}/DepartamentoFuncionario")]
        public IActionResult DepartamentoFuncionario(int id)
        {
            try
            {
                Funcionario func = new Funcionario();
                func.idDepartamento = id;
                List<Funcionario> funcionariosDoDepartamento = funcionarioRepository.GetFuncionario().FindAll(x => x.idDepartamento == id);
                List<string> nomesDosFuncionarios = funcionariosDoDepartamento.Select(x => x.nome).ToList();
                return Ok(nomesDosFuncionarios); 
              
            }
            catch (Exception ex)
            {
                return BadRequest("Erro " + ex.Message);
            }

        }
    }
}
