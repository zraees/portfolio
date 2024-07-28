using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchWithCQRSPattern.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateAudutLog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuditLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false),
                    EntityName = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false),
                    Action = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false),
                    Timestamp = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Changes = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditLogs", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuditLogs");
        }
    }
}
