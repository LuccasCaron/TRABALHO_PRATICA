using PROJETO_ADVOCACIA.Models;

namespace PROJETO_ADVOCACIA.Services.Advogados
{
    public interface IAdvogadoService
    {
        Task<ResultDataObject<Advogado>> AdicionarAdvogadoAsync(Advogado advogado);
        Task<ResultDataObject<Advogado>> DeletarAdvogadoPeloCpfAsync(string cpf);
        Task<ResultDataObject<Advogado>> PegarAdvogadoPeloCpfAsync(string cpf);
        Task<ResultDataObject<List<Advogado>>> PegarTodosAdvogadosAsync();
    }
}