namespace MultiShop.WebUI.Services.StatisticServices.CatalogStatisticServices
{
    public interface ICatalogStatisticService
    {
        Task<long> GetCategoryCount();

        Task<long> GetProductCount();

        Task<long> GetBrandCount();

        Task<decimal> GetProductAvgPrice();

        Task<string> GetMinPriceProductName();
        Task<string> GetMaxPriceProductName();
    }
}
