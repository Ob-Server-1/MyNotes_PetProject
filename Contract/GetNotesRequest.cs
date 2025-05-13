using Microsoft.AspNetCore.Mvc;

namespace MyNotes_PetProject.Contract;

public record GetNotesRequest(string? Serch, string? SortOrder, string? SortItem ="id"); //Контракт на сортивку и получение данных
