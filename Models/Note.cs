namespace MyNotes_PetProject.Models;

public class Note
{
    public Note(string name, string description) // Создали контроллер с двумя свойствами
    {
        Console.WriteLine("Идет использование контролера Note");
        Name= name;
        Description= description;
        CreatedAt = DateTime.UtcNow; //При использование контролера свойсву Date идет дата создания сегодн
    }
    public Guid Id { get; init; }
    public string Name { get; init; } 
    public string Description { get; init; }
    public DateTime CreatedAt { get; init; } //Время создания
}   
