using PROJETO_ADVOCACIA.Entities;
using PROJETO_ADVOCACIA.ModelView.User;

namespace PROJETO_ADVOCACIA.Services.Users
{
    public interface IUserService
    {
        Task<ResultDataObject<User>> LoginAsync(LoginDto credentials);
        Task<ResultDataObject<User>> NovoUsuarioAsync(NovoUserDto user);
    }
}