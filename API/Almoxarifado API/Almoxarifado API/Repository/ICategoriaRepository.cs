using Almoxarifado_API.Models;

namespace Almoxarifado_API.Repository
{
    public interface ICategoriaRepository
    {
        List<CategoriaMotivo> GetAll();
        //void Add(Produto produto);
    }
}
