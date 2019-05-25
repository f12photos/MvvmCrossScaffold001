using System;
using System.Collections.Generic;
using MvvmCrossScaffold001.Core.Models;

namespace MvvmCrossScaffold001.Core.ViewModels.FFImage
{
    public class FFImageViewModel : BaseViewModel
    {

        private List<Image> _images;
        public List<Image> Images
        {
            //get { return _images; }
            //set { SetProperty(ref _images, value); }

            get
            {
                return _images;
            }
            set
            {
                _images = value;
                RaisePropertyChanged(() => Images);
            }

        }

        public override void Start()
        {
            Images = new List<Image>();
            for (int i = 0; i < 999; i++)
            {
                Images.Add(new Image($"res:Images/ic_alarm_on.png"));
            }
        }
    }
}
