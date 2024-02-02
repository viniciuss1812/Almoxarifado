using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using HtmlAgilityPack;
using OpenQA.Selenium.Interactions;
using System.Drawing;
using System.Xml.Linq;
using Microsoft.VisualStudio.TestPlatform.Common.Utilities;
using OpenQA.Selenium.Support.UI;
using System;

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
                Assert.Equal(coresperada, correal);
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
        [Fact]
        public void RN02TelaRequisioCampos()
        {
            driver.Navigate().GoToUrl("https://splendorous-starlight-c2b50a.netlify.app/");
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(120); // Aumenta para 120 segundos

            driver.Manage().Window.Size = new System.Drawing.Size(1552, 832);

            driver.FindElement(By.Id("inpNumero")).Click();
            driver.FindElement(By.Id("idDepartamento")).Click();
            driver.FindElement(By.Id("departamento")).Click();
            driver.FindElement(By.Id("dataRequisicao")).Click();
            driver.FindElement(By.Id("dataRequisicao")).Click();
            driver.FindElement(By.Id("dataRequisicao")).Click();
            driver.FindElement(By.Id("idFuncionario")).Click();
            driver.FindElement(By.Id("NomeFuncionario")).Click();
            driver.FindElement(By.Id("cargo")).Click();
            driver.FindElement(By.Id("categoriaMotivo")).Click();
            driver.FindElement(By.Id("categoriaMotivo")).Click();
            driver.FindElement(By.Id("Motivo")).Click();
            driver.FindElement(By.Id("Motivo")).Click();
            driver.FindElement(By.Id("Motivo")).Click();
            driver.FindElement(By.CssSelector(".camposPrincipaisLinha3")).Click();
            driver.FindElement(By.Id("CodigoProduto")).Click();
            driver.FindElement(By.Id("DescricaoProduto")).Click();
            driver.FindElement(By.Id("Estoque")).Click();
            driver.FindElement(By.Id("Quantidade")).Click();
            driver.FindElement(By.Id("total")).Click();
            var corverde = driver.FindElement(By.Id("BtnInserirItens")).GetCssValue("background-color"); ;
            string coresperada = Convert.ToString(corverde);

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

            Assert.Equal(coresperada, correuisição);
            Assert.Equal(coresperada, corid);
            Assert.Equal(coresperada, cordepartamento);
            Assert.Equal(coresperada, cordata);
            Assert.Equal(coresperada, coridfunc);
            Assert.Equal(coresperada, corcargo);
            Assert.Equal(coresperada, corcatmotivo);
            Assert.Equal(coresperada, cormotivo);
            Assert.Equal(coresperada, nivelprioridade);
            Assert.Equal(coresperada, corcodproduto);
            Assert.Equal(coresperada, cordesc);
            Assert.Equal(coresperada, corestoque);
            Assert.Equal(coresperada, corqtd);
            Assert.Equal(coresperada, cortotal);
        }



        [Theory]
        [InlineData("10")]
        [InlineData("30")]
        [InlineData("0")]


        public void RN03TelaRequisioCampos(string numeros)
        {
            driver.Navigate().GoToUrl("https://splendorous-starlight-c2b50a.netlify.app/");
            driver.Manage().Window.Size = new System.Drawing.Size(1936, 1048);
            driver.FindElement(By.Id("idDepartamento")).Click();
            {
                driver.FindElement(By.Id("idDepartamento")).SendKeys(numeros);
                var valores = driver.FindElement(By.Id("idDepartamento")).GetAttribute("value");
                Assert.Equal(numeros, valores);
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
                string[] categoriamotivo = { "Gestão", "Cliente", "RP" };



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

            string[] Departamento = { "Sec. Educacao", "Sec. Trabalho", "NAT", vazio };
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
            string[] nomeespeado = { "José", "Maria", vazia, "Luiz" };
            string contemValor = nomeespeado.FirstOrDefault(valor => valor == nomefuncionario);

            string array = Convert.ToString(contemValor);


            driver.Quit();

            Assert.Equal(nomefuncionario, array);

        }
        [Theory]
        [InlineData("1")]
        [InlineData("2")]
        [InlineData("7")]
        public void RN08TelaRequisioIDDescricaoEstoque(string codproduto)
        {
            driver.Navigate().GoToUrl("https://splendorous-starlight-c2b50a.netlify.app/");
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(120); // Aumenta para 120 segundos
            driver.Manage().Window.Size = new System.Drawing.Size(1936, 1048);
            driver.FindElement(By.Id("CodigoProduto")).Click();
            driver.FindElement(By.Id("CodigoProduto")).SendKeys(codproduto);
            var nomeproduto = driver.FindElement(By.Id("DescricaoProduto")).GetAttribute("value");

            var estoque = driver.FindElement(By.Id("Estoque")).GetAttribute("value");

            string vazio = string.Empty;
            string[] Nome = { "Vassoura", "Fiação", vazio };
            string[] Quantidade = { "20", "21", vazio };

            string contemnome = Nome.FirstOrDefault(valor => valor == nomeproduto);
            string contemquantidade = Quantidade.FirstOrDefault(valor => valor == estoque);

            driver.Quit();
            Assert.Equal(contemnome, nomeproduto);
            Assert.Equal(contemquantidade, estoque);

        }
        [Theory]
        [InlineData("1")]
        [InlineData("2")]

        public void RN09TelaRequisioCampoQuantidade(string codigo)
        {
            driver.Navigate().GoToUrl("https://splendorous-starlight-c2b50a.netlify.app/");
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(120);

            driver.Manage().Window.Size = new System.Drawing.Size(1552, 832);
            driver.FindElement(By.Id("CodigoProduto")).Click();
            driver.FindElement(By.Id("CodigoProduto")).SendKeys(codigo);
            driver.FindElement(By.Id("Quantidade")).SendKeys("10");
            var campohabilitado = driver.FindElement(By.Id("Quantidade")).GetAttribute("value");
            driver.Quit();
            string valoresperado = "10";
            Assert.Equal(valoresperado, campohabilitado);
        }
        [Theory]
        [InlineData("1")]
        [InlineData("2")]
        [InlineData("3")]
        public void RN09TelaRequisioCampoQuantidadeValorNegativo(string codigo)
        {
            driver.Navigate().GoToUrl("https://splendorous-starlight-c2b50a.netlify.app/");
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(120);
            driver.Manage().Window.Size = new System.Drawing.Size(1552, 832);
            driver.FindElement(By.Id("CodigoProduto")).Click();
            driver.FindElement(By.Id("CodigoProduto")).SendKeys(codigo);
            driver.FindElement(By.Id("Estoque")).Clear();
            driver.FindElement(By.Id("Estoque")).Click();
            driver.FindElement(By.Id("Estoque")).SendKeys("-1");
            var verificarcampo = driver.FindElement(By.Id("Quantidade")).GetAttribute("disabled");
            driver.Quit();
            string valoresperado ="disable";
            Assert.Equal(valoresperado, verificarcampo);
        }
        [Fact]
        public void RN10TelaRequisioCampoQuantidade()
        {
            driver.Navigate().GoToUrl("https://splendorous-starlight-c2b50a.netlify.app/");
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(120);
            driver.Manage().Window.Size = new System.Drawing.Size(1552, 832);
            driver.FindElement(By.Id("CodigoProduto")).Click();
            driver.FindElement(By.Id("CodigoProduto")).SendKeys("3");
            driver.FindElement(By.Id("Quantidade")).Click();
            driver.FindElement(By.Id("Quantidade")).SendKeys("0");
            var campohabilitado = driver.FindElement(By.Id("Quantidade")).GetAttribute("value");
            driver.Quit();
            string valoresperado = "";
            Assert.Equal(valoresperado, campohabilitado);



        }
        [Fact]
        public void RN10TelaRequisioCampoQuantidadeAceitaNegativo()
        {
            driver.Navigate().GoToUrl("https://splendorous-starlight-c2b50a.netlify.app/");
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(120);
            driver.Manage().Window.Size = new System.Drawing.Size(1552, 832);
            driver.FindElement(By.Id("CodigoProduto")).Click();
            driver.FindElement(By.Id("CodigoProduto")).SendKeys("3");
            driver.FindElement(By.Id("Quantidade")).Click();

            IWebElement codigoProdutoElement = driver.FindElement(By.Id("Quantidade"));

            Actions actions = new Actions(driver);
            actions.SendKeys(codigoProdutoElement, Keys.ArrowDown).Build().Perform();

            var campohabilitado = driver.FindElement(By.Id("Quantidade")).GetAttribute("value");
            driver.Quit();
            string valoresperado = "";
            Assert.Equal(valoresperado, campohabilitado);
           
        }
        [Theory]
        [InlineData("21")]
        [InlineData("0")]
        [InlineData("11")]
        [InlineData("20")]
        public void RN11TelaRequisioBotoGravar(string quantidade)
        {
            //quantidade informada for maior que zero e a quantidade for menor ou igual ao valor exibido no estoque
            driver.Navigate().GoToUrl("https://splendorous-starlight-c2b50a.netlify.app/");
            driver.Manage().Window.Size = new System.Drawing.Size(1936, 1048);
            driver.FindElement(By.Id("CodigoProduto")).Click();
            driver.FindElement(By.Id("CodigoProduto")).SendKeys("1");
            driver.FindElement(By.Id("Quantidade")).Click();
            driver.FindElement(By.Id("Quantidade")).SendKeys(quantidade);
            {
                var getquantidade = driver.FindElement(By.Id("Estoque")).GetAttribute("value");
                var estoque = driver.FindElement(By.Id("Estoque")).GetAttribute("value");
                if (Convert.ToInt32(getquantidade) > 0 & Convert.ToInt32(getquantidade) < Convert.ToInt32(estoque))
                {
                    var botao = driver.FindElement(By.Id("Estoque")).GetAttribute("disable");
                    string botãoesperado = null;
                    Assert.Equal(botãoesperado, botao);
                }
                else
                {
                    Assert.Fail();
                }

               


                //botão só fica ativo se a quantidade for maior que 0 e menor do valor contido no estoque

            }
                


           
        }

        [Fact]
        public void RN12TelaRequisioNivelPrioridade()
        {
            driver.Navigate().GoToUrl("https://splendorous-starlight-c2b50a.netlify.app/");
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(120);
            driver.Manage().Window.Size = new System.Drawing.Size(1936, 1048);
            Thread.Sleep(3000);

            driver.FindElement(By.Id("urgente")).Click();

            Thread.Sleep(400);
            var corurgente = driver.FindElement(By.Id("urgente")).GetCssValue("background-color");
            driver.Quit();
            var coresperadaurgente = "rgba(255, 0, 0, 0.706)";

            Assert.Equal(coresperadaurgente, corurgente);
        }
        [Fact]
        public void RN12TelaRequisioNivelPrioridademedio()
        {
            driver.Navigate().GoToUrl("https://splendorous-starlight-c2b50a.netlify.app/");
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(120);
            driver.Manage().Window.Size = new System.Drawing.Size(1936, 1048);
            Thread.Sleep(3000);
            driver.FindElement(By.Id("medio")).Click();

            Thread.Sleep(400);

            var cormedio = driver.FindElement(By.Id("medio")).GetCssValue("background-color");
            driver.Quit();

            var coresperadamedio = "rgba(255, 255, 0, 1)";
            Assert.Equal(coresperadamedio, cormedio);
        }
        [Fact]
        public void RN12TelaRequisioNivelPrioridadebaixo()
        {
            driver.Navigate().GoToUrl("https://splendorous-starlight-c2b50a.netlify.app/");
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(120);
            driver.Manage().Window.Size = new System.Drawing.Size(1936, 1048);
            Thread.Sleep(3000);
            driver.FindElement(By.Id("baixo")).Click();

            Thread.Sleep(400);

            var corbaixo = driver.FindElement(By.Id("baixo")).GetCssValue("background-color");
            driver.Quit();
            var coresperadabaixo = "rgba(0, 128, 0, 0.725)";
            Assert.Equal(coresperadabaixo, corbaixo);

        }
        [Theory]
        [InlineData("1")]
        [InlineData("2")]
        [InlineData("3")]
        
        public void RN13TelaRequisioElementoStatusEstoque(string codproduto)
        {
            driver.Navigate().GoToUrl("https://splendorous-starlight-c2b50a.netlify.app/");
            driver.Manage().Window.Size = new System.Drawing.Size(1936, 1048);
            driver.FindElement(By.Id("CodigoProduto")).Click();
            driver.FindElement(By.Id("CodigoProduto")).SendKeys(codproduto);
            {
                var valorestoque = driver.FindElement(By.Id("Estoque")).GetAttribute("value");
                var corestoque = driver.FindElement(By.Id("nivel")).GetProperty("outerHTML");

                //< img src = "assets/img/vermelho.svg" alt = "" id = "nivel" class="image-with-tooltip">
                string coresreplace = corestoque.Replace("<img","" );
                string substring = coresreplace.Substring(0,30);
                double estoqueconvert = Convert.ToDouble(valorestoque);
                double cálculo = estoqueconvert * 10 /100;


                if (estoqueconvert > cálculo)
                {
                    string imagemesperada = "assets/img/verde.svg";
                    string correal = Convert.ToString(corestoque);
                    Assert.Equal(imagemesperada, correal);
                }
                //if (estoqueconvert > cálculo)
                //{
                //    string imagemesperada = "assets/img/verde.svg";
                //    string correal = Convert.ToString(corestoque);
                //    Assert.Equal(imagemesperada, correal);
                //    //o estoque mínimo é 10, e eu tenho 9. então está abaixo do mínimo

                //}
                if (estoqueconvert < cálculo)
                {
                    string imagemesperada = "assets/img/vermelho.svg";
                    string correal = Convert.ToString(corestoque);
                    Assert.Equal(imagemesperada, correal);
                    //o estoque mínimo é 10 
                }






            }
            
        }
        [Fact]
        public void RN14TelaRequisioStatusEstoqueToolTip()
        {
            driver.Navigate().GoToUrl("https://splendorous-starlight-c2b50a.netlify.app/");
            driver.Manage().Window.Size = new System.Drawing.Size(1936, 1048);
            driver.FindElement(By.Id("nivel")).Click();
            
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



