using PROJETO_ADVOCACIA.Controllers.Base;
using PROJETO_ADVOCACIA.Dtos.Processo;
using PROJETO_ADVOCACIA.Services.Processos;

namespace PROJETO_ADVOCACIA.Controllers;

public static class ProcessoController
{

    public static WebApplication RotasProcesso(this WebApplication app)
    {

        #region Read Operations

        app.MapGet("Processos", async (IProcessoService processoService) =>
        {
            var todosProcessos = await processoService.PegarTodosProcessossAsync();

            if (!todosProcessos.Success)
                return ResultsBase.BadRequest(todosProcessos.Message);

            return ResultsBase.Success(todosProcessos.Message, todosProcessos.Data);
        })
        .WithTags("Processo");

        app.MapGet("Processo/{id}", async (Guid id, IProcessoService processoService) =>
        {
            var processo = await processoService.PegarProcessoPeloIdAsync(id);

            if (!processo.Success)
                return ResultsBase.BadRequest(processo.Message);

            return ResultsBase.Success(processo.Message, processo.Data);
        })
      .WithTags("Processo");

        #endregion

        #region Write Operations

        app.MapPost("Processo", async (NovoProcessoDtO novoProcesso, IProcessoService processoService) =>
        {
            var addProcesso = await processoService.AdicionarProcessoAsync(novoProcesso);

            if (!addProcesso.Success)
                return ResultsBase.BadRequest(addProcesso.Message);

            return ResultsBase.Success(addProcesso.Message, addProcesso.Data);

        })
       .WithTags("Processo");

        app.MapPut("Processo/{id}", async (Guid id, bool novoStatus, IProcessoService processoService) =>
        {
            var processoAtualizado = await processoService.AlterarStatusDoProcessoPeloIdAsync(id, novoStatus);

            if (!processoAtualizado.Success)
                return ResultsBase.BadRequest(processoAtualizado.Message);

            return ResultsBase.Success(processoAtualizado.Message, processoAtualizado.Data);

        })
       .WithTags("Processo");

        app.MapDelete("Processo/{id}", async (Guid id, IProcessoService processoService) =>
        {
            var deletarProcesso = await processoService.DeletarProcessoPeloIdAsync(id);

            if (!deletarProcesso.Success)
                return ResultsBase.NotFound(deletarProcesso.Message);

            return ResultsBase.Success(deletarProcesso.Message, deletarProcesso.Data);

        })
        .WithTags("Processo");

        #endregion

        return app;

    }

}
