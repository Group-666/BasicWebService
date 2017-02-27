using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Kea.BasicWebService.Client
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Task.Run(HandleUserInput).Wait();
        }

        public static async Task HandleUserInput()
        {
            var repo = new TodoRepository();
            
            Console.WriteLine("The Fantastic Todo App!");

            string line;
            while ((line = Console.ReadLine()).ToLower() != "exit")
            {
                if (line.ToLower().StartsWith("add "))
                {
                    var todo = line.Substring(4);
                
                    await repo.Add(todo);
                
                    Console.WriteLine("Added!");
                }
                else if (line.ToLower().StartsWith("remove "))
                {
                    var index = int.Parse(line.Substring(7)) - 1;
                
                    await repo.Remove(index);
                
                    Console.WriteLine("Removed todo.");
                }
                else if (line.ToLower().StartsWith("show all"))
                {
                    Console.WriteLine("Showing all.");
                    var todos = await repo.GetAll();
                    for (var i = 0; i < todos.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}: {todos[i]}");
                    }
                }
                else
                    Console.WriteLine("Invalid command.");
            }
        }
    }
}
