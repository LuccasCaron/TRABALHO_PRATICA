using PROJETO_ADVOCACIA.Dtos.Emprestimo;
using PROJETO_ADVOCACIA.Entities;

namespace PROJETO_ADVOCACIA.Services.Emprestimos
{
    public interface IEmprestimoService
    {
        Task<ResultDataObject<Emprestimo>> AdicionarEmprestimoAsync(NovoEmprestimoDto emprestimo);
        Task<ResultDataObject<Emprestimo>> AlterarStatusDoEmprestimoPeloIdAsync(Guid id, bool novoStatus);
        Task<ResultDataObject<Emprestimo>> DeletarEmprestimoPeloIdAsync(Guid id);
        Task<ResultDataObject<Emprestimo>> PegarEmprestimoPeloIdAsync(Guid id);
        Task<ResultDataObject<List<Emprestimo>>> PegarTodosEmprestimosAsync();
    }
}