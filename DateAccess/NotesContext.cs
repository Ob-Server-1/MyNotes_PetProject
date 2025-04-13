using Microsoft.EntityFrameworkCore;
using MyNotes_PetProject.Models;
namespace MyNotes_PetProject.DateAccess;

public class NotesDbContext :DbContext
{
    public readonly IConfiguration _configuration; //Конфигурация

    public NotesDbContext(IConfiguration configuration) //Передаем через контроллер конфигурацию
    { 
        _configuration = configuration;
    }
    public DbSet<Note> Notes => Set<Note>();  //DbSet Для правильного табличного представления
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) //Основная конфигруация проекта
    {
        //Из конфигурации можем получить данные стркои подключения
        optionsBuilder.UseSqlite(_configuration.GetConnectionString("DataBase"));
    }

}
