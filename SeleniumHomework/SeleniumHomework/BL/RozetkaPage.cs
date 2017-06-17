using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumHomework.Tests.Steps;

namespace SeleniumHomework
{
	public class RozetkaPage
	{
		private IWebDriver _driver;
		private readonly TimeSpan _timeOut = TimeSpan.FromSeconds(50000);
		public WebDriverWait Wait;

		public RozetkaPage(IWebDriver driver)
		{
			_driver = driver;
			Wait = new WebDriverWait(_driver, _timeOut);
		}

		public string Url = "http://rozetka.com.ua/";
		public string SmartphonesUrl = "http://rozetka.com.ua/mobile-phones/c80003/preset=smartfon/";


		public IWebElement SearchField => _driver.FindElement(By.Name("text"));
		public IWebElement GoodsCatalogBtn => _driver.FindElement(By.XPath("//a[@id='fat_menu_btn']"));
		public List<IWebElement> GoodsCategories => _driver.FindElements(By.XPath("//a[@name='fat_menu_link']")).ToList();
		public IWebElement SearchButton => _driver.FindElement(By.Name("rz-search-button"));
		public IWebElement SearchResultTitle => _driver.FindElement(By.Id("search_result_title_text"));
		public List<IWebElement> SearchResultsTitles => _driver.FindElements(By.XPath("//div[@class=\"g-i-tile-i-title clearfix\"]/a")).ToList();
		public List<IWebElement> SearchResultsPrices => _driver.FindElements(By.XPath("//div[@name=\"price\"]/div")).ToList();
		public IWebElement ShowMoreButton => _driver.FindElement(By.Name("button_text"));

		public IWebElement SortComboBox => _driver.FindElement(By.Name("drop_link"));
		public IWebElement FilterByCheap => _driver.FindElement(By.Id("filter_sortcheap"));

		private By FilteredGoodsBuyButtons => By.XPath("//button[contains(text(),\"Купить\")]");
		private By SearchedGoodsBuyButtons => By.XPath("//div[@name=\"buy_search\"]//button");

		public List<IWebElement> GoodsInCart => _driver.FindElements(By.XPath("//div[@id=\"cart-popup\"]/div[@name=\"content\"]//div[contains(@class, 'cart-i cart-added')]")).ToList();

		public By CartXPath => By.XPath("//div[@id=\"cart-popup\"]");

		public void BuyFilteredGood(int number)
		{
			WaitUntillElementsAreFound(FilteredGoodsBuyButtons);
			_driver.FindElements(FilteredGoodsBuyButtons)[number].Click();
		}

		public void BuySearchedGood(int number)
		{
			WaitUntillElementsAreFound(SearchedGoodsBuyButtons);
			var buttonsOfSearchedElements = _driver.FindElements(SearchedGoodsBuyButtons);
			buttonsOfSearchedElements[number].Click();
		}

		public string Open()
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

			Wait.Until(d => d.Title.Contains(searchExpression));
		}

		public void FilterByProducer(params string[] names)
		{
			foreach (var name in names)
			{
				var checkBox = _driver.FindElement(By.XPath($"//ul[@id=\"sort_producer\"]/li//i[text()=\"{name}\"]"));
				Assert.IsNotNull(checkBox, $"{name} producer wasn't found!");

				checkBox.Click();

				Wait.Until(d => d.Url.Contains(name.ToLower()));
			}
		}

		public void SortByCheap()
		{
			SortComboBox.Click();
			FilterByCheap.Click();

			Wait.Until(d => d.Url.Contains("cheap"));
		}

		public void LinkFilter(string filterName)
		{
			var linkXpath = By.XPath($"//a[contains(text(), \"{filterName}\")]");

			WaitUntillElementIsFound(linkXpath);

			_driver.FindElement(linkXpath).Click();
		}

		public void WaitUntillElementIsFound(By xPath)
		{
			Wait.Until(
					d => {
						try
						{
							d.FindElement(xPath);
							return true;
						}
						catch
						{
							return false;
						}
					});
		}
		public void WaitUntillElementsAreFound(By xPath)
		{
			Wait.Until(
					d => {
						try
						{
							d.FindElements(xPath);
							return true;
						}
						catch
						{
							return false;
						}
					});
		}

		public void FilterUsingCheckBoxFilters(string filterName, List<string> filters)
		{

			foreach (var filter in filters)
			{
				var filterXpath = By.XPath($"//ul[contains(@id, \"{filterName}\")]//i[contains(text(),\"{filter}\")]");

				WaitUntillElementIsFound(filterXpath);
						            
				_driver.FindElement(filterXpath).Click();

				Wait.Until(d => d.Url.Contains(filter.ToLower().Replace(" ", "_")));
			}

		}

		public void ChooseCategoryFromCatalog(string categoryName)
		{
			var category = GoodsCategories.First(c => c.Text.Contains(categoryName));
			var href = category.GetAttribute("href");

			category.Click();

			Wait.Until(d => d.Url.Equals(href));
		}

	}


}
