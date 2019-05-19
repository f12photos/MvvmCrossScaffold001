using System;
using MvvmCross.Platforms.Ios.Binding.Views;

namespace MvvmCrossScaffold001.iOS.Views.Chinook.Cells
{
    public class BaseTableViewCell : MvxTableViewCell
    {
        private bool _didSetupConstraints;

        public BaseTableViewCell(IntPtr handle) : base(handle)
        {
            RunLifecycle();
        }

        private void RunLifecycle()
        {
            CreateView();

            SetNeedsUpdateConstraints();
        }

        public override sealed void UpdateConstraints()
        {
            if (!_didSetupConstraints)
            {
                LayoutView();

                _didSetupConstraints = true;
            }
            base.UpdateConstraints();
        }

        protected virtual void CreateView()
        {
        }

        protected virtual void LayoutView() // CreateConstraints()
        {
        }

        protected virtual void BindView() // CreateConstraints()
        {
        }
    }
}
