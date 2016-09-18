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
        public int ShortTermRemaining { get; set; }

        /// <summary>
        /// Saat başına kalan istek sayısıdır
        /// </summary>
        public int LongTermRemaining { get; set; }

        /// <summary>
        /// Saniye başına kullanılan istek sayısıdır
        /// </summary>
        public int ShortTermUsed { get; set; }

        /// <summary>
        /// Saat başına kullanılan istek sayısıdır
        /// </summary>
        public int LongTermUsed { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="shortTermUsed"></param>
        /// <param name="longTermUsed"></param>
        public Usage(int shortTermUsed, int longTermUsed)
        {
            ShortTermUsed = shortTermUsed;
            LongTermUsed = longTermUsed;
        }

        public Usage(int shortTermUsed, int longTermUsed, int shortTermLimit, int longTermLimit)
        {
            ShortTermUsed = shortTermUsed;
            LongTermUsed = longTermUsed;

            ShortTermRemaining = shortTermLimit - shortTermUsed;
            LongTermRemaining = longTermLimit - longTermUsed;
        }
    }
}
