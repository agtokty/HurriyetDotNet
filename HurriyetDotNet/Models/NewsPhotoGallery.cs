using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HurriyetDotNet.Models
{
    public class NewsPhotoGallery : BaseModel
    {
        public string Description { get; set; }

        public List<File> Files { get; set; }

        public DateTime ModifiedDate { get; set; }

    }
}
