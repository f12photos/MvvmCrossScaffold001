using Foundation;
using MvvmCross.Platforms.Ios.Core;
using MvvmCrossScaffold001.Core;

namespace MvvmCrossScaffold001.iOS
{
    [Register(nameof(AppDelegate))]
    public class AppDelegate : MvxApplicationDelegate<Setup, App>
    {
    }
}
