namespace PROJETO_ADVOCACIA.Entities;

public class Processo
{

    #region Properties

    public Guid Id { get; set; }

    public string CpfCliente { get; set; }

    public Cliente Cliente { get; set; }

    public string CpfAdvogado { get; set; }

    public Advogado Advogado { get; set; }

    public bool Status { get; set; } = true;

    public string Descrição { get; set; }

    public DateTime Data_Abertura { get; set; } = DateTime.Now;

    #endregion

    #region Constructor

    public Processo()
    {
        Id = Guid.NewGuid();
    }

    public Processo(string cpfCliente, string cpfAdvogado, bool status, string descricao)
    {
        CpfCliente = cpfCliente;
        CpfAdvogado = cpfAdvogado;
        Status = status;
        Descrição = descricao;
    }

    #endregion

}
