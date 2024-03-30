using MultiShop.DtoLayer.CommentsDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.CatalogServices.CommentServices
{
    public class CommentService : ICommentService
    {
        private readonly HttpClient _httpClient;

        public CommentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateCommentAsync(CreateCommentDto createCommentDto)
        {
           await _httpClient.PostAsJsonAsync<CreateCommentDto>("Comments",createCommentDto);
            
        }

        public async Task DeleteCommentAsync(string CommentId)
        {
            await _httpClient.GetAsync($"Comments/delete/{CommentId}");
        }

        public async Task<List<ResultCommentDto>> GetAllCommentsAsync()
        {
           return await _httpClient.GetFromJsonAsync<List<ResultCommentDto>>("Comments");

        }

        public async Task<UpdateCommentDto> GetByIdCommentAsync(string CommentId)
        {
            return await _httpClient.GetFromJsonAsync<UpdateCommentDto>($"Comments/{CommentId}");
        }

		public async Task<List<ResultCommentDto>> GetCommentsByProductIdAsync(string productId)
		{
			return await _httpClient.GetFromJsonAsync<List<ResultCommentDto>>($"Comments/GetByProductId?productId={productId}");

		}

		public async Task UpdateCommentAsync(UpdateCommentDto updateCommentDto)
        {
            await _httpClient.PostAsJsonAsync<UpdateCommentDto>("Comments/update", updateCommentDto);
        }
    }
}
