using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HurriyetDotNet.Models
{
    public class Path
    {
        public string Id { get; set; }

        [JsonProperty("Path")]
        public string PathName { get; set; }

        public string Title { get; set; }

    }
 
}
