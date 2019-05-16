using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using MvvmCross.IoC;
using MvvmCrossScaffold001.Core.ViewModels.Chinook;

namespace MvvmCrossScaffold001.Core.Services
{
    public interface IChinookService
    {
        Type NextViewModelType(ChinookBaseViewModel currentViewModel);

        IList<Type> All { get; }
    }

    public class ChinookService
        : IChinookService
    {
        public ChinookService()
        {
            All = GetType().GetTypeInfo().Assembly.CreatableTypes()
                           .Where(t => typeof(ChinookBaseViewModel).IsAssignableFrom(t))
                           .ToList();
        }

        public Type NextViewModelType(ChinookBaseViewModel currentViewModel)
        {
            var index = All.IndexOf(currentViewModel.GetType());
            var nextIndex = index + 1;
            if (nextIndex < All.Count)
                return All[nextIndex];

            return null;
        }

        public IList<Type> All { get; private set; }
    }
}
