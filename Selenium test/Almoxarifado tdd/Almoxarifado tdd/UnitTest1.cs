using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using HtmlAgilityPack;
using OpenQA.Selenium.Interactions;
using System.Drawing;
using System.Xml.Linq;
using Microsoft.VisualStudio.TestPlatform.Common.Utilities;

namespace Almoxarifado_TDD
{
    public class UnitTest1 : IDisposable
    {
       

            public IWebDriver driver { get; private set; }
            public IDictionary<String, Object> vars { get; private set; }
            public IJavaScriptExecutor js { get; private set; }
            public UnitTest1()
            {
                driver = new ChromeDriver();
                js = (IJavaScriptExecutor)driver;
                vars = new Dictionary<String, Object>();
            }
            public void Dispose()
            {
                driver.Quit();
            }
           string linkapi = "https://splendorous-starlight-c2b50a.netlify.app/";
        [Fact]
        public void RN01TelaRequisioCampos()
        {
            //"rgba(255, 255, 255, 1)"
            driver.Navigate().GoToUrl("https://splendorous-starlight-c2b50a.netlify.app/");
            driver.Manage().Window.Size = new System.Drawing.Size(1936, 1048);
            driver.FindElement(By.Id("inpNumero")).Click();
            driver.FindElement(By.Id("inpNumero")).SendKeys("1");
            driver.FindElement(By.Id("idDepartamento")).Click();
            driver.FindElement(By.Id("idFuncionario")).Click();
            driver.FindElement(By.Id("idFuncionario")).SendKeys("1");
            driver.FindElement(By.Id("NomeFuncionario")).Click();
            driver.FindElement(By.Id("NomeFuncionario")).Clear();
            //var cornomefuncinicial = driver.FindElement(By.Id("NomeFuncionario")).GetCssValue("background-color");
            Thread.Sleep(800);
            driver.FindElement(By.Id("dataRequisicao")).SendKeys("02022024");
            driver.FindElement(By.Id("urgente")).Click();
            driver.FindElement(By.Id("categoriaMotivo")).Click();
            {
                var dropdown = driver.FindElement(By.Id("categoriaMotivo"));
                dropdown.FindElement(By.XPath("//option[. = 'RP']")).Click();
            }
            driver.FindElement(By.Id("categoriaMotivo")).Click();
            {
                var dropdown = driver.FindElement(By.Id("categoriaMotivo"));
                dropdown.FindElement(By.XPath("//option[. = 'Cliente']")).Click();
            }
            driver.FindElement(By.Id("Motivo")).Click();
            {
                var dropdown = driver.FindElement(By.Id("Motivo"));
                dropdown.FindElement(By.XPath("//option[. = 'Quebra de Máquina']")).Click();
            }
            driver.FindElement(By.Id("CodigoProduto")).Click();
            driver.FindElement(By.Id("CodigoProduto")).SendKeys("1");
            driver.FindElement(By.Id("Quantidade")).SendKeys("1");
            driver.FindElement(By.Id("Quantidade")).Click();
            driver.FindElement(By.Id("Quantidade")).SendKeys("2");
            driver.FindElement(By.Id("Quantidade")).Click();
            {
                var element = driver.FindElement(By.Id("Quantidade"));
                Actions builder = new Actions(driver);
                builder.DoubleClick(element).Perform();
            }
            driver.FindElement(By.Id("Quantidade")).SendKeys("20");
            driver.FindElement(By.CssSelector("#btn-gravar > span")).Click();
            var selecionarcornome = driver.FindElement(By.Id("NomeFuncionario")).GetCssValue("background-color");
            string corerrada = "vermelho";
            string coresperada = "branca";
            string correal = selecionarcornome.ToString();
            if (correal == "\"rgba(231, 86, 86, 1)\"")
            {
                correal = corerrada;
                Assert.Equal(coresperada, correal);
            }
            else 
            {
                correal = coresperada;
                Assert.Equal(coresperada,correal);
            }
            
        }
        [Fact]
        public void RN01TelaRequisioCamposObrigatórios()
        {
            //"rgba(255, 255, 255, 1)"
            driver.Navigate().GoToUrl("https://splendorous-starlight-c2b50a.netlify.app/");
            driver.Manage().Window.Size = new System.Drawing.Size(1936, 1048);
            driver.FindElement(By.CssSelector("#btn-gravar > span")).Click();
            Thread.Sleep(1000);
            string coresperadaCamposObrigatórios = "rgba(231, 86, 86, 1)";

            var correuisição = driver.FindElement(By.Id("inpNumero")).GetCssValue("background-color");
            var corid = driver.FindElement(By.Id("idDepartamento")).GetCssValue("background-color"); 
            var cordepartamento = driver.FindElement(By.Id("departamento")).GetCssValue("background-color"); 
            var cordata = driver.FindElement(By.Id("dataRequisicao")).GetCssValue("background-color"); 
            var coridfunc = driver.FindElement(By.Id("NomeFuncionario")).GetCssValue("background-color"); 
            var corcargo = driver.FindElement(By.Id("cargo")).GetCssValue("background-color"); 
            var corcatmotivo = driver.FindElement(By.Id("categoriaMotivo")).GetCssValue("background-color"); 
            var cormotivo = driver.FindElement(By.Id("Motivo")).GetCssValue("background-color"); 
            var nivelprioridade = driver.FindElement(By.Id("radioPrioridade")).GetCssValue("background-color"); 
            var corcodproduto = driver.FindElement(By.Id("CodigoProduto")).GetCssValue("background-color"); 
            var cordesc = driver.FindElement(By.Id("DescricaoProduto")).GetCssValue("background-color"); 
            var corestoque = driver.FindElement(By.Id("Estoque")).GetCssValue("background-color"); 
            var corqtd = driver.FindElement(By.Id("Quantidade")).GetCssValue("background-color"); 
            var cortotal = driver.FindElement(By.Id("total")).GetCssValue("background-color");
            driver.Quit();
            Assert.Contains(coresperadaCamposObrigatórios, correuisição);
            Assert.Contains(coresperadaCamposObrigatórios, corid);
            Assert.Contains(coresperadaCamposObrigatórios, cordepartamento);
            Assert.Contains(coresperadaCamposObrigatórios, cordata);
            Assert.Contains(coresperadaCamposObrigatórios, coridfunc);
            Assert.Contains(coresperadaCamposObrigatórios, corcargo);
            Assert.Contains(coresperadaCamposObrigatórios, corcatmotivo);
            Assert.Contains(coresperadaCamposObrigatórios, cormotivo);
            Assert.Contains(coresperadaCamposObrigatórios, nivelprioridade);
            Assert.Contains(coresperadaCamposObrigatórios, corcodproduto);
            Assert.Contains(coresperadaCamposObrigatórios, cordesc);
            Assert.Contains(coresperadaCamposObrigatórios, corestoque);
            Assert.Contains(coresperadaCamposObrigatórios, corqtd);
            Assert.Contains(coresperadaCamposObrigatórios, cortotal);
        }


