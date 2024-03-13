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
        public void Add(Departamento departamento)
        {
            bdConexao.Add(departamento);
            bdConexao.SaveChanges();
        }
        public void Delete(Departamento departamento)
        {
            bdConexao.Remove(departamento);
            bdConexao.SaveChanges();
        }
        public void Update(Departamento departamento)
        {
            bdConexao.Update(departamento); 
            bdConexao.SaveChanges();    
        }
    }
}
