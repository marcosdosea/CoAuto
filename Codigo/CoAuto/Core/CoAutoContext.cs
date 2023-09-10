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

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
    // => optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=123456;database=coauto");


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Aluguel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("aluguel");

            entity.HasIndex(e => e.IdDevolucao, "fkAluguelDevolucao");

            entity.HasIndex(e => e.IdEntrega, "fkAluguelEntrega");

            entity.HasIndex(e => e.IdPessoa, "fkAluguelPessoa");

            entity.HasIndex(e => e.IdVeiculo, "fkAluguelVeiculo");

            entity.HasIndex(e => e.Id, "id_UNIQUE").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DataAvaliacaoCliente)
                .HasColumnType("datetime")
                .HasColumnName("dataAvaliacaoCliente");
            entity.Property(e => e.DataAvaliacaoProprietario)
                .HasColumnType("datetime")
                .HasColumnName("dataAvaliacaoProprietario");
            entity.Property(e => e.DataHoraAluguel)
                .HasMaxLength(45)
                .HasColumnName("dataHoraAluguel");
            entity.Property(e => e.DescricaoAvaliacaoCliente)
                .HasMaxLength(50)
                .HasColumnName("descricaoAvaliacaoCliente");
            entity.Property(e => e.DescricaoAvaliacaoProprietario)
                .HasMaxLength(50)
                .HasColumnName("descricaoAvaliacaoProprietario");
            entity.Property(e => e.IdAvaliacaoCliente).HasColumnName("idAvaliacaoCliente");
            entity.Property(e => e.IdDevolucao).HasColumnName("idDevolucao");
            entity.Property(e => e.IdEntrega).HasColumnName("idEntrega");
            entity.Property(e => e.IdVeiculo).HasColumnName("idVeiculo");
            entity.Property(e => e.QtdEstrelasAvaliacaoCliente).HasColumnName("qtdEstrelasAvaliacaoCliente");
            entity.Property(e => e.QtdEstrelasAvaliacaoProprietario).HasColumnName("qtdEstrelasAvaliacaoProprietario");
            entity.Property(e => e.Status)
                .HasColumnType("enum('andamento','concluido','cancelado')")
                .HasColumnName("status");

            entity.HasOne(d => d.IdDevolucaoNavigation).WithMany(p => p.Aluguels)
                .HasForeignKey(d => d.IdDevolucao)
                .HasConstraintName("fk%Aluguel%dtable2");

            entity.HasOne(d => d.IdEntregaNavigation).WithMany(p => p.Aluguels)
                .HasForeignKey(d => d.IdEntrega)
                .HasConstraintName("fk%Aluguel%dtable1");

            entity.HasOne(d => d.IdPessoaNavigation).WithMany(p => p.Aluguels)
                .HasForeignKey(d => d.IdPessoa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fkAluguelUsusario");

            entity.HasOne(d => d.IdVeiculoNavigation).WithMany(p => p.Aluguels)
                .HasForeignKey(d => d.IdVeiculo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("%fk%Aluguel%Veiculo1");
        });

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

        modelBuilder.Entity<Disponibilidade>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("disponibilidade");

            entity.HasIndex(e => e.IdVeiculo, "fkDisponibilidadeVeiculo");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DataFim)
                .HasColumnType("date")
                .HasColumnName("dataFim");
            entity.Property(e => e.DataInicio)
                .HasColumnType("date")
                .HasColumnName("dataInicio");
            entity.Property(e => e.HoraFim)
                .HasColumnType("time")
                .HasColumnName("horaFim");
            entity.Property(e => e.HoraInicio)
                .HasColumnType("time")
                .HasColumnName("horaInicio");
            entity.Property(e => e.IdVeiculo).HasColumnName("idVeiculo");

            entity.HasOne(d => d.IdVeiculoNavigation).WithMany(p => p.Disponibilidades)
                .HasForeignKey(d => d.IdVeiculo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("%fk%DisponibilidadeVeiculo%Veiculo1");
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

        modelBuilder.Entity<Pagamento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("pagamento");

            entity.HasIndex(e => e.IdAluguel, "fkPagamentoVeiculo");

            entity.HasIndex(e => e.Valor, "valor");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FormaPagamento)
                .HasColumnType("enum('a vista','parcelado','pix')")
                .HasColumnName("formaPagamento");
            entity.Property(e => e.IdAluguel).HasColumnName("idAluguel");
            entity.Property(e => e.Valor).HasColumnName("valor");

            entity.HasOne(d => d.IdAluguelNavigation).WithMany(p => p.Pagamentos)
                .HasForeignKey(d => d.IdAluguel)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("%fk%Pagamento%Aluguel1");
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

        modelBuilder.Entity<Veiculo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("veiculo");

            entity.HasIndex(e => e.IdPessoa, "fkPessoaVeiculo");

            entity.HasIndex(e => e.IdModelo, "fkVeiculoModelo");

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
                .HasMaxLength(50)
                .HasColumnName("cidade");
            entity.Property(e => e.Cilindradas).HasColumnName("cilindradas");
            entity.Property(e => e.Combustivel)
                .HasColumnType("enum('flex','gasolina','etanol','diesel','gnv')")
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
            entity.Property(e => e.Numero).HasColumnName("numero");
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

            entity.HasOne(d => d.IdModeloNavigation).WithMany(p => p.Veiculos)
                .HasForeignKey(d => d.IdModelo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("%fk%Veiculo%Modelo1");

            entity.HasOne(d => d.IdPessoaNavigation).WithMany(p => p.Veiculos)
                .HasForeignKey(d => d.IdPessoa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("%fk%Veiculo%Pessoa1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
