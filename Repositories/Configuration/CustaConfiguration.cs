using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PROJETO_ADVOCACIA.Entities;

namespace PROJETO_ADVOCACIA.Repositories.Configuration
{
    public class CustaConfiguration : IEntityTypeConfiguration<Custa>
    {
        public void Configure(EntityTypeBuilder<Custa> builder)
        {
            
            builder.HasKey(x => x.Id);
           
            builder.Property(x => x.Valor)
                .HasColumnName("Valor")
                .HasColumnType("float")
                .IsRequired();

            builder.HasOne(e => e.Processo)
                   .WithMany()
                   .HasForeignKey(e => e.IdProcesso);

            builder.Property(x => x.Descricao)
                .HasColumnName("Descricao")
                .HasColumnType("varchar(255)");

            builder.Property(x => x.Data_Custa)
                .HasColumnName("Data_Custa")
                .HasColumnType("datetime")
                .HasDefaultValueSql("GETDATE()")
                .IsRequired();
        }
    }
}