        [Theory]
        [InlineData("10")]
        [InlineData("30")]
        [InlineData("0")]
        

        public void RN03TelaRequisioCampos( string numeros)
        {
            driver.Navigate().GoToUrl("https://splendorous-starlight-c2b50a.netlify.app/");
            driver.Manage().Window.Size = new System.Drawing.Size(1936, 1048);
            driver.FindElement(By.Id("idDepartamento")).Click();
            {
                driver.FindElement(By.Id("idDepartamento")).SendKeys(numeros);
                var valores = driver.FindElement(By.Id("idDepartamento")).GetAttribute("value");
                Assert.Equal(numeros,valores);
            }
            driver.FindElement(By.Id("Quantidade")).Click();
            {
               driver.FindElement(By.Id("Quantidade")).SendKeys(numeros);
               var valores = driver.FindElement(By.Id("idDepartamento")).GetAttribute("value");
               driver.Quit();
              Assert.Equal(numeros, valores);
            }
      
        }
        //[Fact]
        //public void RN03TelaRequisioCamposnegativo()
        //{
        //    driver.Navigate().GoToUrl("https://splendorous-starlight-c2b50a.netlify.app/");
        //    driver.Manage().Window.Size = new System.Drawing.Size(1936, 1048);
           
        //    driver.FindElement(By.Id("Quantidade")).Click();
        //    {
        //        driver.Navigate().GoToUrl("https://splendorous-starlight-c2b50a.netlify.app/");
        //        driver.Manage().Window.Size = new System.Drawing.Size(1936, 1048);

