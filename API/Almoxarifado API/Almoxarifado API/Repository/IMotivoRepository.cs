using Almoxarifado_API.Models;

namespace Almoxarifado_API.Repository
{
    public interface IMotivoRepository
    {
        List<Motivo> TodososMotivos();
        void Add(Motivo motivo);
        void Update(Motivo motivo);
        void Delete(Motivo motivo);
    }
}
