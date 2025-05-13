using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyNotes_PetProject.Contract;
using MyNotes_PetProject.DateAccess;
using MyNotes_PetProject.Models;
using System.Linq.Expressions;
namespace MyNotes_PetProject.Controllers;

 
[ApiController] //Атрибут Апи контроллера
[Route("[Controller]")] //Роутим контроллер , без надписи Controller, и будет просто Notes
public class NotesController : ControllerBase // ControllerBase нужен для создание оконтроллеров и их интеграцию
{                                   // В Депеденси инжекшен
    private readonly NotesDbContext _context;
    public NotesController(NotesDbContext dbContext) //Через конструктор кидаем ДБ контекст для работы с бд
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
    public async Task<IActionResult> Get([FromQuery] GetNotesRequest request, CancellationToken ct)
    {
     
        var notesQuery = _context.Notes   //Фильтр по поиску названия заметок
                 .Where(n => string.IsNullOrWhiteSpace(request.Serch) ||
                     n.Name.ToLower().Contains(request.Serch.ToLower()));

        Expression<Func<Note, object>> selectorKey = request.SortItem.ToLower() switch
        {
            "date" => note => note.CreatedAt,
            "name" => note => note.Name,
            _ => note => note.Id
        };

        //Тернарная операция Если
        notesQuery = request.SortOrder == "desc"
                 ? notesQuery.OrderByDescending(selectorKey)
                 : notesQuery.OrderBy(selectorKey);


        var noteDtos = await notesQuery
            .Select(n => new NoteDto(n.Id, n.Name, n.Description, n.CreatedAt))
            .ToListAsync(ct);

        return Ok(new GetNotesResponse(noteDtos));


    }

    //Примечание KeySelector - Это прааметр по которому нужно сортировать данные

}