        //       driver.FindElement(By.Id("Quantidade")).SendKeys("-2");
        //       Thread.Sleep(2000);
        //       var valores = driver.FindElement(By.Id("Quantidade")).GetAttribute("value");
        //       driver.Quit();
        //       string[] valoresnegativos = { "-3", "-2", "-1" };
        //       string valor = valoresnegativos.FirstOrDefault(valor => valor == valores);
        //        Assert.Equal(valor, valores);

        //    }
        //    driver.FindElement(By.Id("Quantidade")).Click();
        //    {
        //        driver.Navigate().GoToUrl("https://splendorous-starlight-c2b50a.netlify.app/");
        //        driver.Manage().Window.Size = new System.Drawing.Size(1936, 1048);
        //        driver.FindElement(By.Id("Quantidade")).SendKeys("-1");
        //        driver.FindElement(By.Id("Quantidade")).Click();
        //        var valores = driver.FindElement(By.Id("Quantidade")).GetAttribute("value");

        //        string[] valoresnegativos = { "-3", "-2", "-1" };
        //        string valor = valoresnegativos.FirstOrDefault(valor => valor == valores);
        //        Assert.Equal(valor, valores);
        //    }
        //}


        [Fact]
        public void RN04TelaRequisioCategoriaMotivo()
        {
            driver.Navigate().GoToUrl("https://splendorous-starlight-c2b50a.netlify.app/");
            driver.Manage().Window.Size = new System.Drawing.Size(1936, 1048);
            driver.FindElement(By.Id("categoriaMotivo")).Click();
            {
                var dropdown = driver.FindElement(By.Id("categoriaMotivo"));
               
                var pegargestao = dropdown.FindElement(By.XPath("//option[. = 'Gestão']"));
                string gestao = pegargestao.Text;

                var pegarcliente = dropdown.FindElement(By.XPath("//option[. = 'Cliente']"));
                string cliente = pegarcliente.Text;

                var pegarrp = dropdown.FindElement(By.XPath("//option[. = 'RP']"));
                string rp = pegarrp.Text;

                string[] todososmotivos = { $"{gestao}", $"{cliente}", $"{rp}" };
                string[] categoriamotivo = { "Gestão" ,"Cliente" ,"RP"};
                
               

                driver.Quit();
                Assert.Equal(categoriamotivo, todososmotivos);
            }
          
        }

        [Fact]
 
