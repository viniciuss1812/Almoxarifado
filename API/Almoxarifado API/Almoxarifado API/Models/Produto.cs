using System.ComponentModel.DataAnnotations;

namespace Almoxarifado_API.Models
{
    public class Produto
    {
        [Key]
        public int id { get; set; }
        public string nome { get; set; }
        public int estoque { get; set; }
        public string? photourl { get; set; }
        public int idcategoria { get; set; }

    }
}
