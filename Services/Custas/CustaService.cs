using Microsoft.EntityFrameworkCore;
using PROJETO_ADVOCACIA.Data;
using PROJETO_ADVOCACIA.Dtos.Custa;
using PROJETO_ADVOCACIA.Entities;

namespace PROJETO_ADVOCACIA.Services.Custas;

public class CustaService(ApplicationDbContext context) : ICustaService
{

    #region Properties

    private readonly ApplicationDbContext _context = context ?? throw new ArgumentNullException(nameof(context));

    #endregion

    #region Read Methods

    public async Task<ResultDataObject<List<Custa>>> PegarTodasAsCustasPeloIdDoProcessoAsync(Guid idProcesso)
    {
        var todasAsCustasDoProcesso = await _context.Custas
                                                    .AsNoTracking()
                                                    .Where(c => c.IdProcesso == idProcesso)
                                                    .ToListAsync();

        if (todasAsCustasDoProcesso.Count == 0)
            return new ResultDataObject<List<Custa>>(false, "Nenhuma custa para este processo encontrado.", null);

        return new ResultDataObject<List<Custa>>(true, "", todasAsCustasDoProcesso);
    }

    public async Task<ResultDataObject<Custa>> PegarCustaPeloIdAsync(Guid id)
    {
        var custa = await _context.Custas.FirstOrDefaultAsync(c => c.Id == id);

        if (custa == null)
            return new ResultDataObject<Custa>(false, "Custa não encontrado", null);

        return new ResultDataObject<Custa>(true, "", custa);
    }

    #endregion

    #region Write Methods

    public async Task<ResultDataObject<Custa>> AdicionarCustaAsync(NovaCustaDto custa)
    {

        var existeProcesso = await _context.Processos
                                           .AsNoTracking()
                                           .FirstOrDefaultAsync(p => p.Id == custa.IdProcesso)
                                           .ConfigureAwait(false);

        if (existeProcesso == null)
            return new ResultDataObject<Custa>(false, "Processo não existe", null);

        var novaCusta = new Custa
        {
            IdProcesso = custa.IdProcesso,
            Valor = custa.Valor,
            Descricao = custa.Descricao,
        };

        await _context.Custas
                      .AddAsync(novaCusta)
                      .ConfigureAwait(false);

        await _context.SaveChangesAsync();

        return new ResultDataObject<Custa>(true, "Custa adicionado com sucesso!", novaCusta);
    }

    public async Task<ResultDataObject<Custa>> DeletarCustaPeloIdAsync(Guid id)
    {
        var existeCusta = await PegarCustaPeloIdAsync(id);

        if (!existeCusta.Success)
            return new ResultDataObject<Custa>(existeCusta.Success, existeCusta.Message, null);

        _context.Custas.Remove(existeCusta.Data);

        await _context.SaveChangesAsync();

        return new ResultDataObject<Custa>(true, "Custa deletado com sucesso!", null);
    }

    #endregion

}
