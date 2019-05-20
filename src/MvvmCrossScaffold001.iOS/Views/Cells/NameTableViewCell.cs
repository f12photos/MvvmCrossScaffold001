using System;
using Cirrious.FluentLayouts.Touch;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Binding.Views;
using UIKit;

namespace MvvmCrossScaffold001.iOS.Views.Cells
{
    // generic cell for items with name property
    public class NameTableViewCell : BaseTableViewCell
    {
        private const float PADDING = 12f;

        private UILabel _lblName;


        public NameTableViewCell(IntPtr handle) : base(handle)
        {

        }

        protected override void CreateView()
        {
            base.CreateView();

            SelectionStyle = UITableViewCellSelectionStyle.None;

            _lblName = new UILabel
            {
                TextColor = UIColor.Red,
                Font = UIFont.SystemFontOfSize(15f, UIFontWeight.Bold)
            };

            BackgroundColor = UIColor.Clear;
            ContentView.AddSubview(_lblName);
            ContentView.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();
        }

        protected override void LayoutView()
        {
            base.LayoutView();

            ContentView.AddConstraints(
                _lblName.AtLeftOf(ContentView, PADDING),
                _lblName.AtTopOf(ContentView, PADDING),
                _lblName.AtBottomOf(ContentView, PADDING),
                _lblName.AtRightOf(ContentView, PADDING)
            );
        }

        protected override void BindView()
        {
            this.DelayBind(() =>
                {
                    this.AddBindings(_lblName, "Text Name"); // bind lbl.Text to item.Name
                });

            //this.DelayBind(() =>
            //{
            //    var set = this.CreateBindingSet<HoursEntryCell, EnterTime>();
            //    set.Bind(jobId).To(vm => vm.JobId);
            //    set.Bind(hours).To(vm => vm.Hours);
            //    set.Bind(jobName).To(vm => vm.JobName);
            //    set.Apply();
            //});
        }
    }
}

