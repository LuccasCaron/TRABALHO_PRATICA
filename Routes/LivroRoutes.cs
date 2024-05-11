using PROJETO_ADVOCACIA.Routes.Base;
using PROJETO_ADVOCACIA.Entities;
using PROJETO_ADVOCACIA.Services.Livros;

namespace PROJETO_ADVOCACIA.Routes;

public static class LivroRoutes
{

    public static WebApplication RotasLivro(this WebApplication app)
    {

        #region Read Operations

        app.MapGet("Livros", async (ILivroService livroService) =>
        {
            var todosLivros = await livroService.PegarTodosLivrosAsync();

            if (!todosLivros.Success)
                return ResultsBase.NotFound(todosLivros.Message);

            return ResultsBase.Success(todosLivros.Message, todosLivros.Data);
        })
        .WithTags("Livro");

        app.MapGet("Livro/{isbn}", async (string isbn, ILivroService livroService) =>
        {
            var livro = await livroService.PegarLivroPeloISBNAsync(isbn);

            if (!livro.Success)
                return ResultsBase.NotFound(livro.Message);

            return ResultsBase.Success(livro.Message, livro.Data);
        })
      .WithTags("Livro");

        #endregion

        #region Write Operations

        app.MapPost("Livro", async (Livro novoLivro, ILivroService livroService) =>
        {
            var addLivro = await livroService.AdicionarLivroAsync(novoLivro);

            if (!addLivro.Success)
                return ResultsBase.BadRequest(addLivro.Message);

            return ResultsBase.Success(addLivro.Message, addLivro.Data);

        })
       .WithTags("Livro");

        app.MapDelete("Livro{isbn}", async (string isbn, ILivroService livroService) =>
        {
            var deletarLivro = await livroService.DeletarLivroPeloISBNAsync(isbn);

            if (!deletarLivro.Success)
                return ResultsBase.NotFound(deletarLivro.Message);

            return ResultsBase.Success(deletarLivro.Message, deletarLivro.Data);

        })
        .WithTags("Livro");

        #endregion

        return app;
    }

}
