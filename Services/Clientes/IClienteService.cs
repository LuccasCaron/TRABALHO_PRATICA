using PROJETO_ADVOCACIA.Entities;

namespace PROJETO_ADVOCACIA.Services.Clientes
{
    public interface IClienteService
    {
        Task<ResultDataObject<Cliente>> AdicioanrClienteAsync(Cliente cliente);
        Task<ResultDataObject<Cliente>> DeletarClientePeloCpfAsync(string cpf);
        Task<ResultDataObject<Cliente>> PegarClientePeloCpf(string cpf);
        Task<ResultDataObject<List<Cliente>>> PegarTodosOsClientesAsync();
    }
}