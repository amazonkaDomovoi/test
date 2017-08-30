using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TestDropboxApi.DataModels;
using TestDropboxApi.Helpers;
using TestDropboxApi.Builders;

namespace TestDropboxApi.ApiFacade
{
    public class DropboxApi
    {
        public RequestBuilder request;
        public DropboxApi()
        {
            request = new RequestBuilder(ConfigurationHelper.ServiceUrl);
        }

        public ApiResponse GetFilesList()
        {
            const string url = "files/list_folder";
            var requestBody = JsonConvert.SerializeObject(new Base());
            return request.Method(HttpMethod.Post).Uri(url).WithBody(requestBody).Execute();
        }
		public ApiResponse CreateFolder(string path)
		{
			const string url = "files/create_folder";
			var requestBody = JsonConvert.SerializeObject(new CreateFilderDto {Path = path, AutoRename = true});
			return request.Method(HttpMethod.Post).Uri(url).WithBody(requestBody).Execute();
		}

		public ApiResponse Delete(string path)
		{
			const string url = "files/delete";
			var requestBody = JsonConvert.SerializeObject(new Base { Path = path});
			return request.Method(HttpMethod.Post).Uri(url).WithBody(requestBody).Execute();
		}


	}
}
