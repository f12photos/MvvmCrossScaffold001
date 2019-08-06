using MvvmCross.ViewModels;

namespace MvvmCrossScaffold001.Core.ViewModels.Converter
{
    public class StringsViewModel : MvxViewModel
    {
        private string _theText;

        public StringsViewModel()
        {
            TheText = "Hello World";
        }

        public string TheText
        {
            get { return _theText; }
            set
            {
                _theText = value;
                RaisePropertyChanged(() => TheText);
            }
        }
    }
}