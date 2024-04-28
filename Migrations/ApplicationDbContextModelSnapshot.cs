﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PROJETO_ADVOCACIA.Data;

#nullable disable

namespace PROJETO_ADVOCACIA.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PROJETO_ADVOCACIA.Entities.Advogado", b =>
                {
                    b.Property<string>("CPF")
                        .HasColumnType("varchar(15)")
                        .HasColumnName("CPF");

                    b.Property<string>("Cargo")
                        .IsRequired()
                        .HasColumnType("varchar(30)")
                        .HasColumnName("Cargo");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Nome");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("varchar(30)")
                        .HasColumnName("Telefone");

                    b.HasKey("CPF");

                    b.ToTable("Advogados");
                });

            modelBuilder.Entity("PROJETO_ADVOCACIA.Entities.Cliente", b =>
                {
                    b.Property<string>("CPF")
                        .HasColumnType("varchar(15)")
                        .HasColumnName("CPF");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(40)")
                        .HasColumnName("Email");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Nome");

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Telephone");

                    b.HasKey("CPF");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("PROJETO_ADVOCACIA.Entities.Custa", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Data_Custa")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("Data_Custa")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("Descricao");

                    b.Property<Guid>("IdProcesso")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Valor")
                        .HasColumnType("float")
                        .HasColumnName("Valor");

                    b.HasKey("Id");

                    b.HasIndex("IdProcesso");

                    b.ToTable("Custas");
                });

            modelBuilder.Entity("PROJETO_ADVOCACIA.Entities.Emprestimo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CpfResponsavel")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasColumnName("CpfResponsavel");

                    b.Property<DateTime>("Data_Emprestimo")
                        .HasColumnType("datetime")
                        .HasColumnName("Data_Emprestimo");

                    b.Property<string>("ISBN_Livro")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit")
                        .HasColumnName("Status");

                    b.HasKey("Id");

                    b.HasIndex("ISBN_Livro");

                    b.ToTable("Emprestimos");
                });

            modelBuilder.Entity("PROJETO_ADVOCACIA.Entities.Estagiario", b =>
                {
                    b.Property<string>("CPF")
                        .HasColumnType("varchar(15)")
                        .HasColumnName("CPF");

                    b.Property<string>("CpfAdvogado")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Nome");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("varchar(30)")
                        .HasColumnName("Telefone");

                    b.HasKey("CPF");

                    b.HasIndex("CpfAdvogado");

                    b.ToTable("Estagiarios");
                });

            modelBuilder.Entity("PROJETO_ADVOCACIA.Entities.Livro", b =>
                {
                    b.Property<string>("ISBN")
                        .HasColumnType("varchar(30)")
                        .HasColumnName("ISBN");

                    b.Property<string>("Autor")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Autor");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Titulo");

                    b.HasKey("ISBN");

                    b.ToTable("Livros");
                });

            modelBuilder.Entity("PROJETO_ADVOCACIA.Entities.Processo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CpfAdvogado")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.Property<string>("CpfCliente")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.Property<DateTime>("Data_Abertura")
                        .HasColumnType("datetime")
                        .HasColumnName("Data_Abertura");

                    b.Property<string>("Descrição")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("Descrição");

                    b.Property<bool>("Status")
                        .HasColumnType("bit")
                        .HasColumnName("Status");

                    b.HasKey("Id");

                    b.HasIndex("CpfAdvogado");

                    b.HasIndex("CpfCliente");

                    b.ToTable("Processos");
                });

            modelBuilder.Entity("PROJETO_ADVOCACIA.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(30)")
                        .HasColumnName("Email");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Nome");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("varchar(30)")
                        .HasColumnName("Senha");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PROJETO_ADVOCACIA.Entities.Custa", b =>
                {
                    b.HasOne("PROJETO_ADVOCACIA.Entities.Processo", "Processo")
                        .WithMany()
                        .HasForeignKey("IdProcesso")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Processo");
                });

            modelBuilder.Entity("PROJETO_ADVOCACIA.Entities.Emprestimo", b =>
                {
                    b.HasOne("PROJETO_ADVOCACIA.Entities.Livro", "Livro")
                        .WithMany()
                        .HasForeignKey("ISBN_Livro")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Livro");
                });

            modelBuilder.Entity("PROJETO_ADVOCACIA.Entities.Estagiario", b =>
                {
                    b.HasOne("PROJETO_ADVOCACIA.Entities.Advogado", "Advogado")
                        .WithMany()
                        .HasForeignKey("CpfAdvogado")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Advogado");
                });

            modelBuilder.Entity("PROJETO_ADVOCACIA.Entities.Processo", b =>
                {
                    b.HasOne("PROJETO_ADVOCACIA.Entities.Advogado", "Advogado")
                        .WithMany()
                        .HasForeignKey("CpfAdvogado")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PROJETO_ADVOCACIA.Entities.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("CpfCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Advogado");

                    b.Navigation("Cliente");
                });
#pragma warning restore 612, 618
        }
    }
}
