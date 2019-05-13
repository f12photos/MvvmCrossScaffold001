using System;
namespace MvvmCrossScaffold001.Core.Services.Itf
{
    public interface ICalculationService
    {
        double TipAmount(double subTotal, int generosity);
    }
}
