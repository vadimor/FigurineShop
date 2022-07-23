using Comment.Data.Entities;

namespace Comment.Repositories.Interfaces
{
    public interface ICommentRepository
    {
        Task<CommentEntity?> AddCommentAsync(CommentEntity comment);
        Task<CommentEntity?> GetCommentAsync(int id);
        Task<IEnumerable<CommentEntity>> GetCommentsByProductIdAsync(int id);
        Task<CommentEntity?> RemoveCommentAsync(int id);
    }
}