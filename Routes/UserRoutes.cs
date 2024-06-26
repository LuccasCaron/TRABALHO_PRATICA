﻿using PROJETO_ADVOCACIA.Routes.Base;
using PROJETO_ADVOCACIA.ModelView.User;
using PROJETO_ADVOCACIA.Services.Users;

namespace PROJETO_ADVOCACIA.Routes;

public static class UserRoutes
{

    public static WebApplication RotasUser(this WebApplication app)
    {

        #region Write Operations

        app.MapPost("User/Login", async (LoginDto credentials, IUserService userService) =>
        {
            var autenticado = await userService.LoginAsync(credentials);

            if (!autenticado.Success)
                return ResultsBase.NotFound(autenticado.Message);

            return ResultsBase.Success(autenticado.Message, autenticado.Data);
        })
        .WithTags("User");

        app.MapPost("User", async (NovoUserDto novoUser, IUserService userService) =>
        {
            var adicionarUsuario = await userService.NovoUsuarioAsync(novoUser);

            if (!adicionarUsuario.Success)
                return ResultsBase.NotFound(adicionarUsuario.Message);

            return ResultsBase.Success(adicionarUsuario.Message, adicionarUsuario.Data);
        })
        .WithTags("User");

        #endregion

        return app;
    }

}
