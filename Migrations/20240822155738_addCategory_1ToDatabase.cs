using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rocky_1.Migrations
{
    /// <inheritdoc />
    public partial class addCategory_1ToDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOrder",
                table: "Category_1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberOrder",
                table: "Category_1",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
