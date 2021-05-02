using System.Threading.Tasks;
using TehranStocks.Database;

namespace TehranStocks.Context
{
    public class UnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context) =>
            _context = context;
            
        public virtual async Task SaveChangesAsync() =>
            await _context.SaveChangesAsync();
    }
}