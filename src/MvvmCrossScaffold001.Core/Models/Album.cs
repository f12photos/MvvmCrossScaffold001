﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MvvmCrossScaffold001.Core.Models
{
    public class Album : BaseModel
    {
        //public int Id { get; set; }
        public string Name { get; set; }
        public int ArtistId { get; set; }
    }
}
