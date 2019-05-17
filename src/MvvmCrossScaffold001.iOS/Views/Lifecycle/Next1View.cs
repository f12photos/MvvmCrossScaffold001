using System;
using MvvmCrossScaffold001.Core.ViewModels.Lifecycle;
using MvvmCrossScaffold001.iOS.Views;
using MvvmCrossScaffold001.Core.ViewModels;
using MvvmCross.Plugin.Sidebar;

namespace MyXamarinApp.iOS.Views
{
    [MvxSidebarPresentation(MvxPanelEnum.Center, MvxPanelHintType.PushPanel, true)]
    public class Next1View : BaseViewController<Next1ViewModel>
    {
        public Next1View()
        {
            Title = "VM 1";
        }
    }

    [MvxSidebarPresentation(MvxPanelEnum.Center, MvxPanelHintType.PushPanel, true)]
    public class Next2View : BaseViewController<Next2ViewModel>
    {
        public Next2View()
        {
            Title = "VM 2";
        }
    }
}
