﻿using System;
using System.Windows.Input;
using MvvmCross.Commands;
using MvvmCrossScaffold001.Core.Models;
using MvvmCrossScaffold001.Core.Services;

namespace MvvmCrossScaffold001.Core.ViewModels.Chinook
{
    public class TrackAddViewModel : BaseViewModelResult<Track>
    {
        ITrackService _trackSvc;
        public TrackAddViewModel(ITrackService trackService)
        {
            _trackSvc = trackService;
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; RaisePropertyChanged(() => Name); }
        }

        private string _composer;
        public string Composer 
        {
            get { return _composer; }
            set { _composer = value; RaisePropertyChanged(() => Composer); }
        }

        private int _milliseconds;
        public int Milliseconds
        {
            get { return _milliseconds; }
            set { _milliseconds = value; RaisePropertyChanged(() => Milliseconds); }
        }

        private int _bytes;
        public int Bytes 
        {
            get { return _bytes; }
            set { _bytes = value; RaisePropertyChanged(() => Bytes); }
        }

        private double _unitPrice;
        public double UnitPrice 
        {
            get { return _unitPrice; }
            set { _unitPrice = value; RaisePropertyChanged(() => UnitPrice); }
        }

        private int _albumId;
        public int AlbumId
        {
            get { return _albumId; }
            set { _albumId = value; RaisePropertyChanged(() => AlbumId); }
        }

        private int _mediaTypeId;
        public int MediaTypeId 
        {
            get { return _mediaTypeId; }
            set { _mediaTypeId = value; RaisePropertyChanged(() => MediaTypeId); }
        }

        private int _genreId;
        public int GenreId 
        {
            get { return _genreId; }
            set { _genreId = value; RaisePropertyChanged(() => GenreId); }
        }
    }
}
