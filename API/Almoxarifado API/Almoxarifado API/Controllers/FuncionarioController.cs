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
        [HttpPost]
        [Route("NovoFuncionario")]
        public IActionResult NovoFuncionario(string descrica)
        {
            try
            {
                departamentoRepository.Add(
                  new Departamento() { descricao = descricao, situacao = situacao }
                );

                return Ok("Cadastrado com Sucesso");
            }
            catch (Exception ex) { return BadRequest("Erro " + ex.Message); }
        }
        [HttpDelete]
        [Route("{id}/DeleteDepartamento")]
        public IActionResult DeleteDepartamento(int id)
        {
            var departamento = departamentoRepository.GetDepartamento().FirstOrDefault(x => x.id == id);

            try
            {
                if (departamento != null)
                {
                    // Excluir o departamento usando o ID
                    departamentoRepository.Delete(departamento);

                    return Ok("Deletado com Sucesso");
                }
                else
                {
                    // Lidar com o caso em que nenhum departamento é encontrado
                    return NotFound("Departamento não encontrado");
                }

            }
            catch (Exception ex) { return BadRequest("Erro " + ex.Message); }
        }
        [HttpPut]
        [Route("UpdateDepartamento")]
        public IActionResult UpdateDepartamento(Departamento departamento)
        {

            try
            {
                Departamento DepartamentoAtaulizar = new Departamento
                {
                    id = departamento.id,
                    descricao = departamento.descricao,
                    situacao = departamento.situacao
                };

                departamentoRepository.Update(DepartamentoAtaulizar);
                var departamentoatualizado = departamentoRepository.GetDepartamento().Find(x => x.id == departamento.id);
                return Ok(departamentoatualizado);
            }
            catch (Exception ex)
            {

                return BadRequest("Não Ataulizado. Erro: " + ex.Message);
            }
        }
    }
}
