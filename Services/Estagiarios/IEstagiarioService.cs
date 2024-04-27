using PROJETO_ADVOCACIA.Models;

namespace PROJETO_ADVOCACIA.Services.Estagiarios
{
    public interface IEstagiarioService
    {
        Task<ResultDataObject<Estagiario>> AdicioanrEstagiarioAsync(Estagiario estagiario);
        Task<ResultDataObject<Estagiario>> DeletarEstagiarioPeloCpfAsync(string cpf);
        Task<ResultDataObject<Estagiario>> PegarEstagiarioPeloCpf(string cpf);
        Task<ResultDataObject<List<Estagiario>>> PegarTodosOsEstagiariosAsync();
    }
}