        public void RN05TelaRequisioMotivo()
        {
            driver.Navigate().GoToUrl("https://splendorous-starlight-c2b50a.netlify.app/");
            driver.Manage().Window.Size = new System.Drawing.Size(1936, 1048);
            driver.FindElement(By.Id("categoriaMotivo")).Click();
            {
                var dropdown = driver.FindElement(By.Id("categoriaMotivo"));
                dropdown.FindElement(By.XPath("//option[. = 'Gestão']")).Click();
                var pegar = dropdown.FindElement(By.XPath("//option[. = 'Gestão']"));
                string gestao = pegar.Text;
                Thread.Sleep(3000);

                dropdown.FindElement(By.XPath("//option[. = 'Planejamento']")).Click();
                Thread.Sleep(5000);

                var pegarplane = dropdown.FindElement(By.XPath("//option[. = 'Planejamento']"));
                string plan = pegarplane.Text;


                driver.FindElement(By.Id("Motivo")).Click();
                dropdown.FindElement(By.XPath("//option[. = 'Financeiro']")).Click();
                var pegarfinan = dropdown.FindElement(By.XPath("//option[. = 'Financeiro']"));
                string fin = pegarfinan.Text;
                Thread.Sleep(8000);

                string[] motivo = { plan, fin };
                string[] todososmotivos = { $"{plan}", $"{fin}" };
                string[] motivoesperado = { "Planejamento", "Financeiro" };
                driver.Quit();
                Assert.Equal(motivoesperado, todososmotivos);

                /////////////////////////////////////////////////////////////////////////
            }
        }
        [Fact]
        public void RN05TelaRequisioMotivoCliente()
        {
            driver.Navigate().GoToUrl("https://splendorous-starlight-c2b50a.netlify.app/");
            driver.Manage().Window.Size = new System.Drawing.Size(1936, 1048);
            driver.FindElement(By.Id("categoriaMotivo")).Click();
            {
                var dropdownn = driver.FindElement(By.Id("categoriaMotivo"));
                dropdownn.FindElement(By.XPath("//option[. = 'Cliente']")).Click();
                var pegar2 = dropdownn.FindElement(By.XPath("//option[. = 'Cliente']"));
                string cliente = pegar2.Text;
                Thread.Sleep(3000);

                dropdownn.FindElement(By.XPath("//option[. = 'Quebra de Máquina']")).Click();
                Thread.Sleep(5000);

                var pegarmaqui = dropdownn.FindElement(By.XPath("//option[. = 'Quebra de Máquina']"));
                string maqui = pegarmaqui.Text;
                string motivo2 = "Quebra de Máquina";


                Thread.Sleep(8000);
                driver.Quit();


                Assert.Equal(motivo2, maqui);
            }
            
        }
        [Fact]
        public void RN05TelaRequisioMotivoRP()
        {
            driver.Navigate().GoToUrl("https://splendorous-starlight-c2b50a.netlify.app/");
            driver.Manage().Window.Size = new System.Drawing.Size(1936, 1048);
            driver.FindElement(By.Id("categoriaMotivo")).Click();
            {
                var dropdownn = driver.FindElement(By.Id("categoriaMotivo"));
                dropdownn.FindElement(By.XPath("//option[. = 'RP']")).Click();
                var pegar3 = dropdownn.FindElement(By.XPath("//option[. = 'RP']"));
                string cliente = pegar3.Text;
                Thread.Sleep(3000);

                dropdownn.FindElement(By.XPath("//option[. = 'Funções']")).Click();
                Thread.Sleep(5000);

                var pegarmaqui = dropdownn.FindElement(By.XPath("//option[. = 'Funções']"));
                string RP = pegarmaqui.Text;
                string motivo2 = "Funções";


                Thread.Sleep(8000);
                driver.Quit();


                Assert.Equal(motivo2, RP);
            }

        }

     [Theory]
     [InlineData("10")]
     [InlineData("30")]
     [InlineData("40")]
     [InlineData("2")]
        public void RN06TelaRequisioIDDepartamento(string valor)
        {
        //     //testar com 30, 40 e 2
            driver.Navigate().GoToUrl("https://splendorous-starlight-c2b50a.netlify.app/");
            driver.Manage().Window.Size = new System.Drawing.Size(1936, 1048);
            driver.FindElement(By.Id("idDepartamento")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.Id("idDepartamento")).SendKeys(valor);
            driver.FindElement(By.Id("departamento")).Click();
            driver.FindElement(By.Id("idDepartamento")).Click();

           var resultado = driver.FindElement(By.Id("departamento")).GetAttribute("value");
           string vazio = string.Empty;

           string[] Departamento = { "Sec. Educacao", "Sec. Trabalho", "NAT", vazio};
           string contemValor = Departamento.FirstOrDefault(valor => valor == resultado);

            string array = Convert.ToString(contemValor);

            driver.Quit();
            Assert.Equal(resultado, array);

        }
        [Theory]
        [InlineData("1")]
        [InlineData("3")]
        [InlineData("7")]
        [InlineData("2")]
        
