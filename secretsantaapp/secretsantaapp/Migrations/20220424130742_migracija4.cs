using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace secretsantaapp.Migrations
{
    public partial class migracija4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RolesId", "RoleDuty", "RoleName" },
                values: new object[,]
                {
                    { 1, "Upravljanje sistemom", "Admin" },
                    { 2, "Rad na sistemu", "Uposlenik" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UsersId", "Address", "Email", "FirstName", "LastName", "PasswordHash", "PaswordSalt", "Phone", "Status", "Username" },
                values: new object[,]
                {
                    { 1, "Opine bb, Mostar", "belma@example.com", "Belma", "Nukic", "yAOjokAWoWZ7AIriAcylq7elmVM=", "X4BjiFAZ4rgva59Rabp8hg==", "062147147", false, "belma" },
                    { 2, "Jukiceva 36, Sarajevo", "admin@gmail.com", "Admin", "Admin", "ohXrySDeRILoN47ntKghKMuytn0=", "HJbj66wjuAzLNxDYlZ/T9A==", "063222111", false, "admin" },
                    { 3, "Sehovina bb, Mostar", "uposlenik@gmail.com", "Uposlenik", "Uposlenik", "fhbMFkIaC3MAqqVJ3Pv5v+oJrr8=", "MUbkLKLde+Ym9kT9RJuaBw==", "063132233", false, "uposlenik" },
                    { 4, "Opine bb, Mostar", "ema@gmail.com", "Ema", "Bojcic", "ySI1sfGjOEtRDU6tOzFMnyO0afM=", "BRl3JcN1K/rTRcjwEm4Z3Q==", "0631231323", false, "ema" }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "UsersRolesId", "PublishedDate", "RolesId", "UsersId" },
                values: new object[,]
                {
                    { 2, new DateTime(2022, 4, 24, 15, 7, 40, 822, DateTimeKind.Local).AddTicks(7887), 2, 1 },
                    { 1, new DateTime(2022, 4, 24, 15, 7, 40, 807, DateTimeKind.Local).AddTicks(1615), 1, 2 },
                    { 3, new DateTime(2022, 4, 24, 15, 7, 40, 822, DateTimeKind.Local).AddTicks(8289), 2, 3 },
                    { 4, new DateTime(2022, 4, 24, 15, 7, 40, 822, DateTimeKind.Local).AddTicks(8364), 2, 4 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UsersRoles",
                keyColumn: "UsersRolesId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UsersRoles",
                keyColumn: "UsersRolesId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UsersRoles",
                keyColumn: "UsersRolesId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "UsersRoles",
                keyColumn: "UsersRolesId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UsersId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UsersId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UsersId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UsersId",
                keyValue: 4);
        }
    }
}
