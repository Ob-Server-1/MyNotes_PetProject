using Microsoft.AspNetCore.Mvc;

namespace MyNotes_PetProject.Contract;

public record GetNotesRequest(string serch, string sortItem, string sortOrder); //Контракт на сортивку и получение данных
// 14 16 ролик