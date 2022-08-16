using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Persistence.Migrations
{
    public partial class initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendors_ContactPersons_ContactPersonId",
                table: "Vendors");

            migrationBuilder.AlterColumn<Guid>(
                name: "ContactPersonId",
                table: "Vendors",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Vendors_ContactPersons_ContactPersonId",
                table: "Vendors",
                column: "ContactPersonId",
                principalTable: "ContactPersons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendors_ContactPersons_ContactPersonId",
                table: "Vendors");

            migrationBuilder.AlterColumn<Guid>(
                name: "ContactPersonId",
                table: "Vendors",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Vendors_ContactPersons_ContactPersonId",
                table: "Vendors",
                column: "ContactPersonId",
                principalTable: "ContactPersons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
