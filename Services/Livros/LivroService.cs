using Microsoft.EntityFrameworkCore;
using PROJETO_ADVOCACIA.Data;
using PROJETO_ADVOCACIA.Entities;

namespace PROJETO_ADVOCACIA.Services.Livros;

public class LivroService(ApplicationDbContext context) : ILivroService
{

    #region Properties

    private readonly ApplicationDbContext _context = context ?? throw new ArgumentNullException(nameof(context));

    #endregion

    #region Read Methods

    public async Task<ResultDataObject<List<Livro>>> PegarTodosLivrosAsync()
    {
        var todosOsLivros = await _context.Livros
                                          .AsNoTracking()
                                          .ToListAsync();

        if (todosOsLivros.Count == 0)
            return new ResultDataObject<List<Livro>>(false, "Nenhum Livro encontrado.", null);

        return new ResultDataObject<List<Livro>>(true, "", todosOsLivros);
    }

    public async Task<ResultDataObject<Livro>> PegarLivroPeloISBNAsync(string isbn)
    {
        var livro = await _context.Livros.AsNoTracking()
                                         .FirstOrDefaultAsync(l => l.ISBN == isbn);

        if (livro == null)
            return new ResultDataObject<Livro>(false, "Livro não encontrado", null);

        return new ResultDataObject<Livro>(true, "", livro);
    }

    #endregion

    #region Write Methods

    public async Task<ResultDataObject<Livro>> AdicionarLivroAsync(Livro livro)
    {
        var existeLivroComISBN = await _context.Livros
                                               .AsNoTracking()
                                               .FirstOrDefaultAsync(l => l.ISBN == livro.ISBN)
                                               .ConfigureAwait(false);

        if (existeLivroComISBN != null)
            return new ResultDataObject<Livro>(false, "Livro com esse ISBN já existe!", null);

        var novoLivro = await _context.Livros
                                      .AddAsync(livro)
                                      .ConfigureAwait(false);

        await _context.SaveChangesAsync();

        return new ResultDataObject<Livro>(true, "Livro adicionado com sucesso!", livro);
    }

    public async Task<ResultDataObject<Livro>> DeletarLivroPeloISBNAsync(string isbn)
    {
        var existeLivro = await PegarLivroPeloISBNAsync(isbn);

        if (!existeLivro.Success)
            return new ResultDataObject<Livro>(existeLivro.Success, existeLivro.Message, null);

        _context.Livros.Remove(existeLivro.Data);

        await _context.SaveChangesAsync();

        return new ResultDataObject<Livro>(true, "Livro deletado com sucesso!", null);
    }

    #endregion

}
