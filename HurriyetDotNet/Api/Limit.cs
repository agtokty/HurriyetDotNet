using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HurriyetDotNet.Api
{
    public class Limit
    {
        /// <summary>
        /// Saniyelik istek limiti
        /// </summary>
        public int ShortTerm { get; set; }

        /// <summary>
        /// Saatlik istek limiti
        /// </summary>
        public int LongTerm { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="shortTerm">İstek başlığından okunan saniyelik limit değeri</param>
        /// <param name="longTerm">İstek başlığından okunan saatlik limit değeri</param>
        public Limit(int shortTerm, int longTerm)
        {
            ShortTerm = shortTerm;
            LongTerm = longTerm;
        }
    }
}
