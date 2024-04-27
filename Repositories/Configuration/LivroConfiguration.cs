using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PROJETO_ADVOCACIA.Models;

namespace PROJETO_ADVOCACIA.Repositories.Configuration;

public class LivroConfiguration : IEntityTypeConfiguration<Livro>
{

    public void Configure(EntityTypeBuilder<Livro> builder)
    {
        builder.HasKey(x => x.ISBN);

        builder.Property(x => x.ISBN)
            .HasColumnName("ISBN")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(x => x.Titulo)
          .HasColumnName("Titulo")
          .HasColumnType("varchar(50)")
          .IsRequired();

        builder.Property(x => x.Autor)
         .HasColumnName("Autor")
         .HasColumnType("varchar(50)")
         .IsRequired();
    }

}
