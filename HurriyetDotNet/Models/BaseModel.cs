using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HurriyetDotNet.Models
{
    public class BaseModel
    {
        public int Id { get; set; }

        public ContentType ContentType { get; set; }

        public DateTime CreatedDate { get; set; }

        public string Path { get; set; }

        public string Title { get; set; }

        public string Url { get; set; }
    }
}
