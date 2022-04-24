using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace secretsantaapp.Migrations
{
    public partial class migracija2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gift",
                columns: table => new
                {
                    GiftId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FromUsersId = table.Column<int>(nullable: false),
                    ToUsersId = table.Column<int>(nullable: false),
                    DatePublished = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gift", x => x.GiftId);
                    table.ForeignKey(
                        name: "fk_fromusers",
                        column: x => x.FromUsersId,
                        principalTable: "Users",
                        principalColumn: "UsersId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_tousers",
                        column: x => x.ToUsersId,
                        principalTable: "Users",
                        principalColumn: "UsersId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Gift_FromUsersId",
                table: "Gift",
                column: "FromUsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Gift_ToUsersId",
                table: "Gift",
                column: "ToUsersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Gift");
        }
    }
}
