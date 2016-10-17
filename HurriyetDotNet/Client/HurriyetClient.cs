using HurriyetDotNet.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HurriyetDotNet.Client
{
    /// <summary>
    /// 
    /// </summary>
    public class HurriyetClient
    {
        //TODO - Odata select desteği

        private static IAuthentication _authenticator;

        /// <summary>
        /// 
        /// </summary>
        public IAuthentication Authenticator
        {
            get
            {
                return _authenticator;
            }
            set
            {
                if (value != null)
                {
                    _authenticator = value;

                    Writers = new WriterClient(_authenticator);
                    Articles = new ArticleClient(_authenticator);
                    NewsPhotoGalleries = new NewsPhotoGalleryClient(_authenticator);
                    Pages = new PageClient(_authenticator);
                    Columns = new ColumnClient(_authenticator);
                    Paths = new PathClient(_authenticator);
                }
                else
                    throw new ArgumentException("The auth object must not be null.");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public WriterClient Writers { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ArticleClient Articles { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public NewsPhotoGalleryClient NewsPhotoGalleries { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public PageClient Pages { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public PathClient Paths { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ColumnClient Columns { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="auth"></param>
        public HurriyetClient(IAuthentication auth)
        {
            if (auth != null)
            {
                _authenticator = auth;

                Writers = new WriterClient(_authenticator);
                Articles = new ArticleClient(_authenticator);
                NewsPhotoGalleries = new NewsPhotoGalleryClient(_authenticator);
                Pages = new PageClient(_authenticator);
                Columns = new ColumnClient(_authenticator);
                Paths = new PathClient(_authenticator);
            }
            else
            {
                throw new ArgumentException("The auth object must not be null.");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="apiKey"></param>
        public HurriyetClient(string apiKey)
        {
            if (!string.IsNullOrEmpty(apiKey))
            {
                _authenticator = new Authentication(apiKey);

                Writers = new WriterClient(_authenticator);
                Articles = new ArticleClient(_authenticator);
                NewsPhotoGalleries = new NewsPhotoGalleryClient(_authenticator);
                Pages = new PageClient(_authenticator);
                Columns = new ColumnClient(_authenticator);
                Paths = new PathClient(_authenticator);
            }
            else
            {
                throw new ArgumentException("The apiKey is null or empty");
            }
        }

    }
}
