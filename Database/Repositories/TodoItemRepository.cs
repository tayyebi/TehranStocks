using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TehranStocks.Context;
using TehranStocks.Domain.DatabaseModels;
using TehranStocks.Domain.RepositoriesInterfaces;
using TehranStocks.Libs;

namespace TehranStocks.Database.Repositories
{
    public class TodoItemRepository : BaseRepository, ITodoItemRepository
    {
        public TodoItemRepository(AppDbContext Context, UnitOfWork unitOfWork) : base(Context, unitOfWork)
        {
        }

        public TodoItem Add(TodoItem todoItem)
        {
            _context.TodoItems.Add(todoItem);
            _context.SaveChanges();
            return todoItem;
        }

        public List<TodoItem> GetTodoItems() => _context.TodoItems.Paginate(new PaginationDetails());
    }
}