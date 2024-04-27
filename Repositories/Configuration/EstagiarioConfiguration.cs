using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PROJETO_ADVOCACIA.Models;

namespace PROJETO_ADVOCACIA.Repositories.Configuration;

public class EstagiarioConfiguration : IEntityTypeConfiguration<Estagiario>
{

    public void Configure(EntityTypeBuilder<Estagiario> builder)
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

        builder.HasOne(e => e.Advogado)
            .WithMany() 
            .HasForeignKey(e => e.CpfAdvogado);
    }

}
