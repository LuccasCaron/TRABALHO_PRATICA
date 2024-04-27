using Microsoft.EntityFrameworkCore;
using PROJETO_ADVOCACIA.Data;
using PROJETO_ADVOCACIA.Models;

namespace PROJETO_ADVOCACIA.Services.Clientes;

public class ClienteService(ApplicationDbContext context) : IClienteService
{

    #region Properties

    private readonly ApplicationDbContext _context = context ?? throw new ArgumentNullException(nameof(context));

    #endregion

    #region Read Methods

    public async Task<ResultDataObject<List<Cliente>>> PegarTodosOsClientesAsync()
    {
        var todosOsClientes = await _context.Clientes
                                    .AsNoTracking()
                                    .ToListAsync();

        if (todosOsClientes.Count == 0)
            return new ResultDataObject<List<Cliente>>(false, "Nenhum cliente encontrado.", null);

        return new ResultDataObject<List<Cliente>>(true, "", todosOsClientes);
    }

    public async Task<ResultDataObject<Cliente>> PegarClientePeloCpf(string cpf)
    {
        var cliente = await _context.Clientes.FirstOrDefaultAsync(c => c.CPF == cpf);

        if (cliente == null)
            return new ResultDataObject<Cliente>(false, "Cliente não encontrado", null);

        return new ResultDataObject<Cliente>(true, "", cliente);
    }

    #endregion

    #region Write Methods

    public async Task<ResultDataObject<Cliente>> AdicioanrClienteAsync(Cliente cliente)
    {
        var existeClienteComOCpf = await _context.Clientes
                                                  .AsNoTracking()
                                                  .FirstOrDefaultAsync(c => c.CPF == cliente.CPF)
                                                  .ConfigureAwait(false);

        if (existeClienteComOCpf != null)
            return new ResultDataObject<Cliente>(false, "Cliente com esse cpf já existe!", null);

        var novoCliente = await _context.Clientes
                                         .AddAsync(cliente)
                                         .ConfigureAwait(false);

        await _context.SaveChangesAsync();

        return new ResultDataObject<Cliente>(true, "Cliente adicionado com sucesso!", cliente);
    }

    public async Task<ResultDataObject<Cliente>> DeletarClientePeloCpfAsync(string cpf)
    {
        var existeCliente = await PegarClientePeloCpf(cpf);

        if (!existeCliente.Success)
            return new ResultDataObject<Cliente>(existeCliente.Success, existeCliente.Message, null);

        _context.Clientes.Remove(existeCliente.Data);

        await _context.SaveChangesAsync();

        return new ResultDataObject<Cliente>(true, "Cliente deletado com sucesso!", null);
    }

    #endregion

}

