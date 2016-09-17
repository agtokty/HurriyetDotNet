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
    public class WriterClient : BaseClient
    {
        public WriterClient(IAuthentication auth) : base(auth)
        {
        }

        #region Sync

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Writer GetWriter(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new Exception("Writer id can not be null!");
            string getUrl = string.Format("{0}/{1}/?apikey={2}", Endpoints.Writers, id, Authentication.AccessToken);
            string json = Http.WebRequest.SendGet(new Uri(getUrl));

            return Deserializer<Writer>.Deserialize(json);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Writer GetWriterByName(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new Exception("Writer name can not be null!");
            string getUrl = string.Format("{0}/?$filter=Fullname eq '{1}'&apikey={2}", Endpoints.Writers, name, Authentication.AccessToken);
            string json = Http.WebRequest.SendGet(new Uri(getUrl));

            return Deserializer<Writer>.Deserialize(json);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Column GetWritersLastColumn(string id)
        {
            string getUrl = string.Format("{0}/?$filter=WriterId eq '{1}'&$top=1&apikey={2}", Endpoints.Columns, id, Authentication.AccessToken);
            string json = Http.WebRequest.SendGet(new Uri(getUrl));

            return Deserializer<Column>.Deserialize(json);
        }

        #endregion

        #region Async

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="includeEfforts"></param>
        /// <returns></returns>
        public async Task<Writer> GetActivityAsync(string id, bool includeEfforts)
        {
            string getUrl = string.Format("{0}/{1}/?apikey={2}", Endpoints.Writers, id, Authentication.AccessToken);
            string json = await Http.WebRequest.SendGetAsync(new Uri(getUrl));

            return Deserializer<Writer>.Deserialize(json);
        }

        #endregion

    }

}
