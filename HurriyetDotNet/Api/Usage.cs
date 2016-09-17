using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HurriyetDotNet.Api
{
    public class Usage
    {
        /// <summary>
        /// Saniye başına kalan istek sayısıdır
        /// </summary>
        public int ShortTerm { get; set; }

        /// <summary>
        /// Saat başına kalan istek sayısıdır
        /// </summary>
        public int LongTerm { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="shortTerm"></param>
        /// <param name="longTerm"></param>
        public Usage(int shortTerm, int longTerm)
        {
            ShortTerm = shortTerm;
            LongTerm = longTerm;
        }
    }
}
