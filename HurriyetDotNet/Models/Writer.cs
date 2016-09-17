using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HurriyetDotNet.Models
{
    public class Writer
    {
        public string Id { get; set; }

        [JsonProperty("Fullname")]
        public string FullName { get; set; }

        public ContentType ContentType { get; set; }

        public DateTime CreatedDate { get; set; }

        public List<File> Files { get; set; }

        public string Path { get; set; }

        public string Url { get; set; }
    }
}
