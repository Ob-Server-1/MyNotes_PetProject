namespace MyNotes_PetProject.Models;

public class Note
{
    public Note(string name, string description) // Создали контроллер с двумя свойствами
    {
        Console.WriteLine("Идет использование контролера Note");
        Name= name;
        Description= description;
        CreatedAt = DateTime.Now; //При использование контролера свойсву Date идет дата создания сегодн
    }
    public Guid Id { get; set; }
    public string Name { get; set; } 
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
}   
