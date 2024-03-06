using Almoxarifado_API.Infraestrutura;
using Almoxarifado_API.Models;

namespace Almoxarifado_API.Repository
{
    public class CategoriaRepository : ICategoriaRepository
    {
        ConexaoSQL bdConexao = new ConexaoSQL();
       // public void Add(Categoria categoria)
       // {
          //  bdConexao.Add(produto);
         //   bdConexao.SaveChanges();
      //  }
        public List<CategoriaMotivo> GetAll()
        {
            return bdConexao.Categoria.ToList();
        }
    }
}
