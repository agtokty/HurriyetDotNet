using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HurriyetDotNet.Api
{
    public class UsageChangedEventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        public Usage Usage { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="shortTerm"></param>
        /// <param name="longTerm"></param>
        public UsageChangedEventArgs(int shortTerm, int longTerm)
        {
            Usage = new Usage(shortTerm, longTerm);
        }
    }
}
