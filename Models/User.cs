namespace PROJETO_ADVOCACIA.Models;

public class User
{

    public Guid Id { get; set; }

    public string Nome { get; set; }

    public string Email { get; set; }

    public string Senha { get; set; }


    public User()
    {
        Id = Guid.NewGuid();
    }

    public User(Guid id, string nome, string email, string senha)
    {
        Id = id;
        Nome = nome;
        Email = email;
        Senha = senha;
    }
}
