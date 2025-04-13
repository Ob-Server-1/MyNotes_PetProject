using Microsoft.AspNetCore.Mvc;
using MyNotes_PetProject.Contract;
using MyNotes_PetProject.DateAccess;
using MyNotes_PetProject.Models;
namespace MyNotes_PetProject.Controllers;

 
[ApiController] //Атрибут Апи контроллера
[Route("[Controller]")] //Роутим контроллер , без надписи Controller, и будет просто Notes
public class NotesController : ControllerBase // ControllerBase нужен для создание оконтроллеров и их интеграцию
{                                   // В Депеденси инжекшен
    private readonly NotesDbContext _context;
    public NotesController(NotesDbContext dbContext)
    { 
        _context = dbContext;
    }

    [HttpPost]
    //Метод Post имеет тело и через него мы и отправим данные сюда Для этого и нужен FromBody,
    //Пример POST = { note: {"name" : "заметка"} }  - Тело или FromBody формат Json
    public async Task<IActionResult> Create( [FromBody] CreateNotesRequest request, CancellationToken ct) // позволяетвозращать коды из методов
    {
        var note = new Note(request.Name, request.Description);

        await _context.Notes.AddAsync(note,ct); // Добавляем данные
        await _context.SaveChangesAsync(ct); //Сохраняем изменения
        return Ok(); //Статус код 200 
    }
    [HttpGet] 
    public async Task<IActionResult> Get(string serch, string sortItem, string sortOrder)
    {

        return Ok();
    }
}
