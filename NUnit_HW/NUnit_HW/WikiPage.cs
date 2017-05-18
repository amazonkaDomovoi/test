using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace NUnit_HW
{
	public class WikiPage
	{
		private readonly IWebDriver _driver;
		public readonly string Url = "https://www.wikipedia.org/";

		public string Title => _driver.Title;
		public string Language => _driver.FindElement(By.XPath("/html")).GetAttribute("lang");

		public WikiPage(IWebDriver driver)
		{
			_driver = driver;
		}

		public void Open()
		{
			_driver.Navigate().GoToUrl(Url);
		}

	}
}
