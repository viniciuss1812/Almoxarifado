using System.ComponentModel.DataAnnotations;

namespace Almoxarifado_API.Models
{
    public class Motivo
    {
        [Key]
        public int  MotID { get; set; }
        public string MotDescricao { get; set; }
        public int IDCategoriadoMotivo { get; set; }
        public CategoriaMotivo CategoriaMotivo { get; set; }
     

    }
}
