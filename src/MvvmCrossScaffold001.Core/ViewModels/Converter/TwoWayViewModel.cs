
using MvvmCross.ViewModels;

namespace MvvmCrossScaffold001.Core.ViewModels.Converter
{
    public class TwoWayViewModel : MvxViewModel
    {
        private double _theValue;

        public TwoWayViewModel()
        {
            _theValue = 3;
        }

        public double TheValue
        {
            get { return _theValue; }
            set
            {
                _theValue = value;
                RaisePropertyChanged(() => TheValue);
            }
        }
    }
}