using PROJETO_ADVOCACIA.Entities;

namespace PROJETO_ADVOCACIA.Services.Livros
{
    public interface ILivroService
    {
        Task<ResultDataObject<Livro>> AdicionarLivroAsync(Livro livro);
        Task<ResultDataObject<Livro>> DeletarLivroPeloISBNAsync(string isbn);
        Task<ResultDataObject<Livro>> PegarLivroPeloISBNAsync(string isbn);
        Task<ResultDataObject<List<Livro>>> PegarTodosLivrosAsync();
    }
}