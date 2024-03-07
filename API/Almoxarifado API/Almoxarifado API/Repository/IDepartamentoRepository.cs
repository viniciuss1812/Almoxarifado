using Almoxarifado_API.Models;

namespace Almoxarifado_API.Repository
{
    public interface IDepartamentoRepository
    {
        List<Departamento> GetDepartamento();
        void Add(Departamento departamento);
        void Delete(Departamento departamento);
    }
}
