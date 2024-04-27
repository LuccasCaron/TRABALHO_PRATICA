using PROJETO_ADVOCACIA.Models;
using PROJETO_ADVOCACIA.ModelView.User;

namespace PROJETO_ADVOCACIA.Services.Users
{
    public interface IUserService
    {
        Task<ResultDataObject<User>> LoginAsync(LoginModelView credentials);
        Task<ResultDataObject<User>> NovoUsuarioAsync(NovoUserModelView user);
    }
}