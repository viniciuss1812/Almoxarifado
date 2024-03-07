using System.ComponentModel.DataAnnotations;

namespace Almoxarifado_API.Models
{
    public class CategoriaMotivo
    {
        [Key]
        public int id { get; set; }
        public string descricao { get; set; }
        public List<Motivo> Motivos { get; set; }  
    }
}
