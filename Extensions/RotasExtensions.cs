using PROJETO_ADVOCACIA.Controllers;

namespace PROJETO_ADVOCACIA.Extensions
{
    public static class RotasExtensions
    {
        public static WebApplication AddRotas(this WebApplication app)
        {
            app.RotasEmprestimo();
            app.RotasUser();
            app.RotasAdvogado();
            app.RotasCliente();
            app.RotasProcesso();
            app.RotasEstagiario();
            app.RotasLivro();
            app.RotasCusta();

            return app;
        }
    }
}
