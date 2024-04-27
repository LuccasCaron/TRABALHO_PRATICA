namespace PROJETO_ADVOCACIA.Models;

public record ResultDataObject<T>(bool Success, string Message, T? Data);
