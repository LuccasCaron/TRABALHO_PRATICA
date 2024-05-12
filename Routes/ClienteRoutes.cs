using PROJETO_ADVOCACIA.Routes.Base;
using PROJETO_ADVOCACIA.Entities;
using PROJETO_ADVOCACIA.Services.Clientes;

namespace PROJETO_ADVOCACIA.Routes;

public static class ClienteRoutes
{

    public static WebApplication RotasCliente(this WebApplication app)
    {

        #region Read Operations

        app.MapGet("Clientes", async (IClienteService clienteService) =>
        {
            var todosOsClientes = await clienteService.PegarTodosOsClientesAsync();

            if (!todosOsClientes.Success)
                return ResultsBase.NotFound(todosOsClientes.Message);

            return ResultsBase.Success(todosOsClientes.Message, todosOsClientes.Data);
        })
        .WithTags("Cliente");

        app.MapGet("Cliente/{cpf}", async (string cpf, IClienteService clienteService) =>
        {
            var cliente = await clienteService.PegarClientePeloCpf(cpf);

            if (!cliente.Success)
                return ResultsBase.NotFound(cliente.Message);

            return ResultsBase.Success(cliente.Message, cliente.Data);
        })
      .WithTags("Cliente");

        #endregion

        #region Write Operations

        app.MapPost("Cliente", async (Cliente novoCliente, IClienteService clienteService) =>
        {
            var addCliente = await clienteService.AdicioanrClienteAsync(novoCliente);

            if (!addCliente.Success)
                return ResultsBase.NotFound(addCliente.Message);

            return ResultsBase.Success(addCliente.Message, addCliente.Data);

        })
       .WithTags("Cliente");

        app.MapDelete("Cliente/{cpf}", async (string cpf, IClienteService clienteService) =>
        {
            var deletarCliente = await clienteService.DeletarClientePeloCpfAsync(cpf);

            if (!deletarCliente.Success)
                return ResultsBase.NotFound(deletarCliente.Message);

            return ResultsBase.Success(deletarCliente.Message, deletarCliente.Data);

        })
        .WithTags("Cliente");

        #endregion

        return app;
    }

}
