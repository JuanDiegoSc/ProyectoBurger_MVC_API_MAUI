using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoBurger_MVC_API_MAUI.Migrations
{
    /// <inheritdoc />
    public partial class Burger_JDS : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Burger_JDS",
                columns: table => new
                {
                    BurgerId_JDS = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name_JDS = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WithCheese_JDS = table.Column<bool>(type: "bit", nullable: false),
                    Precio_JDS = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Burger_JDS", x => x.BurgerId_JDS);
                });

            migrationBuilder.CreateTable(
                name: "Promo_JDS",
                columns: table => new
                {
                    PromoId_JDS = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion_JDS = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaPromo_JDS = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BurgerId_JDS = table.Column<int>(type: "int", nullable: false),
                    Burger_JDSBurgerId_JDS = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promo_JDS", x => x.PromoId_JDS);
                    table.ForeignKey(
                        name: "FK_Promo_JDS_Burger_JDS_Burger_JDSBurgerId_JDS",
                        column: x => x.Burger_JDSBurgerId_JDS,
                        principalTable: "Burger_JDS",
                        principalColumn: "BurgerId_JDS");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Promo_JDS_Burger_JDSBurgerId_JDS",
                table: "Promo_JDS",
                column: "Burger_JDSBurgerId_JDS");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Promo_JDS");

            migrationBuilder.DropTable(
                name: "Burger_JDS");
        }
    }
}
