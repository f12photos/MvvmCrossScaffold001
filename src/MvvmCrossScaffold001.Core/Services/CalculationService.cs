using System;
namespace MvvmCrossScaffold001.Core.Services
{
    public interface ICalculationService
    {
        double TipAmount(double subTotal, int generosity);
    }

    //--------------------------------------------------------------------------
    //--------------------------------------------------------------------------
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
