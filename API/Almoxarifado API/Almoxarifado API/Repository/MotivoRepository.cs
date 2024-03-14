using Almoxarifado_API.Infraestrutura;
using Almoxarifado_API.Models;

namespace Almoxarifado_API.Repository
{
    public class MotivoRepository: IMotivoRepository
    {
        ConexaoSQL bdConexao = new ConexaoSQL();
        public void Add(Motivo motivo)
        {
            bdConexao.Add(motivo);
            bdConexao.SaveChanges();
        }
        public List<Motivo> TodososMotivos()
        {
            return bdConexao.Motivo.ToList();
        }
        public void Update(Motivo motivo)
        {
            bdConexao.Update(motivo);
            bdConexao.SaveChanges();
        }
        public void Delete (Motivo motivo)
        {
            bdConexao.Remove(motivo);
            bdConexao.SaveChanges();
        }
    }
}
