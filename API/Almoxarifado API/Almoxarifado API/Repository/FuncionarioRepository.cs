using Almoxarifado_API.Infraestrutura;
using Almoxarifado_API.Models;

namespace Almoxarifado_API.Repository
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        ConexaoSQL bdConexao = new ConexaoSQL();
        public List<Funcionario> GetFuncionario()
        {
            return bdConexao.Funcionario.ToList();
        }
       
    }
}
