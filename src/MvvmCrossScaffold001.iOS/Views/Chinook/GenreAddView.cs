﻿

using System;
using Cirrious.FluentLayouts.Touch;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Binding.Views;
using MvvmCross.Plugin.Sidebar;
using MvvmCrossScaffold001.Core.ViewModels.Chinook;
using UIKit;

namespace MvvmCrossScaffold001.iOS.Views.Chinook
{
    [MvxSidebarPresentation(MvxPanelEnum.Center, MvxPanelHintType.PushPanel, true)]
    public class GenreAddView : BaseViewController<GenreAddViewModel>
    {
        private UILabel _labelWelcome, _labelMessage;
        private UITextField _txt;
        private UIButton _btn;

        protected override void CreateView()
        {
            Title = "Add Genre";

            _labelWelcome = new UILabel
            {
                Text = "Add Genre",
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
                _btn.WithSameWidth(View)
            });
        }

        protected override void BindView()
        {
            ////MvxFluentBindingDescriptionSet<MainViewController, MainViewModel>
            ////    bindingSet = this.CreateBindingSet<MainViewController, MainViewModel>();

            ////bindingSet.Apply();

            //var set = this.CreateBindingSet<GenreView, GenreViewModel>();
            //set.Bind(_source).To(vm => vm.Items);
            ////set.Bind(_source).For(s => s.SelectionChangedCommand).To(vm => vm.GotoTestCommand);
            //set.Apply();
        }
    }
}
