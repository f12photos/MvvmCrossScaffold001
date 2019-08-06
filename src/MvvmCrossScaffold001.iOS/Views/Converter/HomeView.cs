using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Binding.Views;
using MvvmCross.Platforms.Ios.Views;
using MvvmCrossScaffold001.Core.ViewModels.Converter;

namespace MvvmCrossScaffold001.iOS.Views.Converter
{
    public class HomeView : MvxTableViewController
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var source = new MvxStandardTableViewSource(TableView, "TitleText Name; SelectedCommand ShowCommand");

            this.CreateBinding(source).To((HomeViewModel vm) => vm.Items).Apply();

            TableView.Source = source;
            TableView.ReloadData();
        }
    }
}