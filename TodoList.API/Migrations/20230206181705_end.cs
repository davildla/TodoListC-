using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoList.API.Migrations
{
    /// <inheritdoc />
    public partial class end : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Todos_Urgency_UrgencyId",
                table: "Todos");

            migrationBuilder.DropTable(
                name: "Urgency");

            migrationBuilder.DropIndex(
                name: "IX_Todos_UrgencyId",
                table: "Todos");

            migrationBuilder.DropColumn(
                name: "UrgencyId",
                table: "Todos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UrgencyId",
                table: "Todos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Urgency",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Urgency", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Todos_UrgencyId",
                table: "Todos",
                column: "UrgencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Todos_Urgency_UrgencyId",
                table: "Todos",
                column: "UrgencyId",
                principalTable: "Urgency",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
