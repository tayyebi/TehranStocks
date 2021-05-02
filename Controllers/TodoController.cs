using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TehranStocks.Context;
using TehranStocks.Database;
using TehranStocks.Domain.DatabaseModels;
using TehranStocks.Domain.RepositoriesInterfaces;

namespace TehranStocks.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoController : ControllerBase
    {
        private ITodoItemRepository _todoItemRepository;
        public TodoController(ITodoItemRepository todoItemRepository)
        {
            _todoItemRepository = todoItemRepository;
        }

        [HttpGet]
        [Route("All")]
        public async Task<ActionResult<List<TodoItem>>> Get()
        {
            var todoItem = new TodoItem
            {
                Id = 1,
                Name = "A simple TODO item",
                IsComplete = false
            };
            // For rapid testing.
            _todoItemRepository.Add(todoItem);
            todoItem.Id =2;
            _todoItemRepository.Add(todoItem);
            todoItem.Id =3;
            _todoItemRepository.Add(todoItem);
            todoItem.Id =4;
            _todoItemRepository.Add(todoItem);
            var test = _todoItemRepository.GetTodoItems();
            return test;
        }

        [HttpPost]
        public async Task<ActionResult<TodoItem>> Post(TodoItem todoItem)
        {
            return CreatedAtAction(nameof(Get),
                _todoItemRepository.Add(todoItem));
        }
    }
}