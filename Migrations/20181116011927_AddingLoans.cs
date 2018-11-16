using Microsoft.EntityFrameworkCore.Migrations;

namespace Library_Management_System_C_.Migrations
{
    public partial class AddingLoans : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Loans",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "Loans");
        }
    }
}
