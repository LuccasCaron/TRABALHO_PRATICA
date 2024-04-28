using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PROJETO_ADVOCACIA.Entities;

namespace PROJETO_ADVOCACIA.Repositories.Configuration;

public class EmprestimoConfiguration : IEntityTypeConfiguration<Emprestimo>
{

    public void Configure(EntityTypeBuilder<Emprestimo> builder)
    {

        builder.HasKey(x => x.Id);

        builder.HasOne(e => e.Livro)
          .WithMany()
          .HasForeignKey(e => e.ISBN_Livro);

        builder.Property(x => x.CpfResponsavel)
           .HasColumnName("CpfResponsavel")
           .HasColumnType("varchar(20)");

        builder.Property(x => x.Status)
            .HasColumnName("Status")
            .HasColumnType("bit")
            .IsRequired();

        builder.Property(x => x.Data_Emprestimo)
            .HasColumnName("Data_Emprestimo")
            .HasColumnType("datetime")
            .IsRequired();

    }

}
