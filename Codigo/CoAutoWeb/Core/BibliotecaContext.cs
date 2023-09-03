using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Core;

public partial class BibliotecaContext : DbContext
{
    public BibliotecaContext()
    {
    }

    public BibliotecaContext(DbContextOptions<BibliotecaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Banco> Bancos { get; set; }

    public virtual DbSet<Devolucao> Devolucaos { get; set; }

    public virtual DbSet<Entrega> Entregas { get; set; }

    public virtual DbSet<Marca> Marcas { get; set; }

    public virtual DbSet<Modelo> Modelos { get; set; }

    public virtual DbSet<Pessoa> Pessoas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=123456;database=coauto");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Banco>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("banco");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .HasColumnName("nome");
        });

        modelBuilder.Entity<Devolucao>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("devolucao");

            entity.HasIndex(e => e.DataHora, "dataHora");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DataHora)
                .HasColumnType("datetime")
                .HasColumnName("dataHora");
            entity.Property(e => e.Foto1)
                .HasColumnType("blob")
                .HasColumnName("foto1");
            entity.Property(e => e.Foto2)
                .HasColumnType("blob")
                .HasColumnName("foto2");
            entity.Property(e => e.Foto3)
                .HasColumnType("blob")
                .HasColumnName("foto3");
            entity.Property(e => e.Foto4)
                .HasColumnType("blob")
                .HasColumnName("foto4");
            entity.Property(e => e.Foto5)
                .HasColumnType("blob")
                .HasColumnName("foto5");
        });

        modelBuilder.Entity<Entrega>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("entrega");

            entity.HasIndex(e => e.DataHora, "dataHora");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DataHora)
                .HasColumnType("datetime")
                .HasColumnName("dataHora");
            entity.Property(e => e.Foto1)
                .HasColumnType("blob")
                .HasColumnName("foto1");
            entity.Property(e => e.Foto2)
                .HasColumnType("blob")
                .HasColumnName("foto2");
            entity.Property(e => e.Foto3)
                .HasColumnType("blob")
                .HasColumnName("foto3");
            entity.Property(e => e.Foto4)
                .HasColumnType("blob")
                .HasColumnName("foto4");
            entity.Property(e => e.Foto5)
                .HasColumnType("blob")
                .HasColumnName("foto5");
        });

        modelBuilder.Entity<Marca>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("marca");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .HasColumnName("nome");
        });

        modelBuilder.Entity<Modelo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("modelo");

            entity.HasIndex(e => e.IdMarca, "fkModeloMarca");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdMarca).HasColumnName("idMarca");
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .HasColumnName("nome");

            entity.HasOne(d => d.IdMarcaNavigation).WithMany(p => p.Modelos)
                .HasForeignKey(d => d.IdMarca)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("%fk%Modelo%Marca1");
        });

        modelBuilder.Entity<Pessoa>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("pessoa");

            entity.HasIndex(e => e.Id, "Id_UNIQUE").IsUnique();

            entity.HasIndex(e => e.Cpf, "cpf");

            entity.HasIndex(e => e.IdBanco, "fkPessoaBanco");

            entity.HasIndex(e => e.Nome, "nome");

            entity.Property(e => e.Agencia)
                .HasMaxLength(10)
                .HasColumnName("agencia");
            entity.Property(e => e.Autorizado).HasColumnName("autorizado");
            entity.Property(e => e.Bairro)
                .HasMaxLength(50)
                .HasColumnName("bairro");
            entity.Property(e => e.Cep)
                .HasMaxLength(8)
                .HasColumnName("cep");
            entity.Property(e => e.Chavepix)
                .HasMaxLength(32)
                .HasColumnName("chavepix");
            entity.Property(e => e.Cidade)
                .HasMaxLength(50)
                .HasColumnName("cidade");
            entity.Property(e => e.Cnh)
                .HasMaxLength(45)
                .HasColumnName("cnh");
            entity.Property(e => e.ContaCorrente)
                .HasMaxLength(10)
                .HasColumnName("contaCorrente");
            entity.Property(e => e.Cpf)
                .HasMaxLength(11)
                .HasColumnName("cpf");
            entity.Property(e => e.DataAutorizacao)
                .HasColumnType("datetime")
                .HasColumnName("dataAutorizacao");
            entity.Property(e => e.DataNascimento)
                .HasMaxLength(10)
                .HasColumnName("dataNascimento");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .HasColumnName("estado");
            entity.Property(e => e.Fotocnh)
                .HasColumnType("blob")
                .HasColumnName("fotocnh");
            entity.Property(e => e.Fotoperfil)
                .HasColumnType("blob")
                .HasColumnName("fotoperfil");
            entity.Property(e => e.IdBanco).HasColumnName("idBanco");
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .HasColumnName("nome");
            entity.Property(e => e.Numero)
                .HasMaxLength(10)
                .HasColumnName("numero");
            entity.Property(e => e.Rua)
                .HasMaxLength(50)
                .HasColumnName("rua");
            entity.Property(e => e.Senha)
                .HasMaxLength(50)
                .HasColumnName("senha");
            entity.Property(e => e.Telefone)
                .HasMaxLength(23)
                .HasColumnName("telefone");
            entity.Property(e => e.Tipo)
                .HasColumnType("enum('cliente','proprietario')")
                .HasColumnName("tipo");

            entity.HasOne(d => d.IdBancoNavigation).WithMany(p => p.Pessoas)
                .HasForeignKey(d => d.IdBanco)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("%fk%Pessoa%Banco1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
