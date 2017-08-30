using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TestDropboxApi.ApiFacade;
using TestDropboxApi.Helpers;

namespace Dropbox.Api.Tests.StepDefinitions
{
	[Binding]
	public class CommonSteps
	{
		[When(@"I delete '(.*)' (?:folder|file)")]
		public void WhenIDelete(string entityPath)
		{
			var response = new DropboxApi().Delete(entityPath);
			response.EnsureSuccessful();

			ContextHelper.AddToContext("LastApiResponse", response);
		}

	}

}
