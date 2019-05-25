using Foundation;
using System;
using UIKit;
using MvvmCross.Binding.BindingContext;
using FFImageLoading.Cross;
using Cirrious.FluentLayouts.Touch;
using MvvmCross.Platforms.Ios.Binding.Views;
using MvvmCrossScaffold001.Core.Models;

namespace MvvmCrossScaffold001.iOS.Views.FFImage
{
    public class FFImageCell : MvxTableViewCell
    {
        private MvxCachedImageView _imageControl;

        private bool _constraintsCreated;

        public FFImageCell(IntPtr handle) : base(handle)
        {
            _imageControl = new MvxCachedImageView();
            _imageControl.BackgroundColor = UIColor.Red;

            ContentView.AddSubview(_imageControl);
            ContentView.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            SetNeedsUpdateConstraints();

            this.DelayBind(
                () =>
                {
                    _imageControl.LoadingPlaceholderImagePath = "res:place.jpg";
                    _imageControl.ErrorPlaceholderImagePath = "res:place.jpg";
                    _imageControl.TransformPlaceholders = true;

                    var set = this.CreateBindingSet<FFImageCell, Image>();
                    set.Bind(_imageControl).For(v => v.DownsampleWidth).To(vm => vm.DownsampleWidth);
                    //set.Bind(_imageControl).For(v => v.Transformations).To(vm => vm.Transformations);
                    set.Bind(_imageControl).For(v => v.ImagePath).To(vm => vm.Url);
                    set.Apply();
                }
            );
        }

        public override void UpdateConstraints()
        {
            if (!_constraintsCreated)
            {
                ContentView.AddConstraints(
                    _imageControl.WithSameCenterY(ContentView),
                    _imageControl.WithSameCenterX(ContentView),
                    _imageControl.Width().EqualTo(55f),
                    _imageControl.Height().EqualTo(55f)
                );

                _constraintsCreated = true;
            }

            base.UpdateConstraints();
        }
    }
}
