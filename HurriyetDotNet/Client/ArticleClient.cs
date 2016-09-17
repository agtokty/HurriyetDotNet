using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HurriyetDotNet.Auth;
using HurriyetDotNet.Api;
using HurriyetDotNet.Models;
using HurriyetDotNet.Util;

namespace HurriyetDotNet.Client
{
    /// <summary>
    /// 
    /// </summary>
    public class ArticleClient : BaseClient
    {
        public ArticleClient(IAuthentication auth) : base(auth)
        {

        }


        #region Sync

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Article GetArticle(string id)
        {
            string getUrl = string.Format("{0}/{1}/?apikey={2}", Endpoints.Articles, id, Authentication.AccessToken);
            string json = Http.WebRequest.SendGet(new Uri(getUrl));

            return Deserializer<Article>.Deserialize(json);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public List<Article> GetArticles(string title)
        {
            string getUrl = string.Format("{0}/?$filter=Title eq '{1}'&apikey={2}", Endpoints.Articles, title, Authentication.AccessToken);
            string json = Http.WebRequest.SendGet(new Uri(getUrl));

            return Deserializer<List<Article>>.Deserialize(json);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="title"></param>
        /// <param name="path">Article path</param>
        /// <returns></returns>
        public List<Article> GetArticles(string title, string path)
        {
            if (string.IsNullOrEmpty(path))
                return GetArticles(title);

            string getUrl = string.Empty;
            if (string.IsNullOrEmpty(title))
                getUrl = string.Format("{0}/?$filter=Path eq '{1}'&apikey={2}", Endpoints.Articles, path, Authentication.AccessToken);
            else
                getUrl = string.Format("{0}/?$filter=Title eq '{1}' and Path eq '{2}'&apikey={3}", Endpoints.Articles, title, path, Authentication.AccessToken);

            string json = Http.WebRequest.SendGet(new Uri(getUrl));

            return Deserializer<List<Article>>.Deserialize(json);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public List<Article> GetArticlesByPath(string path)
        {
            if (string.IsNullOrEmpty(path))
                throw new Exception("path can not be null!");
            string getUrl = string.Format("{0}/?$filter=Path eq '{1}'&apikey={2}", Endpoints.Articles, path, Authentication.AccessToken);

            string json = Http.WebRequest.SendGet(new Uri(getUrl));

            return Deserializer<List<Article>>.Deserialize(json);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tags"></param>
        /// <returns></returns>
        public List<Article> GetArticles(string[] tags)
        {
            throw new NotImplementedException();
        }






        /// <summary>
        /// 
        /// </summary>
        /// <param name="after"></param>
        /// <param name="before"></param>
        /// <returns></returns>
        public List<Article> GetArticlesByTime(DateTime? after = null, DateTime? before = null)
        {
            string getUrl = "";
            if (after != null && before != null)
            {
                getUrl = string.Format("{0}/?$filter=CreatedDate gt '{1}'&apikey={2}",
                    Endpoints.Articles, after?.ToString(ConfAndConstants.DateFormat), Authentication.AccessToken);
            }
            else if (after != null && before == null)
            {
                getUrl = string.Format("{0}/?$filter=CreatedDate lt '{1}'&apikey={2}",
                    Endpoints.Articles, before?.ToString(ConfAndConstants.DateFormat), Authentication.AccessToken);
            }
            else if (after == null && before != null)
            {
                getUrl = string.Format("{0}/?$filter=CreatedDate gt '{1}' CreatedDate lt '{2}'and &apikey={3}",
                   Endpoints.Articles, after?.ToString(ConfAndConstants.DateFormat), before?.ToString(ConfAndConstants.DateFormat), Authentication.AccessToken);
            }

            if (!string.IsNullOrEmpty(getUrl))
            {
                string json = Http.WebRequest.SendGet(new Uri(getUrl));
                return Deserializer<List<Article>>.Deserialize(json);
            }

            return new List<Article>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lastN"></param>
        /// <returns></returns>
        public List<Article> GetLastNArticles(int lastN)
        {
            if (lastN <= 0)
                lastN = 1;
            string getUrl = string.Format("{0}/?$top={1}&apikey={2}", Endpoints.Articles, lastN, Authentication.AccessToken);
            string json = Http.WebRequest.SendGet(new Uri(getUrl));
            return Deserializer<List<Article>>.Deserialize(json);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public List<Article> GetTodayArticles(string path = null)
        {
            string getUrl = string.Empty;
            DateTime TD = DateTime.Today;
            DateTime today = new DateTime(TD.Year, TD.Month, TD.Day, 0, 0, 0);
            if (string.IsNullOrEmpty(path))
                getUrl = string.Format("{0}/?$filter=CreatedDate gt '{1}'&apikey={2}",
                    Endpoints.Articles, today.ToString(ConfAndConstants.DateFormat), Authentication.AccessToken);
            else
                getUrl = string.Format("{0}/?$filter=CreatedDate gt '{1}' and Path eq '{2}'&apikey={3}",
                   Endpoints.Articles, today.ToString(ConfAndConstants.DateFormat), path, Authentication.AccessToken);

            string json = Http.WebRequest.SendGet(new Uri(getUrl));
            return Deserializer<List<Article>>.Deserialize(json);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="day"></param>
        /// <returns></returns>
        public List<Article> GetDayArticle(DateTime day, string path = null)
        {
            DateTime dayBengin = new DateTime(day.Year, day.Month, day.Day, 0, 0, 0);
            DateTime dayEnd = new DateTime(day.Year, day.Month, day.Day, 23, 59, 59);
            string getUrl = null;
            if (string.IsNullOrEmpty(path))
                getUrl = string.Format("{0}/?$filter=CreatedDate gt '{1}' and CreatedDate lt '{2}'&apikey={3}",
                   Endpoints.Articles, dayBengin.ToString(ConfAndConstants.DateFormat), dayEnd.ToString(ConfAndConstants.DateFormat), Authentication.AccessToken);
            else
                getUrl = string.Format("{0}/?$filter=CreatedDate gt '{1}' and CreatedDate lt '{2}' and Path eq '{3}'&apikey={4}",
                    Endpoints.Articles, dayBengin.ToString(ConfAndConstants.DateFormat), dayEnd.ToString(ConfAndConstants.DateFormat), path, Authentication.AccessToken);

            string json = Http.WebRequest.SendGet(new Uri(getUrl));
            return Deserializer<List<Article>>.Deserialize(json);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter">OData filter i.e : columnname eq 'foo', id eq 1 ..</param>
        /// <returns></returns>
        public Article GetArticleCustomFilter(string filter)
        {
            if (string.IsNullOrEmpty(filter))
                throw new Exception("Custom filter can not be null!");
            string getUrl = string.Format("{0}/?$filter={1}&apikey={2}", Endpoints.Articles, filter, Authentication.AccessToken);
            string json = Http.WebRequest.SendGet(new Uri(getUrl));

            return Deserializer<Article>.Deserialize(json);
        }

        #endregion

        #region Async

        //TODO - ArticleClient Async metodlar

        #endregion
    }

}
