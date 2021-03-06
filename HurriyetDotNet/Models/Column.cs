﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HurriyetDotNet.Models
{
    public class Column : BaseModel
    {
        public string FullName { get; set; }

        public string Description { get; set; }

        public List<File> Files { get; set; }

        public string WriterId { get; set; }

        public string Text { get; set; }
    }
}
