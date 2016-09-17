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
    public class PathClient : BaseClient
    {
        public PathClient(IAuthentication auth) : base(auth) { }

        #region Sync

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Path GetPath(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new Exception("Path id can not be null!");
            string getUrl = string.Format("{0}/{1}/?apikey={2}", Endpoints.Paths, id, Authentication.AccessToken);
            string json = Http.WebRequest.SendGet(new Uri(getUrl));

            return Deserializer<Path>.Deserialize(json);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Path> GetAllPaths()
        {
            string getUrl = string.Format("{0}/?apikey={2}", Endpoints.Paths, Authentication.AccessToken);
            string json = Http.WebRequest.SendGet(new Uri(getUrl));

            return Deserializer<List<Path>>.Deserialize(json);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public Path GetPathCustomFilter(string filter)
        {
            if (string.IsNullOrEmpty(filter))
                throw new Exception("Custom filter can not be null!");
            string getUrl = string.Format("{0}/?$filter={1}&top=1&apikey={2}", Endpoints.Paths, filter, Authentication.AccessToken);
            string json = Http.WebRequest.SendGet(new Uri(getUrl));

            return Deserializer<Path>.Deserialize(json);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public List<Path> GetAllPathsCustomFilter(string filter)
        {
            if (string.IsNullOrEmpty(filter))
                throw new Exception("Custom filter can not be null!");
            string getUrl = string.Format("{0}/?$filter={1}&apikey={2}", Endpoints.Paths, filter, Authentication.AccessToken);
            string json = Http.WebRequest.SendGet(new Uri(getUrl));

            return Deserializer<List<Path>>.Deserialize(json);
        }

        #endregion

        #region Async

        //TODO - PathClient Async metodlar

        #endregion

    }
}
