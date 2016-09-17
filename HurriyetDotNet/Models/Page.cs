using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HurriyetDotNet.Models
{
    public class Page
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Url { get; set; }

        public DateTime CreatedDate { get; set; }

        public List<RelatedNews> RelatedNews { get; set; }

        public List<RelatedNews> PageNews { get; set; }
    }

    public class RelatedNews
    {
        //TODO - RelatedNews sınıfı özellikleri eklenmelidir.
    }

    public class PageNews
    {
        public string Id { get; set; }

        public ContentType ContentType { get; set; }

        public List<File> Files { get; set; }

        public string Path { get; set; }

        public string Url { get; set; }
    }

}
