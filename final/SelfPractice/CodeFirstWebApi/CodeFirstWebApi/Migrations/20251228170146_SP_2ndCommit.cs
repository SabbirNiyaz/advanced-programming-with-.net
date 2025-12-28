using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeFirstWebApi.Migrations
{
    /// <inheritdoc />
    public partial class SP_2ndCommit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SId",
                table: "Depts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Depts_SId",
                table: "Depts",
                column: "SId");

            migrationBuilder.AddForeignKey(
                name: "FK_Depts_Students_SId",
                table: "Depts",
                column: "SId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Depts_Students_SId",
                table: "Depts");

            migrationBuilder.DropIndex(
                name: "IX_Depts_SId",
                table: "Depts");

            migrationBuilder.DropColumn(
                name: "SId",
                table: "Depts");
        }
    }
}
