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

                            string usageHour = response.Headers.GetValues("X-Ratelimit-Remaining-Hour").First();
                            string limitHour = response.Headers.GetValues("X-Ratelimit-Limit-Hour").First();

                            string usageSec = response.Headers.GetValues("X-Ratelimit-Remaining-Second").First();
                            string limitSec = response.Headers.GetValues("X-RateLimit-Limit-Second").First();

                            if (!string.IsNullOrEmpty(usageHour) && !string.IsNullOrEmpty(usageSec))
                            {
                                int _usageSec = int.Parse(usageSec);
                                int _usageHour = int.Parse(usageHour);
                                int _limitSec = 0, _limitHour = 0;

                                if (!string.IsNullOrEmpty(limitHour) && !string.IsNullOrEmpty(limitSec))
                                {
                                    _limitSec = int.Parse(limitSec);
                                    _limitHour = int.Parse(limitHour);
                                    Limits.Limit = new Limit(_limitSec, _limitHour);
                                }

                                Limits.Usage = new Usage(_limitSec - _usageSec, _limitHour - _usageHour, _limitSec, _limitHour);
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

                    string usageHour = httpResponse.GetResponseHeader("X-RateLimit-Remaining-Hour");
                    string limitHour = httpResponse.GetResponseHeader("X-RateLimit-Limit-Hour");

                    string usageSec = httpResponse.GetResponseHeader("X-RateLimit-Remaining-Second");
                    string limitSec = httpResponse.GetResponseHeader("X-RateLimit-Limit-Second");

                    if (!string.IsNullOrEmpty(usageHour) && !string.IsNullOrEmpty(usageSec))
                    {
                        int _usageSec = int.Parse(usageSec);
                        int _usageHour = int.Parse(usageHour);
                        int _limitSec = 0, _limitHour = 0;

                        if (!string.IsNullOrEmpty(limitHour) && !string.IsNullOrEmpty(limitSec))
                        {
                            _limitSec = int.Parse(limitSec);
                            _limitHour = int.Parse(limitHour);
                            Limits.Limit = new Limit(_limitSec, _limitHour);
                        }

                        Limits.Usage = new Usage(_limitSec - _usageSec, _limitHour - _usageHour, _limitSec, _limitHour);
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
