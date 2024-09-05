using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspProjekat.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addedauditlog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AuditLog",
                table: "AuditLog");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "AuditLog");

            migrationBuilder.DropColumn(
                name: "Action",
                table: "AuditLog");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "AuditLog");

            migrationBuilder.RenameTable(
                name: "AuditLog",
                newName: "AuditLogs");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "AuditLogs",
                newName: "StrackTrace");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "AuditLogs",
                newName: "Time");

            migrationBuilder.RenameColumn(
                name: "Text",
                table: "AuditLogs",
                newName: "Message");

            migrationBuilder.AddColumn<Guid>(
                name: "ErrorId",
                table: "AuditLogs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_AuditLogs",
                table: "AuditLogs",
                column: "ErrorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AuditLogs",
                table: "AuditLogs");

            migrationBuilder.DropColumn(
                name: "ErrorId",
                table: "AuditLogs");

            migrationBuilder.RenameTable(
                name: "AuditLogs",
                newName: "AuditLog");

            migrationBuilder.RenameColumn(
                name: "Time",
                table: "AuditLog",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "StrackTrace",
                table: "AuditLog",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "Message",
                table: "AuditLog",
                newName: "Text");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "AuditLog",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Action",
                table: "AuditLog",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "AuditLog",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_AuditLog",
                table: "AuditLog",
                column: "Id");
        }
    }
}
