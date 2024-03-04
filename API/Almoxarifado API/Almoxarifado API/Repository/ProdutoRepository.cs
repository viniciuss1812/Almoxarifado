using Almoxarifado_API.Infraestrutura;
using Almoxarifado_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Almoxarifado_API.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        ConexaoSQL bdConexao = new ConexaoSQL();
        public void Add(Produto produto)
        {
            bdConexao.Add(produto);
            bdConexao.SaveChanges();
        }
        public List<Produto> GetAll()
        {
            return bdConexao.Produto.ToList();
        }
        public void Update(Produto produto) 
        {
           bdConexao.Update(produto);   
           bdConexao.SaveChanges();    
        }


    }
}
