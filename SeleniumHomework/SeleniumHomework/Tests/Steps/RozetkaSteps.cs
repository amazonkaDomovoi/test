using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SeleniumHomework.Tests.Steps
{
	[Binding]
	internal class RozetkaSteps
	{
		private RozetkaPage _rozetka;

		[Given(@"Rozetka page is opened")]
		public void GivenRozetkaIsOpened()
		{
			_rozetka = FeatureContext.Current.Get<RozetkaPage>("Rozetka");

			var currentUrl = _rozetka.Open();
			Assert.AreEqual(_rozetka.Url, currentUrl);
		}

		[Given(@"'(.*)' goods are found")]
		public void GivenGoodsAreFound(string searchedItem)
		{
			_rozetka.SearchFor(searchedItem);

			var searchedItems = _rozetka.SearchResultsTitles;
			Assert.AreEqual(searchedItems.Count,
				searchedItems.Count(item => item.Text.ToLower().Contains(searchedItem.ToLower())));
		}

		[When(@"I open catalog menu")]
		public void WhenIOpenCatalogMenu()
		{
			_rozetka.GoodsCatalogBtn.Click();
		}


		[When(@"I choose (.*) category")]
		public void WhenIOpenCategory(string categoryName)
		{
			_rozetka.ChooseCategoryFromCatalog(categoryName);
		}


		[When(@"I click (.*) laptops")]
		public void GivenAsusLaptops(string brand)
		{
			_rozetka.LinkFilter(brand);
		}


		[When(@"I filter by (.*)")]
		public void GivenGoodsAreFound(string filterName, Table searcheExpressions)
		{
			var filters = searcheExpressions.Rows.SelectMany(c => c.Values).ToList();
			_rozetka.FilterUsingCheckBoxFilters(filterName, filters);
		}

		[Scope(Tag="filter")]
		[When(@"I add first good into basket")]
		public void WhenIBuyGoodFromFilteresResults()
		{
			_rozetka.BuyFilteredGood(0);
		}

		[Scope(Tag = "search")]
		[When(@"I add first good into basket")]
		public void WhenIBuyGoodFromSearchResults()
		{
			_rozetka.BuySearchedGood(0);
		}

		[Then(@"I can see choosen goods in basket")]
		public void ThenICanSeeChoosenGoodsInBasket()
		{
			
			_rozetka.WaitUntillElementIsFound(_rozetka.CartXPath);

			var goodsInCart = _rozetka.GoodsInCart;
			Assert.AreEqual(1, goodsInCart.Count);
		}
	}
}
