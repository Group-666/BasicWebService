using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Kea.BasicWebService.Client
{
    public class MainController
    {
        private readonly TodoRepository _repository;

        public MainController()
        {
            _repository = new TodoRepository();
        }

        public async Task HandleUserInput()
        {
            Console.WriteLine("The Fantastic Todo App!");

            string line;
            while ((line = Console.ReadLine()).ToLower() != "exit")
            {
                if (line.ToLower().StartsWith("add "))
                {
                    var todo = line.Substring(4);
                    await AddTodo(todo);
                }
                else if (line.ToLower().StartsWith("remove "))
                {
                    var index = int.Parse(line.Substring(7)) - 1;
                    await DeleteTodo(index);
                }
                else if (line.ToLower().StartsWith("show all"))
                {
                    await ShowAllTodos();
                }
                else
                    Console.WriteLine("Invalid command.");
            }
        }

        private async Task ShowAllTodos()
        {
            Console.WriteLine("Showing all.");
            
            var todos = await _repository.GetAll();
            for (var i = 0; i < todos.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {todos[i]}");
            }
        }

        private async Task DeleteTodo(int index)
        {
            await _repository.Remove(index);

            Console.WriteLine("Removed todo.");
        }

        private async Task AddTodo(string todo)
        {
            await _repository.Add(todo);

            Console.WriteLine("Added!");
        }
    }
}
