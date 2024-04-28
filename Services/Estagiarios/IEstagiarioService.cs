using PROJETO_ADVOCACIA.Dtos.Estagiario;
using PROJETO_ADVOCACIA.Entities;

namespace PROJETO_ADVOCACIA.Services.Estagiarios
{
    public interface IEstagiarioService
    {
        Task<ResultDataObject<Estagiario>> AdicioanrEstagiarioAsync(NovoEstagiarioDto estagiario);
        Task<ResultDataObject<Estagiario>> DeletarEstagiarioPeloCpfAsync(string cpf);
        Task<ResultDataObject<Estagiario>> PegarEstagiarioPeloCpf(string cpf);
        Task<ResultDataObject<List<Estagiario>>> PegarTodosOsEstagiariosAsync();
    }
}