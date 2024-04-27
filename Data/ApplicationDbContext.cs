using Microsoft.EntityFrameworkCore;
using PROJETO_ADVOCACIA.Models;

namespace PROJETO_ADVOCACIA.Data;

public class ApplicationDbContext : DbContext
{

    #region Constructor
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    #endregion

    #region Tables

    public DbSet<User> Users { get; set; }
    public DbSet<Advogado> Advogados { get; set; }
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Estagiario> Estagiarios { get; set; }
    public DbSet<Livro> Livros { get; set; }

    #endregion

    #region Protected Methods
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }

    #endregion

}
