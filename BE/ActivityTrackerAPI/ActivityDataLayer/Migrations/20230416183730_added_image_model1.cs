using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ActivityDataLayer.Migrations
{
    public partial class added_image_model1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ActivityImages_ActivityId",
                table: "ActivityImages",
                column: "ActivityId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityImages_Activities_ActivityId",
                table: "ActivityImages",
                column: "ActivityId",
                principalTable: "Activities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivityImages_Activities_ActivityId",
                table: "ActivityImages");

            migrationBuilder.DropIndex(
                name: "IX_ActivityImages_ActivityId",
                table: "ActivityImages");
        }
    }
}
