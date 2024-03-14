using Almoxarifado_API.Models;

namespace Almoxarifado_API.Repository
{
    public interface ICategoriaRepository
    {
        List<CategoriaMotivo> GetTodasasCategorias();
        void Add(CategoriaMotivo categoria);
        void Delete(CategoriaMotivo categoria);
        void Update(CategoriaMotivo categoria);
        //void Add(Produto produto);
    }
}
