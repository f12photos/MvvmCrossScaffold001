using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cirrious.FluentLayouts.Touch;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Binding.Views.Gestures;
using MvvmCross.Plugin.Sidebar;
using MvvmCross.Plugin.Sidebar.Views;
using MvvmCrossScaffold001.Core.ViewModels.Menu;
using UIKit;

namespace MvvmCrossScaffold001.iOS.Views.Menu
{
    [MvxSidebarPresentation(MvxPanelEnum.Left, MvxPanelHintType.PushPanel, false)]
    public class MenuView : BaseViewController<MenuViewModel>, IMvxSidebarMenu
    {
        private UILabel _menuHome, _menuSettings, 
            _menuTip, _menuChinook, _menuLifecycle, _menuFFImage,
            _menuRestDemo, _menuSpinner;

        public bool AnimateMenu => true;

        public bool DisablePanGesture => false;

        public float DarkOverlayAlpha => 0;

        public bool HasDarkOverlay => false;

        public bool HasShadowing => true;

        public float ShadowOpacity => 0.5f;

        public float ShadowRadius => 4.0f;

        public UIColor ShadowColor => UIColor.Black;

        public UIImage MenuButtonImage => UIImage.FromBundle("Images/ic_menu");

        public int MenuWidth => 265;

        public bool ReopenOnRotate => true;

        public void MenuDidClose()
        {
            // Method intentionally left empty.
        }

        public void MenuDidOpen()
        {
            // Method intentionally left empty.
        }

        public void MenuWillClose()
        {
            // Method intentionally left empty.
        }

        public void MenuWillOpen()
        {
            // Method intentionally left empty.
        }

        protected override void CreateView()
        {
            _menuHome = new UILabel
            {
                Text = "Home"
            };
            Add(_menuHome);

            _menuSettings = new UILabel
            {
                Text = "Settings"
            };
            Add(_menuSettings);

            _menuTip = new UILabel
            {
                Text = "Tip Calculator"
            };
            Add(_menuTip);

            _menuChinook = new UILabel
            {
                Text = "Chinook"
            };
            Add(_menuChinook);

            _menuLifecycle = new UILabel
            {
                Text = "Lifecycle"
            };
            Add(_menuLifecycle);

            _menuFFImage = new UILabel
            {
                Text = "FF Image"
            };
            Add(_menuFFImage);

            _menuRestDemo = new UILabel
            {
                Text = "Rest Demo"
            };
            Add(_menuRestDemo);

            _menuSpinner = new UILabel
            {
                Text = "Spinner Demo"
            };
            Add(_menuSpinner);
        }

        protected override void LayoutView()
        {
            NSObject topGuide = UIDevice.CurrentDevice.CheckSystemVersion(11, 0) ? 
                View.SafeAreaLayoutGuide : View.LayoutMarginsGuide;
            
            View.AddConstraints(new FluentLayout[]
            {
                _menuHome.Top().EqualTo().TopOf(topGuide).Plus(25f),
                _menuHome.AtLeftOf(View, 10f),
                _menuHome.AtLeftOf(View, 10f),
                _menuHome.ToRightOf(View),

                _menuSettings.Below(_menuHome, 10f),
                _menuSettings.AtLeftOf(View, 10f),
                _menuSettings.ToRightOf(View),

                _menuTip.Below(_menuSettings, 10f),
                _menuTip.AtLeftOf(View, 10f),
                _menuTip.ToRightOf(View),

                _menuChinook.Below(_menuTip, 10f),
                _menuChinook.AtLeftOf(View, 10f),
                _menuChinook.ToRightOf(View),

                _menuLifecycle.Below(_menuChinook, 10f),
                _menuLifecycle.AtLeftOf(View, 10f),
                _menuLifecycle.ToRightOf(View),

                _menuFFImage.Below(_menuLifecycle, 10f),
                _menuFFImage.AtLeftOf(View, 10f),
                _menuFFImage.ToRightOf(View),

                _menuRestDemo.Below(_menuFFImage, 10f),
                _menuRestDemo.AtLeftOf(View, 10f),
                _menuRestDemo.ToRightOf(View),

                _menuSpinner.Below(_menuRestDemo, 10f),
                _menuSpinner.AtLeftOf(View, 10f),
                _menuSpinner.ToRightOf(View),

            });
        }

        protected override void BindView()
        {
            MvxFluentBindingDescriptionSet<MenuView, MenuViewModel>
                bindingSet = this.CreateBindingSet<MenuView, MenuViewModel>();

            bindingSet.Bind(_menuHome.Tap()).For(v => v.Command).To(vm => vm.ShowHomeCommand);
            bindingSet.Bind(_menuSettings.Tap()).For(v => v.Command).To(vm => vm.ShowSettingsCommand);
            bindingSet.Bind(_menuTip.Tap()).For(v => v.Command).To(vm => vm.ShowTipCommand);
            bindingSet.Bind(_menuChinook.Tap()).For(v => v.Command).To(vm => vm.ShowChinookCommand);
            bindingSet.Bind(_menuLifecycle.Tap()).For(v => v.Command).To(vm => vm.ShowLifecycleCommand);
            bindingSet.Bind(_menuFFImage.Tap()).For(v => v.Command).To(vm => vm.ShowFFImageCommand);
            bindingSet.Bind(_menuRestDemo.Tap()).For(v => v.Command).To(vm => vm.ShowRestDemoCommand);
            bindingSet.Bind(_menuSpinner.Tap()).For(v => v.Command).To(vm => vm.ShowSpinnerCommand);
            bindingSet.Apply();
        }
    }
}
