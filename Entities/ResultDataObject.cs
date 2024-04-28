namespace PROJETO_ADVOCACIA.Entities;

public record ResultDataObject<T>(bool Success, string Message, T? Data);
