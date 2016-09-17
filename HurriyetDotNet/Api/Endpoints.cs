using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HurriyetDotNet.Api
{
    /// <summary>
    /// 
    /// </summary>
    public static class Endpoints
    {

        private const string apiHost = "https://api.hurriyet.com.tr";

        private const string apiVersion = "/v1";

        /// <summary>
        /// 
        /// </summary>
        public static string Articles
        {
            get
            {
                return apiHost + apiVersion + "/articles";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static string Writers
        {
            get
            {
                return apiHost + apiVersion + "/writers";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static string Columns
        {
            get
            {
                return apiHost + apiVersion + "/columns";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static string Date
        {
            get
            {
                return apiHost + apiVersion + "/dates";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static string NewsPhotoGalleries
        {
            get
            {
                return apiHost + apiVersion + "/newsphotogalleries";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static string Pages
        {
            get
            {
                return apiHost + apiVersion + "/pages";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static string Paths
        {
            get
            {
                return apiHost + apiVersion + "/paths";
            }
        }

    }
}
