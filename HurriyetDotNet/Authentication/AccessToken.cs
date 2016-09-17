using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HurriyetDotNet.Auth
{
    /// <summary>
    ///
    /// </summary>
    public class AccessToken
    {
        [JsonProperty("apikey")]
        public string Token { get; set; }
    }
}
