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

                            string usageHour = response.Headers.GetValues("X-RateLimit-Remaining-hour").First();
                            string limitHour = response.Headers.GetValues("X-RateLimit-Limit-hour").First();

                            string usageSec = response.Headers.GetValues("X-RateLimit-Remaining-second").First();
                            string limitSec = response.Headers.GetValues("X-RateLimit-Limit-second").First();

                            if (!string.IsNullOrEmpty(usageHour) && !string.IsNullOrEmpty(usageSec))
                            {
                                Limits.Usage = new Usage(Int32.Parse(usageSec), Int32.Parse(usageHour));
                            }

                            if (!string.IsNullOrEmpty(limitHour) && !string.IsNullOrEmpty(limitSec))
                            {
                                Limits.Limit = new Limit(Int32.Parse(usageSec), Int32.Parse(usageHour));
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

                    string usageHour = httpResponse.GetResponseHeader("X-RateLimit-Remaining-hour");
                    string limitHour = httpResponse.GetResponseHeader("X-RateLimit-Limit-hour");

                    string usageSec = httpResponse.GetResponseHeader("X-RateLimit-Remaining-second");
                    string limitSec = httpResponse.GetResponseHeader("X-RateLimit-Limit-second");

                    if (!string.IsNullOrEmpty(usageHour) && !string.IsNullOrEmpty(usageSec))
                    {
                        Limits.Usage = new Usage(Int32.Parse(usageSec), Int32.Parse(usageHour));
                    }

                    if (!string.IsNullOrEmpty(limitHour) && !string.IsNullOrEmpty(limitSec))
                    {
                        Limits.Limit = new Limit(Int32.Parse(usageSec), Int32.Parse(usageHour));
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
