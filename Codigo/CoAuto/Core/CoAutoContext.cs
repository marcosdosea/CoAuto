using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Core;

public partial class CoAutoContext : DbContext
{
    public CoAutoContext()
    {
    }

    public CoAutoContext(DbContextOptions<CoAutoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Aluguel> Aluguels { get; set; }

    public virtual DbSet<Banco> Bancos { get; set; }

    public virtual DbSet<Devolucao> Devolucaos { get; set; }

    public virtual DbSet<Disponibilidade> Disponibilidades { get; set; }

    public virtual DbSet<Entrega> Entregas { get; set; }

    public virtual DbSet<Marca> Marcas { get; set; }

    public virtual DbSet<Modelo> Modelos { get; set; }

    public virtual DbSet<Pagamento> Pagamentos { get; set; }

    public virtual DbSet<Pessoa> Pessoas { get; set; }

    public virtual DbSet<Veiculo> Veiculos { get; set; }

    ///protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    ///   => optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=123456;database=coauto");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Aluguel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("aluguel");

            entity.HasIndex(e => e.IdPessoa, "IdPessoa_UNIQUE").IsUnique();

            entity.HasIndex(e => e.IdDevolucao, "fkAluguelDevolucao");

            entity.HasIndex(e => e.IdEntrega, "fkAluguelEntrega");

            entity.HasIndex(e => e.IdPessoa, "fkAluguelPessoa");

            entity.HasIndex(e => e.IdVeiculo, "fkAluguelVeiculo");

            entity.HasIndex(e => e.IdDevolucao, "idDevolucao_UNIQUE").IsUnique();

            entity.HasIndex(e => e.IdEntrega, "idEntrega_UNIQUE").IsUnique();

            entity.HasIndex(e => e.IdVeiculo, "idVeiculo_UNIQUE").IsUnique();

            entity.HasIndex(e => e.Id, "id_UNIQUE").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DataHoraAluguel)
                .HasColumnType("datetime")
                .HasColumnName("dataHoraAluguel");
            entity.Property(e => e.DataHoraAvaliacaoCliente)
                .HasColumnType("datetime")
                .HasColumnName("dataHoraAvaliacaoCliente");
            entity.Property(e => e.DataHoraAvaliacaoProprietario)
                .HasColumnType("datetime")
                .HasColumnName("dataHoraAvaliacaoProprietario");
            entity.Property(e => e.DescricaoAvaliacaoCliente)
                .HasMaxLength(100)
                .HasColumnName("descricaoAvaliacaoCliente");
            entity.Property(e => e.DescricaoAvaliacaoProprietario)
                .HasMaxLength(100)
                .HasColumnName("descricaoAvaliacaoProprietario");
            entity.Property(e => e.IdDevolucao).HasColumnName("idDevolucao");
            entity.Property(e => e.IdEntrega).HasColumnName("idEntrega");
            entity.Property(e => e.IdVeiculo).HasColumnName("idVeiculo");
            entity.Property(e => e.QtdEstrelasAvaliacaoCliente).HasColumnName("qtdEstrelasAvaliacaoCliente");
            entity.Property(e => e.QtdEstrelasAvaliacaoProprietario).HasColumnName("qtdEstrelasAvaliacaoProprietario");
            entity.Property(e => e.Status)
                .HasColumnType("enum('andamento','concluido','cancelado')")
                .HasColumnName("status");

            entity.HasOne(d => d.IdDevolucaoNavigation).WithOne(p => p.Aluguel)
                .HasForeignKey<Aluguel>(d => d.IdDevolucao)
                .HasConstraintName("fkAluguelDevolucao");

            entity.HasOne(d => d.IdEntregaNavigation).WithOne(p => p.Aluguel)
                .HasForeignKey<Aluguel>(d => d.IdEntrega)
                .HasConstraintName("fkAluguelEntrega");

            entity.HasOne(d => d.IdPessoaNavigation).WithOne(p => p.Aluguel)
                .HasForeignKey<Aluguel>(d => d.IdPessoa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fkAluguelPessoa");

            entity.HasOne(d => d.IdVeiculoNavigation).WithOne(p => p.Aluguel)
                .HasForeignKey<Aluguel>(d => d.IdVeiculo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fkAluguelVeiculo");
        });

        modelBuilder.Entity<Banco>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("banco");

            entity.HasIndex(e => e.Id, "id_UNIQUE").IsUnique();

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

            entity.HasIndex(e => e.Id, "id_UNIQUE").IsUnique();

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

        modelBuilder.Entity<Disponibilidade>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("disponibilidade");

            entity.HasIndex(e => e.IdVeiculo, "fkDisponibilidadeVeiculo");

            entity.HasIndex(e => e.IdVeiculo, "idVeiculo_UNIQUE").IsUnique();

