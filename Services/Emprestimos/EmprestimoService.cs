using Microsoft.EntityFrameworkCore;
using PROJETO_ADVOCACIA.Data;
using PROJETO_ADVOCACIA.Dtos.Emprestimo;
using PROJETO_ADVOCACIA.Dtos.Processo;
using PROJETO_ADVOCACIA.Entities;

namespace PROJETO_ADVOCACIA.Services.Emprestimos;

public class EmprestimoService(ApplicationDbContext context) : IEmprestimoService
{

    #region Properties

    private readonly ApplicationDbContext _context = context ?? throw new ArgumentNullException(nameof(context));

    #endregion

    #region Read Methods

    public async Task<ResultDataObject<List<Emprestimo>>> PegarTodosEmprestimosAsync()
    {
        var todosEmprestimos = await _context.Emprestimos
                                           .AsNoTracking()
                                           .ToListAsync();

        if (todosEmprestimos.Count == 0)
            return new ResultDataObject<List<Emprestimo>>(false, "Nenhum Emprestimo encontrado.", null);

        return new ResultDataObject<List<Emprestimo>>(true, "", todosEmprestimos);
    }

    public async Task<ResultDataObject<Emprestimo>> PegarEmprestimoPeloIdAsync(Guid id)
    {
        var emprestimo = await _context.Emprestimos.FirstOrDefaultAsync(e => e.Id == id);

        if (emprestimo == null)
            return new ResultDataObject<Emprestimo>(false, "Emprestimo não encontrado", null);

        return new ResultDataObject<Emprestimo>(true, "", emprestimo);
    }

    #endregion

    #region Write Methods

    public async Task<ResultDataObject<Emprestimo>> AdicionarEmprestimoAsync(NovoEmprestimoDto emprestimo)
    {
        var quantidadeEmprestimos = await _context.Emprestimos
                                                  .AsNoTracking()
                                                  .CountAsync(e => e.CpfResponsavel == emprestimo.CpfResponsavel && e.Status)
                                                  .ConfigureAwait(false);

        var existeMaisDeUmEmprestimoEmAbertoComOMesmoCpf = quantidadeEmprestimos > 1;

        if (existeMaisDeUmEmprestimoEmAbertoComOMesmoCpf)
            return new ResultDataObject<Emprestimo>(false, "Esse cliente já possui 2 emprestimos em aberto, resolva um deles pra solicitar mais", null);

        var existeAdvogado = await _context.Advogados.AsNoTracking()
                                                       .FirstOrDefaultAsync(a => a.CPF == emprestimo.CpfResponsavel)
                                                       .ConfigureAwait(false);

        var existeEstagiario = await _context.Estagiarios.AsNoTracking()
                                                      .FirstOrDefaultAsync(c => c.CPF == emprestimo.CpfResponsavel)
                                                      .ConfigureAwait(false);

        if (existeAdvogado == null && existeEstagiario == null)
            return new ResultDataObject<Emprestimo>(false, "Cpf responsavel não existe", null);

        var novoEmprestimo = new Emprestimo
        {
            CpfResponsavel = emprestimo.CpfResponsavel,
            ISBN_Livro = emprestimo.ISBN_Livro
        };

        await _context.Emprestimos
                      .AddAsync(novoEmprestimo)
                      .ConfigureAwait(false);

        await _context.SaveChangesAsync();

        return new ResultDataObject<Emprestimo>(true, "Emprestimo adicionado com sucesso!", novoEmprestimo);
    }

    public async Task<ResultDataObject<Emprestimo>> AlterarStatusDoEmprestimoPeloIdAsync(Guid id, bool novoStatus)
    {
        var existeProcesso = await PegarEmprestimoPeloIdAsync(id);

        if (!existeProcesso.Success)
            return new ResultDataObject<Emprestimo>(existeProcesso.Success, existeProcesso.Message, null);

        existeProcesso.Data.Status = novoStatus;

        await _context.SaveChangesAsync();

        return new ResultDataObject<Emprestimo>(true, "Emprestimo atualizado com sucesso!", existeProcesso.Data);
    }

    public async Task<ResultDataObject<Emprestimo>> DeletarEmprestimoPeloIdAsync(Guid id)
    {
        var existeEmprestimo = await PegarEmprestimoPeloIdAsync(id);

        if (!existeEmprestimo.Success)
            return new ResultDataObject<Emprestimo>(existeEmprestimo.Success, existeEmprestimo.Message, null);

        _context.Emprestimos.Remove(existeEmprestimo.Data);

        await _context.SaveChangesAsync();

        return new ResultDataObject<Emprestimo>(true, "Emprestimo deletado com sucesso!", null);
    }

    #endregion

}
