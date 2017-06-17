using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace SeleniumHomework
{
	public static class SeleniumDriver
	{
		private static IWebDriver _driver;

		public static IWebDriver Driver
		{
			get { return _driver ?? (_driver = new FirefoxDriver()); }
			set { _driver = value; }
		}
	}
}
