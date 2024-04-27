using PROJETO_ADVOCACIA.Models;

namespace PROJETO_ADVOCACIA.Services.Livros
{
    public interface ILivroService
    {
        Task<ResultDataObject<Livro>> AdicionarLivroAsync(Livro livro);
        Task<ResultDataObject<Livro>> DeletarLivroPeloISBNAsync(int cpf);
        Task<ResultDataObject<Livro>> PegarLivroPeloISBNAsync(int isbn);
        Task<ResultDataObject<List<Livro>>> PegarTodosLivrosAsync();
    }
}