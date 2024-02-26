using System.ComponentModel.DataAnnotations;

namespace Almoxarifado_API.Models
{
    public class Departamento
    {
        [Key]
        public int id { get; set; }
        public int decricao { get; set; }
        public int ativo { get; set; }

    }
}
