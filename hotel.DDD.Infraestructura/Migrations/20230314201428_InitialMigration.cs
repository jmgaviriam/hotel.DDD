using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hotel.DDD.Infraestructura.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EventoGuardado",
                columns: table => new
                {
                    IdGuardado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreGuardado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdAgregado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CuerpoDelEvento = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventoGuardado", x => x.IdGuardado);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventoGuardado");
        }
    }
}
