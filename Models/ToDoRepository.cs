using System; 
using System.Collections.Generic;
using System.ComponentModel;

namespace ToDoApplication.Models
{
    public class ToDoRepository : IToDoRepository
    {
        private List<ToDo> toDoList = new List<ToDo>(); 
        private int _nextId = 1; 

        public ToDoRepository() 
        {
            Add(new ToDo { Title = "Order pizza", Desc = "Pepperoni & Sausage", IsComplete = false, CreatedAt = new DateTime(2024,5,15)}); 
            Add(new ToDo { Title = "Mail tax papers", IsComplete = false, CreatedAt = new DateTime(2024,4,1)}); 

        }

        public IEnumerable<ToDo> GetAll()
        {
            return toDoList; 
        }

        public ToDo Add(ToDo item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            item.Id = _nextId++;
            toDoList.Add(item);
            return item;
        }

        public ToDo Edit(ToDo item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            int index = item.Id; 

            if(index != -1)
            {
                toDoList[index] = item; 
            }

            return item; 
        }

        public int Delete(ToDo item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            toDoList.Remove(item); 

            return toDoList.Count; 
        }
    }
}