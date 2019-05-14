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
        readonly IGenreService _genreSvc;
        public ChinookViewModel(IMediaTypeService mediaTypeService, IGenreService genreSvc)
        {
            _mediaTypeSvc = mediaTypeService;
            _genreSvc = genreSvc;

            var all = _mediaTypeSvc.GetAll().ToList();
            var types = all.Select(x => x.Name).ToList();

            var allgen = _genreSvc.GetAll().ToList();
            var genTypes = allgen.Select(x => x.Name).ToList();
        }
    }
}