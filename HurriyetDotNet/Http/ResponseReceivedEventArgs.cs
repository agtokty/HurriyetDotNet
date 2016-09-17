using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HurriyetDotNet.Http
{
    public class ResponseReceivedEventArgs
    {
        public HttpWebResponse Response { get; set; }

        public ResponseReceivedEventArgs(HttpWebResponse response)
        {
            Response = response;
        }
    }
}
