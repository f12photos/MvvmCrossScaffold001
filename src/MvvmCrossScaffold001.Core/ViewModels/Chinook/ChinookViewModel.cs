using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using MvvmCrossScaffold001.Core.Services;

namespace MvvmCrossScaffold001.Core.ViewModels.Chinook
{
    public class ChinookViewModel : BaseViewModel
    {
        readonly IMediaTypeService _mediaTypeSvc;
        public ChinookViewModel(IMediaTypeService mediaTypeService)
        {
            _mediaTypeSvc = mediaTypeService;
            var all = _mediaTypeSvc.GetAll().ToList();
            var types = all.Select(x => x.Name).ToList();
        }
    }
}