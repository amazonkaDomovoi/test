using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TestDropboxApi.DataModels
{
	public class BaseResponseDto
	{
		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("path_lower")]
		public string PathLower { get; set; }

		[JsonProperty("path_display")]
		public string PathDisplay { get; set; }
		[JsonProperty("id")]
		public string Id { get; set; }
	}
}
