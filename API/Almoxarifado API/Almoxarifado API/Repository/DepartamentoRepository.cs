using Almoxarifado_API.Infraestrutura;
using Almoxarifado_API.Models;

namespace Almoxarifado_API.Repository
{
    public class DepartamentoRepository : IDepartamentoRepository
    {
        ConexaoSQL bdConexao = new ConexaoSQL();
      
        public List<Departamento> GetDepartamento()
        {
           return bdConexao.Departamento.ToList();
        }
       
    }
}
