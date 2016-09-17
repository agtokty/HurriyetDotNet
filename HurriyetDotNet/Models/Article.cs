using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HurriyetDotNet.Models
{
    public class Article : BaseModel
    {
        public string Description { get; set; }

        public List<File> Files { get; set; }

        public DateTime ModifiedDate { get; set; }

        public string Text { get; set; }

        public string[] Writers { get; set; }

        public string[] Tags { get; set; }

        public string Editor { get; set; }
    }
}
