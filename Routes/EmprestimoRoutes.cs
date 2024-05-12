using PROJETO_ADVOCACIA.Routes.Base;
using PROJETO_ADVOCACIA.Dtos.Emprestimo;
using PROJETO_ADVOCACIA.Services.Emprestimos;

namespace PROJETO_ADVOCACIA.Routes;

public static class EmprestimoRoutes
{

    public static WebApplication RotasEmprestimo(this WebApplication app)
    {

        #region Read Operations

        app.MapGet("Emprestimos", async (IEmprestimoService emprestimoService) =>
        {
            var todosProcessos = await emprestimoService.PegarTodosEmprestimosAsync();

            if (!todosProcessos.Success)
                return ResultsBase.NotFound(todosProcessos.Message);

            return ResultsBase.Success(todosProcessos.Message, todosProcessos.Data);
        })
        .WithTags("Emprestimo");

        app.MapGet("Emprestimo/{id}", async (Guid id, IEmprestimoService emprestimoService) =>
        {
            var emprestimo = await emprestimoService.PegarEmprestimoPeloIdAsync(id);

            if (!emprestimo.Success)
                return ResultsBase.NotFound(emprestimo.Message);

            return ResultsBase.Success(emprestimo.Message, emprestimo.Data);
        })
        .WithTags("Emprestimo");

        #endregion

        #region Write Operations

        app.MapPost("Emprestimo", async (NovoEmprestimoDto novoEmprestimo, IEmprestimoService emprestimoService) =>
        {
            var addEmprestimo = await emprestimoService.AdicionarEmprestimoAsync(novoEmprestimo);

            if (!addEmprestimo.Success)
                return ResultsBase.NotFound(addEmprestimo.Message);

            return ResultsBase.Success(addEmprestimo.Message, addEmprestimo.Data);

        })
       .WithTags("Emprestimo");

        app.MapPut("Emprestimo/{id}", async (Guid id, bool novoStatus, IEmprestimoService emprestimoService) =>
        {
            var emprestimoAtualizado = await emprestimoService.AlterarStatusDoEmprestimoPeloIdAsync(id, novoStatus);

            if (!emprestimoAtualizado.Success)
                return ResultsBase.NotFound(emprestimoAtualizado.Message);

            return ResultsBase.Success(emprestimoAtualizado.Message, emprestimoAtualizado.Data);

        })
       .WithTags("Emprestimo");

        app.MapDelete("Emprestimo/{id}", async (Guid id, IEmprestimoService emprestimoService) =>
        {
            var deletarEmprestimo = await emprestimoService.DeletarEmprestimoPeloIdAsync(id);

            if (!deletarEmprestimo.Success)
                return ResultsBase.NotFound(deletarEmprestimo.Message);

            return ResultsBase.Success(deletarEmprestimo.Message, deletarEmprestimo.Data);

        })
        .WithTags("Emprestimo");

        #endregion

        return app;
    }

}
