using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HurriyetDotNet.Auth
{
    /// <summary>
    ///
    /// </summary>
    public class Authentication : IAuthentication
    {
        /// <summary>
        /// 
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accessToken">Api anahtarı</param>
        public Authentication(string accessToken)
        {
            AccessToken = accessToken;
        }
    }
}
