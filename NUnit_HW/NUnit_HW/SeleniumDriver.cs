using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace NUnit_HW
{
	public static class SeleniumDriver
	{
		private static IWebDriver _driver;
		
		public static IWebDriver Driver
		{
			get
			{
				return _driver ?? (_driver = new FirefoxDriver());
			}
			set { _driver = value; }
		}

	}
}
