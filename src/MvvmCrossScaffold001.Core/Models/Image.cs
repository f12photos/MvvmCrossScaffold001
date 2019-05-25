using System;
using System.Collections.Generic;

using FFImageLoading.Transformations;
using FFImageLoading.Work;

namespace MvvmCrossScaffold001.Core.Models
{
    public class Image
    {
        public string Url { get; }
        public double DownsampleWidth => 200d;
        //public List<ITransformation> Transformations => new List<ITransformation> { new CircleTransformation() };

        public Image(string url)
        {
            Url = url;
        }
    }
}
