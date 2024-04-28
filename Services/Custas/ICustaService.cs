using PROJETO_ADVOCACIA.Dtos.Custa;
using PROJETO_ADVOCACIA.Entities;

namespace PROJETO_ADVOCACIA.Services.Custas
{
    public interface ICustaService
    {
        Task<ResultDataObject<Custa>> AdicionarCustaAsync(NovaCustaDto custa);
        Task<ResultDataObject<Custa>> DeletarCustaPeloIdAsync(Guid id);
        Task<ResultDataObject<Custa>> PegarCustaPeloIdAsync(Guid id);
        Task<ResultDataObject<List<Custa>>> PegarTodasAsCustasPeloIdDoProcessoAsync(Guid idProcesso);
    }
}