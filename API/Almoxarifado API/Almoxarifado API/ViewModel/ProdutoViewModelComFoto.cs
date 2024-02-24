namespace Almoxarifado_API.ViewModel
{
    public class ProdutoViewModelComFoto
    {
        public string nome { get; set; }
        public int estoque { get; set; } = 0;
        public IFormFile photourl { get; set; }

    }
}
