using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TestDropboxApi.DataModels
{
    public class FileResponseDtoDto : BaseResponseDto
    {
        [JsonProperty("client_modified")]
        public string ClientModified { get; set; }
        [JsonProperty("server_modified")]
        public string ServerModified { get; set; }
        [JsonProperty("rev")]
        public string Rev { get; set; }
        [JsonProperty("size")]
        public int Size { get; set; }
        [JsonProperty("content_hash")]
        public string ContentHash { get; set; }
    }

    public class FileListResponseDto
    {
        [JsonProperty("entries")]
        public List<FileResponseDtoDto> Entries { get; set; }
        [JsonProperty("cursor")]
        public string Cursor { get; set; }
        [JsonProperty("has_more")]
        public bool HasMore { get; set; }
    }

	public class FolderResponseDtoDto : BaseResponseDto
	{

	}
}
