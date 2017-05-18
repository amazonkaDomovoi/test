using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace NUnit_HW
{
	public class WikiTestsBase
	{
		protected WikiPage WikiPage{ get; private set; }

		[OneTimeSetUp]
		public void InitDriverAndNavigateToWikipedia()
		{
			WikiPage = new WikiPage(SeleniumDriver.Driver);
		}

		[OneTimeTearDown]
		public void KillDriver()
		{
			SeleniumDriver.Driver.Quit();
		}
	}
}
