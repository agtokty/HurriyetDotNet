using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HurriyetDotNet.Http
{
    public class AsyncResponseReceivedEventArgs
    {
        public HttpResponseMessage Response { get; set; }

        public AsyncResponseReceivedEventArgs(HttpResponseMessage response)
        {
            Response = response;
        }
    }
}
