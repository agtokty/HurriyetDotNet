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
    public interface IAuthentication
    {
        /// <summary>
        /// 
        /// </summary>
        string AccessToken { get; set; }
    }
}
