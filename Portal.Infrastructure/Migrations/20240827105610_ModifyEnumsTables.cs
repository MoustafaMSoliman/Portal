using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portal.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ModifyEnumsTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Value",
                table: "UserTypes");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "UserStatuses");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "UserRoles");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "UserTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "UserStatuses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "UserRoles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "UserTypes");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "UserStatuses");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "UserRoles");

            migrationBuilder.AddColumn<int>(
                name: "Value",
                table: "UserTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Value",
                table: "UserStatuses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Value",
                table: "UserRoles",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
