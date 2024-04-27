using PROJETO_ADVOCACIA.Controllers.Base;
using PROJETO_ADVOCACIA.Models;
using PROJETO_ADVOCACIA.Services.Livros;

namespace PROJETO_ADVOCACIA.Controllers;

public static class LivroController
{

    public static WebApplication RotasLivro(this WebApplication app)
    {

        #region Read Operations

        app.MapGet("Livros", async (ILivroService livroService) =>
        {
            var allLivros = await livroService.PegarTodosLivrosAsync();

            if (!allLivros.Success)
                return ResultsBase.BadRequest(allLivros.Message);

            return ResultsBase.Success(allLivros.Message, allLivros.Data);
        })
        .WithTags("Livro");

        app.MapGet("Livro/{isbn}", async (int isbn, ILivroService livroService) =>
        {
            var livro = await livroService.PegarLivroPeloISBNAsync(isbn);

            if (!livro.Success)
                return ResultsBase.BadRequest(livro.Message);

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

        app.MapDelete("Livro{isbn}", async (int isbn, ILivroService livroService) =>
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
