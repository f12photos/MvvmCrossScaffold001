using Cirrious.FluentLayouts.Touch;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Plugin.Sidebar;
using MvvmCrossScaffold001.Core.ViewModels.RestDemo;
using MvvmCrossScaffold001.iOS.Sources;
using UIKit;

namespace MvvmCrossScaffold001.iOS.Views.RestDemo
{
    [MvxSidebarPresentation(MvxPanelEnum.Center, MvxPanelHintType.ResetRoot, false)]
    public class RestDemoView : BaseViewController<RestDemoViewModel>
    {
        private UILabel _labelWelcome, _labelMessage;
        private UITextField _txt;
        private UIButton _btn, _btnAdd, _btnRestClient, _btnMvxRestClient,
            _btnMvxJsonRestClient, _btnModernHttpClient;
        //private MvxStandardTableViewSource _source;
        //private MySimpleTableViewSource _source;

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
        }

        protected override void CreateView()
        {
            Title = "Rest Demo";

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
            _labelMessage.Lines = 10;
            Add(_labelMessage);

            _txt = new UITextField
            {
                Placeholder = "Message to Send",
                TextAlignment = UITextAlignment.Center
            };
            Add(_txt);

            _btn = new UIButton(UIButtonType.System);
            _btn.SetTitle("This is a Button", UIControlState.Normal);
            Add(_btn);

            _btnRestClient = new UIButton(UIButtonType.System);
            _btnRestClient.SetTitle("Rest Client", UIControlState.Normal);
            Add(_btnRestClient);

            _btnMvxRestClient = new UIButton(UIButtonType.System);
            _btnMvxRestClient.SetTitle("Mvx Rest Client", UIControlState.Normal);
            Add(_btnMvxRestClient);

            _btnMvxJsonRestClient = new UIButton(UIButtonType.System);
            _btnMvxJsonRestClient.SetTitle("Mvx Json Rest Client", UIControlState.Normal);
            Add(_btnMvxJsonRestClient);

            _btnModernHttpClient = new UIButton(UIButtonType.System);
            _btnModernHttpClient.SetTitle("Modern Http Client", UIControlState.Normal);
            Add(_btnModernHttpClient);
        }

        protected override void LayoutView()
        {
            View.AddConstraints(new FluentLayout[]
            {
                _labelWelcome.AtTopOfSafeArea(View),
                _labelWelcome.WithSameCenterX(View),

                _txt.Below(_labelWelcome, 10f),
                _txt.WithSameWidth(View),

                _btn.Below(_txt, 10f),
                _btn.WithSameWidth(View),

                _btnRestClient.Below(_btn, 10f),
                _btnRestClient.AtLeftOfSafeArea(View, 10f),

                _btnMvxRestClient.Below(_btnRestClient, 10f),
                _btnMvxRestClient.AtLeftOfSafeArea(View, 10f),

                _btnMvxJsonRestClient.Below(_btnMvxRestClient, 10f),
                _btnMvxJsonRestClient.AtLeftOfSafeArea(View, 10f),

                _btnModernHttpClient.Below(_btnMvxJsonRestClient, 10f),
                _btnModernHttpClient.AtLeftOfSafeArea(View, 10f),

                _labelMessage.Below(_btnModernHttpClient, 10f),
                _labelMessage.WithSameWidth(View)


            });
        }

        protected override void BindView()
        {
            //MvxFluentBindingDescriptionSet<MainViewController, MainViewModel>
            //    bindingSet = this.CreateBindingSet<MainViewController, MainViewModel>();

            //bindingSet.Apply();

            var set = this.CreateBindingSet<RestDemoView, RestDemoViewModel>();
            set.Bind(_labelMessage).To(vm => vm.Message);
            set.Bind(_btnRestClient).To(vm => vm.RestCommand);
            set.Bind(_btnMvxRestClient).To(vm => vm.MvxRestCommand);
            set.Bind(_btnMvxJsonRestClient).To(vm => vm.MvxJsonRestCommand);
            set.Bind(_btnModernHttpClient).To(vm => vm.ModernHttpClientCommand);



            //set.Bind(_source).For(v => v.ItemsSource).To(vm => vm.Items);
            //set.Bind(_source).For(v => v.SelectionChangedCommand).To(vm => vm.AlbumSelectedCommand);
            //set.Bind(_source).For(v => v.FetchCommand).To(vm => vm.FetchPeopleCommand);
            set.Apply();
        }
    }
}
