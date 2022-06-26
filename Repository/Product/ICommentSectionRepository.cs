using tropsly_api.Model;

namespace tropsly_api.Repository
{
    public interface ICommentSectionRepository
    {
        Task<IEnumerable<CommentSection>> GetAllByProductId(int id);
        Task<CommentSection> GetById(int id);
        Task Add(CommentSection commentSection);
    }
}
