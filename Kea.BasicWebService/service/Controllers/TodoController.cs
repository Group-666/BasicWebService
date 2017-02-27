using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Kea.BasicWebService.Service
{
    [Route("api/[controller]")]
    public class TodoController : Controller
    {
        private static readonly List<string> Todos = new List<string>
            {
                "Do shopping", 
                "Walk the dog",
                "Be happy",
                "Praise Satan"
            };

        [HttpGet]
        public IEnumerable<string> GetAll()
        {
            return Todos;
        }

        [HttpPost]
        public IActionResult AddTodo([FromBody] string todo)
        {
            Todos.Add(todo);

            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteTodo([FromBody] int index)
        {
            Todos.RemoveAt(index);

            return Ok();
        }
    }
}