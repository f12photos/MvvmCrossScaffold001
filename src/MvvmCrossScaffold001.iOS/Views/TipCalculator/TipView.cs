using System;
using Cirrious.FluentLayouts.Touch;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Views;
using MvvmCross.Plugin.Sidebar;
using MvvmCrossScaffold001.Core.ViewModels.TipCalculator;
using UIKit;

namespace MvvmCrossScaffold001.iOS.Views.TipCalculator
{
    [MvxSidebarPresentation(MvxPanelEnum.Center, MvxPanelHintType.ResetRoot, false)]
    public class TipView : BaseViewController<TipViewModel>
    {
        private UILabel _lblTip;
        private UITextField _txtSubTotal;
        private UISlider _sliderGenerosity;
        private UIButton _btn;

        protected override void CreateView()
        {
            _lblTip = new UILabel
            {
                Text = "Welcome!!",
                TextAlignment = UITextAlignment.Center
            };
            Add(_lblTip);

            _txtSubTotal = new UITextField
            {
                Placeholder = "Enter Text Here",
                TextAlignment = UITextAlignment.Center
            };
            Add(_txtSubTotal);

            _sliderGenerosity = new UISlider
            {
                MaxValue = 100,
                Value = 10
            };
            Add(_sliderGenerosity);

        }

        protected override void LayoutView()
        {
            View.AddConstraints(new FluentLayout[]
            {
                _txtSubTotal.AtTopOfSafeArea(View),
                _txtSubTotal.WithSameCenterX(View),

                _sliderGenerosity.Below(_txtSubTotal, 10f),
                _sliderGenerosity.AtLeftOfSafeArea(View, 10f),
                _sliderGenerosity.AtRightOfSafeArea(View, 10f),
                //_sliderGenerosity.WithSameCenterX(View),

                _lblTip.Below(_sliderGenerosity, 10f),
                _lblTip.WithSameWidth(View)
            });
        }

        protected override void BindView()
        {
            var set = this.CreateBindingSet<TipView, TipViewModel>();
            set.Bind(_lblTip).To(vm => vm.Tip);
            set.Bind(_txtSubTotal).To(vm => vm.SubTotal);
            set.Bind(_sliderGenerosity).To(vm => vm.Generosity);
            set.Apply();

            // this is optional. What this code does is to close the keyboard whenever you 
            // tap on the screen, outside the bounds of the TextField
            View.AddGestureRecognizer(new UITapGestureRecognizer(() =>
            {
                _txtSubTotal.ResignFirstResponder();
            }));
        }
    }
}
