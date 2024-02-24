using Almoxarifado_API.Models;

namespace Almoxarifado_API.Repository
{
    public interface IProdutoRepository
    {
        List<Produto> GetAll();
        void Add(Produto produto);  
    }
}
