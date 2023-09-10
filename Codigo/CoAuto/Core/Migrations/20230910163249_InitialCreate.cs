using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace Core.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "banco",
                columns: table => new
                {
                    id = table.Column<uint>(type: "int unsigned", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "devolucao",
                columns: table => new
                {
                    id = table.Column<uint>(type: "int unsigned", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    foto1 = table.Column<byte[]>(type: "blob", nullable: true),
                    foto2 = table.Column<byte[]>(type: "blob", nullable: true),
                    foto3 = table.Column<byte[]>(type: "blob", nullable: true),
                    foto4 = table.Column<byte[]>(type: "blob", nullable: true),
                    foto5 = table.Column<byte[]>(type: "blob", nullable: true),
                    dataHora = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "entrega",
                columns: table => new
                {
                    id = table.Column<uint>(type: "int unsigned", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    foto1 = table.Column<byte[]>(type: "blob", nullable: true),
                    foto2 = table.Column<byte[]>(type: "blob", nullable: true),
                    foto3 = table.Column<byte[]>(type: "blob", nullable: true),
                    foto4 = table.Column<byte[]>(type: "blob", nullable: true),
                    foto5 = table.Column<byte[]>(type: "blob", nullable: true),
                    dataHora = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "marca",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "pessoa",
                columns: table => new
                {
                    Id = table.Column<uint>(type: "int unsigned", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    cnh = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false),
                    cpf = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: false),
                    senha = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    fotocnh = table.Column<byte[]>(type: "blob", nullable: true),
                    dataNascimento = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    telefone = table.Column<string>(type: "varchar(23)", maxLength: 23, nullable: false),
                    fotoperfil = table.Column<byte[]>(type: "blob", nullable: true),
                    cep = table.Column<string>(type: "varchar(8)", maxLength: 8, nullable: false),
                    estado = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    cidade = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    bairro = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    rua = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    numero = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    agencia = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    contaCorrente = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    chavepix = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: true),
                    dataAutorizacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    autorizado = table.Column<sbyte>(type: "tinyint", nullable: false),
                    tipo = table.Column<string>(type: "enum('cliente','proprietario')", nullable: false),
                    idBanco = table.Column<uint>(type: "int unsigned", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                    table.ForeignKey(
                        name: "%fk%Pessoa%Banco1",
                        column: x => x.idBanco,
                        principalTable: "banco",
                        principalColumn: "id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "modelo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    idMarca = table.Column<int>(type: "int", nullable: false),
                    nome = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "%fk%Modelo%Marca1",
                        column: x => x.idMarca,
                        principalTable: "marca",
                        principalColumn: "id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "veiculo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    tipo = table.Column<string>(type: "enum('moto','carro')", nullable: false),
                    ano = table.Column<string>(type: "varchar(4)", maxLength: 4, nullable: false),
                    placa = table.Column<string>(type: "varchar(8)", maxLength: 8, nullable: false),
                    crlv = table.Column<string>(type: "varchar(13)", maxLength: 13, nullable: false),
                    cilindradas = table.Column<int>(type: "int", nullable: true),
                    valor = table.Column<float>(type: "float", nullable: false),
                    cep = table.Column<string>(type: "varchar(8)", maxLength: 8, nullable: false),
                    estado = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: false),
                    cidade = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    bairro = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    rua = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    numero = table.Column<int>(type: "int", nullable: false),
                    dataAutorizacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    portas = table.Column<string>(type: "enum('2','3','4')", nullable: true),
                    autorizado = table.Column<sbyte>(type: "tinyint", nullable: false),
                    idModelo = table.Column<int>(type: "int", nullable: false),
                    combustivel = table.Column<string>(type: "enum('flex','gasolina','etanol','diesel','gnv')", nullable: false),
                    cambio = table.Column<string>(type: "enum('automatico','manual')", nullable: false),
                    passageiro = table.Column<string>(type: "enum('4','5','6','7','8')", nullable: true),
                    carroceria = table.Column<string>(type: "enum('hatch','sedan','picape','suv')", nullable: true),
                    IdPessoa = table.Column<uint>(type: "int unsigned", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "%fk%Veiculo%Modelo1",
                        column: x => x.idModelo,
                        principalTable: "modelo",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "%fk%Veiculo%Pessoa1",
                        column: x => x.IdPessoa,
                        principalTable: "pessoa",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "aluguel",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    dataHoraAluguel = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false),
                    IdPessoa = table.Column<uint>(type: "int unsigned", nullable: false),
                    idAvaliacaoCliente = table.Column<uint>(type: "int unsigned", nullable: true),
                    status = table.Column<string>(type: "enum('andamento','concluido','cancelado')", nullable: false),
                    idVeiculo = table.Column<int>(type: "int", nullable: false),
                    dataAvaliacaoProprietario = table.Column<DateTime>(type: "datetime", nullable: true),
                    qtdEstrelasAvaliacaoProprietario = table.Column<byte>(type: "tinyint unsigned", nullable: true),
                    dataAvaliacaoCliente = table.Column<DateTime>(type: "datetime", nullable: true),
                    qtdEstrelasAvaliacaoCliente = table.Column<sbyte>(type: "tinyint", nullable: true),
                    descricaoAvaliacaoProprietario = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    descricaoAvaliacaoCliente = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    idEntrega = table.Column<uint>(type: "int unsigned", nullable: true),
                    idDevolucao = table.Column<uint>(type: "int unsigned", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "%fk%Aluguel%Veiculo1",
                        column: x => x.idVeiculo,
                        principalTable: "veiculo",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk%Aluguel%dtable1",
                        column: x => x.idEntrega,
                        principalTable: "entrega",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk%Aluguel%dtable2",
                        column: x => x.idDevolucao,
                        principalTable: "devolucao",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fkAluguelUsusario",
                        column: x => x.IdPessoa,
                        principalTable: "pessoa",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "disponibilidade",
                columns: table => new
                {
                    id = table.Column<uint>(type: "int unsigned", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    dataInicio = table.Column<DateTime>(type: "date", nullable: false),
                    dataFim = table.Column<DateTime>(type: "date", nullable: false),
                    horaInicio = table.Column<TimeSpan>(type: "time", nullable: false),
                    horaFim = table.Column<TimeSpan>(type: "time", nullable: false),
                    idVeiculo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "%fk%DisponibilidadeVeiculo%Veiculo1",
                        column: x => x.idVeiculo,
                        principalTable: "veiculo",
                        principalColumn: "id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "pagamento",
                columns: table => new
                {
                    id = table.Column<uint>(type: "int unsigned", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    valor = table.Column<float>(type: "float", nullable: false),
                    formaPagamento = table.Column<string>(type: "enum('a vista','parcelado','pix')", nullable: false),
                    idAluguel = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "%fk%Pagamento%Aluguel1",
                        column: x => x.idAluguel,
                        principalTable: "aluguel",
                        principalColumn: "id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "fkAluguelDevolucao",
                table: "aluguel",
                column: "idDevolucao");

            migrationBuilder.CreateIndex(
                name: "fkAluguelEntrega",
                table: "aluguel",
                column: "idEntrega");

            migrationBuilder.CreateIndex(
                name: "fkAluguelPessoa",
                table: "aluguel",
                column: "IdPessoa");

            migrationBuilder.CreateIndex(
                name: "fkAluguelVeiculo",
                table: "aluguel",
                column: "idVeiculo");

            migrationBuilder.CreateIndex(
                name: "id_UNIQUE",
                table: "aluguel",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "dataHora",
                table: "devolucao",
                column: "dataHora");

            migrationBuilder.CreateIndex(
                name: "fkDisponibilidadeVeiculo",
                table: "disponibilidade",
                column: "idVeiculo");

            migrationBuilder.CreateIndex(
                name: "dataHora1",
                table: "entrega",
                column: "dataHora");

            migrationBuilder.CreateIndex(
                name: "fkModeloMarca",
                table: "modelo",
                column: "idMarca");

            migrationBuilder.CreateIndex(
                name: "fkPagamentoVeiculo",
                table: "pagamento",
                column: "idAluguel");

            migrationBuilder.CreateIndex(
                name: "valor",
                table: "pagamento",
                column: "valor");

            migrationBuilder.CreateIndex(
                name: "cpf",
                table: "pessoa",
                column: "cpf");

            migrationBuilder.CreateIndex(
                name: "fkPessoaBanco",
                table: "pessoa",
                column: "idBanco");

            migrationBuilder.CreateIndex(
                name: "Id_UNIQUE",
                table: "pessoa",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "nome",
                table: "pessoa",
                column: "nome");

            migrationBuilder.CreateIndex(
                name: "fkPessoaVeiculo",
                table: "veiculo",
                column: "IdPessoa");

            migrationBuilder.CreateIndex(
                name: "fkVeiculoModelo",
                table: "veiculo",
                column: "idModelo");

            migrationBuilder.CreateIndex(
                name: "id_UNIQUE1",
                table: "veiculo",
                column: "id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "disponibilidade");

            migrationBuilder.DropTable(
                name: "pagamento");

            migrationBuilder.DropTable(
                name: "aluguel");

            migrationBuilder.DropTable(
                name: "veiculo");

            migrationBuilder.DropTable(
                name: "entrega");

            migrationBuilder.DropTable(
                name: "devolucao");

            migrationBuilder.DropTable(
                name: "modelo");

            migrationBuilder.DropTable(
                name: "pessoa");

            migrationBuilder.DropTable(
                name: "marca");

            migrationBuilder.DropTable(
                name: "banco");
        }
    }
}
