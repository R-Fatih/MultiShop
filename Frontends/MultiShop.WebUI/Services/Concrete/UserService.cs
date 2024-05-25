using MultiShop.DtoLayer.IdentityDtos.UserDtos;
using MultiShop.WebUI.Models;
using MultiShop.WebUI.Services.Interfaces;
using System.Net.Http;

namespace MultiShop.WebUI.Services.Concrete
{
    public class UserService : IUserService
    {
        private readonly HttpClient _client;

        public UserService(HttpClient client)
        {
            _client = client;
        }

        public async Task<UserDetailViewModel> GetUserInfo()
        {
            return await _client.GetFromJsonAsync<UserDetailViewModel>("/api/users/getuser");
        }
        public async Task<List<ResultUserDto>> GetAllUsers()
        {
			return await _client.GetFromJsonAsync<List<ResultUserDto>>("/api/users/GetAllUserList");

		}

        public async Task<int> GetUserCount()
        {
            return await _client.GetFromJsonAsync<int>("/api/Statistics");
        }
    }
}
