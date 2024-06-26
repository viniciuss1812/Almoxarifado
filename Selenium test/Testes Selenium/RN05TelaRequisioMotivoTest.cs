// Generated by Selenium IDE
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using Xunit;
public class SuiteTests : IDisposable {
  public IWebDriver driver {get; private set;}
  public IDictionary<String, Object> vars {get; private set;}
  public IJavaScriptExecutor js {get; private set;}
  public SuiteTests()
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
  public void RN05TelaRequisioMotivo() {
    driver.Navigate().GoToUrl("https://splendorous-starlight-c2b50a.netlify.app/");
    driver.Manage().Window.Size = new System.Drawing.Size(1936, 1048);
    driver.FindElement(By.Id("categoriaMotivo")).Click();
    {
      var dropdown = driver.FindElement(By.Id("categoriaMotivo"));
      dropdown.FindElement(By.XPath("//option[. = 'Gestão']")).Click();
    }
    driver.FindElement(By.Id("Motivo")).Click();
    {
      var dropdown = driver.FindElement(By.Id("Motivo"));
      dropdown.FindElement(By.XPath("//option[. = 'Planejamento']")).Click();
    }
    driver.FindElement(By.Id("Motivo")).Click();
    {
      var dropdown = driver.FindElement(By.Id("Motivo"));
      dropdown.FindElement(By.XPath("//option[. = 'Financeiro']")).Click();
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
    driver.FindElement(By.Id("categoriaMotivo")).Click();
    {
      var dropdown = driver.FindElement(By.Id("categoriaMotivo"));
      dropdown.FindElement(By.XPath("//option[. = 'RP']")).Click();
    }
    driver.FindElement(By.Id("Motivo")).Click();
    {
      var dropdown = driver.FindElement(By.Id("Motivo"));
      dropdown.FindElement(By.XPath("//option[. = 'Funções']")).Click();
    }
    driver.FindElement(By.Id("categoriaMotivo")).Click();
    {
      var dropdown = driver.FindElement(By.Id("categoriaMotivo"));
      dropdown.FindElement(By.XPath("//option[. = 'label']")).Click();
    }
  }
}
