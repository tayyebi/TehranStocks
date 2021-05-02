using System.Collections.Generic;
using System.Threading.Tasks;
using TehranStocks.Domain.DatabaseModels;

namespace TehranStocks.Domain.RepositoriesInterfaces
{
    public interface ITodoItemRepository
    {
        TodoItem Add(TodoItem todoItem);
        List<TodoItem> GetTodoItems();
    }
}