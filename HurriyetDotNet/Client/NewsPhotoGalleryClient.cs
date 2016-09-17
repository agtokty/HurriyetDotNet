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
    public class NewsPhotoGalleryClient : BaseClient
    {
        public NewsPhotoGalleryClient(IAuthentication auth) : base(auth)
        {

        }


        #region Sync

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public NewsPhotoGallery GetPath(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new Exception("NewsPhotoGallery id can not be null!");
            string getUrl = string.Format("{0}/{1}/?apikey={2}", Endpoints.NewsPhotoGalleries, id, Authentication.AccessToken);
            string json = Http.WebRequest.SendGet(new Uri(getUrl));

            return Deserializer<NewsPhotoGallery>.Deserialize(json);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<NewsPhotoGallery> GetAllPaths()
        {
            string getUrl = string.Format("{0}/?apikey={2}", Endpoints.NewsPhotoGalleries, Authentication.AccessToken);
            string json = Http.WebRequest.SendGet(new Uri(getUrl));

            return Deserializer<List<NewsPhotoGallery>>.Deserialize(json);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public NewsPhotoGallery GetPathCustomFilter(string filter)
        {
            if (string.IsNullOrEmpty(filter))
                throw new Exception("Custom filter can not be null!");
            string getUrl = string.Format("{0}/?$filter={1}&top=1&apikey={2}", Endpoints.NewsPhotoGalleries, filter, Authentication.AccessToken);
            string json = Http.WebRequest.SendGet(new Uri(getUrl));

            return Deserializer<NewsPhotoGallery>.Deserialize(json);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public List<NewsPhotoGallery> GetAllPathsCustomFilter(string filter)
        {
            if (string.IsNullOrEmpty(filter))
                throw new Exception("Custom filter can not be null!");
            string getUrl = string.Format("{0}/?$filter={1}&apikey={2}", Endpoints.NewsPhotoGalleries, filter, Authentication.AccessToken);
            string json = Http.WebRequest.SendGet(new Uri(getUrl));

            return Deserializer<List<NewsPhotoGallery>>.Deserialize(json);
        }

        #endregion

        #region Async

        //TODO - NewsPhotoGalleryClient Async metodlar

        #endregion
    }
}
