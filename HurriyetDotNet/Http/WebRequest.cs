using HurriyetDotNet.Api;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HurriyetDotNet.Http
{
    class WebRequest
    {
        public static HttpStatusCode ResponseCode { get; set; }

        public static event EventHandler<AsyncResponseReceivedEventArgs> AsyncResponseReceived;

        public static event EventHandler<ResponseReceivedEventArgs> ResponseReceived;

        public static async Task<String> SendGetAsync(Uri uri)
        {
            if (uri == null)
            {
                throw new ArgumentException("Parameter uri must not be null. Please commit a valid Uri object.");
            }

            using (var httpClient = new HttpClient())
            {
                using (HttpResponseMessage response = await httpClient.GetAsync(uri))
                {
                    if (response != null)
                    {
                        AsyncResponseReceived?.Invoke(null, new AsyncResponseReceivedEventArgs(response));

                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            KeyValuePair<String, IEnumerable<String>> usage = response.Headers.ToList().Find(x => x.Key.Equals("X-RateLimit-Remaining-hour"));

                            if (usage.Value != null)
                            {
                                Limits.Usage = new Usage(Int32.Parse(usage.Value.ElementAt(0).Split(',')[0]),
                                    Int32.Parse(usage.Value.ElementAt(0).Split(',')[1]));
                            }

                            KeyValuePair<String, IEnumerable<String>> limit = response.Headers.ToList().Find(x => x.Key.Equals("X-RateLimit-Limit-hour"));

                            if (limit.Value != null)
                            {
                                Limits.Limit = new Limit(Int32.Parse(limit.Value.ElementAt(0).Split(',')[0]),
                                    Int32.Parse(limit.Value.ElementAt(0).Split(',')[1]));
                            }

                            ResponseCode = response.StatusCode;
                            return await response.Content.ReadAsStringAsync();
                        }
                    }
                }
            }

            return string.Empty;
        }

        public static string SendGet(Uri uri)
        {
            HttpWebRequest httpRequest = (HttpWebRequest)System.Net.WebRequest.Create(uri);
            httpRequest.Method = "GET";

            using (HttpWebResponse httpResponse = (HttpWebResponse)httpRequest.GetResponse())
            {
                Stream responseStream = httpResponse.GetResponseStream();

                if (responseStream != null)
                {
                    ResponseReceived?.Invoke(null, new ResponseReceivedEventArgs(httpResponse));

                    string usage = httpResponse.GetResponseHeader("X-RateLimit-Remaining-hour");

                    string limit = httpResponse.GetResponseHeader("X-RateLimit-Limit-hour");

                    if (!string.IsNullOrEmpty(usage))
                    {
                        Limits.Usage = new Usage(Int32.Parse(usage.Split(',')[0]), Int32.Parse(usage.Split(',')[1]));
                    }

                    if (!string.IsNullOrEmpty(limit))
                    {
                        Limits.Limit = new Limit(Int32.Parse(limit.Split(',')[0]), Int32.Parse(limit.Split(',')[1]));
                    }

                    StreamReader reader = new StreamReader(responseStream);
                    string response = reader.ReadToEnd();

                    reader.Close();
                    responseStream.Close();

                    return response;
                }
            }

            return string.Empty;
        }

    }
}
