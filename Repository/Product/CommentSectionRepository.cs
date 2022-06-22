using Microsoft.EntityFrameworkCore;
using tropsly_api.Data;
using tropsly_api.Model;
using tropsly_api.Model.UserAccess;

namespace tropsly_api.Repository
{
    public class CommentSectionRepository : ICommentSectionRepository
    {
        private readonly IDataContext _dataContext;

        public CommentSectionRepository(IDataContext dataContext)
        {
            _dataContext=dataContext; 
        }

        public async Task Add(CommentSection commentSection)
        {
             _dataContext.CommentSections.Add(commentSection);
            await _dataContext.SaveChangeAsync();
        }

        public async Task<IEnumerable<CommentSection>> GetAllByProductId(int id)
        {
            return await _dataContext.CommentSections.Where(x => x.ProductId == id).ToListAsync();
        }

        public async Task<CommentSection> GetById(int id)
        {
            return await _dataContext.CommentSections.FindAsync(id);
        }
    }
}
