using MultiShop.DtoLayer.CatalogDtos.ContactDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.CatalogServices.ContactServices
{
    public class ContactService : IContactService
    {
        private readonly HttpClient _httpClient;

        public ContactService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateContactAsync(CreateContactDto createContactDto)
        {
           await _httpClient.PostAsJsonAsync<CreateContactDto>("Contacts",createContactDto);
            
        }

        public async Task DeleteContactAsync(string ContactId)
        {
            await _httpClient.GetAsync($"Contacts/delete/{ContactId}");
        }

        public async Task<List<ResultContactDto>> GetAllContactsAsync()
        {
           return await _httpClient.GetFromJsonAsync<List<ResultContactDto>>("Contacts");

        }

        public async Task<UpdateContactDto> GetByIdContactAsync(string ContactId)
        {
            return await _httpClient.GetFromJsonAsync<UpdateContactDto>($"Contacts/{ContactId}");
        }

        public async Task UpdateContactAsync(UpdateContactDto updateContactDto)
        {
            await _httpClient.PostAsJsonAsync<UpdateContactDto>("Contacts/update", updateContactDto);
        }
    }
}
