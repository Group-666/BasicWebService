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
                    Console.WriteLine("Adding todo.");
                }
                else if (line.ToLower().StartsWith("remove "))
                {
                    Console.WriteLine("Removing todo.");
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
