namespace ToDoApplication.Models 
{
    public class ToDo 
    {
        public int Id {get; set;}
        public required string Title {get; set;}
        public string? Desc {get; set;}
        public bool IsComplete {get; set; }
        public DateTime CreatedAt {get; set; }
    }
}