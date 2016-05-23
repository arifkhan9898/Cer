namespace Cer.Infrastructure.Business.Service.Interfaces
{
    public interface ILoyaltyPointsStrategy
    {
        decimal GetLoyaltyPoints(int heavyCount, int regularCount, int specializedCount);
    }
}