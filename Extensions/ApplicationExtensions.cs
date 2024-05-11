using PROJETO_ADVOCACIA.Services.Advogados;
using PROJETO_ADVOCACIA.Services.Clientes;
using PROJETO_ADVOCACIA.Services.Custas;
using PROJETO_ADVOCACIA.Services.Emprestimos;
using PROJETO_ADVOCACIA.Services.Estagiarios;
using PROJETO_ADVOCACIA.Services.Livros;
using PROJETO_ADVOCACIA.Services.Processos;
using PROJETO_ADVOCACIA.Services.Users;

namespace PROJETO_ADVOCACIA.Extensions;

public static class ApplicationExtensions
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAdvogadoService, AdvogadoService>();
        services.AddScoped<IClienteService, ClienteService>();
        services.AddScoped<IEstagiarioService, EstagiarioService>();
        services.AddScoped<ILivroService, LivroService>();
        services.AddScoped<IProcessoService, ProcessoService>();
        services.AddScoped<ICustaService, CustaService>();
        services.AddScoped<IEmprestimoService, EmprestimoService>();

        services.AddCors(options =>
        {
            options.AddPolicy("AllowSpecificOrigin",
                builder => builder.AllowAnyOrigin()
                                  .AllowAnyHeader()
                                  .WithMethods("GET", "PUT", "POST", "DELETE"));
        });

    }

}