            entity.HasIndex(e => e.Id, "id_UNIQUE").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DataHoraFim)
                .HasColumnType("datetime")
                .HasColumnName("dataHoraFim");
            entity.Property(e => e.DataHoraInicio)
                .HasColumnType("datetime")
                .HasColumnName("dataHoraInicio");
            entity.Property(e => e.IdVeiculo).HasColumnName("idVeiculo");

            entity.HasOne(d => d.IdVeiculoNavigation).WithOne(p => p.Disponibilidade)
                .HasForeignKey<Disponibilidade>(d => d.IdVeiculo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fkDisponibilidadeVeiculo");
        });

        modelBuilder.Entity<Entrega>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("entrega");

            entity.HasIndex(e => e.DataHora, "dataHora");

            entity.HasIndex(e => e.Id, "id_UNIQUE").IsUnique();

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

            entity.HasIndex(e => e.Id, "id_UNIQUE").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nome)
                .HasMaxLength(20)
                .HasColumnName("nome");
        });

        modelBuilder.Entity<Modelo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("modelo");

            entity.HasIndex(e => e.IdMarca, "fkModeloMarca");

            entity.HasIndex(e => e.IdMarca, "idMarca_UNIQUE").IsUnique();

            entity.HasIndex(e => e.Id, "id_UNIQUE").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdMarca).HasColumnName("idMarca");
            entity.Property(e => e.Nome)
                .HasMaxLength(20)
                .HasColumnName("nome");

            entity.HasOne(d => d.IdMarcaNavigation).WithOne(p => p.Modelo)
                .HasForeignKey<Modelo>(d => d.IdMarca)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fkModeloMarca");
        });

        modelBuilder.Entity<Pagamento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("pagamento");

            entity.HasIndex(e => e.IdAluguel, "fkPagamentoVeiculo");

            entity.HasIndex(e => e.IdAluguel, "idAluguel_UNIQUE").IsUnique();

            entity.HasIndex(e => e.Id, "id_UNIQUE").IsUnique();

            entity.HasIndex(e => e.Valor, "valor");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FormaPagamento)
                .HasColumnType("enum('à vista','parcelado','pix')")
                .HasColumnName("formaPagamento");
            entity.Property(e => e.IdAluguel).HasColumnName("idAluguel");
            entity.Property(e => e.Valor).HasColumnName("valor");

            entity.HasOne(d => d.IdAluguelNavigation).WithOne(p => p.Pagamento)
                .HasForeignKey<Pagamento>(d => d.IdAluguel)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fkPagamentoAluguel");
        });

        modelBuilder.Entity<Pessoa>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("pessoa");

            entity.HasIndex(e => e.Id, "Id_UNIQUE").IsUnique();

            entity.HasIndex(e => e.Cpf, "cpf");

            entity.HasIndex(e => e.IdBanco, "fkPessoaBanco");

            entity.HasIndex(e => e.IdBanco, "idBanco_UNIQUE").IsUnique();

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
                .HasMaxLength(20)
                .HasColumnName("cidade");
            entity.Property(e => e.Cnh)
                .HasMaxLength(9)
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
                .HasColumnType("date")
                .HasColumnName("dataNascimento");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Estado)
                .HasMaxLength(2)
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
                .HasMaxLength(14)
                .HasColumnName("telefone");
            entity.Property(e => e.Tipo)
                .HasColumnType("enum('cliente','proprietario')")
                .HasColumnName("tipo");

            entity.HasOne(d => d.IdBancoNavigation).WithOne(p => p.Pessoa)
                .HasForeignKey<Pessoa>(d => d.IdBanco)
                .HasConstraintName("fkPessoaBanco");
        });

        modelBuilder.Entity<Veiculo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("veiculo");

            entity.HasIndex(e => e.IdPessoa, "IdPessoa_UNIQUE").IsUnique();

            entity.HasIndex(e => e.IdModelo, "fkVeiculoModelo");

            entity.HasIndex(e => e.IdPessoa, "fkVeiculoPessoa");

            entity.HasIndex(e => e.IdModelo, "idModelo_UNIQUE").IsUnique();

            entity.HasIndex(e => e.Id, "id_UNIQUE").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Ano)
                .HasMaxLength(4)
                .HasColumnName("ano");
            entity.Property(e => e.Autorizado).HasColumnName("autorizado");
            entity.Property(e => e.Bairro)
                .HasMaxLength(50)
                .HasColumnName("bairro");
            entity.Property(e => e.Cambio)
                .HasColumnType("enum('automatico','manual')")
                .HasColumnName("cambio");
            entity.Property(e => e.Carroceria)
                .HasColumnType("enum('hatch','sedan','picape','suv')")
                .HasColumnName("carroceria");
            entity.Property(e => e.Cep)
                .HasMaxLength(8)
                .HasColumnName("cep");
            entity.Property(e => e.Cidade)
                .HasMaxLength(20)
                .HasColumnName("cidade");
            entity.Property(e => e.Cilindradas).HasColumnName("cilindradas");
            entity.Property(e => e.Combustivel)
                .HasColumnType("enum('flex','gasolina','etanol','diesel','gnv','elétrico')")
                .HasColumnName("combustivel");
            entity.Property(e => e.Crlv)
                .HasMaxLength(13)
                .HasColumnName("crlv");
            entity.Property(e => e.DataAutorizacao)
                .HasColumnType("datetime")
                .HasColumnName("dataAutorizacao");
            entity.Property(e => e.Estado)
                .HasMaxLength(2)
                .HasColumnName("estado");
            entity.Property(e => e.IdModelo).HasColumnName("idModelo");
            entity.Property(e => e.Numero)
                .HasMaxLength(10)
                .HasColumnName("numero");
            entity.Property(e => e.Passageiro)
                .HasColumnType("enum('4','5','6','7','8')")
                .HasColumnName("passageiro");
            entity.Property(e => e.Placa)
                .HasMaxLength(8)
                .HasColumnName("placa");
            entity.Property(e => e.Portas)
                .HasColumnType("enum('2','3','4')")
                .HasColumnName("portas");
            entity.Property(e => e.Rua)
                .HasMaxLength(50)
                .HasColumnName("rua");
            entity.Property(e => e.Tipo)
                .HasColumnType("enum('moto','carro')")
                .HasColumnName("tipo");
            entity.Property(e => e.Valor).HasColumnName("valor");

            entity.HasOne(d => d.IdModeloNavigation).WithOne(p => p.Veiculo)
                .HasForeignKey<Veiculo>(d => d.IdModelo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fkVeiculoModelo");

            entity.HasOne(d => d.IdPessoaNavigation).WithOne(p => p.Veiculo)
                .HasForeignKey<Veiculo>(d => d.IdPessoa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fkVeiculoPessoa");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
