using System;
using System.Collections.Generic;
using System.Text;

namespace MvvmCrossScaffold001.Core.Models
{
    public class PlayListTrack
    {   // many to many
        public int PlaylistId { get; set; }
        public int TrackId { get; set; }
    }
}
