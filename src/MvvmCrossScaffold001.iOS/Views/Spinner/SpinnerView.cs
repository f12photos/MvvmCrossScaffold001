
using System;
using Cirrious.FluentLayouts.Touch;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Binding.Views;
using MvvmCross.Plugin.Sidebar;
using MvvmCrossScaffold001.Core.ViewModels.Chinook;
using MvvmCrossScaffold001.Core.ViewModels.RestDemo;
using MvvmCrossScaffold001.Core.ViewModels.Spinner;
using MvvmCrossScaffold001.iOS.Sources;
using UIKit;
namespace MvvmCrossScaffold001.iOS.Views.Spinner

{
    [MvxSidebarPresentation(MvxPanelEnum.Center, MvxPanelHintType.ResetRoot, false)]
    public class SpinnerView : BaseViewController<SpinnerViewModel>
    {
        private UILabel _labelWelcome, _labelMessage;
        private UITextField _txt;
        private UIPickerView _picker;
        private MvxPickerViewModel _mvxPicker;

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
        }

        protected override void CreateView()
        {
            Title = "Spinner";

            _picker = new UIPickerView();
            _mvxPicker = new MvxPickerViewModel(_picker);
            _picker.Model = _mvxPicker;
            _picker.ShowSelectionIndicator = true;

            _labelWelcome = new UILabel
            {
                Text = Title,
                TextAlignment = UITextAlignment.Center
            };
            Add(_labelWelcome);

            _labelMessage = new UILabel
            {
                Text = "App scaffolded with MvxScaffolding",
                TextAlignment = UITextAlignment.Center
            };
            Add(_labelMessage);


            _txt = new UITextField
            {
                Placeholder = "Enter Text Here",
                TextAlignment = UITextAlignment.Center
            };
            _txt.InputView = _picker;
            Add(_txt);
        }

        protected override void LayoutView()
        {
            View.AddConstraints(new FluentLayout[]
            {
                _labelWelcome.AtTopOfSafeArea(View),
                _labelWelcome.WithSameCenterX(View),

                _labelMessage.Below(_labelWelcome, 10f),
                _labelMessage.WithSameWidth(View),

                _txt.Below(_labelMessage, 10f),
                _txt.WithSameWidth(View)
            });
        }

        protected override void BindView()
        {

            var set = this.CreateBindingSet<SpinnerView, SpinnerViewModel>();             set.Bind(_mvxPicker).For(p => p.SelectedItem).To(vm => vm.SelectedItem);             set.Bind(_mvxPicker).For(p => p.ItemsSource).To(vm => vm.Items);             set.Bind(_txt).To(vm => vm.SelectedItem);             //set.Bind(label).To(vm => vm.SelectedItem);             set.Apply();


            //MvxFluentBindingDescriptionSet<MainViewController, MainViewModel>
            //    bindingSet = this.CreateBindingSet<MainViewController, MainViewModel>();

            //bindingSet.Apply();

            //var set = this.CreateBindingSet<AlbumView, AlbumViewModel>();
            //set.Bind(_btnAdd).To(vm => vm.AddCommand);

            //set.Bind(_source).For(v => v.ItemsSource).To(vm => vm.Items);
            //set.Bind(_source).For(v => v.SelectionChangedCommand).To(vm => vm.AlbumSelectedCommand);
            ////set.Bind(_source).For(v => v.FetchCommand).To(vm => vm.FetchPeopleCommand);
            //set.Apply();
        }
    }
}
