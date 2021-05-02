using TehranStocks.Context;

namespace TehranStocks.Database.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly AppDbContext _context;
        protected readonly UnitOfWork _unitOfWork;
        public BaseRepository(AppDbContext Context, UnitOfWork unitOfWork)
        {
            _context = Context;
            _unitOfWork = unitOfWork;
        }
    }
}