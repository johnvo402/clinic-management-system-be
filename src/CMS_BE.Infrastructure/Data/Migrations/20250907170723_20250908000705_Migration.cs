using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMS_BE.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class _20250908000705_Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "expires_at", table: "account_token");
            migrationBuilder.AddColumn<long>(
                name: "expires_at",
                table: "account_token",
                type: "bigint",
                nullable: false
            );

            migrationBuilder.AddColumn<short>(
                name: "gender",
                table: "account",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "gender", table: "account");

            migrationBuilder.DropColumn(name: "expires_at", table: "account_token");
            migrationBuilder.AddColumn<long>(
                name: "expires_at",
                table: "account_token",
                type: "timestamp with time zone",
                nullable: false
            );
        }
    }
}
