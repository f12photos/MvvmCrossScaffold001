﻿using System;
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
    public class ArtistEditView : BaseViewController<ArtistEditViewModel>
    {
        private UILabel _label;
        private UITextField _txt;
        private UIButton _btn;

        private UITableView _table;
        private MySimpleTableViewSource _source;

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
        }

        protected override void CreateView()
        {
            Title = "Edit Artist";

            _label = new UILabel
            {
                Text = Title,
                TextAlignment = UITextAlignment.Center
            };
            Add(_label);

            _txt = new UITextField
            {
                Placeholder = "Enter Artist Name Here",
                TextAlignment = UITextAlignment.Center
            };
            Add(_txt);
            Title += _txt.Text;

            _btn = new UIButton(UIButtonType.System);
            _btn.SetTitle("Submit", UIControlState.Normal);
            Add(_btn);

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
                _label.AtTopOfSafeArea(View),
                _label.WithSameCenterX(View),

                _txt.Below(_label, 10f),
                _txt.WithSameWidth(View),

                _btn.Below(_txt, 10f),
                _btn.WithSameWidth(View),
    
                _table.Below(_btn, 10f),
                _table.WithSameWidth(View),
                _table.AtBottomOfSafeArea(View)
            });
        }


        protected override void BindView()
        {
            //MvxFluentBindingDescriptionSet<MainViewController, MainViewModel>
            //    bindingSet = this.CreateBindingSet<MainViewController, MainViewModel>();

            //bindingSet.Apply();

            var set = this.CreateBindingSet<ArtistEditView, ArtistEditViewModel>();
            set.Bind(_txt).To(vm => vm.Name);
            set.Bind(_btn).To(vm => vm.AddCommand);

            set.Bind(_source).For(v => v.ItemsSource).To(vm => vm.Albums);

            set.Apply();
        }
    }
}
