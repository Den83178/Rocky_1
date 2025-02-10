using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rocky_1.Migrations
{
    /// <inheritdoc />
    public partial class AddApplicationTypeToProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ApplicationType_1_Id",
                table: "Product_1",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Product_1_ApplicationType_1_Id",
                table: "Product_1",
                column: "ApplicationType_1_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_1_ApplicationType_1_ApplicationType_1_Id",
                table: "Product_1",
                column: "ApplicationType_1_Id",
                principalTable: "ApplicationType_1",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_1_ApplicationType_1_ApplicationType_1_Id",
                table: "Product_1");

            migrationBuilder.DropIndex(
                name: "IX_Product_1_ApplicationType_1_Id",
                table: "Product_1");

            migrationBuilder.DropColumn(
                name: "ApplicationType_1_Id",
                table: "Product_1");
        }
    }
}
