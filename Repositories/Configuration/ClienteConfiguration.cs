using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PROJETO_ADVOCACIA.Entities;

namespace PROJETO_ADVOCACIA.Repositories.Configuration;

public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
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

        builder.Property(x => x.Email)
            .HasColumnName("Email")
            .HasColumnType("varchar(40)");

        builder.Property(x => x.Telephone)
            .HasColumnName("Telephone")
            .HasColumnType("varchar(50)");
    }
}
