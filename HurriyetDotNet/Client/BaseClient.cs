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
    public class BaseClient
    {
        protected IAuthentication Authentication;

        /// <summary>
        ///
        /// </summary>
        /// <param name="auth"></param>
        public BaseClient(IAuthentication auth)
        {
            if (auth == null)
            {
                throw new ArgumentNullException("auth parameter can not be null!");
            }

            Authentication = auth;
        }
    }
}
