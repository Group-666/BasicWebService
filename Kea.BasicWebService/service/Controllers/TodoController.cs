using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Kea.BasicWebService.Service
{
    [Route("api/[controller]")]
    public class TodoController : Controller
    {
        public TodoController()
        {

        }

        [HttpGet]
        public IEnumerable<string> GetAll()
        {
            return new[] {"Do shopping", "Walk the dog"};
        }

        [HttpGet("{id}", Name = "GetTodo")]
        public IActionResult GetById(long id)
        {
            return new ObjectResult($"The id was: {id}");
        }
    }
}