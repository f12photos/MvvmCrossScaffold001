using Cirrious.FluentLayouts.Touch;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Binding.Views;
using MvvmCross.Plugin.Sidebar;
using MvvmCrossScaffold001.Core.ViewModels.Lifecycle;
using MvvmCrossScaffold001.iOS.Views;
using UIKit;

namespace MyXamarinApp.iOS.Views
{
    [MvxSidebarPresentation(MvxPanelEnum.Center, MvxPanelHintType.ResetRoot, false)]
    public class Next0View : BaseViewController<Next0ViewModel>
    {
        private UIButton _btn1, _btn2;

        public Next0View()
        {
            Title = "Lifecycle";
        }

        //public override void ViewWillAppear(bool animated)
        //{
        //    base.ViewWillAppear(animated);

        //    View.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();
        //}

        protected override void CreateView()
        {
            _btn1 = new UIButton(UIButtonType.System);
            _btn1.SetTitle("Next View Model 1", UIControlState.Normal);
            Add(_btn1);

            _btn2 = new UIButton(UIButtonType.System);
            _btn2.SetTitle("Next View Model 2", UIControlState.Normal);
            Add(_btn2);

        }

        protected override void LayoutView()
        {
            float fMargin = 10f;

            View.AddConstraints(new FluentLayout[]
            {
                _btn1.AtTopOfSafeArea(View),
                _btn1.WithSameCenterX(View),

                _btn2.Below(_btn1, fMargin),
                _btn2.WithSameCenterX(View)

                //_btnSave.AtTopOf(View, fMargin),


                //_lblMsg.Below(_btnReturn, fMargin),
                //_lblMsg.AtLeftOf(View),
                //_lblMsg.AtBottomOf(View, fMargin),

            });
        }

        protected override void BindView()
        {
            var set = this.CreateBindingSet<Next0View, Next0ViewModel>();
            set.Bind(_btn1).To(vm => vm.Next1Command);
            set.Bind(_btn2).To(vm => vm.Next2Command);
            //set.Bind(_textView).To(vm => vm.SelectedItem);
            //set.Bind(_label).To(vm => vm.SelectedItem);
            set.Apply();
        }
    }


}
