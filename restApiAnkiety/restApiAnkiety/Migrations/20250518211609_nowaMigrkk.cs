using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace restApiAnkiety.Migrations
{
    /// <inheritdoc />
    public partial class nowaMigrkk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnswerId",
                table: "Answers");

            migrationBuilder.RenameColumn(
                name: "FormDate",
                table: "Answers",
                newName: "AnswerDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AnswerDate",
                table: "Answers",
                newName: "FormDate");

            migrationBuilder.AddColumn<int>(
                name: "AnswerId",
                table: "Answers",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
