using MyNotes_PetProject.DateAccess;
//Видеос 30 43 https://www.youtube.com/watch?v=csD_-3Gdk5k&t=855s
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddSwaggerGen();
builder.Services.AddScoped<NotesDbContext>();

var app = builder.Build();

using var scope = app.Services.CreateScope();

var _context = scope.ServiceProvider.GetRequiredService<NotesDbContext>();
await _context.Database.EnsureCreatedAsync();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapControllers();

app.Run();
