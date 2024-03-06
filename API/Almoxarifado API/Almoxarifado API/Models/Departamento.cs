using System.ComponentModel.DataAnnotations;

namespace Almoxarifado_API.Models
{
    public class Departamento
    {
        [Key]
        public int id { get; set; }
        public string descricao { get; set; }
        public string situacao { get; set; }

    }
}
