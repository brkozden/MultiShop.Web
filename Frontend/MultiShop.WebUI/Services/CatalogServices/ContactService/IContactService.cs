using MultiShop.Dtos.CatalogDtos.ContactDtos;

namespace MultiShop.WebUI.Services.CatalogServices.ContactService
{
    public interface IContactService
    {
        Task<List<ResultContactDto>> GetAllContactsAsync();
        Task CreateContactAsync(CreateContactDto createContactDto);

        Task UpdateContactAsync(UpdateContactDto updateContactDto);
        Task DeleteContactAsync(string id);

        Task<GetByIdContactDto> GetByIdContactAsync(string id);
    }
}
