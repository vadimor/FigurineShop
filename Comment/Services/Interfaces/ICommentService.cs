using Comment.Models.Dtos;
using Comment.Models.Request;

namespace Comment.Services.Interfaces
{
    public interface ICommentService
    {
        Task<CommentDto?> AddCommentAsync(AddRequest request, int userId);
        Task<IEnumerable<CommentDto>> GetCommentsByProductIdAsync(int id);
        Task<CommentDto?> RemoveCommentAsync(int commentId, int userId);
    }
}