namespace Cer.Service.Logics
{
    public interface IPriceCalculatorLogic
    {
        decimal GetPriceInEuros(int days);
        decimal OneTimeRentalFeeInEuros { get; }
        decimal PremiumDailyFeeInEuros { get; }
        decimal RegularDailyFeeInEuros { get; }
    }
}
