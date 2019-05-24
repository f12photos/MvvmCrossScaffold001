using System;
using Cirrious.FluentLayouts.Touch;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Binding.Views;
using MvvmCrossScaffold001.Core.Models;
using UIKit;

namespace MvvmCrossScaffold001.iOS.Views.Cells
{
    // generic cell for items with name property
    public class ArtistTableViewCell : BaseTableViewCell
    {
        private const float PADDING = 12f;

        private UILabel _lblName, _lblImageUrl;
        private UIImageView _imgView;


        public ArtistTableViewCell(IntPtr handle) : base(handle)
        {
            //MvxImageViewLoader
        }

        protected override void CreateView()
        {
            base.CreateView();

            SelectionStyle = UITableViewCellSelectionStyle.None;
            BackgroundColor = UIColor.Clear;

            _lblName = new UILabel
            {
                TextColor = UIColor.Blue,
                Font = UIFont.SystemFontOfSize(15f, UIFontWeight.Bold)
            };
            ContentView.AddSubview(_lblName);

            _lblImageUrl = new UILabel
            {
                TextColor = UIColor.Blue,
                Font = UIFont.SystemFontOfSize(15f, UIFontWeight.Bold)
            };
            ContentView.AddSubview(_lblImageUrl);

            _imgView = new UIImageView();
            ContentView.AddSubview(_imgView);

            ContentView.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();
        }

        protected override void LayoutView()
        {
            base.LayoutView();

            ContentView.AddConstraints(
                _lblName.AtRightOfSafeArea(ContentView, PADDING),
                _lblName.AtTopOf(ContentView, PADDING),

                _lblImageUrl.AtRightOfSafeArea(ContentView, PADDING),
                _lblImageUrl.Below(_lblName, PADDING),
                _lblImageUrl.AtBottomOf(ContentView, PADDING),

                _imgView.AtLeftOfSafeArea(ContentView, PADDING),
                _imgView.AtTopOf(ContentView, PADDING),
                _imgView.ToRightOfCenterOf(ContentView, PADDING),
                _imgView.AtBottomOf(ContentView, PADDING)
            );
        }

        protected override void BindView()
        {
            this.DelayBind(() =>
            {
                var set = this.CreateBindingSet<ArtistTableViewCell, Artist>();
                set.Bind(_lblName).To(vm => vm.Name);
                set.Bind(_lblImageUrl).To(vm => vm.ImageUrl);
                set.Bind(_imgView).To(vm => vm.ImageUrl);
                set.Apply();
            });
        }
    }
}

