using Almoxarifado_API.Infraestrutura;
using Almoxarifado_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Almoxarifado_API.Repository
{
    public class CategoriaRepository : ICategoriaRepository
    {
        ConexaoSQL bdConexao = new ConexaoSQL();
     
        public List<CategoriaMotivo> GetTodasasCategorias()
        {
            return bdConexao.Categoria.ToList();
        }
        public void Add(CategoriaMotivo categoria)
        {
            bdConexao.Add(categoria);
            bdConexao.SaveChanges();

        }
        public void Delete(CategoriaMotivo categoria)
        {
           bdConexao.Remove(categoria);
           bdConexao.SaveChanges();

        }
        public void Update(CategoriaMotivo categoria)
        {
            bdConexao.Update(categoria);
            bdConexao.SaveChanges();

        }
    }
}
