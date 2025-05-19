using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace restApiAnkiety.Migrations
{
    /// <inheritdoc />
    public partial class nowamigracja : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Opcje_Ankiety_FormId",
                table: "Opcje");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Opcje",
                table: "Opcje");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ankiety",
                table: "Ankiety");

            migrationBuilder.RenameTable(
                name: "Opcje",
                newName: "Options");

            migrationBuilder.RenameTable(
                name: "Ankiety",
                newName: "Forms");

            migrationBuilder.RenameColumn(
                name: "Glosy",
                table: "Options",
                newName: "Votes");

            migrationBuilder.RenameIndex(
                name: "IX_Opcje_FormId",
                table: "Options",
                newName: "IX_Options_FormId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Options",
                table: "Options",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Forms",
                table: "Forms",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Options_Forms_FormId",
                table: "Options",
                column: "FormId",
                principalTable: "Forms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Options_Forms_FormId",
                table: "Options");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Options",
                table: "Options");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Forms",
                table: "Forms");

            migrationBuilder.RenameTable(
                name: "Options",
                newName: "Opcje");

            migrationBuilder.RenameTable(
                name: "Forms",
                newName: "Ankiety");

            migrationBuilder.RenameColumn(
                name: "Votes",
                table: "Opcje",
                newName: "Glosy");

            migrationBuilder.RenameIndex(
                name: "IX_Options_FormId",
                table: "Opcje",
                newName: "IX_Opcje_FormId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Opcje",
                table: "Opcje",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ankiety",
                table: "Ankiety",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Opcje_Ankiety_FormId",
                table: "Opcje",
                column: "FormId",
                principalTable: "Ankiety",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
