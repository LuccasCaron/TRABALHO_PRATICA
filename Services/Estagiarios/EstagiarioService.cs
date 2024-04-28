using Microsoft.EntityFrameworkCore;
using PROJETO_ADVOCACIA.Data;
using PROJETO_ADVOCACIA.Dtos.Estagiario;
using PROJETO_ADVOCACIA.Entities;

namespace PROJETO_ADVOCACIA.Services.Estagiarios;

public class EstagiarioService(ApplicationDbContext context) : IEstagiarioService
{

    #region Properties

    private readonly ApplicationDbContext _context = context ?? throw new ArgumentNullException(nameof(context));

    #endregion

    #region Read Methods

    public async Task<ResultDataObject<List<Estagiario>>> PegarTodosOsEstagiariosAsync()
    {
        var todosOsEstagiarios = await _context.Estagiarios
                                               .AsNoTracking()
                                               .ToListAsync();

        if (todosOsEstagiarios.Count == 0)
            return new ResultDataObject<List<Estagiario>>(false, "Nenhum estagiario encontrado.", null);

        return new ResultDataObject<List<Estagiario>>(true, "", todosOsEstagiarios);
    }

    public async Task<ResultDataObject<Estagiario>> PegarEstagiarioPeloCpf(string cpf)
    {
        var cliente = await _context.Estagiarios.FirstOrDefaultAsync(e => e.CPF == cpf);

        if (cliente == null)
            return new ResultDataObject<Estagiario>(false, "Estagiario não encontrado", null);

        return new ResultDataObject<Estagiario>(true, "", cliente);
    }

    #endregion

    #region Write Methods

    public async Task<ResultDataObject<Estagiario>> AdicioanrEstagiarioAsync(NovoEstagiarioDto estagiario)
    {
        var existeEstagiarioComCpf = await _context.Estagiarios
                                                  .AsNoTracking()
                                                  .FirstOrDefaultAsync(e => e.CPF == estagiario.CPF)
                                                  .ConfigureAwait(false);

        if (existeEstagiarioComCpf != null)
            return new ResultDataObject<Estagiario>(false, "Estagiario com esse cpf já existe!", null);

        var novoEstagiario = new Estagiario
        {
            Nome = estagiario.Nome,
            CPF = estagiario.CPF,
            Telefone = estagiario.Telefone,
            CpfAdvogado = estagiario.CpfAdvogado
        };

        await _context.Estagiarios.AddAsync(novoEstagiario)
                                  .ConfigureAwait(false);

        await _context.SaveChangesAsync();

        return new ResultDataObject<Estagiario>(true, "Estagiario adicionado com sucesso!", novoEstagiario);
    }

    public async Task<ResultDataObject<Estagiario>> DeletarEstagiarioPeloCpfAsync(string cpf)
    {
        var existeEstagiario = await PegarEstagiarioPeloCpf(cpf);

        if (!existeEstagiario.Success)
            return new ResultDataObject<Estagiario>(existeEstagiario.Success, existeEstagiario.Message, null);

        _context.Estagiarios.Remove(existeEstagiario.Data);

        await _context.SaveChangesAsync();

        return new ResultDataObject<Estagiario>(true, "Estagiario deletado com sucesso!", null);
    }

    #endregion

}
