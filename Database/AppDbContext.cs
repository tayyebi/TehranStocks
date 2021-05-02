using Microsoft.EntityFrameworkCore;
using TehranStocks.Domain.DatabaseModels;

namespace TehranStocks.Database
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<TodoItem> TodoItems { get; set; }
    }
}