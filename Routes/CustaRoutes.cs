using PROJETO_ADVOCACIA.Routes.Base;
using PROJETO_ADVOCACIA.Dtos.Custa;
using PROJETO_ADVOCACIA.Services.Custas;

namespace PROJETO_ADVOCACIA.Routes;

public static class CustaRoutes
{

    public static WebApplication RotasCusta(this WebApplication app)
    {

        #region Read Operations

        app.MapGet("Custas/{idProcesso}", async (Guid idProcesso, ICustaService custaService) =>
        {
            var todasAsCustasDoProcesso = await custaService.PegarTodasAsCustasPeloIdDoProcessoAsync(idProcesso);

            if (!todasAsCustasDoProcesso.Success)
                return ResultsBase.NotFound(todasAsCustasDoProcesso.Message);

            return ResultsBase.Success(todasAsCustasDoProcesso.Message, todasAsCustasDoProcesso.Data);
        })
        .WithTags("Custa");

        app.MapGet("Custa/{id}", async (Guid id, ICustaService custaService) =>
        {
            var custa = await custaService.PegarCustaPeloIdAsync(id);

            if (!custa.Success)
                return ResultsBase.NotFound(custa.Message);

            return ResultsBase.Success(custa.Message, custa.Data);
        })
        .WithTags("Custa");

        #endregion

        #region Write Operations

        app.MapPost("Custa", async (NovaCustaDto novaCusta, ICustaService custaService) =>
        {
            var addCusta = await custaService.AdicionarCustaAsync(novaCusta);

            if (!addCusta.Success)
                return ResultsBase.NotFound(addCusta.Message);

            return ResultsBase.Success(addCusta.Message, addCusta.Data);

        })
       .WithTags("Custa");

        app.MapDelete("Custa/{id}", async (Guid id, ICustaService custaService) =>
        {
            var deletarCusta = await custaService.DeletarCustaPeloIdAsync(id);

            if (!deletarCusta.Success)
                return ResultsBase.NotFound(deletarCusta.Message);

            return ResultsBase.Success(deletarCusta.Message, deletarCusta.Data);

        })
        .WithTags("Custa");

        #endregion

        return app;
    }

}
