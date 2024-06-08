using PROJETO_ADVOCACIA.Routes.Base;
using PROJETO_ADVOCACIA.Entities;
using PROJETO_ADVOCACIA.Services.Advogados;

namespace PROJETO_ADVOCACIA.Routes;

public static class AdvogadoRoutes
{

    public static WebApplication RotasAdvogado(this WebApplication app)
    {

        #region Read Operations

        app.MapGet("Advogados", async (IAdvogadoService advogadoService) =>
        {
            var allAdvogados = await advogadoService.PegarTodosAdvogadosAsync();

            if(!allAdvogados.Success)
                return ResultsBase.NotFound(allAdvogados.Message);

            return ResultsBase.Success(allAdvogados.Message, allAdvogados.Data);
        })
        .WithTags("Advogado");

        app.MapGet("Advogado/{cpf}", async (string cpf, IAdvogadoService advogadoService) =>
        {
            var advogado = await advogadoService.PegarAdvogadoPeloCpfAsync(cpf);

            if (!advogado.Success)
                return ResultsBase.NotFound(advogado.Message);

            return ResultsBase.Success(advogado.Message, advogado.Data);
        })
      .WithTags("Advogado");

        #endregion

        #region Write Operations

        app.MapPost("Advogado", async (Advogado novoAdvogado, IAdvogadoService advogadoService) =>
        {
            if (novoAdvogado.CPF == null)
                return ResultsBase.BadRequest("Cpf é obrigatório");

            var addAdvogado = await advogadoService.AdicionarAdvogadoAsync(novoAdvogado);

            if (!addAdvogado.Success)
                return ResultsBase.NotFound(addAdvogado.Message);

            return ResultsBase.Success(addAdvogado.Message, addAdvogado.Data);

        })
       .WithTags("Advogado");

        app.MapDelete("Advogado/{cpf}", async (string cpf, IAdvogadoService advogadoService) =>
        {
            var deletarAdvogado = await advogadoService.DeletarAdvogadoPeloCpfAsync(cpf);

            if (!deletarAdvogado.Success)
                return ResultsBase.NotFound(deletarAdvogado.Message);

            return ResultsBase.Success(deletarAdvogado.Message, deletarAdvogado.Data);

        })
        .WithTags("Advogado");

        #endregion

        return app;
    }

}
