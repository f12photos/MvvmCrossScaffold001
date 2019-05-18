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
    public class TrackAddView : BaseViewController<TrackAddViewModel>
    {
        private UILabel _labelWelcome, _labelMessage, 
            _lblAlbum,
            _lblMediaType,
            _lblGenre;

        private UITextField _txt, 
            _txtName, 
            _txtComposer, 
            _txtMilliseconds, 
            _txtBytes, 
            _txtUnitPrice;

        private UIButton _btn;

        protected override void CreateView()
        {
            Title = "Add Track";

            _labelWelcome = new UILabel
            {
                Text = "Add Track",
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
                Placeholder = "Enter New Track",
                TextAlignment = UITextAlignment.Center
            };
            Add(_txt);

            _txtName = new UITextField
            {
                Placeholder = "Enter Track Name",
                TextAlignment = UITextAlignment.Center
            };
            _txtName.Layer.BorderColor = UIColor.LightGray.CGColor;
            _txtName.Layer.BorderWidth = 1f;
            Add(_txtName);

            _txtComposer = new UITextField
            {
                Placeholder = "Enter Composer",
                TextAlignment = UITextAlignment.Center
            };
            _txtComposer.Layer.BorderColor = UIColor.LightGray.CGColor;
            _txtComposer.Layer.BorderWidth = 1f;
            Add(_txtComposer);

            _txtMilliseconds = new UITextField
            {
                Placeholder = "Enter Milliseconds",
                TextAlignment = UITextAlignment.Center
            };
            _txtMilliseconds.Layer.BorderColor = UIColor.LightGray.CGColor;
            _txtMilliseconds.Layer.BorderWidth = 1f;
            Add(_txtMilliseconds);

            _txtBytes = new UITextField
            {
                Placeholder = "Enter Bytes",
                TextAlignment = UITextAlignment.Center
            };
            _txtBytes.Layer.BorderColor = UIColor.LightGray.CGColor;
            _txtBytes.Layer.BorderWidth = 1f;
            Add(_txtBytes);

            _txtUnitPrice = new UITextField
            {
                Placeholder = "Enter Unit Price",
                TextAlignment = UITextAlignment.Center
            };
            _txtUnitPrice.Layer.BorderColor = UIColor.LightGray.CGColor;
            _txtUnitPrice.Layer.BorderWidth = 1f;
            Add(_txtUnitPrice);

            _btn = new UIButton(UIButtonType.System);
            _btn.SetTitle("Add", UIControlState.Normal);
            Add(_btn);

        }

        protected override void LayoutView()
        {
            var margin = 10f;
            View.AddConstraints(new FluentLayout[]
            {
                _labelMessage.AtTopOfSafeArea(View),
                _labelMessage.WithSameCenterX(View),

                _labelWelcome.Below(_labelMessage, margin),
                _labelWelcome.WithSameWidth(View),

                _txt.Below(_labelWelcome, margin),
                _txt.WithSameWidth(View),

                _btn.Below(_txt, margin),
                _btn.WithSameWidth(View),

                _txtName.Below(_btn, margin),
                _txtName.AtLeftOfSafeArea(View, margin),
                _txtName.AtRightOfSafeArea(View, margin),

                _txtComposer.Below(_txtName, margin),
                _txtComposer.AtLeftOfSafeArea(View, margin),
                _txtComposer.AtRightOfSafeArea(View, margin),

                _txtMilliseconds.Below(_txtComposer, margin),
                _txtMilliseconds.AtRightOfSafeArea(View, margin),
                _txtMilliseconds.AtLeftOfSafeArea(View, margin),

                _txtBytes.Below(_txtMilliseconds, margin),
                _txtBytes.AtLeftOfSafeArea(View, margin),
                _txtBytes.AtRightOfSafeArea(View, margin),

                _txtUnitPrice.Below(_txtBytes, margin),
                _txtUnitPrice.AtLeftOfSafeArea(View, margin),
                _txtUnitPrice.AtRightOfSafeArea(View, margin),
            });
        }

        //protected override void BindView()
        //{
        //    var set = this.CreateBindingSet<GenreAddView, GenreAddViewModel>();
        //    set.Bind(_txt).To(vm => vm.Name);
        //    set.Bind(_btn).To(vm => vm.AddCommand);
        //    ////set.Bind(_source).For(s => s.SelectionChangedCommand).To(vm => vm.GotoTestCommand);
        //    set.Apply();
        //}
    }
}
