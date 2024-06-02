

using MultiShop.Catalog.Dtos.OfferDiscount;

namespace MultiShop.Catalog.Services.OfferDiscountService
{
    public interface IOfferDiscountService
    {
        Task<List<ResultOfferDiscountDto>> GetAllOfferDiscountsAsync();
        Task CreateOfferDiscountAsync(CreateOfferDiscountDto createOfferDiscountDto);

        Task UpdateOfferDiscountAsync(UpdateOfferDiscountDto updateOfferDiscountDto);
        Task DeleteOfferDiscountAsync(string id);

        Task<GetByIdOfferDiscountDto> GetByIdOfferDiscountAsync(string id);
    }
}
