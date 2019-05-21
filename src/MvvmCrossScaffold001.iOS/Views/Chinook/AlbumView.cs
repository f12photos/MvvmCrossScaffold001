
using System;
using Cirrious.FluentLayouts.Touch;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Binding.Views;
using MvvmCross.Plugin.Sidebar;
using MvvmCrossScaffold001.Core.ViewModels.Chinook;
using MvvmCrossScaffold001.iOS.Sources;
using UIKit;

namespace MvvmCrossScaffold001.iOS.Views.Chinook
{
    [MvxSidebarPresentation(MvxPanelEnum.Center, MvxPanelHintType.PushPanel, true)]
    public class AlbumView : BaseViewController<AlbumViewModel>
    {
        private UILabel _labelWelcome, _labelMessage;
        private UITextField _txt;
        private UIButton _btn, _btnAdd;
        private UITableView _table;
        //private MvxStandardTableViewSource _source;
        private MySimpleTableViewSource _source;

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
        }

        protected override void CreateView()
        {
            Title = "Album";

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
            Add(_txt);

            _btn = new UIButton(UIButtonType.System);
            _btn.SetTitle("This is a Button", UIControlState.Normal);
            Add(_btn);

            _btnAdd = new UIButton(UIButtonType.System);
            _btnAdd.SetTitle("Add Album", UIControlState.Normal);
            Add(_btnAdd);

            _table = new UITableView();
            _table.BackgroundColor = UIColor.Clear;
            _table.RowHeight = UITableView.AutomaticDimension;
            _table.EstimatedRowHeight = 44f;
            Add(_table);

            _source = new MySimpleTableViewSource(_table);
            _table.Source = _source;
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
                _txt.WithSameWidth(View),

                _btn.Below(_txt, 10f),
                _btn.WithSameWidth(View),

                _btnAdd.Below(_btn, 10f),
                _btnAdd.AtLeftOfSafeArea(View, 10f),

                _table.Below(_btnAdd, 10f),
                _table.WithSameWidth(View),
                _table.AtBottomOfSafeArea(View)
            });
        }

        protected override void BindView()
        {

            var set = this.CreateBindingSet<AlbumView, AlbumViewModel>();
            set.Bind(_btnAdd).To(vm => vm.AddCommand);

            set.Bind(_source).For(v => v.ItemsSource).To(vm => vm.Items);
            set.Bind(_source).For(v => v.SelectionChangedCommand).To(vm => vm.AlbumSelectedCommand);
            //set.Bind(_source).For(v => v.FetchCommand).To(vm => vm.FetchPeopleCommand);
            set.Apply();
        }
    }
}
