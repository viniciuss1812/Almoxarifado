using Almoxarifado_API.Models;
using Almoxarifado_API.Repository;
using Almoxarifado_API.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace Almoxarifado_API.Controllers
{
    [ApiController]
    [Route("api/v1/produto")]
    public class ProdutoController : ControllerBase
    {
       private readonly  IProdutoRepository _produtoRepository;
       private readonly ICategoriaRepository _categoriaRepository;
         public ProdutoController(IProdutoRepository repositorio, ICategoriaRepository categoria)
         {
            _produtoRepository = repositorio;
            _categoriaRepository = categoria;
         }
        [HttpGet]
        [Route("Hello")]  
        public IActionResult Hello()
        {
            return Ok("Hello Mundo");
        }
        [HttpGet]
        [Route("GetAllFake")]
        public IActionResult GetAllFake()
        {
            var produtos = new List<Produto>()
            {
              new Produto()
              {
                  id = 1,
                  nome = "PC HP",
                  estoque = 10
              },
               new Produto()
               {
                  id = 2,
                  nome = "PC DELL",
                  estoque = 20
               }

            };
            return Ok(produtos);    
        }
        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll() 
        {
            return Ok(_produtoRepository.GetAll());
        
        }
        [HttpPost]
        [Route("AdicioanProdutoSemFoto")]
        public IActionResult AdicionarProdutoSemFoto(ProdutoViewModelSemFoto produto)
        {
            try
            {
                _produtoRepository.Add(
                  new Produto() { nome = produto.nome, estoque = produto.estoque, photourl = null }
                );

                return Ok("Cadastrado com Sucesso");
            }
            catch (Exception ex)
            {

                return BadRequest("Não Cadastrado. Erro: " + ex.Message);
            }

        }

        [HttpPut]
        [Route("AtualizarProdutoSemFoto")]
        public IActionResult AtualizarProdutoSemFoto(ProdutoViewModelUpdateSemFoto produto)
        {
            try
            {
                //var produtoAtualizar = _produtoRepository.GetAll().Find(x => x.id == produto.id);

                Produto produtoAtaulizar = new Produto
                {
                    id = produto.id,
                    nome = produto.nome,
                    estoque = produto.estoque
                };

                _produtoRepository.Update(produtoAtaulizar);

                return Ok("Atualizado com Sucesso");
            }
            catch (Exception ex)
            {

                return BadRequest("Não Ataulizado. Erro: " + ex.Message);
            }

        }


        [HttpPost]
        [Route("AdicioanProdutoComFoto")]
        public IActionResult AdicionarProdutoComFoto([FromForm] ProdutoViewModelComFoto produto)
        {
            try
            {
                var caminho = Path.Combine("Storage", produto.photourl.FileName);

                using Stream fileStream = new FileStream(caminho, FileMode.Create);
                produto.photourl.CopyTo(fileStream);

                _produtoRepository.Add(
                  new Produto() { nome = produto.nome, estoque = produto.estoque, photourl = caminho }
                );

                return Ok("Cadastrado com Sucesso");
            }
            catch (Exception ex)
            {

                return BadRequest("Não Cadastrado. Erro: " + ex.Message);
            }

        }

        [HttpGet]
        [Route("{id}/GetProduto")]
        public IActionResult GetProduto(int id)
        {

            return Ok(_produtoRepository.GetAll().Find(x => x.id == id));
        }

        [HttpGet]
        [Route("{id}/Download")]
        public IActionResult Download(int id)
        {
            try
            {
                var produto = _produtoRepository.GetAll().Find(x => x.id == id);
                if (produto.photourl == null)
                {
                    return Ok("Não existe falta cadastrada para o Produto");
                }
                else
                {
                    var dataBytes = System.IO.File.ReadAllBytes(produto.photourl);
                    return File(dataBytes, "image/jpg");

                }
            }
            catch (Exception ex)
            {

                return BadRequest("Erro em fazer download: " + ex.Message);
            }


        }
    }


}
