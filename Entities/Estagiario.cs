namespace PROJETO_ADVOCACIA.Entities;

public class Estagiario
{

    #region Properties

    public string CPF { get; set; }
    public string Nome { get; set; }
    public string Telefone { get; set; }
    public string CpfAdvogado { get; set; }
    public Advogado Advogado { get; set; }

    #endregion

}
