using Microsoft.EntityFrameworkCore;
using PROJETO_ADVOCACIA.Data;
using PROJETO_ADVOCACIA.Models;

namespace PROJETO_ADVOCACIA.Services.Advogados;

public class AdvogadoService(ApplicationDbContext context) : IAdvogadoService
{

    #region Properties

    private readonly ApplicationDbContext _context = context ?? throw new ArgumentNullException(nameof(context));

    #endregion

    #region Read Methods

    public async Task<ResultDataObject<List<Advogado>>> PegarTodosAdvogadosAsync()
    {
        var todosAdvogados = await _context.Advogados
                                           .AsNoTracking()
                                           .ToListAsync();

        if (todosAdvogados.Count == 0)
            return new ResultDataObject<List<Advogado>>(false, "Nenhum Advogado encontrado.", null);

        return new ResultDataObject<List<Advogado>>(true, "", todosAdvogados);
    }

    public async Task<ResultDataObject<Advogado>> PegarAdvogadoPeloCpfAsync(string cpf)
    {
        var advogado = await _context.Advogados.FirstOrDefaultAsync(a => a.CPF == cpf);

        if (advogado == null)
            return new ResultDataObject<Advogado>(false, "Advogado não encontrado", null);

        return new ResultDataObject<Advogado>(true, "", advogado);
    }

    #endregion

    #region Write Methods

    public async Task<ResultDataObject<Advogado>> AdicionarAdvogadoAsync(Advogado advogado)
    {
        var existeAdvogadoComOCpf = await _context.Advogados
                                                  .AsNoTracking()
                                                  .FirstOrDefaultAsync(a => a.CPF == advogado.CPF)
                                                  .ConfigureAwait(false);

        if (existeAdvogadoComOCpf != null)
            return new ResultDataObject<Advogado>(false, "Advogado com esse cpf já existe!", null);

        var novoAdvogado = await _context.Advogados
                                         .AddAsync(advogado)
                                         .ConfigureAwait(false);

        await _context.SaveChangesAsync();

        return new ResultDataObject<Advogado>(true, "Advogado adicionado com sucesso!", advogado);
    }

    public async Task<ResultDataObject<Advogado>> DeletarAdvogadoPeloCpfAsync(string cpf)
    {
        var existeAdvogado = await PegarAdvogadoPeloCpfAsync(cpf);

        if (!existeAdvogado.Success)
            return new ResultDataObject<Advogado>(existeAdvogado.Success, existeAdvogado.Message, null);

        _context.Advogados.Remove(existeAdvogado.Data);

        await _context.SaveChangesAsync();

        return new ResultDataObject<Advogado>(true, "Advogado deletado com sucesso!", null);
    }

    #endregion

}
