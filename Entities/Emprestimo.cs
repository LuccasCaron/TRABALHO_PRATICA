namespace PROJETO_ADVOCACIA.Entities;

public class Emprestimo
{

    #region Properties

    public Guid Id { get; set; }

    public string CpfResponsavel { get; set; }

    public string ISBN_Livro { get; set; }

    public Livro Livro { get; set; }

    public bool Status { get; set; } = true;

    public DateTime Data_Emprestimo { get; set; } = DateTime.Now;

    #endregion

    #region Constructor

    public Emprestimo()
    {
        Id = Guid.NewGuid();
    }

    public Emprestimo(string cpfResponsavel, bool status)
    {
        CpfResponsavel = cpfResponsavel;
        Status = status;
    }

    #endregion

}
