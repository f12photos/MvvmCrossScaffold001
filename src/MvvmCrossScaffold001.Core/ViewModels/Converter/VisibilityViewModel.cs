using MvvmCross.ViewModels;

namespace MvvmCrossScaffold001.Core.ViewModels.Converter
{
    public class VisibilityViewModel : MvxViewModel
    {
        private bool _makeItVisible;

        public VisibilityViewModel()
        {
            _makeItVisible = true;
        }

        public bool MakeItVisible
        {
            get { return _makeItVisible; }
            set
            {
                _makeItVisible = value;
                RaisePropertyChanged(() => MakeItVisible);
            }
        }
    }
}