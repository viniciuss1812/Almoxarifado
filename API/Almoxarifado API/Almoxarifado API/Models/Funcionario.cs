using System.ComponentModel.DataAnnotations;

namespace Almoxarifado_API.Models
{
    public class Funcionario
    {
        [Key]
        public int Id { get; set; }
        public string nome { get; set; }
        public int idDepartamento { get; set; }
    }
}
