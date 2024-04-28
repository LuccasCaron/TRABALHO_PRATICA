using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PROJETO_ADVOCACIA.Entities;

namespace PROJETO_ADVOCACIA.Repositories.Configuration;

public class AdvogadoConfiguration : IEntityTypeConfiguration<Advogado>
{
    public void Configure(EntityTypeBuilder<Advogado> builder)
    {

        builder.HasKey(x => x.CPF);


        builder.Property(x => x.CPF)
            .HasColumnName("CPF")
            .HasColumnType("varchar(15)")
            .IsRequired();

        builder.Property(x => x.Nome)
            .HasColumnName("Nome")
            .HasColumnType("varchar(50)")
            .IsRequired();

        builder.Property(x => x.Telefone)
            .HasColumnName("Telefone")
            .HasColumnType("varchar(30)")
            .IsRequired();

        builder.Property(x => x.Cargo)
            .HasColumnName("Cargo")
            .HasColumnType("varchar(30)")
            .IsRequired();
    }
}
