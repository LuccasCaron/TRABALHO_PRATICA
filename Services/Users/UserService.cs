using Microsoft.EntityFrameworkCore;
using PROJETO_ADVOCACIA.Data;
using PROJETO_ADVOCACIA.Entities;
using PROJETO_ADVOCACIA.ModelView.User;

namespace PROJETO_ADVOCACIA.Services.Users;

public class UserService(ApplicationDbContext context) : IUserService
{

    #region Properties

    private readonly ApplicationDbContext _context = context ?? throw new ArgumentNullException(nameof(context));

    #endregion

    #region Write Methods

    public async Task<ResultDataObject<User>> LoginAsync(LoginDto credentials)
    {
        var autenticado = await _context.Users.AsNoTracking()
                                              .FirstOrDefaultAsync(u => u.Email == credentials.Email && u.Senha == credentials.Senha)
                                              .ConfigureAwait(false);

        if (autenticado == null)
            return new ResultDataObject<User>(true, "Usuario ou senha inválidos", null);



        return new ResultDataObject<User>(true, $"Bem vindo {autenticado.Nome}", autenticado);
    }

    public async Task<ResultDataObject<User>> NovoUsuarioAsync(NovoUserDto user)
    {

        var existeUsuario = await _context.Users.AsNoTracking()
                                                .FirstOrDefaultAsync(u => u.Email == user.Email)
                                                .ConfigureAwait(false);

        if (existeUsuario != null)
            return new ResultDataObject<User>(false, "Usuario com esse email já existe!", null);

        var novoUser = new User
        {
            Nome = user.Nome,
            Email = user.Email,
            Senha = user.Senha
        };

        await _context.Users.AddAsync(novoUser);

        _context.SaveChangesAsync();

        return new ResultDataObject<User>(true, "Usuario criado com sucesso!", null);

    }

    #endregion

}
