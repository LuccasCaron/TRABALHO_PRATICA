using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PROJETO_ADVOCACIA.Entities;

namespace PROJETO_ADVOCACIA.Repositories.Configuration;

public class ProcessoConfiguration : IEntityTypeConfiguration<Processo>
{
    public void Configure(EntityTypeBuilder<Processo> builder)
    {
        
        builder.HasKey(x => x.Id);

        builder.HasOne(e => e.Cliente)
          .WithMany()
          .HasForeignKey(e => e.CpfCliente);

        builder.HasOne(e => e.Advogado)
         .WithMany()
         .HasForeignKey(e => e.CpfAdvogado);

        builder.Property(x => x.Status)
            .HasColumnName("Status")
            .HasColumnType("bit")
            .IsRequired();

        builder.Property(x => x.Descrição)
            .HasColumnName("Descrição")
            .HasColumnType("varchar(255)");

        builder.Property(x => x.Data_Abertura)
            .HasColumnName("Data_Abertura")
            .HasColumnType("datetime")
            .IsRequired();

    }
}
