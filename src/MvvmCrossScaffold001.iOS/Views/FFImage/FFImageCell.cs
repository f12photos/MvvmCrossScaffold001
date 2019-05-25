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
        private UILabel _labelWelcome;
        private bool _constraintsCreated;

        public FFImageCell(IntPtr handle) : base(handle)
        {
            _imageControl = new MvxCachedImageView();
            _imageControl.BackgroundColor = UIColor.Red;
            ContentView.AddSubview(_imageControl);

            _labelWelcome = new UILabel
            {
                TextAlignment = UITextAlignment.Center
            };
            ContentView.AddSubview(_labelWelcome);

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
                    set.Bind(_labelWelcome).To(vm => vm.Url);
                    set.Apply();
                }
            );
        }

        public override void UpdateConstraints()
        { 
            var margin = 10f;
            if (!_constraintsCreated)
            {
                ContentView.AddConstraints(
                    _imageControl.AtLeftOfSafeArea(ContentView, 2 * margin),
                    _imageControl.AtTopOfSafeArea(ContentView, margin),
                    _imageControl.AtBottomOfSafeArea(ContentView, margin),
                    _imageControl.Width().EqualTo(100f),
                    _imageControl.Height().EqualTo(100f),

                    _labelWelcome.ToRightOf(_imageControl, margin),
                    _labelWelcome.AtRightOfSafeArea(ContentView, 2 * margin),
                    _labelWelcome.WithSameCenterY(_imageControl)
                );

                _constraintsCreated = true;
            }

            base.UpdateConstraints();
        }
    }
}
