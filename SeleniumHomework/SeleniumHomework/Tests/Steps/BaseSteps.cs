using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SeleniumHomework.Tests.Steps
{
	[Binding]
	internal class BaseSteps
	{
		public static IWebDriver Driver { get; private set; }

		[BeforeTestRun]
		public static void InitWebDriver()
		{
			Driver = SeleniumDriver.Driver;
		}

		[BeforeFeature("rozetka")]
		public static void InitRozetkaPageObject()
		{
			FeatureContext.Current.Add("Rozetka", new RozetkaPage(Driver));
		}

		[AfterFeature("rozetka")]
		public static void CloseDriver()
		{
			Driver.Close();
		}

	}
}
