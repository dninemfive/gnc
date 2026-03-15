using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Naibbe.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TranslationTables",
                columns: table => new
                {
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Weight = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TranslationTables", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "TranslationTableRow",
                columns: table => new
                {
                    Letter = table.Column<string>(type: "TEXT", nullable: false),
                    Unigram = table.Column<string>(type: "TEXT", nullable: false),
                    Prefix = table.Column<string>(type: "TEXT", nullable: false),
                    Suffix = table.Column<string>(type: "TEXT", nullable: false),
                    TranslationTableName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TranslationTableRow", x => x.Letter);
                    table.ForeignKey(
                        name: "FK_TranslationTableRow_TranslationTables_TranslationTableName",
                        column: x => x.TranslationTableName,
                        principalTable: "TranslationTables",
                        principalColumn: "Name");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TranslationTableRow_TranslationTableName",
                table: "TranslationTableRow",
                column: "TranslationTableName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TranslationTableRow");

            migrationBuilder.DropTable(
                name: "TranslationTables");
        }
    }
}
