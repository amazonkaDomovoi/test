using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using TechTalk.SpecFlow;
using TestDropboxApi.ApiFacade;
using TestDropboxApi.DataModels;
using TestDropboxApi.Helpers;

namespace Dropbox.Api.Tests.StepDefinitions
{
	[Binding]
	public class FoldersManager
	{
		[Given(@"'(.*)' folder is created")]
		[When(@"I create '(.*)' folder")]
		public void WhenICreateFolder(string folderPath)
		{
			var response = new DropboxApi().CreateFolder(folderPath);
			response.EnsureSuccessful();

			ContextHelper.AddToContext("LastApiResponse", response);
		}

		[Then(@"The folder exists")]
		public void ThenTheFolderExists()
		{
			var apiResponse = ContextHelper.GetFromContext<ApiResponse>("LastApiResponse");
			var createdFolder = apiResponse.Content<FolderResponseDtoDto>();
			createdFolder.Should().NotBeNull();
			createdFolder.Id.Replace("id:",string.Empty).Should().NotBeNullOrEmpty();
		}

	}
}
