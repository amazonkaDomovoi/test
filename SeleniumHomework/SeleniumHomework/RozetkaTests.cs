using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumHomework
{
	[TestClass]
	public class RozetkaTests
	{
		[TestMethod]
		public void Search()
		{
			var driver = SeleniumDriver.Driver;
			var rozetka = new RozetkaPage(driver);

			var currentUrl = rozetka.Open();
			Assert.AreEqual(rozetka.Url, currentUrl);

			rozetka.SearchFor("Hyundai");

			var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
			wait.Until(d => d.Title.Contains("Hyundai"));

			//Verify that all shown are 'Hyundai'
			Assert.AreEqual(rozetka.SearchResultsTitles.Count, rozetka.SearchResultsTitles.Count(item => item.Text.Contains("Hyundai")));

			Assert.AreEqual("Показать еще 32 товара", rozetka.ShowMoreButton.Text.Replace(Environment.NewLine," "));
		}

		[TestMethod]
		public void Filtering()
		{
			var driver = SeleniumDriver.Driver;
			var rozetka = new RozetkaPage(driver);

			var currentUrl = rozetka.OpenSmartphonesSection();
			Assert.AreEqual(rozetka.SmartphonesUrl, currentUrl);

			rozetka.FilterByProducer("Apple", "Samsung");

			//Verify that all shown are "Apple" or "Samsung"
			Assert.AreEqual(rozetka.SearchResultsTitles.Count, rozetka.SearchResultsTitles.Count(item => item.Text.Contains("Apple")|| item.Text.Contains("Samsung")));

			rozetka.SortByCheap();

			// Verify that all items shown are properly sorted
			var searchResults = rozetka.SearchResultsPrices;
			var orderedResults = searchResults.ToList();
			orderedResults.Sort((price1, price2) =>
			{
				var convertedPrice1 = ConverToNumeric(price1);
				var convertedPrice2 = ConverToNumeric(price2);

				if (convertedPrice1 == 0 || convertedPrice2 == 0) return 1;

				return convertedPrice1.CompareTo(convertedPrice2);
			});
			orderedResults.Reverse();

			Assert.IsTrue(searchResults.SequenceEqual(orderedResults));
		}

		private static long ConverToNumeric(IWebElement price)
		{
			long converted;
			long.TryParse(price.Text.Replace("грн", string.Empty).Replace(" ", ""), out converted);
			return converted;
		}


		[ClassCleanup]
		public static void KillDriver()
		{
			//SeleniumDriver.Driver.Quit();
		}

	}
}
