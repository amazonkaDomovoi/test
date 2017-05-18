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
	[TestFixture]
	public class WikiTests : WikiTestsBase
	{
		[SetUp]
		public void OpenWiki()
		{
			WikiPage.Open();
		}
		

		[Test]
		public void TestWiki()
		{
			Assert.That(WikiPage.Title,Is.EqualTo("Wikipedia"));
			Assert.That(WikiPage.Language,Is.EqualTo("ru"));
		}
	}
}
