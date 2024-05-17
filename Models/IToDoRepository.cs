using System;
using System.Collections.Generic;

namespace ToDoApplication.Models
{
    public interface IToDoRepository
    {
        IEnumerable<ToDo> GetAll();
        
        ToDo Add(ToDo item);

        ToDo Edit(ToDo item); 

        int Delete(ToDo item); 
    }
}