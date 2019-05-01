using System;
using System.Collections.Generic;
using System.Text;

namespace MvvmCrossScaffold001.Model
{
    public class PlayListTrack : BaseClass
    {   // many to many
        public int PlaylistId { get; set; }
        public int TrackId { get; set; }
    }
}
