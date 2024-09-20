namespace MultiShop.Catalog.Services.StatisticService
{
    public interface IStatisticService
    {
        long GetCategoryCount();

        long GetProductCount();

        long GetBrandCount();

         Task< decimal> GetProductAvgPrice();

        Task<string> GetMinPriceProductName();
        Task<string> GetMaxPriceProductName();


    }
}
