using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace src.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "TopicId",
                table: "TodoItems",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "Topics",
                columns: table => new
                {
                    TopicId = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Topico = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topics", x => x.TopicId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TodoItems_TopicId",
                table: "TodoItems",
                column: "TopicId");

            migrationBuilder.AddForeignKey(
                name: "FK_TodoItems_Topics_TopicId",
                table: "TodoItems",
                column: "TopicId",
                principalTable: "Topics",
                principalColumn: "TopicId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoItems_Topics_TopicId",
                table: "TodoItems");

            migrationBuilder.DropTable(
                name: "Topics");

            migrationBuilder.DropIndex(
                name: "IX_TodoItems_TopicId",
                table: "TodoItems");

            migrationBuilder.DropColumn(
                name: "TopicId",
                table: "TodoItems");
        }
    }
}
