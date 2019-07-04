using System;
using System.Collections.Generic;
using MvvmCross.Navigation;

namespace MvvmCrossScaffold001.Core.ViewModels.Spinner
{
    public class SpinnerViewModel : BaseViewModel
    {
        private readonly IMvxNavigationService _navigationService;

        public SpinnerViewModel(IMvxNavigationService navigationService )
        {
            _navigationService = navigationService;

        }

        private List<Thing> _items = new List<Thing>()
        {
            new Thing("One"),
            new Thing("Two"),             new Thing("Three"),             new Thing("Four"),         };          public List<Thing> Items         {             get { return _items; }             set { _items = value; RaisePropertyChanged(() => Items); }         }          private Thing _selectedItem = new Thing("Three");          public Thing SelectedItem         {             get { return _selectedItem; }             set { _selectedItem = value; RaisePropertyChanged(() => SelectedItem); }         }

        //----------------------------------------------------------------------
        //----------------------------------------------------------------------
        public class Thing         {             public Thing(string caption)             {                 Caption = caption;             }              public string Caption { get; private set; }              public override string ToString()             {                 return Caption;             }              public override bool Equals(object obj)             {                 var rhs = obj as Thing;                 if (rhs == null)                     return false;                 return rhs.Caption == Caption;             }              public override int GetHashCode()             {                 if (Caption == null)                     return 0;                 return Caption.GetHashCode();             }         }
    }
}
