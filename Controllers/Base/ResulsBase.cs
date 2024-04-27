using PROJETO_ADVOCACIA.Models;

namespace PROJETO_ADVOCACIA.Controllers.Base;

public static class ResultsBase
{
    public static IResult Success<T>(string message, T data)
    {
        return Results.Ok(new ResultDataObject<T>(true, message, data));
    }

    public static IResult BadRequest(string message)
    {
        return Results.BadRequest(new ResultDataObject<object>(false, message, null));
    }

    public static IResult NotFound(string message)
    {
        return Results.NotFound(new ResultDataObject<object>(false, message, null));
    }
}
