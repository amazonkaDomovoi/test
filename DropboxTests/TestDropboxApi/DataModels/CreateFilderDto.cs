using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TestDropboxApi.DataModels
{
	public class CreateFilderDto : Base
	{
		[JsonProperty("autorename")]
		public bool AutoRename { get; set; }
	}

}
