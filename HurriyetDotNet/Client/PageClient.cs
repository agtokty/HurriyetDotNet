using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HurriyetDotNet.Auth;
using HurriyetDotNet.Models;
using HurriyetDotNet.Api;
using HurriyetDotNet.Util;

namespace HurriyetDotNet.Client
{
    /// <summary>
    /// 
    /// </summary>
    public class PageClient : BaseClient
    {
        public PageClient(IAuthentication auth) : base(auth)
        {

        }

        #region Sync

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Page GetPage(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new Exception("Page id can not be null!");
            string getUrl = string.Format("{0}/{1}/?apikey={2}", Endpoints.Pages, id, Authentication.AccessToken);
            string json = Http.WebRequest.SendGet(new Uri(getUrl));

            return Deserializer<Page>.Deserialize(json);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Page> GetAllPages()
        {
            string getUrl = string.Format("{0}/?apikey={2}", Endpoints.Pages, Authentication.AccessToken);
            string json = Http.WebRequest.SendGet(new Uri(getUrl));

            return Deserializer<List<Page>>.Deserialize(json);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public List<Page> SearchPageByTitle(string title)
        {
            string getUrl = string.Format("{0}/?$filter=Title eq '{1}'&apikey={2}", Endpoints.Pages, title, Authentication.AccessToken);
            string json = Http.WebRequest.SendGet(new Uri(getUrl));

            return Deserializer<List<Page>>.Deserialize(json);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public Page GetPageCustomFilter(string filter)
        {
            if (string.IsNullOrEmpty(filter))
                throw new Exception("Custom filter can not be null!");
            string getUrl = string.Format("{0}/?$filter={1}&top=1&apikey={2}", Endpoints.Pages, filter, Authentication.AccessToken);
            string json = Http.WebRequest.SendGet(new Uri(getUrl));

            return Deserializer<Page>.Deserialize(json);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public List<Page> GetAllPagesCustomFilter(string filter)
        {
            if (string.IsNullOrEmpty(filter))
                throw new Exception("Custom filter can not be null!");
            string getUrl = string.Format("{0}/?$filter={1}&apikey={2}", Endpoints.Pages, filter, Authentication.AccessToken);
            string json = Http.WebRequest.SendGet(new Uri(getUrl));

            return Deserializer<List<Page>>.Deserialize(json);
        }


        #endregion

        #region Async

        //TODO - PageClient Async metodlar

        #endregion
    }
}
