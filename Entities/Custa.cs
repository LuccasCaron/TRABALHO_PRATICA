namespace PROJETO_ADVOCACIA.Entities;

public class Custa
{

    #region Properties

    public Guid Id { get; set; }

    public float Valor { get; set; }

    public Guid IdProcesso { get; set; }

    public Processo Processo { get; set; }

    public string Descricao { get; set; }

    public DateTime Data_Custa { get; set; } = DateTime.Now;

    #endregion

    #region Constructor

    public Custa()
    {
        Id = Guid.NewGuid();
    }

    public Custa(float valor, Guid idProcesso, string descricao)
    {
        Valor = valor;
        IdProcesso = idProcesso;
        Descricao = descricao;
    }

    #endregion

}
