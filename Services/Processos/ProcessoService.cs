using Microsoft.EntityFrameworkCore;
using PROJETO_ADVOCACIA.Data;
using PROJETO_ADVOCACIA.Dtos.Processo;
using PROJETO_ADVOCACIA.Entities;

namespace PROJETO_ADVOCACIA.Services.Processos;

public class ProcessoService(ApplicationDbContext context) : IProcessoService
{

    #region Properties

    private readonly ApplicationDbContext _context = context ?? throw new ArgumentNullException(nameof(context));

    #endregion

    #region Read Methods

    public async Task<ResultDataObject<List<Processo>>> PegarTodosProcessossAsync()
    {
        var todosProcessos = await _context.Processos
                                           .AsNoTracking()
                                           .ToListAsync();

        if (todosProcessos.Count == 0)
            return new ResultDataObject<List<Processo>>(false, "Nenhum Processo encontrado.", null);

        return new ResultDataObject<List<Processo>>(true, "", todosProcessos);
    }

    public async Task<ResultDataObject<Processo>> PegarProcessoPeloIdAsync(Guid id)
    {
        var processo = await _context.Processos.FirstOrDefaultAsync(p => p.Id == id);

        if (processo == null)
            return new ResultDataObject<Processo>(false, "Processo não encontrado", null);

        return new ResultDataObject<Processo>(true, "", processo);
    }

    #endregion

    #region Write Methods

    public async Task<ResultDataObject<Processo>> AdicionarProcessoAsync(NovoProcessoDtO processo)
    {
        var quantidadeProcessosAbertos = await _context.Processos
                                                       .AsNoTracking()
                                                       .CountAsync(p => p.CpfCliente == processo.CpfCliente && p.Status)
                                                       .ConfigureAwait(false);

        var existeMaisDeDoisProcessosEmAbertoComOMesmoCliente = quantidadeProcessosAbertos > 2;

        if (existeMaisDeDoisProcessosEmAbertoComOMesmoCliente)
            return new ResultDataObject<Processo>(false, "Esse cliente já possui 3 processos em aberto, resolva um deles pra cadastrar mais", null);

        var existeAdvogado = await _context.Advogados.AsNoTracking()
                                                     .FirstOrDefaultAsync(a => a.CPF == processo.CpfAdvogado)
                                                     .ConfigureAwait(false);

        if (existeAdvogado == null)
            return new ResultDataObject<Processo>(false, "Advogado não existe", null);

        var existeCliente = await _context.Clientes.AsNoTracking()
                                                    .FirstOrDefaultAsync(c => c.CPF == processo.CpfCliente)
                                                    .ConfigureAwait(false);

        if (existeCliente == null)
            return new ResultDataObject<Processo>(false, "Cliente não existe", null);

        var novoProcesso = new Processo
        {
            CpfCliente = processo.CpfCliente,
            CpfAdvogado = processo.CpfAdvogado,
            Descrição = processo.Descrição
        };

        await _context.Processos
                      .AddAsync(novoProcesso)
                      .ConfigureAwait(false);

        await _context.SaveChangesAsync();

        return new ResultDataObject<Processo>(true, "Processo adicionado com sucesso!", novoProcesso);
    }

    public async Task<ResultDataObject<Processo>> AlterarStatusDoProcessoPeloIdAsync(Guid id, bool novoStatus)
    {
        var existeProcesso = await PegarProcessoPeloIdAsync(id);

        if (!existeProcesso.Success)
            return new ResultDataObject<Processo>(existeProcesso.Success, existeProcesso.Message, null);

        existeProcesso.Data.Status = novoStatus;

        await _context.SaveChangesAsync();

        return new ResultDataObject<Processo>(true, "Processo atualizado com sucesso!", existeProcesso.Data);
    }

    public async Task<ResultDataObject<Processo>> DeletarProcessoPeloIdAsync(Guid id)
    {
        var existeProcesso = await PegarProcessoPeloIdAsync(id);

        if (!existeProcesso.Success)
            return new ResultDataObject<Processo>(existeProcesso.Success, existeProcesso.Message, null);

        _context.Processos.Remove(existeProcesso.Data);

        await _context.SaveChangesAsync();

        return new ResultDataObject<Processo>(true, "Processo deletado com sucesso!", null);
    }

    #endregion

}
