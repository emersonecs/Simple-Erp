using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class adjustProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CodeBars",
                table: "Products",
                newName: "BarCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BarCode",
                table: "Products",
                newName: "CodeBars");
        }
    }
}
