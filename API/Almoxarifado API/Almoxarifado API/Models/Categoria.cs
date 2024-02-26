using System.ComponentModel.DataAnnotations;

namespace Almoxarifado_API.Models
{
    public class Categoria
    {
        [Key]
        public int id { get; set; }
        public string descricao { get; set; }
    }
}
