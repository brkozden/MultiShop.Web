using MultiShop.Dtos.CommentDtos;

namespace MultiShop.WebUI.Services.CommentServices
{
    public interface ICommentService
    {
        Task<List<ResultCommentDto>> GetAllCommentAsync();
        Task CreateCommentAsync(CreateCommentDto createCommentDto);

        Task UpdateCommentAsync(UpdateCommentDto updateCommentDto);
        Task DeleteCommentAsync(string id);

        Task<GetByIdCommentDto> GetByIdCommentAsync(string id);

        Task<List<GetByIdCommentDto>> GetCommentListByProductIdAsync(string id);



    }
}
