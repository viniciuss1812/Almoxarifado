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
  public void RN07TelaRequisioIDFunNomeFuncionrio() {
    driver.Navigate().GoToUrl("https://splendorous-starlight-c2b50a.netlify.app/");
    driver.Manage().Window.Size = new System.Drawing.Size(1936, 1048);
    driver.FindElement(By.Id("idFuncionario")).Click();
    driver.FindElement(By.Id("idFuncionario")).SendKeys("1");
    driver.FindElement(By.CssSelector("body")).Click();
    driver.FindElement(By.Id("idFuncionario")).Click();
    driver.FindElement(By.Id("idFuncionario")).SendKeys("2");
    driver.FindElement(By.CssSelector("body")).Click();
    driver.FindElement(By.CssSelector("body")).Click();
    {
      var element = driver.FindElement(By.CssSelector("body"));
      Actions builder = new Actions(driver);
      builder.DoubleClick(element).Perform();
    }
    driver.FindElement(By.Id("idFuncionario")).Click();
    driver.FindElement(By.Id("idFuncionario")).SendKeys("3");
    driver.FindElement(By.CssSelector("body")).Click();
    driver.FindElement(By.CssSelector("body")).Click();
    {
      var element = driver.FindElement(By.CssSelector("body"));
      Actions builder = new Actions(driver);
      builder.DoubleClick(element).Perform();
    }
    driver.FindElement(By.Id("idFuncionario")).Click();
    driver.FindElement(By.Id("idFuncionario")).SendKeys("6");
    driver.FindElement(By.CssSelector("body")).Click();
  }
}
