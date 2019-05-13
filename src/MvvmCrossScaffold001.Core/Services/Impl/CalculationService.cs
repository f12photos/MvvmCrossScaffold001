using System;
using MvvmCrossScaffold001.Core.Services.Itf;

namespace MvvmCrossScaffold001.Core.Services.Impl
{
    public class CalculationService : ICalculationService
    {
        public CalculationService()
        {
        }

        public double TipAmount(double subTotal, int generosity)
        {
            return subTotal * ((double)generosity) / 100.0;
        }
    }
}
