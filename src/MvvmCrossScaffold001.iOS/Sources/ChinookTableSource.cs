using System;
using System.Collections.Generic;
using System.Windows.Input;
using MvvmCross.Binding.Extensions;
using MvvmCross.Platforms.Ios.Binding.Views;
using MvvmCrossScaffold001.iOS.Views.Cells;
//using MvvmCrossScaffold001.iOS.Views.Chinook.Cells;
using UIKit;

namespace MvvmCrossScaffold001.iOS.Sources
{
    //--------------------------------------------------------------------------
    //--------------------------------------------------------------------------
    public class MySimpleTableViewSource : MvxSimpleTableViewSource
    {
        public ICommand FetchCommand { get; set; }

        public MySimpleTableViewSource(UITableView tableView) : base(tableView, typeof(NameTableViewCell))
        {
            DeselectAutomatically = true;
        }

        protected override UITableViewCell GetOrCreateCellFor(UITableView tableView, Foundation.NSIndexPath indexPath, object item)
        {
            var cell = base.GetOrCreateCellFor(tableView, indexPath, item);

            if (indexPath.Item == ItemsSource.Count() - 5)
                FetchCommand?.Execute(null);

            return cell;
        }
    }

    //--------------------------------------------------------------------------
    //--------------------------------------------------------------------------
    /*
    public class PlanetsTableViewSource : MvxTableViewSource
    {
        private readonly Dictionary<Type, Type> _itemsTypeDictionary = new Dictionary<Type, Type>
        {
            [typeof(Planet)] = typeof(NameTableViewCell),
            [typeof(Planet2)] = typeof(WhiteNameTableViewCell)
        };

        public ICommand FetchCommand { get; set; }

        public PlanetsTableViewSource(UITableView tableView) : base(tableView)
        {
            RegisterCellsForReuse();

            DeselectAutomatically = true;
        }

        protected override UITableViewCell GetOrCreateCellFor(UITableView tableView, Foundation.NSIndexPath indexPath, object item)
        {
            Type cellType = null;
            if (!_itemsTypeDictionary.TryGetValue(item.GetType(), out cellType))
                throw new MvxException($"Type {item.GetType().Name} is not registered as cell. Please override RegisterCellsForReuse");

            var cell = this.TableView.DequeueReusableCell(cellType.Name, indexPath) as BaseTableViewCell;

            if (indexPath.Item == ItemsSource.Count() - 5)
                FetchCommand?.Execute(null);

            return cell;
        }

        private void RegisterCellsForReuse()
        {
            foreach (var type in _itemsTypeDictionary.Values)
            {
                TableView.RegisterClassForCellReuse(type, type.Name);
            }
        }
    }
    */
}
