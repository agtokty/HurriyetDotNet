using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HurriyetDotNet.Auth;
using HurriyetDotNet.Models;
using HurriyetDotNet.Api;
using HurriyetDotNet.Util;
using HurriyetDotNet.Client.EventArgs;

namespace HurriyetDotNet.Client
{
    /// <summary>
    /// 
    /// </summary>
    public class ColumnClient : BaseClient
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="auth"></param>
        public ColumnClient(IAuthentication auth) : base(auth) { }

        public event EventHandler<ColumnReceivedEventArgs> ColumnReceived;

        #region Sync

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Column GetColumn(string id)
        {
            string getUrl = string.Format("{0}/{1}/?apikey={2}", Endpoints.Columns, id, Authentication.AccessToken);
            string json = Http.WebRequest.SendGet(new Uri(getUrl));

            return Deserializer<Column>.Deserialize(json);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="writerId"></param>
        /// <returns></returns>
        public List<Column> GetAllColumnsByWiter(string writerId)
        {
            string getUrl = string.Format("{0}/?Filter=WriterId eq '{1}'&apikey={2}", Endpoints.Columns, writerId, Authentication.AccessToken);
            string json = Http.WebRequest.SendGet(new Uri(getUrl));

            return Deserializer<List<Column>>.Deserialize(json);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <param name="perPage"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public List<Column> GetColumns(int top, int skip, string filter = null)
        {
            string getUrl = "";
            if (string.IsNullOrEmpty(filter))
                getUrl = string.Format("{0}/?$top={1}$skip={2}&apikey={3}", Endpoints.Columns, top, skip, Authentication.AccessToken);
            else
                getUrl = string.Format("{0}/?Filter={1}&apikey={2}", Endpoints.Columns, filter, Authentication.AccessToken);

            string json = Http.WebRequest.SendGet(new Uri(getUrl));

            return Deserializer<List<Column>>.Deserialize(json);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="writerId"></param>
        /// <param name="lastNColumn"></param>
        /// <returns></returns>
        public List<Column> GetLastColumnsByWiter(string writerId, int lastNColumn)
        {
            string getUrl = string.Format("{0}/?Filter=WriterId eq '{1}'&$top={2}&apikey={3}", Endpoints.Columns, writerId, lastNColumn, Authentication.AccessToken);
            string json = Http.WebRequest.SendGet(new Uri(getUrl));

            return Deserializer<List<Column>>.Deserialize(json);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="writerId"></param>
        /// <param name="after"></param>
        /// <returns></returns>
        public List<Column> GetColumnsByWiter(string writerId, DateTime after)
        {
            string getUrl = string.Format("{0}/?Filter=WriterId eq '{1}' and CreatedDate gt '{2}'&apikey={3}",
                Endpoints.Columns, writerId, after.ToString(ConfAndConstants.DateFormat), Authentication.AccessToken);
            string json = Http.WebRequest.SendGet(new Uri(getUrl));

            return Deserializer<List<Column>>.Deserialize(json);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lastNColumn"></param>
        /// <returns></returns>
        public List<Column> GetLastNColumn(int lastNColumn)
        {
            string getUrl = string.Format("{0}/?$top={1}&apikey={2}", Endpoints.Columns, lastNColumn, Authentication.AccessToken);
            string json = Http.WebRequest.SendGet(new Uri(getUrl));

            return Deserializer<List<Column>>.Deserialize(json);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="after"></param>
        /// <param name="before"></param>
        /// <returns></returns>
        public List<Column> GetLastColumns(DateTime? after = null, DateTime? before = null)
        {
            string getUrl = "";
            if (after != null && before != null)
            {
                getUrl = string.Format("{0}/?$filter=CreatedDate gt '{1}'&apikey={3}",
                    Endpoints.Articles, after?.ToString(ConfAndConstants.DateFormat), Authentication.AccessToken);
            }
            else if (after != null && before == null)
            {
                getUrl = string.Format("{0}/?$filter=CreatedDate lt '{1}'&apikey={3}",
                    Endpoints.Articles, before?.ToString(ConfAndConstants.DateFormat), Authentication.AccessToken);
            }
            else if (after == null && before != null)
            {
                getUrl = string.Format("{0}/?$filter=CreatedDate gt '{1}' CreatedDate lt '{1}'and &apikey={3}",
                   Endpoints.Articles, before?.ToString(ConfAndConstants.DateFormat), Authentication.AccessToken);
            }

            if (!string.IsNullOrEmpty(getUrl))
            {
                string json = Http.WebRequest.SendGet(new Uri(getUrl));
                return Deserializer<List<Column>>.Deserialize(json);
            }

            return new List<Column>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="writerId"></param>
        /// <returns></returns>
        public List<Column> GetTodayColumns(string writerId = null)
        {
            string getUrl = string.Empty;
            DateTime TD = DateTime.Today;
            DateTime today = new DateTime(TD.Year, TD.Month, TD.Day, 0, 0, 0);
            if (string.IsNullOrEmpty(writerId))
                getUrl = string.Format("{0}/?$filter=CreatedDate gt '{1}'&apikey={2}",
                    Endpoints.Articles, today.ToString(ConfAndConstants.DateFormat), Authentication.AccessToken);
            else
                getUrl = string.Format("{0}/?$filter=CreatedDate gt '{1}' WiterId eq '{2}'and &apikey={3}",
                   Endpoints.Articles, today.ToString(ConfAndConstants.DateFormat), writerId, Authentication.AccessToken);

            string json = Http.WebRequest.SendGet(new Uri(getUrl));
            return Deserializer<List<Column>>.Deserialize(json);
        }

        /// <summary>
        /// Verilen güne ait köşe yazılarını getirir.
        /// </summary>
        /// <param name="writerId"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        public List<Column> GetDayColumns(DateTime day, string writerId = null)
        {
            DateTime dayBengin = new DateTime(day.Year, day.Month, day.Day, 0, 0, 0);
            DateTime dayEnd = new DateTime(day.Year, day.Month, day.Day, 23, 59, 59);
            string getUrl = "";
            if (string.IsNullOrEmpty(writerId))
                getUrl = string.Format("{0}/?$filter=CreatedDate gt '{1}' and CreatedDate lt '{2}'&apikey={3}",
                 Endpoints.Articles, dayBengin.ToString(ConfAndConstants.DateFormat), dayEnd.ToString(ConfAndConstants.DateFormat), Authentication.AccessToken);
            else
                getUrl = string.Format("{0}/?$filter=CreatedDate gt '{1}' and CreatedDate lt '{2}'and  WiterId eq '{3}'&apikey={4}",
                 Endpoints.Articles, dayBengin.ToString(ConfAndConstants.DateFormat), dayEnd.ToString(ConfAndConstants.DateFormat), writerId, Authentication.AccessToken);

            string json = Http.WebRequest.SendGet(new Uri(getUrl));

            return Deserializer<List<Column>>.Deserialize(json);
        }

        #endregion

        #region Async

        //TODO - ColumnClient Async metodlar

        #endregion
    }
}
