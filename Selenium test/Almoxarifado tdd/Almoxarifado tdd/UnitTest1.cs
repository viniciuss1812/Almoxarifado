using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using HtmlAgilityPack;

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
            [Fact]
            public void RN06TelaRequisioIDDepartamentoID10()
            {
                driver.Navigate().GoToUrl("https://splendorous-starlight-c2b50a.netlify.app/");
                driver.Manage().Window.Size = new System.Drawing.Size(1936, 1048);
                driver.FindElement(By.Id("idDepartamento")).Click();
                driver.FindElement(By.Id("idDepartamento")).SendKeys("10");

                Thread.Sleep(3000);

                var resultado = driver.FindElement(By.Id("departamento")).GetAttribute("value");
                string veDepartamento = "Sec. Educacao";
                driver.Quit();
                Assert.Equal(resultado, veDepartamento);

            }
            [Theory]
            [InlineData("1")]
            [InlineData("4")]
            public void CT03R03RequisicaoQtdItem(string valoresperado)
            {
                driver.Navigate().GoToUrl("https://splendorous-starlight-c2b50a.netlify.app/");
                driver.Manage().Window.Size = new System.Drawing.Size(1936, 1048);
                driver.FindElement(By.Id("CodigoProduto")).Click();
                driver.FindElement(By.Id("CodigoProduto")).SendKeys("1");
                driver.FindElement(By.Id("Quantidade")).Click();
                driver.FindElement(By.Id("CodigoProduto")).SendKeys(valoresperado);
                driver.FindElement(By.CssSelector("#BtnInserirItens > span")).Click();
                Thread.Sleep(3000);
                IWebElement tabela = driver.FindElement(By.Id("tabelaItens"));
                IWebElement celula = tabela.FindElement(By.XPath(".//tr[1]/[3]"));

                string valorencontrado = celula.Text;
                driver.Quit();
                Assert.Equal(valoresperado, valorencontrado);
            }

            [Theory]
            [InlineData("1")]
            [InlineData("2")]
            public void RequisicaoTotal(string valoresperado)
            {
                driver.Navigate().GoToUrl("https://splendorous-starlight-c2b50a.netlify.app/");
                driver.Manage().Window.Size = new System.Drawing.Size(1936, 1048);
                driver.FindElement(By.Id("CodigoProduto")).Click();
               Thread.Sleep(4000);


                driver.FindElement(By.Id("CodigoProduto")).SendKeys(valoresperado);
                driver.FindElement(By.CssSelector("#BtnInserirItens > span")).Click();
                Thread.Sleep(3000);

                
                IWebElement tabela = driver.FindElement(By.Id("tabelaItens"));
                IWebElement celula = tabela.FindElement(By.XPath(".//tr[1]/[6]"));

                string valorencontrado = celula.Text;
                driver.Quit();
                Assert.Equal(valoresperado, valorencontrado);
            }

        
    }
}