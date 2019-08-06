

using System;
using System.IO;
using Cirrious.FluentLayouts.Touch;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Binding.Views;
using MvvmCross.Plugin.Sidebar;
using MvvmCrossScaffold001.Core.ViewModels.Chinook;
using MvvmCrossScaffold001.Core.ViewModels.RestDemo;
using MvvmCrossScaffold001.Core.ViewModels.WebView;
using MvvmCrossScaffold001.iOS.Sources;
using UIKit;
using WebKit;

namespace MvvmCrossScaffold001.iOS.Views.RestDemo
{
    [MvxSidebarPresentation(MvxPanelEnum.Center, MvxPanelHintType.ResetRoot, false)]
    public class WebViewView : BaseViewController<WebViewViewModel>
    {
        private UILabel _labelWelcome, _labelMessage;
        private UITextField _txt;
        private UIButton _btn, _btnAdd;
        private UITableView _table;
        //private MvxStandardTableViewSource _source;
        private MySimpleTableViewSource _source;

        //private UIWebView _webView;
        private readonly NSUrl url = new NSUrl("https://visualstudio.microsoft.com/xamarin/");


        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
        }

        protected override void CreateView()
        {
            Title = "Web View";

            WKWebView webView = new WKWebView(View.Frame, new WKWebViewConfiguration());
            View.AddSubview(webView);

            var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var filename2 = Path.Combine(documents, "xxx.pdf");

            var request = new NSUrlRequest(new NSUrl(filename2, false));

            //var request = new NSUrlRequest(url);
            webView.LoadRequest(request);

            //_table = new UITableView();
            //_table.BackgroundColor = UIColor.Clear;
            //_table.RowHeight = UITableView.AutomaticDimension;
            //_table.EstimatedRowHeight = 44f;
            //Add(_table);

            //_webView = new UIWebView();
            //_webView.LoadRequest(new NSUrlRequest(url));
            //_webView.LoadData
        }

        protected override void LayoutView()
        {
            //View.AddConstraints(new FluentLayout[]
            //{
            //    _labelWelcome.AtTopOfSafeArea(View),
            //    _labelWelcome.WithSameCenterX(View),

            //    _labelMessage.Below(_labelWelcome, 10f),
            //    _labelMessage.WithSameWidth(View),

            //    _txt.Below(_labelMessage, 10f),
            //    _txt.WithSameWidth(View),

            //    _btn.Below(_txt, 10f),
            //    _btn.WithSameWidth(View),

            //    _btnAdd.Below(_btn, 10f),
            //    _btnAdd.AtLeftOfSafeArea(View, 10f),

            //    _webView.Below(_btnAdd, 10f),
            //    _webView.WithSameWidth(View),
            //    _webView.AtBottomOfSafeArea(View)
            //});
        }

        //protected override void BindView()
        //{
        //    //MvxFluentBindingDescriptionSet<MainViewController, MainViewModel>
        //    //    bindingSet = this.CreateBindingSet<MainViewController, MainViewModel>();

        //    //bindingSet.Apply();

        //    var set = this.CreateBindingSet<AlbumView, AlbumViewModel>();
        //    set.Bind(_btnAdd).To(vm => vm.AddCommand);

        //    set.Bind(_source).For(v => v.ItemsSource).To(vm => vm.Items);
        //    set.Bind(_source).For(v => v.SelectionChangedCommand).To(vm => vm.AlbumSelectedCommand);
        //    //set.Bind(_source).For(v => v.FetchCommand).To(vm => vm.FetchPeopleCommand);
        //    set.Apply();
        //}
    }
}
