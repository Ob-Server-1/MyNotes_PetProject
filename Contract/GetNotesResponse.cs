namespace MyNotes_PetProject.Contract;

public record GetNotesResponse(List<NoteDto> listDtos); //Возвращаем список с элементами


public record NoteDto(Guid Id, string Name, string description, DateTime CreatedAt);