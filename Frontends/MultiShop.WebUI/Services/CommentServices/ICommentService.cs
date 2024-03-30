using MultiShop.DtoLayer.CommentsDtos;

namespace MultiShop.WebUI.Services.CatalogServices.CommentServices
{
    public interface ICommentService
    {
        Task<List<ResultCommentDto>> GetAllCommentsAsync();
        Task CreateCommentAsync(CreateCommentDto createCommentDto);
        Task UpdateCommentAsync(UpdateCommentDto updateCommentDto);
        Task DeleteCommentAsync(string CommentId);
        Task<UpdateCommentDto> GetByIdCommentAsync(string CommentId);
        Task<List<ResultCommentDto>> GetCommentsByProductIdAsync(string productId);

	}
}
