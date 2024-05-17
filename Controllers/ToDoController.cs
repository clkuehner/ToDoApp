using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using ToDoApplication.Models;

namespace ToDoApplication.Controllers 
{
    [ApiController]
    public class ToDoController : ControllerBase
    {

        static readonly IToDoRepository repository = new ToDoRepository(); 

        [HttpGet]
        [Route("/api/todo_list")]
        public IEnumerable<ToDo> GetToDos() 
        {
            return repository.GetAll(); 
        }


        [HttpPost]
        [Route("api/todo")]
        [Consumes("application/json")] 
        public ToDo PostItem(ToDo item)
        {
            return repository.Add(item); 
        }

        [HttpPost]
        [Route("api/edittodo")]
        [Consumes("application/json")]
        public ToDo EditItem(ToDo item)
        {
            return repository.Edit(item); 
        }

        [HttpPost]
        [Route("api/deltodo")]
        [Consumes("application/json")]
        public int DeleteItem(ToDo item)
        {
            return repository.Delete(item); 
        }
    }
}