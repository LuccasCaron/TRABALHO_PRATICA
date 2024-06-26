﻿using PROJETO_ADVOCACIA.Dtos.Estagiario;
using PROJETO_ADVOCACIA.Routes.Base;
using PROJETO_ADVOCACIA.Services.Estagiarios;

namespace PROJETO_ADVOCACIA.Routes;

public static class EstagiarioRoutes
{
    public static WebApplication RotasEstagiario(this WebApplication app)
    {

        #region Read Operations

        app.MapGet("Estagiarios", async (IEstagiarioService estagiarioService) =>
        {
            var todosOsEstagiarios = await estagiarioService.PegarTodosOsEstagiariosAsync();

            if (!todosOsEstagiarios.Success)
                return ResultsBase.NotFound(todosOsEstagiarios.Message);

            return ResultsBase.Success(todosOsEstagiarios.Message, todosOsEstagiarios.Data);
        })
        .WithTags("Estagiario");

        app.MapGet("Estagiario/{cpf}", async (string cpf, IEstagiarioService estagiarioService) =>
        {
            var estagiario = await estagiarioService.PegarEstagiarioPeloCpf(cpf);

            if (!estagiario.Success)
                return ResultsBase.NotFound(estagiario.Message);

            return ResultsBase.Success(estagiario.Message, estagiario.Data);
        })
      .WithTags("Estagiario");

        #endregion

        #region Write Operations

        app.MapPost("Estagiario", async (NovoEstagiarioDto novoEstagiario, IEstagiarioService estagiarioService) =>
        {
            var addEstagiario = await estagiarioService.AdicioanrEstagiarioAsync(novoEstagiario);

            if (!addEstagiario.Success)
                return ResultsBase.NotFound(addEstagiario.Message);

            return ResultsBase.Success(addEstagiario.Message, addEstagiario.Data);

        })
       .WithTags("Estagiario");

        app.MapDelete("Estagiario/{cpf}", async (string cpf, IEstagiarioService estagiarioService) =>
        {
            var deletarEstagiario = await estagiarioService.DeletarEstagiarioPeloCpfAsync(cpf);

            if (!deletarEstagiario.Success)
                return ResultsBase.NotFound(deletarEstagiario.Message);

            return ResultsBase.Success(deletarEstagiario.Message, deletarEstagiario.Data);

        })
        .WithTags("Estagiario");

        #endregion

        return app;
    }

}
