using Almoxarifado_API.Models;

namespace Almoxarifado_API.Repository
{
    public interface IMotivo
    {
        List<Motivo> GetAll();
        void Add(Motivo motivo);
        void Update(Motivo motivo);
    }
}
