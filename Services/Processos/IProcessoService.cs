using PROJETO_ADVOCACIA.Dtos.Processo;
using PROJETO_ADVOCACIA.Entities;

namespace PROJETO_ADVOCACIA.Services.Processos
{
    public interface IProcessoService
    {
        Task<ResultDataObject<Processo>> AdicionarProcessoAsync(NovoProcessoDtO processo);
        Task<ResultDataObject<Processo>> AlterarStatusDoProcessoPeloIdAsync(Guid id, bool novoStatus);
        Task<ResultDataObject<Processo>> DeletarProcessoPeloIdAsync(Guid id);
        Task<ResultDataObject<Processo>> PegarProcessoPeloIdAsync(Guid id);
        Task<ResultDataObject<List<Processo>>> PegarTodosProcessossAsync();
    }
}