        public void RN07TelaRequisioIDFunNomeFuncionrio(string idfunc)
        {
            //1, 2, 3 e 7
            driver.Navigate().GoToUrl("https://splendorous-starlight-c2b50a.netlify.app/");
            driver.Manage().Window.Size = new System.Drawing.Size(1936, 1048);
            driver.FindElement(By.Id("idFuncionario")).Click();
            driver.FindElement(By.Id("idFuncionario")).SendKeys(idfunc);
            driver.FindElement(By.CssSelector("body")).Click();
            driver.FindElement(By.Id("idFuncionario")).Click();
            Thread.Sleep(3000);
            var nomefuncionario = driver.FindElement(By.Id("NomeFuncionario")).GetAttribute("value");
            string vazia = string.Empty;
            string [] nomeespeado = {"José", "Maria", vazia, "Luiz" };
            string contemValor = nomeespeado.FirstOrDefault(valor => valor == nomefuncionario);

            string array = Convert.ToString(contemValor);

        
            driver.Quit();

            Assert.Equal(nomefuncionario,array);
           
        }

      
    }
}
























    // [Fact]
    //        public void RN06TelaRequisioIDDepartamentoID10()
    //        {
    //            driver.Navigate().GoToUrl("https://splendorous-starlight-c2b50a.netlify.app/");
    //            driver.Manage().Window.Size = new System.Drawing.Size(1936, 1048);
    //            driver.FindElement(By.Id("idDepartamento")).Click();
    //            driver.FindElement(By.Id("idDepartamento")).SendKeys("10");

    //            Thread.Sleep(3000);

    //            var resultado = driver.FindElement(By.Id("departamento")).GetAttribute("value");
    //            string veDepartamento = "Sec. Educacao";
    //            driver.Quit();
    //            Assert.Equal(resultado, veDepartamento);

    //        }
    //        [Theory]
    //        [InlineData("1")]
    //        [InlineData("4")]
    //        public void CT03R03RequisicaoQtdItem(string valoresperado)
    //        {
    //            driver.Navigate().GoToUrl("https://splendorous-starlight-c2b50a.netlify.app/");
    //            driver.Manage().Window.Size = new System.Drawing.Size(1936, 1048);
    //            driver.FindElement(By.Id("CodigoProduto")).Click();
    //            driver.FindElement(By.Id("CodigoProduto")).SendKeys("1");
    //            driver.FindElement(By.Id("Quantidade")).Click();
    //            driver.FindElement(By.Id("CodigoProduto")).SendKeys(valoresperado);
    //            driver.FindElement(By.CssSelector("#BtnInserirItens > span")).Click();
    //            Thread.Sleep(3000);
    //            IWebElement tabela = driver.FindElement(By.Id("tabelaItens"));
    //            IWebElement celula = tabela.FindElement(By.XPath(".//tr[1]/[3]"));

    //            string valorencontrado = celula.Text;
    //            driver.Quit();
    //            Assert.Equal(valoresperado, valorencontrado);
    //        }

    //        [Theory]
    //        [InlineData("1")]
    //        [InlineData("2")]
    //        public void RequisicaoTotal(string valoresperado)
    //        {
    //            driver.Navigate().GoToUrl("https://splendorous-starlight-c2b50a.netlify.app/");
    //            driver.Manage().Window.Size = new System.Drawing.Size(1936, 1048);
    //            driver.FindElement(By.Id("CodigoProduto")).Click();
    //           Thread.Sleep(4000);


    //            driver.FindElement(By.Id("CodigoProduto")).SendKeys(valoresperado);
    //            driver.FindElement(By.CssSelector("#BtnInserirItens > span")).Click();
    //            Thread.Sleep(3000);


    //            IWebElement tabela = driver.FindElement(By.Id("tabelaItens"));
    //            IWebElement celula = tabela.FindElement(By.XPath(".//tr[1]/[6]"));

    //            string valorencontrado = celula.Text;
    //            driver.Quit();
    //            Assert.Equal(valoresperado, valorencontrado);
    //        }



