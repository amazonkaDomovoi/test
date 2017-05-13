using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumHomework
{
	public class RozetkaPage
	{
		private IWebDriver _driver;

		public RozetkaPage(IWebDriver driver)
		{
			_driver = driver;
		}

		public string Url = "http://rozetka.com.ua/";
		public string SmartphonesUrl = "http://rozetka.com.ua/mobile-phones/c80003/preset=smartfon/";

		public IWebElement SearchField => _driver.FindElement(By.Name("text"));
		public IWebElement SearchButton => _driver.FindElement(By.Name("rz-search-button"));
		public IWebElement SearchResultTitle => _driver.FindElement(By.Id("search_result_title_text"));
		public List<IWebElement> SearchResultsTitles => _driver.FindElements(By.XPath("//div[@class=\"g-i-tile-i-title clearfix\"]/a")).ToList();
		public List<IWebElement> SearchResultsPrices => _driver.FindElements(By.XPath("//div[@name=\"price\"]/div")).ToList();
		public IWebElement ShowMoreButton => _driver.FindElement(By.Name("button_text"));

		public IWebElement SortComboBox => _driver.FindElement(By.Name("drop_link"));
		public IWebElement FilterByCheap => _driver.FindElement(By.Id("filter_sortcheap"));

		public string  Open()
		{
			_driver.Navigate().GoToUrl(Url);
			return _driver.Url;
		}

		public string OpenSmartphonesSection()
		{
			_driver.Navigate().GoToUrl(SmartphonesUrl);
			return _driver.Url;
		}

		public void SearchFor(string searchExpression)
		{
			SearchField.Clear();
			SearchField.SendKeys(searchExpression);
			SearchButton.Click();
		}

		public void FilterByProducer(params string[] names)
		{
			foreach (var name in names)
			{
				var checkBox = _driver.FindElement(By.XPath($"//ul[@id=\"sort_producer\"]/li//i[text()=\"{name}\"]"));
				Assert.IsNotNull(checkBox, $"{name} producer wasn't found!");

				checkBox.Click();

				var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
				wait.Until(d => d.Url.Contains(name.ToLower()));
			}
		}

		public void SortByCheap()
		{
			SortComboBox.Click();
			FilterByCheap.Click();

			var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
			wait.Until(d => d.Url.Contains("cheap"));
		}

	}


}
