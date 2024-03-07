using Almoxarifado_API.Models;

namespace Almoxarifado_API.Repository
{
    public interface IFuncionarioRepository
    {
        List<Funcionario> GetFuncionario();
        //void Add(Funcionario funcionario);  
    }
}
